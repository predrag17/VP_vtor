using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsInHoles
{
    public class Scene
    {
        public List<Ball> balls { get; set; }
        public List<Hole> holes { get; set; }
        Font font;
        Random random;
        public Scene() { 
            balls = new List<Ball>();
            holes = new List<Hole>();
            font = new Font("Arial", 20);
            random = new Random();
        }

        public void AddBall(Ball b)
        {
            balls.Add(b);
        }

        public void GenerateHoles(int left, int top, int width, int height)
        {
            holes = new List<Hole>();
            GenerateHolesR(left, top, width, height);
        }

        public void GenerateHolesR(int left, int top, int width, int height)
        {
            if (holes.Count == 5)
            {
                return;
            }

            int x = random.Next(left + Hole.RADIUS, (left + width) - Hole.RADIUS);
            int y = random.Next(top + Hole.RADIUS, (top + height) - Hole.RADIUS);
            bool touches = false;
            foreach (Hole h in holes)
            {
                touches = h.Touches(x, y);
                if (touches) break;
            }

            if(!touches)
            {
                Hole h = new Hole(new Point(x, y));
                holes.Add(h);
            }

            GenerateHolesR(left, top, width, height);
        }

        public void Draw(Graphics g)
        {
            foreach (Ball b in balls)
            {
                b.Draw(g);
            }

            foreach (Hole h in holes)
            {
                h.Draw(g, font);
            }
        }

        public void MoveBalls(int left, int top, int width, int height)
        {
            foreach(Ball b in balls)
            {
                b.Move(left, top, width, height);
            }
        }

        public void CheckCollision()
        {
            for(int i = 0; i < balls.Count; i++)
            {
                for(int j = 0; j < holes.Count; j++)
                {
                    if (balls[i].inHole(holes[j]))
                    {
                        balls[i].isInHole = true;
                        holes[j].Count++;
                    }
                }
            }

            for(int i =  balls.Count - 1; i >= 0; i--)
            {
                if (balls[i].isInHole)
                {
                    balls.RemoveAt(i);
                }
            }
        }
    }
}
