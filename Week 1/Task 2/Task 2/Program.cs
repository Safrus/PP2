using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student
    {
       
        public string name;// create public variable
        public string id;
        public int year;
        public Student(string name,string id)
        {
            this.name = name;//create constructor of class Student
            this.id = id;
        }
        public string getname()// by this function we can get a name
        {
            return name;
        }
        public string getid()// by this function we can get an id
        {
            return id;

        }
        public int getyear()
        {
            year++;// year will increase as it is 4 year of study for bachelor degree
            return year;
        }
        public string getinfo()// get the total and finished information about student
        {
            return ("Name: " + getname() + "\nId:" + getid() + "\nYear:" + getyear());
        }
        class Program
        {
            static void Main(string[] args)
            {
                string name = Console.ReadLine();// create string name and enter it
                string id = Console.ReadLine();// create string id and enter it
                Student st = new Student(name, id);/*creating an object addressing to class Student 
                                                    and its Constructor with parameters name and id (excluding year) */
                for(int i=0;i<4;i++)
                {
                    Console.WriteLine();
                    Console.WriteLine(st.getinfo());// info about student
                    Console.WriteLine();
                }
                Console.ReadKey();//obtains the next character or function key pressed by the user
            }
        }
    }
}
