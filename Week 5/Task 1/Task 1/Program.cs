using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_1
{
    public class Complex//creating class Complex
    {
        public int real;// creating public int
        public int imaginary;// creating public int

        public Complex() { }// creating empty constructor to serialize

        public Complex(int real,int imaginary)
        {
            this.real = real;//refers to the current instance of the class
            this.imaginary = imaginary;
        }       
    }
    class Program
    {
        public static Complex n;
        public static string countreal;
        public static string countimage;// creating some strings and integers
        public static int realpart=0;
        public static int imagepart=0;

        public static void GetRealandImage(string comnumber)// method to find real and imaginary
        {
            int i = 0;
            while(comnumber[i]!='+')
            {
                countreal += comnumber[i];
                i++;
            }
            realpart = int.Parse(countreal);
            while(comnumber[i]!='i')
            {
                countimage += comnumber[i];
                i++;
            }
            imagepart = int.Parse(countimage);
        }
        static void Serialization(Complex number)// serialization method
        {
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer ser = new XmlSerializer(typeof(Complex));
            ser.Serialize(fs, number);
            fs.Close();
        }
        static void Deserialization()// deserilization method
        {
            FileStream fs = new FileStream("Data.xml", FileMode.OpenOrCreate,FileAccess.ReadWrite);
            XmlSerializer des = new XmlSerializer(typeof(Complex));
            n = des.Deserialize(fs) as Complex;
            fs.Close();
        }
        static void Main(string[] args)
        {
            string com_number = Console.ReadLine();// enter string of a complex number
            GetRealandImage(com_number);//trigger a function
            Complex number = new Complex(realpart, imagepart);// creating new object
            Serialization(number);// trigger a function
            Deserialization();// trigger a function
            Console.WriteLine(n.real + "+" + n.imaginary+'i');
            Console.ReadKey();
        }             
    }
} 