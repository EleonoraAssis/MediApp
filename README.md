# 🏥 MediApp - Sistema de Gestão de Clínica Médica

> Aplicação de console desenvolvida em **C# / .NET** para praticar os principais pilares da linguagem, como Programação Orientada a Objetos (POO), validação de dados, manipulação de coleções e consultas com LINQ.

---

## 🎯 Sobre o Projeto

O **MediApp** é um sistema de gerenciamento para uma clínica médica. O aplicativo permite cadastrar médicos e pacientes, agendar consultas aplicand o regras de negócio financeiras (como desconto para planos de saúde) e gerar relatórios analíticos de faturamento em tempo real.

---

## 🛠️ Conceitos Praticados e Tecnologias

Neste projeto foram colocados em prática os seguintes aprendizados em C#:

* **Programação Orientada a Objetos (POO):**
  * **Herança:** Classe abstrata `Pessoa` servindo de base para `Paciente` e `Medico`.
  * **Polimorfismo:** Sobrescrita do método `ExibirInfo()` usando as palavras-chave `virtual` e `override`.
  * **Encapsulamento:** Propriedades fortemente tipadas (`public`, `get`, `set`).
  * **Construtores e Overloads:** Encadeamento de construtores utilizando `: base(...)` e `: this(...)`.
* **Tratamento de Dados e Robustez:**
  * Validação segura de entrada do usuário com `int.TryParse` e `decimal.TryParse` em laços `while`.
  * Formatação monetária e de datas com interpolação de strings (`:C2`, `dd/MM/yyyy HH:mm`).
  * Tipagem adequada para valores financeiros usando `decimal`.
* **Consultas e Manipulação com LINQ:**
  * Busca de entidades por ID utilizando `.FirstOrDefault()`.
  * Filtros de dados com `.Where()`.
  * Contagem e cálculos financeiros dinâmicos com `.Count()` e `.Sum()`.

---

## 💻 Funcionalidades do Sistema

- [x] **Cadastrar Paciente:** Registro de ID, Nome, CPF e status do Plano de Saúde.
- [x] **Cadastrar Médico:** Registro de ID, Nome, CPF, CRM, Especialidade e Valor da Consulta.
- [x] **Agendar Consulta:** Associação entre paciente e médico cadastrados, definindo data/hora de forma automática.
- [x] **Listagem Polimórfica:** Exibição unificada de pacientes e médicos cadastrados.
- [x] **Relatórios e Faturamento:**
  - Total de consultas agendadas.
  - Faturamento total estimado (considerando 20% de desconto automático para quem possui plano de saúde).
  - Quantidade de consultas realizadas por convênio.
  - Detalhamento de cada agendamento.

---

## 🚀 Como Executar o Projeto

### Pré-requisitos
* [.NET SDK 8.0](https://dotnet.microsoft.com/download) ou superior instalado.
* Git instalado.

### Passo a Passo

1. **Clone este repositório:**
   ```bash
   git clone [https://github.com/EleonoraAssis/MediApp.git](https://github.com/EleonoraAssis/MediApp.git)

   📂 Estrutura das Classes
Plaintext
MediApp/
├── Pessoa.cs (Classe Abstrata Base)
├── Paciente.cs (Herda de Pessoa)
├── Medico.cs (Herda de Pessoa)
├── Consulta.cs (Agendamento e Regra de Desconto)
└── Program.cs (Menu de Interação, Validações e LINQ)