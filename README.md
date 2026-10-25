<div align="center">

<img src="https://capsule-render.vercel.app/api?type=blur&color=0:000000,100:0D0D0D&height=180&section=header&text=MINIBANCO%20.NET&fontSize=50&fontColor=ffffff&fontAlignY=45&desc=MOTOR%20DE%20GEST%C3%83O%20BANC%C3%81RIA%20%E2%80%A2%20POO%20%E2%80%A2%20AN%C3%81LISE%20FINANCEIRA&descAlignY=68&descSize=14&letterSpacing=5" width="100%"/>

<br/>

<sub>Mini-Projeto Avaliativo · Módulo 2 (Semana 07) · Formação Desenvolvedor Back-End .NET</sub>

<br/><br/>

`C#` `.NET 10` `POO` `Console Application` `Clean Code` `Exception Handling` `Git Flow`

<br/>

▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔▔

</div>

<br/>

## ⎡ ABOUT ⎦

O **MiniBanco.ConsoleApp** é uma aplicação de console desenvolvida em **C# / .NET** que funciona como o motor de gestão e auditoria de contas bancárias de um banco digital.

O sistema gerencia o ciclo operacional de diferentes modalidades de contas (`ContaCorrente`, `ContaPoupanca` e `ContaSalario`), processa movimentações financeiras tipadas (`Deposito`, `Saque` e `Tarifa`), executa o fechamento mensal com comportamento polimórfico e calcula um **Índice de Saúde Financeira (%)**, classificando a carteira de clientes e gerando recomendações automatizadas para a gerência de relacionamento.

Projeto concebido com foco estrito em **Programação Orientada a Objetos (POO)**, encapsulamento, robustez via tratamento de exceções customizadas e algoritmos iterativos tradicionais (sem dependência de LINQ).

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ VIDEO DEMONSTRATION ⎦

