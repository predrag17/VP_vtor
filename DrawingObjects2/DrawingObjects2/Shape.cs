using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingObjects2
{
    public abstract class Shape
    {
        public Point Point { get; set; }
        public Color Color { get; set; }
        public bool Selected { get; set; } = false;

        protected Shape(Point point, Color color)
        {
            Point = point;
            Color = color;
        }

        public abstract void Draw(Graphics g);
        public abstract void Pulse();

        public abstract bool isHit(Point location);

        public abstract void Move(Point location);
       
    }
}
