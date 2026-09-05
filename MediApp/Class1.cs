using System;
using System.Collections.Generic;
using System.Text;

namespace MediApp
{
    public abstract class Pessoa  
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }


        public Pessoa(int id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
        public virtual void ExibirInfo()
        {
            Console.WriteLine($"Nome: {Nome}, CPF: {Cpf}");
        }

    }

    public class Paciente : Pessoa //Classe para cadastro de paciente, herda de pessoa
    {

        public bool PlanoDeSaude { get; set; }

        //Inicialização das propriedades id nome e cpf são herdados de pessoa e o plano de saude é configurado aqui
        public Paciente(int id, string nome, string cpf, bool temPlanoSaude) : base(id, nome, cpf)
        {
            PlanoDeSaude = temPlanoSaude;
        }

        //sobrescreve o metodo ExibirInfo de pessoa e muda a menssagem
        public override void ExibirInfo()
        {
            //Usamos uma condição Ternaria para simplificar a informação do plano de saude se true valor a esquerda, se false a direita
            string plano = PlanoDeSaude ? "Possui Plano" : "Particular";
            Console.WriteLine($"[Paciente ID:{Id}] {Nome} | CPF: {Cpf} | Tipo: {plano}");
        }
    }

    public class Medico : Pessoa
    {
        public string CRM { get; set; }
        public string Especialidade { get; set; }
        public decimal ValorConsulta { get; set; }

        public Medico(int id, string nome, string cpf, string crm, string especialidade, decimal valorConsulta) : base(id, nome, cpf)
        {
            CRM = crm;
            Especialidade = especialidade;
            ValorConsulta = valorConsulta;
        }

        public override void ExibirInfo()
        {
            Console.WriteLine($"[Médico ID:{Id}] Dr(a). {Nome} | CRM: {CRM} | {Especialidade} | Consulta: {ValorConsulta:C2}");
        }

    }

    public class Consulta {
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public DateTime DataHora { get; set; }


        public Consulta(Paciente paciente, Medico medico, DateTime dataHora)
        {
            Paciente = paciente;
            Medico = medico;
            DataHora = dataHora;
        }

        public Consulta(Paciente paciente, Medico medico) : this(paciente, medico, DateTime.Now)
        {
         
        }

        public decimal CalcularValorFinal(decimal descontoPercentual = 20m) {
            
            if (Paciente.PlanoDeSaude)
            {
                decimal fatorDesconto = 1 - (descontoPercentual / 100m);
               return Medico.ValorConsulta * fatorDesconto;
            }
            else {
                return  Medico.ValorConsulta;           
            } 
        
        }
         public void ExibirResumo() {
            Console.WriteLine($"[Consulta] Data: {DataHora:dd/MM/yyyy HH:mm} | Paciente: {Paciente.Nome} | Médico: Dr(a). {Medico.Nome} | Valor Final: {CalcularValorFinal():C2}");
        }

    }}
