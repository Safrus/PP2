using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cartimer
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        Rectangle r = new Rectangle(new Point(100, 100), new Size(100, 40));
        Rectangle r1 = new Rectangle(new Point(120, 80), new Size(60, 20));
        Rectangle r2 = new Rectangle(new Point(125, 85), new Size(50, 15));
        Rectangle w1 = new Rectangle(new Point(110, 130), new Size(20, 20));
        Rectangle w2 = new Rectangle(new Point(170, 130), new Size(20, 20));
        Rectangle w3 = new Rectangle(new Point(114, 133), new Size(13, 13));
        Rectangle w4 = new Rectangle(new Point(174, 133), new Size(13, 13));
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            r = new Rectangle(new Point(r.X+1, r.Y), new Size(r.Width, r.Height));
            r1 = new Rectangle(new Point(r1.X + 1, r1.Y), new Size(r1.Width, r1.Height));
            r2 = new Rectangle(new Point(r2.X + 1, r2.Y), new Size(r2.Width, r2.Height));
            w1 = new Rectangle(new Point(w1.X+1, w1.Y), new Size(w1.Width, w1.Height));
            w2 = new Rectangle(new Point(w2.X+1, w2.Y), new Size(w2.Width, w2.Height));
            w3 = new Rectangle(new Point(w3.X+1, w3.Y), new Size(w3.Width, w3.Height));
            w4 = new Rectangle(new Point(w4.X+1, w4.Y), new Size(w4.Width, w4.Height));
            pictureBox1.Refresh();
        }

        private void pictureBox_paint(object sender, PaintEventArgs e)
        {
            g.Clear(Color.White);
            g.FillRectangle(new SolidBrush(Color.Orange),r);
            g.FillRectangle(new SolidBrush(Color.Orange), r1);
            g.FillRectangle(new SolidBrush(Color.LightBlue), r2);
            g.FillEllipse(new SolidBrush(Color.Black), w1);
            g.FillEllipse(new SolidBrush(Color.Black), w2);
            g.FillEllipse(new SolidBrush(Color.White), w3);
            g.FillEllipse(new SolidBrush(Color.White), w4);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
