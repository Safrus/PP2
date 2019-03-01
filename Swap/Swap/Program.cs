using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swap// antiantiplag
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";// push your text here in " "
            
            char[] arr = new char[s.Length];
          
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    arr[i] = 'а';

                }
                else if (s[i] == 'A')
                {
                    arr[i] = 'А';
                }
                else
                    arr[i] = s[i];
                    
            }
            foreach(char q in arr)
            {
                Console.Write(q);
            }
            Console.ReadKey();
        }
    }
}
