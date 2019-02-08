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
        static void Main(string[] args)
        {
            /*
           System.IO.Directory.CreateDirectory(pathString);
            Console.ReadKey();*/
            /* ;
             string FileName = "Kukushkax.pptx";
             ;@""
             pathString = System.IO.Path.Combine(pathString,FileName);
             System.IO.File.Create(pathString);
             Console.WriteLine("Path to my file: {0}\n", pathString);*/
            string folderName = @"E:\Xiaomi\Kuku";
            string fileName = "NoName.txt";
            string pathString = System.IO.Path.Combine(folderName);
            pathString = System.IO.Path.Combine(pathString, fileName);
            System.IO.File.Create(pathString);
            string sourcePath = @"‪E:\Xiaomi\Kuku";
            string targetPath = @"‪E:\Xiaomi\Kuku\Da";
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if(!System.IO.Directory.Exists(targetPath))
            {
                System.IO.Directory.CreateDirectory(targetPath);
            }
            System.IO.File.Copy(sourceFile, destFile, true);

        }
    }
}
