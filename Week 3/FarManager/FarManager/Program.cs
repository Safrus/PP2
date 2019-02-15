using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class FarManager
    {
        public int cursor;
        public string path;
        public int sz;
        DirectoryInfo directory = null;
        FileSystemInfo currentfs = null;

        public FarManager()
        {
            cursor = 0;
        }

        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
            directory = new DirectoryInfo(path);
            sz = directory.GetFileSystemInfos().Length;


        }
        public void Show()
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            for(int i=0,k=0;i<sz;i++)
            {
                Color(fs[i],k);
                Console.WriteLine(i+1+"." + "  " + fs[i].Name);
                k++;
            }
        }
        public void NewDir()
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            sz = fs.Length;
        }
        public void Down()
        {
            cursor++;
            if (cursor == sz)
                cursor = 0;
        }
        public void Up()
        {
            cursor--;
            if (cursor < 0)
                cursor = sz - 1;
        }
        public void Color(FileSystemInfo fs, int index)
        {
                if (cursor == index)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    currentfs = fs;
                }
                else if (fs.GetType() == typeof(DirectoryInfo))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
            }
            public void Start()
            {
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            
            while(consoleKey.Key!=ConsoleKey.Escape)
            {
                NewDir();
                Show();
                consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.UpArrow)
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)
                    Down();
                if(consoleKey.Key==ConsoleKey.Enter)
                {
                    if(currentfs.GetType()==typeof(DirectoryInfo))
                    {
                        cursor = 0;
                        path = currentfs.FullName;
                    }
                }
                if(consoleKey.Key==ConsoleKey.Backspace)
                {
                    cursor = 0;
                    path = directory.Parent.FullName;
                }
            }
            }

        }
      
        class Program
        {
            static void Main(string[] args)
            {
                string path = @"\Users\Lenovo.DESKTOP-CFOPLGE\Documents\PP1";
                FarManager farManager = new FarManager(path);
                farManager.Start();
                Console.ReadKey();
            }
        }
    }

