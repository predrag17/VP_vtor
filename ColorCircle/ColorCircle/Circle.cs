using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorCircle
{
    public class Circle
    {
        public int radius { get; set; }
        public Point Center { get; set; }
        public bool Selected { get; internal set; }

        public Circle(int radius, Point center)
        {
            this.radius = radius;
            Center = center;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Blue);
            if(Selected)
            {
                Pen p = new Pen(Brushes.Red, 5);
                g.DrawEllipse(p, Center.X - radius, Center.Y - radius, radius * 2, radius * 2);
                p.Dispose();
            }
            g.FillEllipse(b, Center.X - radius, Center.Y - radius, radius*2, radius*2);
            b.Dispose();
        }

        public bool isHit(Point location)
        {
            return Math.Sqrt(Math.Pow(Center.X - location.X, 2) + Math.Pow(Center.Y - location.Y, 2)) <= radius;
        }
    }
}
