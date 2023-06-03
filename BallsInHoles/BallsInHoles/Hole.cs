using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles
{
    public class Hole
    {
        public static readonly int RADIUS = 25;
        public Point Center { get; set; }
        public int Count;

        public Hole(Point center)
        {
            Center = center;
            Count = 0;
        }

        public void Draw(Graphics g, Font font)
        {
            Brush b = new SolidBrush(Color.Black);
            Brush fontBrush = new SolidBrush(Color.White);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS  * 2);
            g.DrawString(String.Format("{0}", Count), font, fontBrush, Center.X - 10, Center.Y - 10);
            b.Dispose();
        }

        public bool Touches(int x, int y)
        {
            return Math.Pow(x - Center.X, 2) + Math.Pow(y - Center.Y, 2) <= RADIUS * RADIUS;
        }
    }
}
