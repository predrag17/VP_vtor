using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallsInHoles
{
    public partial class Form1 : Form
    {
        Scene scene;
        int left;
        int top;
        int width;
        int height;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            this.DoubleBuffered = true;
            timer1.Interval = 30;
            timer1.Start();
            left = 20;
            top = 60;
            width = this.Width - (3 * left);
            height = this.Height - (int)(2.5 * top);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 3);
            e.Graphics.DrawRectangle(pen, left, top, width, height);
            scene.Draw(e.Graphics);
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            width = this.Width - (3 * left);
            height = this.Height - (int)(2.5 * top);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.MoveBalls(left, top, width, height);
            scene.CheckCollision();
            Invalidate(true);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scene.GenerateHoles(left, top, width, height);
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Ball b = new Ball(e.Location);
            scene.AddBall(b);
        }
    }
}
