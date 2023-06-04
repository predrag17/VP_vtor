using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingBalls
{
    public partial class Form1 : Form
    {

        Scene scene;
        public int timerTicks;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene(this.Height, this.Width);
            DoubleBuffered = true;
            timer1.Interval = 20;
            timer1.Start();
            timerTicks = 0;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            scene.Hit(e.Location);
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerTicks++;
            if(timerTicks % 10 == 0)
            {
                scene.AddBall();
            }
            scene.Move();
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            scene.height = this.Height;
            scene.width = this.Width;
        }
    }
}
