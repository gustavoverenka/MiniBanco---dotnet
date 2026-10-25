namespace MiniBanco.ConsoleApp.Models;

using MiniBanco.ConsoleApp.Exceptions;

public abstract class Conta
{
    public string Titular { get; }
    public int Numero { get; }
    public decimal Saldo { get; protected set; }
    public List<Transacao> Extrato { get; }

    public Conta(string titular, int numero, decimal saldoInicial)
    {
        if (string.IsNullOrWhiteSpace(titular))
        {
            throw new ArgumentException("O titular nao pode ser vazio.", nameof(titular));
        }

        if (numero <= 0)
        {
            throw new ArgumentException("O numero da conta deve ser positivo.", nameof(numero));
        }

        if (saldoInicial < 0)
        {
            throw new ArgumentException("O saldo inicial nao pode ser negativo.", nameof(saldoInicial));
        }

        this.Titular = titular;
        this.Numero = numero;
        this.Saldo = saldoInicial;
        this.Extrato = new List<Transacao>();
    }

    public void RegistrarTransacao(string descricao, string tipo, decimal valor)
    {
        Transacao transacao = new Transacao(descricao, tipo, valor);
        this.Extrato.Add(transacao);
    }

    public virtual void Depositar(decimal valor, string descricao = "Deposito")
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do deposito deve ser maior que zero.", nameof(valor));
        }

        this.Saldo += valor;
        this.RegistrarTransacao(descricao, "Deposito", valor);
    }

    public virtual void Sacar(decimal valor)
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
        this.RegistrarTransacao("Saque", "Saque", valor);
    }

    public virtual void AplicarFechamentoMensal()
    {
        
    }

    public abstract string ObterTipoFormatado();
    public abstract string ObterResumoAtributoEspecifico();
}