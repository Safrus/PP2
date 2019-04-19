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
    public partial class Form1 : Form
    {
        public int a;
        public string s;
        public string z;
        public string total;
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '5';
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '7';
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '8';
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '1';
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '9';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '2';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '3';
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '4';
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '6';
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";
            }
            textBox1.Text += '0';
        }

        private void button17_Click(object sender, EventArgs e)
        {
            s = textBox1.Text;
            textBox1.Text = "0";
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            z = textBox1.Text;
            textBox1.Clear();
            textBox1.Text = (float.Parse(s) + float.Parse(z)).ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            string s;
            s = textBox1.Text;
            char a = s[s.Length - 1];
            textBox1.Text = s.Remove(s.Length - 1, 1);
            if (textBox1.Text == "")
                textBox1.Text = "0";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        private void button11_Click(object sender, EventArgs e)
        { 
            if(textBox1.Text!="")
            textBox1.Text += ",";
        }
    }
}