> 📹 **Demonstração em Vídeo (Até 5 minutos):**
> 
> Assista à apresentação detalhada do funcionamento no terminal, arquitetura de POO e decisões técnicas:
> 
> 🔗 **[Clique aqui para assistir ao vídeo no Google Drive / YouTube](#)** *(substitua por seu link)*

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ FEATURES ⎦

<table width="100%">
<tr>
<td width="50%" valign="top">

**Gestão & Operações Bancárias**
- **Abertura de Contas:** cadastro dinâmico de `ContaCorrente`, `ContaPoupanca` e `ContaSalario`.
- **Movimentações Validadas:** depósitos e saques com validação de saldo e limite.
- **Fechamento Mensal Polimórfico:** execução automática de tarifas, rendimentos e renovação de franquias sem checagem de tipo em tempo de execução.
- **Histórico & Extrato:** registro cronológico de transações imutáveis.

</td>
<td width="50%" valign="top">

**Motor de Análise & Auditoria**
- **Sistema de Pontuação:** conversão de movimentações em score de conformidade financeira.
- **Índice de Saúde (%):** cálculo percentual com prevenção a divisão por zero e precisão em ponto flutuante.
- **Classificação Dinâmica:** enquadramento em *Saudável*, *Em Atenção* ou *Em Risco*.
- **Relatório Gerencial:** apontamento de itens críticos (tarifas), atenção (saques em cheque especial) e plano de ação comercial.

</td>
</tr>
</table>

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ BUSINESS RULES ⎦

### 1. Tipos de Contas e Comportamentos Específicos

| Tipo de Conta | Atributo Específico | Regra de Saque | Fechamento Mensal |
| :--- | :--- | :--- | :--- |
| **Conta Corrente** | `LimiteChequeEspecial` (decimal) | Permite saque até `Saldo + LimiteChequeEspecial`. | Debita tarifa de manutenção fixa de **R$ 10,00**. |
| **Conta Poupança** | `TaxaRendimentoMensal` (double, %) e `DiaAniversario` (int) | Permite saque apenas até o limite do `Saldo` positivo. | Aplica rendimento creditando `Saldo × (Taxa / 100)`. |
| **Conta Salário** | `Empregador` (string) e `LimiteSaquesMensais` (int) | Saques dentro do limite são gratuitos; saques excedentes cobram tarifa de **R$ 5,00**. | Zera o contador de saques mensais realizados. |

### 2. Tabela de Pontuação por Movimentação

| Tipo de Transação | Pontuação Atribuída | Justificativa de Negócio |
| :---: | :---: | :--- |
| **`Deposito`** | **10 pts** | Entrada de capital e fortalecimento do saldo da conta. |
| **`Saque`** | **5 pts** | Retirada de recursos operacionais. |
| **`Tarifa`** | **0 pts** | Cobrança punitiva ou de manutenção de serviços. |

### 3. Cálculo do Índice de Saúde Financeira

$$\text{Índice de Saúde (\%)} = \left( \frac{\text{Pontuação Obtida}}{\text{Total de Transações} \times 10} \right) \times 100$$

> *Para contas sem movimentações registradas, o índice é tratado com valor neutro ($0,0\%$), prevenindo divisões por zero.*

### 4. Matriz de Classificação e Ação Corporativa

| Índice Calculado | Classificação Final | Ação Corporativa Recomendada |
| :---: | :---: | :--- |
| **90,0% a 100,0%** | `CONTA SAUDÁVEL` | Oferecer investimentos e avaliar aumento de limite. |
| **60,0% a 89,9%** | `CONTA EM ATENÇÃO` | Contato da gerência para orientação financeira e revisão de tarifas. |
| **0,0% a 59,9%** | `CONTA EM RISCO` | Bloquear aumento de limite e abrir análise de crédito. |

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ TECH STACK ⎦

<div align="center">

<table width="100%">
<tr>
<td align="center" width="20%">
<img src="https://cdn.simpleicons.org/dotnet/512BD4" width="40"/><br/>
<sub><b>.NET 10</b></sub>
</td>
<td align="center" width="20%">
<img src="https://cdn.simpleicons.org/csharp/239120" width="40"/><br/>
<sub><b>C#</b></sub>
</td>
<td align="center" width="20%">
<img src="https://cdn.simpleicons.org/git/F05032" width="40"/><br/>
<sub><b>Git</b></sub>
</td>
<td align="center" width="20%">
<img src="https://cdn.simpleicons.org/github/FFFFFF" width="40"/><br/>
<sub><b>GitHub</b></sub>
</td>
<td align="center" width="20%">
<img src="https://cdn.simpleicons.org/powershell/5391FE" width="40"/><br/>
<sub><b>CLI / Terminal</b></sub>
</td>
</tr>
</table>

</div>

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ PROJECT STRUCTURE ⎦

```txt
minibanco-dotnet/
├── src/
│   └── MiniBanco.ConsoleApp/
│       ├── Exceptions/
│       │   └── SaldoInsuficienteException.cs    # Exceção de domínio para regras de saque
│       ├── Models/
│       │   ├── Conta.cs                         # Classe base abstrata com encapsulamento de saldo
│       │   ├── ContaCorrente.cs                 # Subclasse com cheque especial e tarifa
│       │   ├── ContaPoupanca.cs                 # Subclasse com taxa de rendimento e aniversário
│       │   ├── ContaSalario.cs                  # Subclasse com empregador e franquia de saques
│       │   └── Transacao.cs                     # Modelo imutável de movimentação financeira
│       ├── Services/
│       │   └── MotorAnalise.cs                  # Motor de pontuação, saúde e geração de relatórios
│       ├── MiniBanco.ConsoleApp.csproj          # Configurações do projeto e runtime .NET
│       └── Program.cs                           # Menu interativo, fluxo de console e try/catch
├── .gitignore                                   # Exclusão de artefatos de compilação (bin/obj)
└── README.md                                    # Documentação técnica e guia do projeto
```

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ GETTING STARTED ⎦

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) versão 8.0 ou 10.0+ instalada
- [Git](https://git-scm.com/) instalado no ambiente

<br/>

**1 · Clonar o repositório**

```bash
git clone https://github.com/SEU_USUARIO/minibanco-dotnet.git
cd minibanco-dotnet
```

**2 · Restaurar dependências e compilar a solução**

```bash
dotnet build src/MiniBanco.ConsoleApp/MiniBanco.ConsoleApp.csproj
```

**3 · Executar a aplicação via terminal**

```bash
dotnet run --project src/MiniBanco.ConsoleApp/MiniBanco.ConsoleApp.csproj
```

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ NAVIGATION & CLI PREVIEW ⎦

### Menu Principal Interativo

O fluxo de navegação permanece ativo em laço contínuo (`while`), tratando todas as exceções sem abortar o processo:

```txt
==================================================
        MINIBANCO .NET - GESTÃO DE CONTAS         
==================================================
1 - Abrir Nova Conta
2 - Registrar Movimentação (Depósito / Saque)
3 - Aplicar Fechamento Mensal
4 - Exibir Relatório das Contas
0 - Sair
Escolha uma opção:
```

<details>
<summary><b>Exemplo de Saída: Relatório de Processamento Geral (RF10)</b></summary>

```txt
====================================================================
        MINIBANCO .NET - MOTOR DE GESTÃO DE CONTAS
====================================================================

[1/2] PROCESSANDO CONTA
--------------------------------------------------------------------
> DADOS DA CONTA:
  - Tipo: Conta Corrente
  - Titular: Ana Souza | Conta: 1001
  - Atributo Específico: limite Cheque Especial: R$ 500,00
  - Saldo Atual: R$ -310,00

> MOVIMENTAÇÕES REGISTRADAS (5 TRANSAÇÕES):
  [OK] Salário ----------------------- Deposito: R$ 2000,00 (10 pts)
  [OK] Transferência recebida -------- Deposito: R$ 300,00 (10 pts)
  [ ! ] Saque ------------------------ Saque: R$ 800,00 (5 pts)
  [ ! ] Saque ------------------------ Saque: R$ 2800,00 (5 pts)
  [ X ] Tarifa de manutenção --------- Tarifa: R$ 10,00 (0 pts)

> RESUMO DA PONTUAÇÃO:
  - Pontuação Atingida: 30 de 50 pontos possíveis
  - Índice de Saúde: 60,0%
  - Classificação Final: [ CONTA EM ATENÇÃO ]

> RELATÓRIO DE PENDÊNCIAS E RECOMENDAÇÕES DA GERÊNCIA:
  🔴 ITENS CRÍTICOS (TARIFAS):
    - Tarifa de manutenção: Avaliar isenção ou migração para pacote de serviços.

  🟡 ITENS DE ATENÇÃO (SAQUES):
    - Saque de R$ 2800,00: Conta usando limite do cheque especial. Entrar em contato com o cliente.
--------------------------------------------------------------------

[2/2] PROCESSANDO CONTA
--------------------------------------------------------------------
> DADOS DA CONTA:
  - Tipo: Conta Poupança
  - Titular: Bia Lima | Conta: 2001
  - Atributo Específico: Rendimento: 0,5% ao mes | Aniversario: dia 10
  - Saldo Atual: R$ 2814,00

> MOVIMENTAÇÕES REGISTRADAS (3 TRANSAÇÕES):
  [OK] Depósito em dinheiro ---------- Deposito: R$ 500,00 (10 pts)
  [OK] Transferência recebida -------- Deposito: R$ 300,00 (10 pts)
  [OK] Rendimento Mensal ------------- Deposito: R$ 14,00 (10 pts)

> RESUMO DA PONTUAÇÃO:
  - Pontuação Atingida: 30 de 30 pontos possíveis
  - Índice de Saúde: 100,0%
  - Classificação Final: [ CONTA SAUDÁVEL ]

> RELATÓRIO DE PENDÊNCIAS E RECOMENDAÇÕES DA GERÊNCIA:
  🟢 Nenhuma pendência identificada. Oferecer investimentos e avaliar aumento de limite.

====================================================================
        FIM DO PROCESSAMENTO DE CONTAS
====================================================================
```

</details>

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ OOP & ARCHITECTURE HIGHLIGHTS ⎦

- **Encapsulamento Estrito:** A propriedade `Saldo` possui modificador `{ get; protected set; }`, garantindo que apenas a classe base `Conta` e suas classes derivadas possam atualizar o valor monetário através de métodos explícitos (`Depositar`, `Sacar`, `AplicarFechamentoMensal`).
- **Polimorfismo Dinâmico:** O método `AplicarFechamentoMensal` é invocado diretamente a partir de instâncias de `Conta` no loop do banco (`c.AplicarFechamentoMensal()`), acionando a sobrescrita (`override`) específica de cada conta sem recorrer a checagens de tipo em tempo de execução (`is` ou `as`).
- **Resiliência a Falhas (Exceptions):** Tratamento estruturado capturando `SaldoInsuficienteException`, `ArgumentException`, `FormatException` e `Exception` genérica com mensagens orientadas ao usuário final, mantendo o terminal ativo.
- **Conformidade Algorítmica (RF09):** Total ausência de métodos de extensão LINQ (`Where`, `Select`, `Sum`, etc.). Todos os cálculos de pontuação, filtragens de pendências e varreduras utilizam laços `for` e `foreach` com estruturas condicionais tradicionais.

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ WHAT I LEARNED ⎦

- Estruturação de soluções C# divididas em camadas (`Models`, `Services`, `Exceptions`).
- Aplicação prática dos 4 pilares de POO: Abstração, Encapsulamento, Herança e Polimorfismo.
- Modelagem de hierarquias de classes com construtores encadeados (`base(...)`) e uso explícito de `this`.
- Criação e disparo de exceções customizadas de domínio (`SaldoInsuficienteException`).
- Construção de interfaces de console amigáveis com menus interativos e validação de entradas numéricas.
- Prevenção de armadilhas de precisão aritmética em C#, como truncamento em divisão inteira com `(double)` casting e aritmética monetária exata via tipo `decimal`.
- Fluxo de trabalho com Git e GitHub: commits atômicos descritivos e uso de branches temáticas (`feature/relatorio`).

<div align="center">

▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁▁

</div>

## ⎡ ROADMAP & LIMITATIONS ⎦

- [x] Motor de análise de saúde financeira e classificação em 3 níveis
- [x] Abertura e movimentação polimórfica de contas
- [x] Tratamento robusto de exceções com custom exceptions
- [ ] Persistência de dados em banco relacional (ex: PostgreSQL / SQLite com EF Core)
- [ ] Suíte de testes unitários automatizados com xUnit e FluentAssertions
- [ ] Evolução para API Web RESTful com ASP.NET Core
- [ ] Exportação de relatórios em formato JSON ou CSV

<br/>

<div align="center">

<sub>◈ Mini-Projeto Avaliativo · Módulo 2 - Semana 07 · Back-End .NET ◈</sub>

</div>

<img src="https://capsule-render.vercel.app/api?type=blur&color=0:0D0D0D,100:000000&height=90&section=footer" width="100%"/>
