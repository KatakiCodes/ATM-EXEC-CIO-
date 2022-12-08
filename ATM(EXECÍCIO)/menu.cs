using System;
using System.Collections.Generic;
using System.Text;

namespace ATM_EXECÍCIO
{
    public class menu
    {
        public void showMenu()
        {

            Console.WriteLine("--------------------------------------------------------------------");

            Console.WriteLine("\t\t1 - Consultar");
            Console.WriteLine("\t\t2 - Depositar");
            Console.WriteLine("\t\t3 - Levantamento");
            Console.WriteLine("\t\t4 - Transferência");
            Console.WriteLine("\t\t5 - Extrato");

            Console.WriteLine("--------------------------------------------------------------------");
        }
        public void menuExtrato()
        {
            Console.WriteLine("\t\t******Extrato \n\n");
            Console.WriteLine("\t\t1 - Hoje");;
        }
    }
}
