using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_2

            {
            public class Mark//creating class Mark
            {
            public int points;// creating public int
            public Mark() { }// creating an empty constructor for serialization
            public Mark(int points)
            {
                this.points = points;//refers to the current instance of the class
        }
            public string getLetter()// function getLetter
            {
                if (points >= 95 && points <= 100)
                    return "A";
                else if (points >= 90 && points < 95)
                    return "A-";
                else if (points >= 85 && points < 90)
                    return "B+";
                else if (points >= 80 && points < 85)
                    return "B";
                else if (points >= 75 && points < 80)
                    return "B-";
                else if (points >= 70 && points < 75)// different cases of points with marks
                    return "C+";
                else if (points >= 65 && points < 70)
                    return "C";
                else if (points >= 60 && points < 65)
                    return "C-";
                else if (points >= 55 && points < 60)
                    return "D+";
                else if (points >= 50 && points < 55)
                    return "D-";
                else
                    return "F";
            }
            public override string ToString()// override string tostring
            {
                return "Mark: "+ getLetter().ToString();
            }
            }

    class Program
    {
        public static List<Mark> marks = new List<Mark>();//creating a list for serialization
        public static List<Mark> desmarks;//creating a list for deserialization

        static void Serialization(List<Mark> marks)// serialization function
        {
            FileStream fs = new FileStream("Yes.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer ser = new XmlSerializer(typeof(List<Mark>));
            ser.Serialize(fs, marks);
            fs.Close();
        }
        static void Deserialization()// deserialization function
        {
            FileStream fs = new FileStream("Yes.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer deser = new XmlSerializer(typeof(List<Mark>));
            desmarks = deser.Deserialize(fs) as List<Mark>;
            fs.Close();
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());// amount of marks
            for(int i=0;i<n;i++)
            {
                Mark mark=new Mark(int.Parse(Console.ReadLine()));
                Console.WriteLine(mark);// show points and marks
                marks.Add(mark);
            }
            foreach(Mark z in marks)
            {
                Console.WriteLine(z);//show all together
            }
            Serialization(marks);//trigger
            Deserialization();//trigger
            foreach(Mark z in desmarks)
            {
                Console.WriteLine(z);//show for deserialization
            }
            Console.ReadKey();//obtains the next character or function key pressed by the user
        }
    }
}
