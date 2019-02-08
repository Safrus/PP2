using System;
using System.IO;
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
            string rev="";//creating string rev to compare with string s if string s a palnidrome
            StreamReader sr = new StreamReader("input.txt");// reading from text file
            String s = sr.ReadToEnd();//assumes that the stream knows when it has reached an end
            for (int i=s.Length-1;i>=0;i--)// checking string s
            {
                rev += s[i].ToString();// add chars of s to string rev
            }
            if (rev == s)// check if they are equal
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No");
            sr.Close();// close StreamReader
            Console.ReadKey();// obtains the next character or function key pressed by the user
        }
    }
}
