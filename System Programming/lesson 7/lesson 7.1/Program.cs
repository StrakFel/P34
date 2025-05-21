using System;
using MathLibrary;

namespace lesson_7._1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.Add(2, 4));
            Console.WriteLine(calculator.Multiply(2, 4));
        }
    }
}