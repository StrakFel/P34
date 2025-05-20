using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace lesson_5._3
{
    internal class Program
    {
        static void Task1() { Thread.Sleep(1000); Console.WriteLine("Завадння 1 виконано"); }
        static void Task2() { Thread.Sleep(1000); Console.WriteLine("Завадння 2 виконано"); }
        static void Task3() { Thread.Sleep(1000); Console.WriteLine("Завадння 3 виконано"); }

        static void Main(string[] args)
        {
            Parallel.Invoke(Task1, Task2, Task3);
        }
    }
}