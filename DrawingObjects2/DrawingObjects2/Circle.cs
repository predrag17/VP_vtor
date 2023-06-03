using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingObjects2
{
    public class Circle : Shape
    {
        public static readonly int RADIUS = 25;
        public int radius;
        public int qoef = 1;

        public Circle(Point point, Color color) : base(point, color)
        {
            radius = RADIUS;
        }

        public override void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Point.X - radius, Point.Y - radius, radius * 2, radius * 2);
            b.Dispose();
        }

        public override bool isHit(Point p)
        {
            return Math.Sqrt(Math.Pow(p.X - Point.X, 2) + Math.Pow(p.Y - Point.Y, 2)) <= radius;    
        }

        public override void Move(Point location)
        {
            Point = location;
        }

        public override void Pulse()
        {
            radius += (qoef * 2);
            if(radius > 60 || radius < 10)
            {
                qoef *= -1;
            }
        }
    }
}
