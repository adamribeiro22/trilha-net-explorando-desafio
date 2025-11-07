using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria a lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>();

while (true)
{
    // Adiciona hóspedes à lista
    Console.WriteLine("Digite o nome do hóspede (ou 'sair' para finalizar):");
    string nome = Console.ReadLine();
    if (nome.ToLower() == "sair")
        break;

    Console.WriteLine("Digite o sobrenome do hóspede:");
    string sobrenome = Console.ReadLine();

    Pessoa hospede = new Pessoa(nome, sobrenome);
    hospedes.Add(hospede);

    Console.WriteLine($"Hóspede {hospede.NomeCompleto} adicionado com sucesso!\n");

    Console.WriteLine("Deseja adicionar outro hóspede? (s/n)");
    string resposta = Console.ReadLine();
    if (resposta.ToLower() == "s")
    {
        continue;
    }
    else if (resposta.ToLower() != "s" && resposta.ToLower() != "n")
    {
        Console.WriteLine("Resposta inválida. Encerrando adição de hóspedes.");
        break;
    }
    else
    {
        // Seleciona a opção de suíte
        Console.WriteLine("Digite a opção de suíte desejada:");
        Console.WriteLine("1 - Premium");
        Console.WriteLine("2 - Deluxe");
        Console.WriteLine("3 - Standard");
        string opcaoSuite = Console.ReadLine();
        Suite suite;
        switch (opcaoSuite)
        {
            case "1":
                suite = new Suite(tipoSuite: "Standard", capacidade: 1, valorDiaria: 20);
                break;
            case "2":
                suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);
                break;
            case "3":
                suite = new Suite(tipoSuite: "Deluxe", capacidade: 3, valorDiaria: 50);
                break;
            default:
                Console.WriteLine("Opção inválida. Usando suíte Standard por padrão.");
                suite = new Suite(tipoSuite: "Standard", capacidade: 1, valorDiaria: 20);
                break;
        }

        Console.WriteLine($"Suíte {suite.TipoSuite} selecionada. \n");
        if (hospedes.Count > suite.Capacidade){
            Console.WriteLine("Número de hóspedes excede a capacidade da suíte.");
            break;
        }
        else{
            // Solicita a quantidade de dias para a reserva
            Console.WriteLine("Digite a quantidade de dias para a reserva: ");
            int diasReservados;
            while (!int.TryParse(Console.ReadLine(), out diasReservados) || diasReservados <= 0)
            {
                Console.WriteLine("Entrada inválida. Digite um número inteiro positivo para a quantidade de dias:");
            }
        
        // Cria uma nova reserva, passando a suíte e os hóspedes
        Reserva reserva = new Reserva(diasReservados);
        reserva.CadastrarSuite(suite);
        reserva.CadastrarHospedes(hospedes);

        // Exibe a quantidade de hóspedes e o valor da diária
        Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
        break;
        }
    }
}
