using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsChaos
{
    public partial class Form1 : Form
    {
        Scene Scene;
        int left;
        int top;
        int width;
        int height;
        public Form1()
        {
            InitializeComponent();
            Scene = new Scene();
            this.DoubleBuffered = true;
            timer1.Interval = 20;
            timer1.Start();
            left = 20;
            top = 60;
            width = this.Width - (3 * left);
            height = this.Height - (int)(2.5 * top);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            width = this.Width - (3 * left);
            height = this.Height - (int)(2.5 * top);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 3);
            e.Graphics.DrawRectangle(pen, left, top, width, height);
            pen.Dispose();
            Scene.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Scene.MoveBalls(left, top, width, height);
            Scene.isTouching();
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Scene.AddBall(e.Location);
            Invalidate();
        }
    }
}
