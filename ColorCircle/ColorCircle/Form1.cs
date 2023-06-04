using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorCircle
{
    public partial class Form1 : Form
    {

        Scene scene;
        int radius;
        Point center;
        Point radiusMove;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;
            radius = 25;

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(center.IsEmpty)
                {
                    center = e.Location;
                } else
                {
                    scene.AddCircle(center, radius);
                    center = Point.Empty;
                    Invalidate();
                }
            }
            if(e.Button == MouseButtons.Right)
            {
                scene.findSelected(e.Location);
            }

            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                scene.deleteSelected();
                Invalidate();
            }
            if(e.KeyCode == Keys.Escape)
            {
                center = Point.Empty;
                Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            if(!center.IsEmpty)
            {
                Pen p = new Pen(Color.Black, 3);
                p.DashStyle = DashStyle.Dot;
                e.Graphics.DrawEllipse(p, center.X - radius, center.Y - radius, radius*2, radius*2);
                p.Dispose();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            radiusMove = e.Location;
            radius = (int)Math.Sqrt(Math.Pow(radiusMove.X - center.X, 2) +  Math.Pow(radiusMove.Y - center.Y, 2));
            Invalidate();
        }
    }
}
