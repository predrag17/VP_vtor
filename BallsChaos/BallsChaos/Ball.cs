using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsChaos
{
    public class Ball
    {
        private static readonly int RADIUS = 25;
        public Point Center { get; set; }
        public bool Flag { get; set; }
        public double Velocity { get; set; }
        public double Angle { get; set; }
        private float velocityX;
        private float velocityY;

        public Ball(Point center)
        {
            Center = center;
            Flag = false;
            Velocity = 10;
            Random r = new Random();
            Angle = r.NextDouble() * 2 * Math.PI;
            velocityX = (float)(Math.Cos(Angle) * Velocity);
            velocityY = (float)(Math.Sin(Angle) * Velocity);
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Red);
            g.FillEllipse(b, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * 2, RADIUS * 2);
            b.Dispose();
        }

        public bool isTouching(Ball ball)
        {
            double distance = Math.Pow(Center.X -  ball.Center.X, 2) + Math.Pow(Center.Y - ball.Center.Y, 2);
            return distance <= Math.Pow(2 * RADIUS, 2);
        }

        public void Move(int left, int top, int width, int height)
        {
            float nextX = Center.X + velocityX;
            float nextY = Center.Y + velocityY;
            if (nextX - RADIUS <= left || nextX + RADIUS >= width + left)
            {
                velocityX = -velocityX;
            }
            if (nextY - RADIUS <= top || nextY + RADIUS >= height + top)
            {
                velocityY = -velocityY;
            }
            Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));
        }
    }
}
