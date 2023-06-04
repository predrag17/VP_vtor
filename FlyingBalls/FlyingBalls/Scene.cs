using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyingBalls
{
    public class Scene
    {
        public static Random RANDOM = new Random();
        public List<Ball> balls;
        public int height;
        public int width;

        public Scene(int height, int width)
        {
            balls = new List<Ball>();
            this.height = height;
            this.width = width;
        }

        public void AddBall() {
            balls.Add(new Ball(new Point(-Ball.RADIUS, RANDOM.Next(2 * Ball.RADIUS, height - 2 * Ball.RADIUS))));
        }

        public void Draw(Graphics g)
        {
            foreach (Ball b in balls)
            {
                b.Draw(g);
            }
        }

        public void Hit(Point location)
        {
            foreach (Ball b in balls)
            {
                b.isHit(location);
            }

            for (int i =  0; i < balls.Count; i++)
            {
                if (balls[i].state == 3)
                {
                    balls.RemoveAt(i);
                }
            }
        }

        public void Move()
        {
           foreach (Ball b in balls)
            {
                b.Move(5, 0);
            }

           foreach (Ball b in balls)
            {
                if (b.Center.X - Ball.RADIUS > width)
                {
                    b.state = -1;
                }
            }

           for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].state == -1)
                {
                    balls.RemoveAt(i);
                }
            }
        }
    }
}
