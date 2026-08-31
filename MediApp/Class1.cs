using System;
using System.Collections.Generic;
using System.Text;

namespace MediApp
{
    public abstract class Pessoa  //classe base para o cadastro de cliente e funcionarios
    {
        // Definindo as propriedades
        public int Id { get; set; } 
        public string Nome { get; set; }
        public string Cpf { get; set; }

        //Inicialização das propriedades
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
    
        public bool PlanoDeSaude { get; set;}

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

        public Medico(int id, string nome, string cpf, string crm, string especialidade, decimal valorConsulta ) : base(id, nome, cpf) 
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
        public int paciente {get; set; }
        public int Medico { get; set; }
        public DateTime hora { get; set; }

        public Consulta(int Paciente, int Medico, DateTime hora) { 
        
        }

        public Consulta(int PAciente, int MEdico) : this() { }
    }
}
