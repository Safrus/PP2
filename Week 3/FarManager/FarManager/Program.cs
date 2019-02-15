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
        public int cursor;// creating public int
        public string path;// creating public string
        public int sz;// creating public int sz
        DirectoryInfo directory = null;// creating default DirectoryInfo which has no value
        FileSystemInfo currentfs = null;// creating default FileSystemInfo which has noo value
        
        public FarManager(string path)
        {
            this.path = path;// refers to the current instance of the class 
            cursor = 0;// set cursor to 0
            directory = new DirectoryInfo(path);// DirectoryInfo with path
            sz = directory.GetFileSystemInfos().Length;//set sz to Length of files and directories of directory
        }
        public void Show()// this function helps us to show all the files and directories with enumeration
        {
            Console.BackgroundColor = ConsoleColor.DarkCyan;// set Background color to DarkCyan
            Console.Clear();// clear the console
            DirectoryInfo directory = new DirectoryInfo(path);// creating DirectoryInfo with path which is in main function
            FileSystemInfo[] fs = directory.GetFileSystemInfos();// get all files and directories from directory
            for(int i=0,k=0;i<sz;i++)// here k is for indicating index in Color function
            {
                Color(fs[i],k);// trigger the Color function
                Console.WriteLine(i+1+"." + "  " + fs[i].Name);
                k++;// add 1 to k
            }
        }
        public void NewDir()// this function helps us to measure the Length of directory which we have opened or exit
        {
            directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            sz = fs.Length;
        }
        public void Down()// this function helps us to move cursor down
        {
            cursor++;
            if (cursor == sz)// if cursor is on the last file or directory it goes 
                cursor = 0;// to the cursor=0
        }
        public void Up()// this ffunction helps us to move cursor up
        {
            cursor--;
            if (cursor < 0)// if cursor is lower than 0 
                cursor = sz - 1;// it goes to the last position
        }
        public void Color(FileSystemInfo fs, int index)// this function helps us to set color of background and foreground
            //for console,files,index,directories
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                currentfs = fs;// now currentfs take the FileSystemInfo of cursor
            }
            else if (fs.GetType() == typeof(DirectoryInfo))// for directories
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else// for files
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
        }
        

        public void Start()// the basic function
            {
            ConsoleKeyInfo consoleKey = Console.ReadKey();//describes the console key that was pressed

            while (consoleKey.Key!=ConsoleKey.Escape)// while we didn't push the button Escape
            {
                NewDir();// trigger the function NewDir()
                Show();// trigger the function Show()
                consoleKey = Console.ReadKey();//set console key for Console.Readkey()(we push it)
                if (consoleKey.Key == ConsoleKey.UpArrow)// if we pushed UpArrow
                    Up();// we trigger the Up()
                if (consoleKey.Key == ConsoleKey.DownArrow)//if we pushed Down
                    Down();// we trigger the Down()
                if(consoleKey.Key==ConsoleKey.Enter)// if we pushed Enter
                {
                    if(currentfs.GetType()==typeof(DirectoryInfo))// if it is a Directory
                    {
                        cursor = 0;// set cursor to 0
                        path = currentfs.FullName;// and taking a new path
                    }
                }
                if(consoleKey.Key==ConsoleKey.Backspace)// if we pushed Backspace
                {
                    cursor = 0;// set cursor to 0
                    path = directory.Parent.FullName;//goes to last path
                }
                if(consoleKey.Key==ConsoleKey.Delete)// if we pushed Delete
                {
                    if (currentfs.GetType() == typeof(DirectoryInfo))// if it is a Directory
                    {
                        path = currentfs.FullName;// path takes current path
                        Directory.Delete(path,true);// and Delete the Directory
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine("Deleting the directory...");
                        Console.ReadKey();//obtains the next character or function key pressed by the user
                        path = directory.FullName;// set to previous path
                    }
                    else//if it is a File
                    {
                        path = currentfs.FullName;// path takes current path
                        File.Delete(path);// and Delete the File
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Clear();
                        Console.WriteLine("Deleting the file...");
                        Console.ReadKey();//obtains the next character or function key pressed by the user
                        path = directory.FullName;// set to previous path
                    }
                }
                if(consoleKey.Key==ConsoleKey.PageDown)// if we pushed PageDown
                {
                    path = currentfs.FullName;// path takes current path
                    StreamReader sr = new StreamReader(path);//creating a StreamReader with path
                    String s = sr.ReadToEnd();// it reads to the end
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine(s);// shows the text
                    Console.ReadKey();//obtains the next character or function key pressed by the user
                    path = directory.FullName;// set to previous path

                    /*path = currentfs.FullName;
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    using (FileStream fs = File.Open(path, FileMode.Open))
                    {
                        byte[] b = new byte[1024];                          // second method
                        UTF8Encoding temp = new UTF8Encoding(true);

                        while (fs.Read(b, 0, b.Length) > 0)
                        {
                            Console.WriteLine(temp.GetString(b));
                        }
                    }
                    Console.ReadKey();
                    path = directory.FullName;*/
                }
                if(consoleKey.Key==ConsoleKey.PageUp)// if we pushed PageUp
                {
                    path = currentfs.FullName;// path takes current path
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Console.WriteLine("Enter a new name for your directory or file:");
                    string newname = Console.ReadLine();// creating a string for entering a new name of our directory or file
                    if (currentfs.GetType() == typeof(DirectoryInfo))// if it is a Directory 
                    {
                        Directory.Move(path, Path.GetDirectoryName(currentfs.FullName) + "/" + newname);// rename it
                    }
                    else// if it is a file 
                    {
                        File.Move(path, Path.GetDirectoryName(currentfs.FullName) + "/" + newname);// rename it
                    }
                    path = directory.FullName;// set to the previous path
                }
            }
        }
    }      
        class Program
        {
            static void Main(string[] args)
            {
                string path = @"\Users\Lenovo.DESKTOP-CFOPLGE\Documents\PP1";// taking a path
                FarManager farManager = new FarManager(path);// send this path to FarManager class with object farManager
                farManager.Start();// trigger the function Start() with the object 
                Console.ReadKey();//obtains the next character or function key pressed by the user
        }
        }
}
