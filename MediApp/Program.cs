using System.Runtime.CompilerServices;

namespace MediApp
{

    internal class Program
    {

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando)
            {
                Console.Clear();
                Console.WriteLine("Sistema de getão - MEDIAPP -");
                Console.WriteLine("1. Cadastrar Paciente");
                Console.WriteLine("2. Cadastrar Medico");
                Console.WriteLine("3. Agendar Consulta");
                Console.WriteLine("4. Listar Médicos e Pacientes");
                Console.WriteLine("5. Relatorios e Faturamento");
                Console.WriteLine("0. Sair");
                string opcaoInput = Console.ReadLine();


                if (!int.TryParse(opcaoInput, out int opcao))
                {
                    Console.WriteLine("Opção invalida! Digite um número inteiro");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarPaciente();
                        break;
                    case 2:
                        CadastrarMedico();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 0:
                        executando = false;
                        Console.WriteLine("Finalizando sistema...");
                        break;
                }


            }
        }


        private static void CadastrarPaciente() {
            Console.Clear();
            Console.WriteLine("-- Cadastro de Paciente --");

            Console.WriteLine("ID do Paciente");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Possui plano de saude? (S/N)"); 
            bool possuiPlano = Console.ReadLine().Trim().ToUpper() == "S";

            Paciente paciente = new Paciente(id, nome, cpf, possuiPlano);
        }
        private static void CadastrarMedico() {
            Console.Clear();
            Console.WriteLine("-- Cadastro de Médico --");

            Console.WriteLine("ID do médico");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("CRM: ");
            string crm = Console.ReadLine();
            Console.WriteLine("Especialidade: ");
            string especialidade = Console.ReadLine();
            Console.WriteLine("Valor da consulta: R$");
            decimal valorConsulta = decimal.Parse(Console.ReadLine());

            Medico medico = new Medico(id, nome, cpf, crm, especialidade, valorConsulta);

        }
    }
}
