using System;

namespace ATM_EXECÍCIO
{
    class Program
    {
        static void Main(string[] args)
        {
            menu menu = new menu();
            Operations operations = new Operations();
            operations.criarConta();
            operations.gerarOutrasContas();

            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Digite o seu pin para acessar a sua conta: ");
            int pin = Convert.ToInt16(Console.ReadLine());

            Console.Clear();

            if (pin != operations.getsenha())
            {
                Console.WriteLine("O seu pine está incorreto");
            }
            else
            {
                bool menuOn = true;

                while (menuOn == true)
                {
                    menu.showMenu();
                    int option = Int16.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (option)
                    {
                        case (1):
                            operations.Consulta(operations.conta.senha);
                            break;
                        case (2):
                            operations.Deposito(operations.conta.senha);
                            break;
                        case (3):
                            operations.levantamento(operations.conta.senha);
                            break;
                        case (4):
                            operations.Transferencia(operations.conta.senha);
                            break;
                        case (5):
                            operations.Extrato();
                            break;
                        default:
                            menuOn = false;
                            break;
                    }
                    Console.Clear();
                }

            }

        }
    }
}
