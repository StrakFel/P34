using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lesson_6._4;

namespace lesson_6._4
{
    class MultyVector
    {
        public int X;
        public int Y;

        public MultyVector(int x, int y){
            this.X = x;
            this.Y = y;
        }
        public static MultyVector operator +(MultyVector a, MultyVector b)
        {
            return new MultyVector(a.X + b.X, a.Y + b.Y);
        }
        public static MultyVector operator -(MultyVector a, MultyVector b)
        {
            return new MultyVector(a.X - b.X, a.Y - b.Y);
        }
        public static MultyVector operator *(MultyVector a, int scalar)
        {
            return new MultyVector(a.X * scalar, a.Y * scalar);
        }
        public static bool operator ==(MultyVector a, MultyVector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        public static bool operator !=(MultyVector a, MultyVector b)
        {
            return !(a == b);
        }
        public override string ToString()
        {
            return ($"{X}, {Y}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MultyVector v1 = new MultyVector(3, 4);
            MultyVector v2 = new MultyVector(1, 2);
            MultyVector sum = v1 + v2;
            MultyVector scaled = v1 * 2;

            Console.WriteLine($"Сложение: {sum}");
            Console.WriteLine($"Умножение на 2: {scaled}");
            Console.WriteLine($"Равны ли v1 и v2? {v1 == v2}");
        }
    }
}