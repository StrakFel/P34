using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_9._1
{
    internal class Program
    {
        delegate int Operation(int x, int y);
        static void Main(string[] args)
        {
            int Add(int a, int b) => a + b;
            int Multiplus(int a, int b) => a * b;

            Operation operation;

            operation = Add;
            Console.WriteLine($"Сума {operation(5,3)}");
            operation = Multiplus;
            Console.WriteLine($"Добуток {operation(5, 3)}");
        }
    }
}
