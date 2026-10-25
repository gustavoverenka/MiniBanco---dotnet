namespace MiniBanco.ConsoleApp;

using MiniBanco.ConsoleApp.Exceptions;
using MiniBanco.ConsoleApp.Models;
using MiniBanco.ConsoleApp.Services;

public class Program
{
    private static List<Conta> contas = new List<Conta>();
    private static MotorAnalise motorAnalise = new MotorAnalise();

    public static void Main(string[] args)
    {
        bool executando = true;

        while (executando)
        {
            Console.WriteLine("\n==================================================");
            Console.WriteLine("        MINIBANCO .NET - GESTÃO DE CONTAS         ");
            Console.WriteLine("==================================================");
            Console.WriteLine("1 - Abrir Nova Conta");
            Console.WriteLine("2 - Registrar Movimentação (Depósito / Saque)");
            Console.WriteLine("3 - Aplicar Fechamento Mensal");
            Console.WriteLine("4 - Exibir Relatório das Contas");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine() ?? string.Empty;

            try
            {
                switch (opcao)
                {
                    case "1":
                        AbrirNovaConta();
                        break;
                    case "2":
                        RegistrarMovimentacao();
                        break;
                    case "3":
                        AplicarFechamentoMensal();
                        break;
                    case "4":
                        ExibirRelatorio();
                        break;
                    case "0":
                        executando = false;
                        Console.WriteLine("\nEncerrando o sistema. Até logo!");
                        break;
                    default:
                        Console.WriteLine("\n[!] Opção inválida. Digite um número de 0 a 4.");
                        break;
                }
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine($"\n[ERRO DE OPERAÇÃO]: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n[DADO INVÁLIDO]: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n[ERRO DE FORMATAÇÃO]: Valor numérico inválido. Certifique-se de digitar números corretamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERRO INESPERADO]: {ex.Message}");
            }
        }
    }

    private static void AbrirNovaConta()
    {
        Console.WriteLine("\n--- ABERTURA DE NOVA CONTA ---");
        Console.WriteLine("Selecione o tipo:");
        Console.WriteLine("1 - Conta Corrente");
        Console.WriteLine("2 - Conta Poupança");
        Console.WriteLine("3 - Conta Salário");
        Console.Write("Opção: ");
        string tipoConta = Console.ReadLine() ?? string.Empty;

        if (tipoConta != "1" && tipoConta != "2" && tipoConta != "3")
        {
            throw new ArgumentException("Tipo de conta inválido. Escolha 1, 2 ou 3.");
        }

        Console.Write("Nome do Titular: ");
        string titular = Console.ReadLine() ?? string.Empty;

        Console.Write("Número da Conta: ");
        int numero = int.Parse(Console.ReadLine()!);

        
        foreach (Conta c in contas)
        {
            if (c.Numero == numero)
            {
                throw new ArgumentException($"Já existe uma conta cadastrada com o número {numero}.");
            }
        }

        Console.Write("Saldo Inicial (R$): ");
        decimal saldoInicial = decimal.Parse(Console.ReadLine()!);

        Conta novaConta;

        if (tipoConta == "1")
        {
            Console.Write("Limite do Cheque Especial (R$): ");
            decimal limite = decimal.Parse(Console.ReadLine()!);
            novaConta = new ContaCorrente(titular, numero, saldoInicial, limite);
        }
        else if (tipoConta == "2")
        {
            Console.Write("Taxa de Rendimento Mensal (% ao mês): ");
            double taxa = double.Parse(Console.ReadLine()!);
            Console.Write("Dia de Aniversário da Conta (1 a 31): ");
            int aniversario = int.Parse(Console.ReadLine()!);
            novaConta = new ContaPoupanca(titular, numero, saldoInicial, taxa, aniversario);
        }
        else
        {
            Console.Write("Nome do Empregador: ");
            string empregador = Console.ReadLine() ?? string.Empty;
            Console.Write("Limite de Saques Gratuitos no Mês: ");
            int limiteSaques = int.Parse(Console.ReadLine()!);
            novaConta = new ContaSalario(titular, numero, saldoInicial, empregador, limiteSaques);
        }

        contas.Add(novaConta);
        Console.WriteLine($"\n[OK] Conta {novaConta.Numero} cadastrada com sucesso para {novaConta.Titular}!");
    }

    private static void RegistrarMovimentacao()
    {
        Console.WriteLine("\n--- REGISTRO DE MOVIMENTAÇÃO ---");
        Console.Write("Digite o número da conta: ");
        int numero = int.Parse(Console.ReadLine()!);

        Conta? contaEncontrada = null;

        
        foreach (Conta c in contas)
        {
            if (c.Numero == numero)
            {
                contaEncontrada = c;
                break;
            }
        }

        if (contaEncontrada == null)
        {
            Console.WriteLine($"\n[!] Conta de número {numero} não foi encontrada.");
            return;
        }

        Console.WriteLine($"Conta localizada: {contaEncontrada.Titular} | Saldo Atual: R$ {contaEncontrada.Saldo:F2}");
        Console.WriteLine("Tipo de movimentação:");
        Console.WriteLine("1 - Depósito");
        Console.WriteLine("2 - Saque");
        Console.Write("Opção: ");
        string opcaoOperacao = Console.ReadLine() ?? string.Empty;

        Console.Write("Valor (R$): ");
        decimal valor = decimal.Parse(Console.ReadLine()!);

        if (opcaoOperacao == "1")
        {
            Console.Write("Descrição do depósito (opcional, pressione Enter para padrão): ");
            string descricao = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(descricao))
            {
                descricao = "Depósito em dinheiro";
            }

            contaEncontrada.Depositar(valor, descricao);
            Console.WriteLine($"\n[OK] Depósito de R$ {valor:F2} realizado. Novo saldo: R$ {contaEncontrada.Saldo:F2}");
        }
        else if (opcaoOperacao == "2")
        {
            contaEncontrada.Sacar(valor);
            Console.WriteLine($"\n[OK] Saque de R$ {valor:F2} realizado. Novo saldo: R$ {contaEncontrada.Saldo:F2}");
        }
        else
        {
            throw new ArgumentException("Opção de operação inválida. Escolha 1 para Depósito ou 2 para Saque.");
        }
    }

    private static void AplicarFechamentoMensal()
    {
        if (contas.Count == 0)
        {
            Console.WriteLine("\n[!] Nenhuma conta cadastrada para aplicar fechamento mensal.");
            return;
        }

        Console.WriteLine("\n--- APLICANDO FECHAMENTO MENSAL (POLIMORFISMO) ---");

        
        foreach (Conta c in contas)
        {
            c.AplicarFechamentoMensal();
            Console.WriteLine($"[Processada] Conta {c.Numero} ({c.ObterTipoFormatado()}) - Saldo atualizado: R$ {c.Saldo:F2}");
        }

        Console.WriteLine("\n[OK] Fechamento mensal concluído para todas as contas!");
    }

    private static void ExibirRelatorio()
    {
        motorAnalise.ExibirRelatorioGeral(contas);
    }
}