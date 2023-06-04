using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingBalls
{
    public class Ball
    {
        public static readonly int RADIUS = 25;
        public static Random RANDOM = new Random();
        public Point Center { get; set; }
        public int state { get; set; }

        public Ball(Point center)
        {
            Center = center;
            state = RANDOM.Next(3);
        }

        public void Draw(Graphics g)
        {
            Color color;
            if (state == 0)
            {
                color = Color.Red;
            }
            else if (state == 1)
            {
                color = Color.Blue;
            } else
            {
                color = Color.Green;
            }

            Brush b = new SolidBrush(color);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }

        public void Move(int x, int y)
        {
            Center = new Point(Center.X + x, Center.Y + y);
        }

        public bool isHit(Point point)
        {
            double distance = Math.Sqrt(Math.Pow(Center.X - point.X, 2) + Math.Pow(Center.Y - point.Y, 2)); 
            if(distance < RADIUS)
            {
                ++state;
                return true;
            }

            return false;
        }


    }
}
