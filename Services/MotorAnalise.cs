namespace MiniBanco.ConsoleApp.Services;

using MiniBanco.ConsoleApp.Models;

public class MotorAnalise
{
    public void ExibirRelatorioGeral(List<Conta> contas)
    {
        if (contas == null || contas.Count == 0)
        {
            Console.WriteLine("\n[!] Nenhuma conta cadastrada no momento para processamento.");
            return;
        }

        Console.WriteLine("\n====================================================================");
        Console.WriteLine("        MINIBANCO .NET - MOTOR DE GESTÃO DE CONTAS");
        Console.WriteLine("====================================================================");

        
        for (int i = 0; i < contas.Count; i++)
        {
            Conta conta = contas[i];
            this.ProcessarConta(conta, i + 1, contas.Count);
        }

        Console.WriteLine("\n====================================================================");
        Console.WriteLine("        FIM DO PROCESSAMENTO DE CONTAS");
        Console.WriteLine("====================================================================\n");
    }

    private void ProcessarConta(Conta conta, int indice, int totalContas)
    {
        Console.WriteLine($"\n[{indice}/{totalContas}] PROCESSANDO CONTA");
        Console.WriteLine("--------------------------------------------------------------------");
        Console.WriteLine("> DADOS DA CONTA:");
        Console.WriteLine($"  - Tipo: {conta.ObterTipoFormatado()}");
        Console.WriteLine($"  - Titular: {conta.Titular} | Conta: {conta.Numero}");
        Console.WriteLine($"  - Atributo Específico: {conta.ObterResumoAtributoEspecifico()}");
        Console.WriteLine($"  - Saldo Atual: R$ {conta.Saldo:F2}");

        Console.WriteLine($"\n> MOVIMENTAÇÕES REGISTRADAS ({conta.Extrato.Count} TRANSAÇÕES):");

        int pontuacaoObtida = 0;
        bool possuiTarifas = false;
        bool possuiSaques = false;

        
        foreach (Transacao transacao in conta.Extrato)
        {
            int pontosTransacao = 0;
            string marcador = "[OK]";

            if (transacao.Tipo == "Deposito")
            {
                pontosTransacao = 10;
                marcador = "[OK]";
            }
            else if (transacao.Tipo == "Saque")
            {
                pontosTransacao = 5;
                marcador = "[ ! ]";
                possuiSaques = true;
            }
            else if (transacao.Tipo == "Tarifa")
            {
                pontosTransacao = 0;
                marcador = "[ X ]";
                possuiTarifas = true;
            }

            pontuacaoObtida += pontosTransacao;

            string descricaoFormatada = (transacao.Descricao + " ").PadRight(32, '-');
            Console.WriteLine($"  {marcador} {descricaoFormatada} {transacao.Tipo}: R$ {transacao.Valor:F2} ({pontosTransacao} pts)");
        }

        if (conta.Extrato.Count == 0)
        {
            Console.WriteLine("  (Nenhuma movimentacao registrada nesta conta)");
        }

        
        int totalTransacoes = conta.Extrato.Count;
        int pontuacaoMaxima = totalTransacoes * 10;
        double indiceSaude = 0.0;

        if (pontuacaoMaxima > 0)
        {
            indiceSaude = ((double)pontuacaoObtida / pontuacaoMaxima) * 100.0;
        }

        
        string classificacao;
        string acaoCorporativa;

        if (indiceSaude >= 90.0)
        {
            classificacao = "CONTA SAUDÁVEL";
            acaoCorporativa = "Oferecer investimentos e avaliar aumento de limite.";
        }
        else if (indiceSaude >= 60.0)
        {
            classificacao = "CONTA EM ATENÇÃO";
            acaoCorporativa = "Contato da gerência para orientação financeira e revisão de tarifas.";
        }
        else
        {
            classificacao = "CONTA EM RISCO";
            acaoCorporativa = "Bloquear aumento de limite e abrir análise de crédito.";
        }

        Console.WriteLine("\n> RESUMO DA PONTUAÇÃO:");
        Console.WriteLine($"  - Pontuação Atingida: {pontuacaoObtida} de {pontuacaoMaxima} pontos possíveis");
        Console.WriteLine($"  - Índice de Saúde: {indiceSaude:F1}%");
        Console.WriteLine($"  - Classificação Final: [ {classificacao} ]");

        
        Console.WriteLine("\n> RELATÓRIO DE PENDÊNCIAS E RECOMENDAÇÕES DA GERÊNCIA:");

        bool possuiPendencias = possuiTarifas || (possuiSaques && conta.Saldo < 0);

        if (!possuiPendencias)
        {
            Console.WriteLine($"  Nenhuma pendência identificada. {acaoCorporativa}");
        }
        else
        {
            if (possuiTarifas)
            {
                Console.WriteLine("  ITENS CRÍTICOS (TARIFAS):");
                foreach (Transacao t in conta.Extrato)
                {
                    if (t.Tipo == "Tarifa")
                    {
                        Console.WriteLine($"    - {t.Descricao}: Avaliar isenção ou migração para pacote de serviços.");
                    }
                }
            }

            if (possuiSaques)
            {
                bool cabecalhoSaqueExibido = false;

                foreach (Transacao t in conta.Extrato)
                {
                    if (t.Tipo == "Saque")
                    {
                        if (!cabecalhoSaqueExibido)
                        {
                            if (possuiTarifas) Console.WriteLine();
                            Console.WriteLine("  ITENS DE ATENÇÃO (SAQUES):");
                            cabecalhoSaqueExibido = true;
                        }

                        if (conta.Saldo < 0)
                        {
                            Console.WriteLine($"    - Saque de R$ {t.Valor:F2}: Conta usando limite do cheque especial. Entrar em contato com o cliente.");
                        }
                        else
                        {
                            Console.WriteLine($"    - Saque de R$ {t.Valor:F2}: Acompanhar histórico de retiradas para manutenção de saldo.");
                        }
                    }
                }
            }
        }

        Console.WriteLine("--------------------------------------------------------------------");
    }
}