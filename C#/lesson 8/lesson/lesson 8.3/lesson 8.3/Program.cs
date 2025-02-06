using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_8._3
{
    public interface IShape
    {
        double CalculateArea();
    }
    public interface IDrawable
    {
        void Draw();
    }

    public class Circle : IShape, IDrawable
    {
        public double Radius { get; set; }
        public Circle(double radius) { Radius = radius; }
        public double CalculateArea() { return Math.PI * (Radius * Radius); }
        public void Draw() { Console.WriteLine($"Малюємо коло з радіусом {Radius}"); }
    }
    public class Rectangle : IShape, IDrawable
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double CalculateArea() { return Width * Height; }
        public void Draw() { Console.WriteLine($"Малюємо прямокутник розміром {Width}x{Height}"); }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IShape circleShape = new Circle(5);
            IDrawable circleDrawable = (Circle)circleShape;

            IShape rectangleShape = new Rectangle(4, 6);
            IDrawable rectangleDrawable = (Rectangle)rectangleShape;

            Console.WriteLine($"Площа кола: {circleShape.CalculateArea():F2}");
            circleDrawable.Draw();

            Console.WriteLine($"Площа прямокутника: {rectangleShape.CalculateArea():F2}");
            rectangleDrawable.Draw();
        }
    }
}
