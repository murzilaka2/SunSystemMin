using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace SunSystemMin
{
    public partial class Form1 : Form
    {

        private readonly int px, py, dst;
        public Form1()
        {
            InitializeComponent();
            px = Width / 2;
            py = Height / 2;
            dst = 100;
        }

        //Velocity - скорость движения
        float mercuryAngle = 0, mercuryVelocity = 1, venusAngle = 0, venusVelocity = 0.5f, earthAngle = 0, earthVelocity = 0.25f, 
            marsAngle = 0, marsVelocity = 0.25f;

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            StringFormat str = new StringFormat();

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TranslateTransform(px, py, MatrixOrder.Append);

            //Draw Mercury`s orbit
            g.DrawEllipse(Pens.White, -dst / 2 + 6, -dst / 2 + 6, 100, 100);

            //Draw Venus`s orbit
            g.DrawEllipse(Pens.White, -dst + 6, -dst + 6, 200, 200);

            //Draw Earth`s orbit
            g.DrawEllipse(Pens.White, -2 * dst + 6, -2 * dst + 6, 400, 400);

            //Draw Mars orbit
            g.DrawEllipse(Pens.White, -2 * dst - 43, -3 * dst + 60, 500, 500);

            g.ResetTransform();

            //Draw Sun
            g.FillEllipse(Brushes.Yellow, px - 12, py - 6, 40, 40);
            g.DrawString("Sun", Font, new SolidBrush(Color.Yellow), px - dst + 95, py - dst + 75, str);

            //Draw Mercury
            int mercuryX = (int)(px + dst / 2 * Math.Sin(mercuryAngle * Math.PI / 182.5f));
            int mercuryY = (int)(py + dst / 2 * Math.Cos(mercuryAngle * Math.PI / 182.5f));
            g.FillEllipse(Brushes.Gray, mercuryX, mercuryY, 15, 15);
            mercuryAngle -= mercuryVelocity;

            //Draw Venus
            int venusX = (int)(px + dst * Math.Sin(venusAngle * Math.PI / 182.5f));
            int venusY = (int)(py + dst * Math.Cos(venusAngle * Math.PI / 182.5f));
            g.FillEllipse(Brushes.OrangeRed, venusX - 5, venusY - 5, 20, 20);
            venusAngle -= venusVelocity;

            //Draw Earth
            int earthX = (int)(px + 2 * dst * Math.Sin(earthAngle * Math.PI / 182.5f));
            int earthY = (int)(py + 2 * dst * Math.Cos(earthAngle * Math.PI / 182.5f));
            g.FillEllipse(Brushes.Aqua, earthX - 5, earthY - 5, 20, 20);            
            earthAngle -= earthVelocity;

            //Draw Moon`s orbit
            g.DrawEllipse(Pens.White, earthX - 25, earthY - 25, 60, 60);

            //Draw Moon
            int moonX = (int)(earthX + 30 * Math.Sin(earthAngle * Math.PI / 30f));
            int moonY = (int)(earthY + 30 * Math.Cos(earthAngle * Math.PI / 30f));
            g.FillEllipse(Brushes.LightGray, moonX, moonY, 10, 10);

            //Draw Mars
            int marsX = (int)(px + 2.5 * dst * Math.Sin(marsAngle * Math.PI / 182.5f));
            int marsY = (int)(py + 2.5 * dst * Math.Cos(marsAngle * Math.PI / 182.5f));
            g.FillEllipse(Brushes.Brown, marsX, marsY, 20, 20);
            marsAngle -= marsVelocity;
        }
    }
}
