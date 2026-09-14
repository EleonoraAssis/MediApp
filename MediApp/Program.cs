using System.Linq;
using System.Collections.Generic;
using System;
namespace MediApp
{

    internal class Program
    {
        private static List<Paciente> pacientesList = new List<Paciente>();
        private static List<Medico> medicosList = new List<Medico>();
        private static List<Consulta> consultasList = new List<Consulta>();

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
                        AgendarConsulta();
                        break;
                    case 4:
                        ListarPessoa();
                        break;
                    case 5:
                        Relatorio();
                        break;
                    case 0:
                        executando = false;
                        Console.WriteLine("Finalizando sistema...");
                        break;
                    default:
                        ExibirMensagemErro("Opção não encontrada no menu.");
                        break;
                }


            }
        }

        private static void ExibirMensagemErro(string mensagem) {
            Console.ForegroundColor =ConsoleColor.Red;
            Console.WriteLine($"[Erro] {mensagem}");
            Console.ResetColor();
            Pause();
        }
        private static void ExibirMensagemSucesso(string mensagem) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{mensagem}");
            Console.ResetColor();
            Pause();
        }
        private static void CadastrarPaciente() {
            Console.Clear();
            Console.WriteLine("\n -- Cadastro de Paciente --");

            int id = LerInt("Id do paciente: ");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("Possui plano de saude? (S/N)"); 
            bool possuiPlano = Console.ReadLine().Trim().ToUpper() == "S";

            pacientesList.Add(new Paciente(id, nome, cpf, possuiPlano));
            ExibirMensagemSucesso("Paciente cadastrado com sucesso!");
        }
        private static void CadastrarMedico() {
            Console.Clear();
            Console.WriteLine("\n -- Cadastro de Médico --");

            int id = LerInt("ID do médico");
            Console.WriteLine("Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("CPF: ");
            string cpf = Console.ReadLine();
            Console.WriteLine("CRM: ");
            string crm = Console.ReadLine();
            Console.WriteLine("Especialidade: ");
            string especialidade = Console.ReadLine();
            decimal valorConsulta = LerDecimal("Valor da consulta: R$");

            medicosList.Add(new Medico(id, nome, cpf, crm, especialidade, valorConsulta));
            ExibirMensagemSucesso("Medico cadastrado com sucesso!");
        }
        private static void AgendarConsulta() {
            Console.Clear();
            Console.WriteLine("-- AgendarConsulta --");

            int idPaciente = LerInt("Id do paciente: ");
            Paciente paciente = pacientesList.FirstOrDefault(p => p.Id == idPaciente);
            if (paciente == null) {
                ExibirMensagemErro("Paciente não encontrado");
                return;
            }

            int idMedico = LerInt("Id do médico: ");
            Medico medico = medicosList.FirstOrDefault(p => p.Id == idMedico);
            if (medico == null)
            {
                ExibirMensagemErro("Medico não encontrado");
                return;
            }

            consultasList.Add(new Consulta(paciente, medico));
            Console.WriteLine("Consulta agendada com sucesso!");
            Pause();
        }
        private static void ListarPessoa() {
            Console.Clear();
            Console.WriteLine("\n___Pacientes Cadastrados___");
            foreach (var p in pacientesList) {
                p.ExibirInfo();
            }

            Console.WriteLine("\n ___Medicos Cadastrados___");
            foreach (var m in medicosList) {
                m.ExibirInfo();
            }
            Pause();
            
        }
        private static void Relatorio() { 
            Console.Clear();
            Console.WriteLine("__Relatorios e Estatísticas__");
            if (!consultasList.Any())
            {
                Console.WriteLine("Nenhuma consulta agendada.");
                return;
            }
            else
            {
                int totalConsultas = consultasList.Count;
                Console.WriteLine($"Total de consultas realizadas: {totalConsultas}");

                decimal faturamentoTotal = consultasList.Sum(c => c.CalcularValorFinal());
                Console.WriteLine($"Faturamento total: {faturamentoTotal:C2}");

                int consultaPlano = consultasList.Where(c => c.Paciente.PlanoDeSaude).Count();
                Console.WriteLine($"Consultas via plano de saúde {consultaPlano}");

                Console.WriteLine("-- Detalhamento de Consultas---");
                foreach (var c in consultasList)
                {
                    c.ExibirResumo();

                }
            }
            
            Pause();

        }
        private static void Pause() {
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
        private static int LerInt(string mensagem) {
            int valor;
            while (true) {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out valor)){
                    return valor;
                }
                Console.WriteLine("Digite um número valido.");
            }

        }
        private static decimal LerDecimal(string mensagem) {
            decimal valor;
            while (true) {
                Console.Write(mensagem);
                if (decimal.TryParse(Console.ReadLine(), out valor)) {
                    return valor;
                }
                Console.WriteLine("Digite um valor valido.");
            }
        }
    }
}
