namespace MiniBanco.ConsoleApp.Models;

using MiniBanco.ConsoleApp.Exceptions;

public class ContaSalario : Conta
{
    private const decimal TARIFA_SAQUE_EXTRA = 5.00m;

    public string Empregador { get; }
    public int LimiteSaquesMensais { get; }
    private int saquesRealizadosNoMes;

    public ContaSalario(string titular, int numero, decimal saldoInicial, string empregador, int limiteSaquesMensais)
        : base(titular, numero, saldoInicial)
    {
        if (string.IsNullOrWhiteSpace(empregador))
        {
            throw new ArgumentException("O nome do empregador nao pode ser vazio.", nameof(empregador));
        }

        if (limiteSaquesMensais < 0)
        {
            throw new ArgumentException("O limite de saques mensais nao pode ser negativo.", nameof(limiteSaquesMensais));
        }

        this.Empregador = empregador;
        this.LimiteSaquesMensais = limiteSaquesMensais;
        this.saquesRealizadosNoMes = 0;
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser maior que zero.", nameof(valor));
        }

        if (this.Saldo < valor)
        {
            throw new SaldoInsuficienteException($"Saldo insuficiente para saque de R$ {valor:F2}. Saldo atual: R$ {this.Saldo:F2}.");
        }

        this.Saldo -= valor;
        this.saquesRealizadosNoMes++;
        this.RegistrarTransacao("Saque", "Saque", valor);

        if (this.saquesRealizadosNoMes > this.LimiteSaquesMensais)
        {
            this.Saldo -= TARIFA_SAQUE_EXTRA;
            this.RegistrarTransacao("Tarifa de saque excedente", "Tarifa", TARIFA_SAQUE_EXTRA);
        }
    }

    public override void AplicarFechamentoMensal()
    {
        this.saquesRealizadosNoMes = 0;
    }

    public override string ObterTipoFormatado() => "Conta Salário";

    public override string ObterResumoAtributoEspecifico() => 
        $"Empregador: {this.Empregador} | Limite de Saques: {this.LimiteSaquesMensais}";
}
