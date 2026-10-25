namespace MiniBanco.ConsoleApp.Models;

public class ContaPoupanca : Conta
{
    public double TaxaRendimentoMensal { get; set; }
    public int DiaAniversario { get; }

    public ContaPoupanca(string titular, int numero, decimal saldoInicial, double taxaRendimentoMensal, int diaAniversario )
        : base(titular, numero, saldoInicial)
    {
        if (taxaRendimentoMensal < 0)
        {
            throw new ArgumentException("A taxa de rendimento mensal não pode ser negativa.", nameof(taxaRendimentoMensal));
        }

        if (diaAniversario < 1 || diaAniversario > 31)
        {
            throw new ArgumentException("O dia do aniversário deve estar entre 1 e 31.", nameof(diaAniversario));
        }

        this.DiaAniversario = diaAniversario;
        this.TaxaRendimentoMensal = taxaRendimentoMensal;
    }

    public override void AplicarFechamentoMensal()
    {
        if (this.Saldo > 0)
        {
            decimal rendimento = this.Saldo * (decimal)this.TaxaRendimentoMensal;
            this.Saldo += rendimento;
            this.RegistrarTransacao("Rendimento Mensal", "Deposito", rendimento);
        }
    }

    public override string ObterTipoFormatado() => "Conta Poupança";

    public override string ObterResumoAtributoEspecifico() => 
        $"Rendimento: {this.TaxaRendimentoMensal:F1}% ao mes | Aniversario: dia {this.DiaAniversario}";
}