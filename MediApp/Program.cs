namespace MediApp {

    internal class Program {

        static void Main(string[] args)
        {
            bool executando = true;

            while (executando) {
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

                switch (opcao) {
                    case 1:
                        break;
                    case 2:
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
    }
}
