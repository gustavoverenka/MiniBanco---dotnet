namespace MiniBanco.ConsoleApp.Models;

using MiniBanco.ConsoleApp.Exceptions;

public class ContaCorrente : Conta
{
    private const decimal TARIFA_MANUTENCAO = 10.00m;

    public decimal LimiteChequeEspecial { get; set; }

    public ContaCorrente(string titular, int numero, decimal saldoInicial, decimal limiteChequeEspecial) 
        : base(titular, numero, saldoInicial)
    {
        if (limiteChequeEspecial < 0)
        {
            throw new ArgumentException("O limite do cheque especial não pode ser negativo.", nameof(limiteChequeEspecial));
        }

        this.LimiteChequeEspecial = limiteChequeEspecial;
    }

    public override void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser maior que zero.", nameof(valor));
        }

        if (this.Saldo + this.LimiteChequeEspecial < valor)
        {
            throw new SaldoInsuficienteException(
                $"Saldo insuficiente considerando o limite. Saldo: R$ {this.Saldo:F2}, Limite: R$ {this.LimiteChequeEspecial:F2}."
            );
        }

        this.Saldo -= valor;
        this.RegistrarTransacao("Saque", "Saque", valor);
    }

    public override void AplicarFechamentoMensal()
    {
        this.Saldo -= TARIFA_MANUTENCAO;
        this.RegistrarTransacao("Tarifa de manutenção", "Tarifa", TARIFA_MANUTENCAO);
    }

    public override string ObterTipoFormatado() => "Conta Corrente";

    public override string ObterResumoAtributoEspecifico() => $"limite Cheque Especial: R$ {this.LimiteChequeEspecial:F2}";
}
