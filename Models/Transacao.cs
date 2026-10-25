namespace MiniBanco.ConsoleApp.Models;

public class Transacao
{
    public string Descricao { get; set; }
    public string Tipo { get; set; }
    public decimal Valor { get; }

    public Transacao(string descricao, string tipo, decimal valor)
    {
        if (string.IsNullOrWhiteSpace(descricao))
        {
            throw new ArgumentException("A descrição da transação não pode ser nula ou vazia.", nameof(descricao));
        }

        if (tipo != "Deposito" && tipo != "Saque" && tipo != "Tarifa")
        {
            throw new ArgumentException("O tipo da transação deve ser 'Deposito', 'Saque' ou 'Tarifa'.", nameof(tipo));
        }

        if (valor <= 0)
        {
            throw new ArgumentException("O valor da transação deve ser maior que zero.", nameof(valor));
        }

        this.Descricao = descricao;
        this.Tipo = tipo;
        this.Valor = valor;
    }
}