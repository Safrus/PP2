using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");// read the input.txt
            String s = sr.ReadToEnd();//assumes that the stream knows when it has reached an end
            String[] arr = s.Split();//// divide string s to substrings without " "(space)
            int[] b = new int[arr.Length];// create an array with dimension equal to length of string
            for(int i=0;i<arr.Length;i++)
            {
                b[i] = int.Parse(arr[i]);// push splitted string converted to int to int array
            }
            sr.Close();// close StreamReader,because we got the information from it
            StreamWriter sw = new StreamWriter("output.txt");// open StreamWriter
            foreach(int z in b)// foreach int in b array we check if the int is prime
            {
                bool prime = true;
                if (z == 1)
                    prime = false;//if z in array b is equal 1 it means that our bool prime is false,cause number 1 is not prime
                for (int i=2;i<=Math.Sqrt(z);i++)
                {
                    if (z % i == 0)
                        prime = false;//if z divided on i is having remainder 0 it means that this number has other divider
                }
                if (prime == true)
                    sw.Write(z + " ");// if int is a prime number write it to output.txt with " "

            }
            sw.Close();// close StreamWriter
            Console.ReadKey();//obtains the next character or function key pressed by the user

        }
    }
}