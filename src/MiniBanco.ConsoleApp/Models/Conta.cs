namespace MiniBanco.ConsoleApp.Models;

using MiniBanco.ConsoleApp.Exceptions;

public abstract class Conta
{
    public string Titular { get; set; }
    public int Numero { get; set; }
    public decimal Saldo { get; protected set; }
    public List<Transacao> Extrato { get; }

    public Conta(string titular, int numero, decimal saldoInicial)
    {
        if (string.IsNullOrWhiteSpace(titular))
        {
            throw new ArgumentException("O titular da conta não pode ser nulo ou vazio.", nameof(titular));
        }

        if (numero <= 0)
        {
            throw new ArgumentException("O número da conta deve ser maior que zero.", nameof(numero));
        }

        if (saldoInicial < 0)
        {
            throw new ArgumentException("O saldo inicial não pode ser negativo.", nameof(saldoInicial));
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
            throw new ArgumentException("O valor do depósito deve ser maior que zero.", nameof(valor));
        }

        this.Saldo += valor;
        this.RegistrarTransacao(descricao, "Deposito", valor);
    }

    public virtual void Saca(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("O valor do saque deve ser maior que zero.", nameof(valor));
        }

        if (this.Saldo < valor)
        {
            throw new ArgumentException("Saldo insuficiente para realizar o saque.", nameof(valor));
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