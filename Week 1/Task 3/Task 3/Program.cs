using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        
        
            static void prikol(int[] b) // making new function
            {
                List<int> glist = new List<int>();// create the list
                foreach (int k in b)
                {
                    glist.Add(k);// making foreach cycle to add each k twice at array b to list "glist"
                    glist.Add(k);
                }
                foreach (int k in glist)
                { Console.Write(k + " "); }// show the final result 
            }

            static void Main(string[] args)
            {

                int n = int.Parse(Console.ReadLine());// create int n and convert string to int

                string s = Console.ReadLine();// create string s and enter it

                string[] a = s.Split();// divide string s to substrings without " "(space)
                int[] b = new int[n];// create a new array of int

                for (int i = 0; i < n; i++) // making cycle
                {
                    b[i] = int.Parse(a[i]);// enter substrings to an array b as int 
                }

                prikol(b); // trigger the function

                Console.ReadKey();// obtains the next character or function key pressed by the user



            }
        }
    }

    

