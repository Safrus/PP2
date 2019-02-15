using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void PrintSpaces(int level)// creating function PrintSpaces to add distributive empty place
            {
                for (int i = 0; i < level; i++)
                    Console.Write("     ");// show distributive empty place
            }

        static void FileDire(DirectoryInfo dir, int level)// creating FileDire function to know get all directories and files
        {
            foreach (FileInfo f in dir.GetFiles())// each file from directory dir
            {
                PrintSpaces(level);// add PrintSpace
                Console.WriteLine(f.Name);// show file's name
            }
            foreach (DirectoryInfo d in dir.GetDirectories())// each directory from directory dir
            {
                PrintSpaces(level);// add PrintSpace
                Console.WriteLine("   " + d.Name);// show empty place + name of directory
                FileDire(d, level + 1);// trigger a fucntion FireDire with level+1
            }
            
        }
        static void Main(string[] args)
        {           
                DirectoryInfo dir = new DirectoryInfo(@"E:\Test");// creating DirectoryInfo dir to know information about it
                Console.WriteLine(dir.Name);// show directory's name "Test"
                FileDire(dir, 0);// trigger the function
                Console.ReadKey();//// obtains the next character or function key pressed by the user
        }
    }
}
