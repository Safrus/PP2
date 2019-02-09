using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        public static string FolderName = "C:\\ds\\";// create a folder ds
        public static string fileName = "FileToCopy.txt";// create a new file

   
        public static void Copy(string source, string dest)
        {
            File.Copy(source, dest, true); //copying the file from one directory to another directory
            Delete(source); // create function in order to delete the file from the source directory

        }

        
        public static void Delete(string source)
        {
            File.Delete(source); //deleting the file from the source directory
        }

        static void Main(string[] args)
        {
            string path = Path.Combine(FolderName, "From");
            string path1 = Path.Combine(FolderName, "To");
            Console.WriteLine(path, path1);
            Directory.CreateDirectory(path); // creating a directory 1 called "path"
            Directory.CreateDirectory(path1); // creating a directory 2 called "path1"
            path = Path.Combine(path, fileName); // creating the way to the file in directory 1
            path1 = Path.Combine(path1, fileName); // creating the way to the file in directory 2

            FileInfo fi = new FileInfo(path); // getting a file info in order to check whether the file exists or not

            //if the file does not exist the following condition holds
            if (!fi.Exists)
            {
                // creating a file and writing a text to it
                // using StreamWriter
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("Hello World!");
                }
            }

            else
            {
                Console.WriteLine("File already exists!");

            }
              Copy(path, path1); // call the function which then will call the function Delete()

              Console.ReadKey();
        }
    }
}
