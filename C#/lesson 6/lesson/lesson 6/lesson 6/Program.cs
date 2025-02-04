using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6
{
    internal class Program
    {
        public class Complex
        {
            public double Real { get; }
            public double Imaginary { get; }
            public Complex(double real, double imaginary)
            {
                this.Real = real;
                this.Imaginary = imaginary;
            }
            public static Complex operator +(Complex a, Complex b)
            {
                return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
            }
            public override string ToString()
            {
                return $"{Real} + {Imaginary}";
            }
        }
        static void Main(string[] args)
        {
            int a = 20;
            int b = 30;
            Console.WriteLine(a + b);
        }
    }
}
