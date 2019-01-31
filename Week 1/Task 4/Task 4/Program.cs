using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());// create int n and convert string to int

            for (int i = 1; i <= n; i++) // making cycle and show [*] for each row and column
            {
                for (int j = 1; j <= i; j++)
                    Console.Write("[*]");
                Console.WriteLine();
            }

            Console.ReadKey();// obtains the next character or function key pressed by the user
        }
    }
}
