using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    enum Tools{
        Pen,
        Rectangle,
        Circle,
        Triangle,
        Line,
        Fill,
        Eraser,
        Pick
    }
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics g;
        bool clicked = false;
        Point prev, cur;
        Tools tools = Tools.Pen;
        int penwidth = 1;
        Color color;
        Queue<Point>q;
        Color c1;
        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            q = new Queue<Point>();
        }

        private void fill(int x, int y)
        {
            if (x >= bmp.Width)return;          
            if (x < 0) return;
            if (y >= bmp.Height) return;
            if (y < 0) return;
            if (bmp.GetPixel(x, y) != c1) return;
            bmp.SetPixel(x, y, color);
            q.Enqueue(new Point(x, y));
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int x = Math.Min(prev.X, cur.X);
            int y = Math.Min(prev.Y, cur.Y);
            int width = Math.Abs(prev.X - cur.X);
            int height = Math.Abs(prev.Y - cur.Y);

            if (tools == Tools.Rectangle)
            {
                e.Graphics.DrawRectangle(new Pen(color, penwidth), x, y, width, height);
            }
            if(tools == Tools.Circle)
            {
                e.Graphics.DrawEllipse(new Pen(color, penwidth), x, y, width, height);
            }
            if (tools == Tools.Line)
            {
                e.Graphics.DrawLine(new Pen(color, penwidth), prev, cur);
            }
            if (tools == Tools.Triangle)
            {
                Point[] polygon = { new Point(width / 2 + x, y), new Point(x, Math.Max(prev.Y, cur.Y)), new Point(Math.Max(prev.X, cur.X), Math.Max(prev.Y, cur.Y)), };
                g.DrawPolygon(new Pen(color, penwidth), polygon);
                
            }
            
            }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            prev = e.Location;
            if (e.Button== MouseButtons.Left)
            {
                color = pictureBox2.BackColor;
            }
            else
            {
                color = pictureBox3.BackColor;
            }
            if(tools == Tools.Fill)
            {
                q.Enqueue(e.Location);
                c1 = bmp.GetPixel(e.X,e.Y);
                while (q.Count > 0)
                {
                    int x = q.First().X;
                    int y = q.First().Y;
                    fill(x, y + 1);
                    fill(x, y - 1);
                    fill(x - 1, y);
                    fill(x + 1, y);
                    q.Dequeue();
                }
            }
            if (tools == Tools.Pick) {
                if (e.Button == MouseButtons.Left)
                {
                    pictureBox2.BackColor = bmp.GetPixel(e.X, e.Y);
                }
                else
                {
                    pictureBox3.BackColor = bmp.GetPixel(e.X, e.Y);
                }
            }
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            cur = e.Location;
            
            if (clicked)
            {
                if (tools == Tools.Pen)
                {   
                    g.DrawLine(new Pen(color, penwidth), prev, cur);
                    prev = cur;
                }
                if(tools == Tools.Eraser)
                {
                    g.DrawLine(new Pen(Color.White, penwidth), prev, cur);
                    prev = cur;
                }
                pictureBox1.Refresh();
                

            }

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            int x = Math.Min(prev.X, e.X);
            int y = Math.Min(prev.Y, e.Y);
            int width = Math.Abs(prev.X - e.X);
            int height = Math.Abs(prev.Y - e.Y);

            if (tools == Tools.Rectangle)
            {
                g.DrawRectangle(new Pen(color, penwidth), x, y, width, height);

            }
            else if (tools == Tools.Circle)
            {
                g.DrawEllipse(new Pen(color, penwidth), x, y, width, height);
            }
            else if (tools == Tools.Line)
            {
                g.DrawLine(new Pen(color, penwidth), prev, e.Location);
            }
            else if (tools == Tools.Triangle)
            {             
                Point[] polygon = { new Point(width / 2 + x, y), new Point(x, Math.Max(prev.Y, cur.Y)), new Point(Math.Max(prev.X, cur.X), Math.Max(prev.Y, cur.Y)), };
                g.DrawPolygon(new Pen(color, penwidth), polygon);
                
            }
            
            pictureBox1.Refresh();
            clicked = false;

        }

        private void tools_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "Pen")
            {
                tools = Tools.Pen;
            }
            if (button.Text == "Rectangle")
            {
                tools = Tools.Rectangle;
            }
            if (button.Text == "Circle")
            {
                tools = Tools.Circle;
            }
            if (button.Text == "Line")
            {
                tools = Tools.Line;
            }
            if(button.Text == "Fill")
            {
                tools = Tools.Fill;
            }
            if(button.Text == "Eraser")
            {
                tools = Tools.Eraser;
            }
            if(button.Text == "Pick")
            {
                tools = Tools.Pick;
            }if(button.Text == "Tri")
            {
                tools = Tools.Triangle;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            penwidth = trackBar1.Value;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackColor = colorDialog1.Color;
            }
        }

        private void Save_click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog()== DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog1.FileName);
            }
        }

        private void open_click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.OpenFile();
                bmp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmp;
                g = Graphics.FromImage(bmp);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox3.BackColor = colorDialog1.Color;
            }
        }


    }
}
