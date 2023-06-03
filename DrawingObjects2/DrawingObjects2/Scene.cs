using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingObjects2
{
    public class Scene
    {
        public List<Shape> shapes { get; set; }
        public enum ShapeType{
            CIRCLE,
            TRIANGLE
        }


        public Scene()
        {
            shapes = new List<Shape>();
        }

        public void AddShape(Point p, ShapeType type)
        {
            Shape shape = null;
            if(type.Equals(ShapeType.CIRCLE))
            {
                shape = new Circle(p, Color.Red);
            } else
            {
                shape = new Triangle(p, Color.Red, new Point(p.X + 50, p.Y), new Point(p.X, p.Y + 40));
            }

            shapes.Add(shape);
        }

        public void Draw(Graphics g)
        {
            foreach (Shape shape in shapes)
            {
                shape.Draw(g);
            }
        }

        public void Pulse()
        {
            foreach(Shape shape in shapes)
            {
                shape.Pulse();
            }
        }

        public void findShape(Point location)
        {
            foreach(Shape shape in shapes)
            {
                if(shape.isHit(location))
                {
                    shape.Selected = true;
                }
            }
        }

        public void Move(Point location)
        {
            foreach (Shape shape in shapes)
            {
                if(shape.Selected)
                {
                    shape.Move(location);
                }
            }
        }

        internal void Unselect(Point location)
        {
            foreach(Shape shape in shapes)
            {
                if(shape.Selected)
                {
                    shape.Selected = false;
                }
            }
        }
    }
}
