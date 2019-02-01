using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());// create int n and convert string to int
            string s = Console.ReadLine();// create string s and enter it
            string[] a = s.Split();// divide string s to substrings without " "(space)
            List<int> ku = new List<int>();// create List for adding prime numbers
            int[] b = new int[n];// create an array of int 
            for (int i = 0; i < n; i++)// creating cycle
            {
                b[i] = int.Parse(a[i]);//adding integers from string []a to a new array
            }
            foreach (int z in b)// creating cycle to determine which numbers are prime
            {
                bool prime = true;// create bool 
                if (z == 1)
                    prime = false;//if z in array b is equal 1 it means that our bool prime is false,cause number 1 is not prime
                for (int i = 2; i <= Math.Sqrt(z); i++)
                {
                    if (z % i == 0)//if z divided on i is having remainder 0 it means that this number has other divider
                        prime = false;
                }
                if (prime == true)
                    ku.Add(z);// finally add int z to list because this number passed checking
            }
            Console.WriteLine(ku.Count());// show total number of primes
            foreach (int k in ku)
            {
                Console.Write(k + " ");// show every prime number with "(space)" after it
            }
            Console.ReadKey(); //obtains the next character or function key pressed by the user
        }
    }
}
