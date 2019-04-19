using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    enum Operations
    {
        sum,
        subtract,
        multiply,
        division,
        sin,
        cos,
        tan,
        ctg,
        pi
    }
    public partial class Form1 : Form
    {
        static Operations op = Operations.sum;
        static double temporary = 0; // то что ушло но еще в памяти 
        static bool opera = false;// если нажимают не на равно а снова на операцию то показывает результат 
        static bool text = true; //тектс исчезает при нажатии на операцию
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            if(text == false)
            {
                textBox1.Text = "";
            }
            Button btn = sender as Button; 
            if(textBox1.Text == "0")
            {
                textBox1.Text = btn.Text;
            }
            else
            {
                textBox1.Text = textBox1.Text + btn.Text;
            }
            text = true;
        }

        private void Operations_Click(object sender, EventArgs e)
        {
            if (opera == true && text == true)
            {
               
                    if (op == Operations.sum)
                    {
                        temporary += double.Parse(textBox1.Text);
                        textBox1.Text = temporary.ToString();
                    }
                    if (op == Operations.subtract)
                    {
                        temporary -= double.Parse(textBox1.Text);
                        textBox1.Text = temporary.ToString();
                    }
                    if (op == Operations.multiply)
                    {
                        temporary *= double.Parse(textBox1.Text);
                        textBox1.Text = temporary.ToString();
                    }
                    if (op == Operations.division)
                    {
                        temporary /= double.Parse(textBox1.Text);
                        textBox1.Text = temporary.ToString();
                    
                    }
                    if(op == Operations.sin)
                    {
                        temporary = Math.Sin(double.Parse(textBox1.Text));
                        textBox1.Text = temporary.ToString();
                    }
                    if (op == Operations.cos)
                    {
                        temporary = Math.Cos(double.Parse(textBox1.Text));
                        textBox1.Text = temporary.ToString();
                    }
                    if (op == Operations.tan)
                    {
                        temporary = Math.Tan(double.Parse(textBox1.Text));
                        textBox1.Text = temporary.ToString();
                    }
                    if(op == Operations.ctg)
                    {
                        temporary = 1/Math.Tan(double.Parse(textBox1.Text));
                        textBox1.Text = temporary.ToString();
                    }
                    if(op == Operations.pi)
                {
                    temporary = Math.PI;
                    textBox1.Text = temporary.ToString();
                }
            }
            Button btn = sender as Button;
            temporary = double.Parse(textBox1.Text);
            if(btn.Text == "+")
            {
                op = Operations.sum;
            }
            if (btn.Text == "-")
            {
                op = Operations.subtract;
            }
            if (btn.Text == "*")
            {
                op = Operations.multiply;
            }
            if (btn.Text == "/")
            {
                op = Operations.division;
            }
            if(btn.Text == "sin")
            {
                op = Operations.sin;
            }
            if(btn.Text == "cos")
            {
                op = Operations.cos;
            }
            if(btn.Text == "tan")
            {
                op = Operations.tan;
            }
            if(btn.Text == "ctg")
            {
                op = Operations.ctg;
            }
            if(btn.Text == "П")
            {
                op = Operations.pi;
            }
            opera = true;
            text = false;
        }

        private void Result(object sender, EventArgs e)
        {
            if(op == Operations.sum)
            {
                textBox1.Text = (temporary + int.Parse(textBox1.Text)).ToString();
            }
            if (op == Operations.subtract)
            {
                textBox1.Text = (temporary - int.Parse(textBox1.Text)).ToString();
            }
            if (op == Operations.multiply)
            {
                textBox1.Text = (temporary * int.Parse(textBox1.Text)).ToString();
            }
            if (op == Operations.division)
            {
                textBox1.Text = (temporary / int.Parse(textBox1.Text)).ToString();
            }
            if (op == Operations.sin)
            {
                temporary = Math.Sin(double.Parse(textBox1.Text));
                textBox1.Text = temporary.ToString();
            }
            if (op == Operations.cos)
            {
                temporary = Math.Cos(double.Parse(textBox1.Text));
                textBox1.Text = temporary.ToString();
            }
            if (op == Operations.tan)
            {
                temporary = Math.Tan(double.Parse(textBox1.Text));
                textBox1.Text = temporary.ToString();
            }
            if (op == Operations.ctg)
            {
                temporary = 1/ Math.Tan(double.Parse(textBox1.Text));
                textBox1.Text = temporary.ToString();
            }
            if(op == Operations.pi)
            {
                temporary = Math.PI;
                textBox1.Text = temporary.ToString();
                textBox1.Text = temporary.ToString();
                textBox1.Text = temporary.ToString();
            }
        }

        private void sqrt(object sender, EventArgs e)
        {
            textBox1.Text = Math.Sqrt(double.Parse(textBox1.Text)).ToString();
        }

        private void sqr(object sender, EventArgs e)
        {
            textBox1.Text = Math.Pow(double.Parse(textBox1.Text),2).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            temporary = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string s = "";
            if(textBox1.Text.Length <= 1)
            {
                textBox1.Text = "0";
            }
            else
            {
                for(int i = 0; i<textBox1.Text.Length-1; i++)
                {
                    s += textBox1.Text[i];
                }
                textBox1.Text = s;
            }
        }

        private void Dot(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }


        private void log_click(object sender, EventArgs e)
        {
           textBox1.Text = Math.Log(temporary, double.Parse(textBox1.Text)).ToString();                                
        }

        private void lg_click(object sender, EventArgs e)
        {
            textBox1.Text = Math.Log10(double.Parse(textBox1.Text)).ToString();
        }

        private void ln_click(object sender, EventArgs e)
        {
            textBox1.Text = Math.Log(double.Parse(textBox1.Text)).ToString();
        }

        private void procent(object sender, EventArgs e)
        {
            textBox1.Text = ((temporary / double.Parse(textBox1.Text) * 100)).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void prime_click(object sender, EventArgs e)
        {
            double d = double.Parse(textBox1.Text);

            if (d == 1)
            {
                textBox1.Text = "No";
                return;
            }
            for(double i = 2; i < d; i++)
            {
                if (d % i == 0)
                {
                    textBox1.Text = "No";
                    return;
                }
            }
            textBox1.Text = "Yes";
            return;
        }

        private void Polina_Click(object sender, EventArgs e)
        {
            int n = textBox1.Text.Length;
            for(int i = 0; i < n; i++)
            {
                if(textBox1.Text[i] != textBox1.Text[n - i - 1])
                {
                    textBox1.Text = "No";
                    return;
                }
            }
            textBox1.Text = "Yes";
            return;
        }

        private void button33_Click(object sender, EventArgs e)
        {
           double n =double.Parse(textBox1.Text);
            double fac = 1;
           for(double i = 2; i <= n; i++)
            {
                fac *= i;
            }
            textBox1.Text = fac.ToString();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            string binary = Convert.ToString(int.Parse(textBox1.Text), 2);
            textBox1.Text = binary.ToString();

        }
    }
}
