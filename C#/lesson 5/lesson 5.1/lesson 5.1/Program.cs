using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5._1
{
    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Display()
        {
            Console.WriteLine($"Point:(X {X}, Y {Y})");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(10, 20);
            p.Display();
        }
    }
}
