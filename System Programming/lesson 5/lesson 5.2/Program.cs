using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace lesson_5._2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<int> numbers = new List <int> {1, 2, 3, 4, 5};

            Parallel.ForEach(numbers, number =>
            {
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId} обробляє число {number}");
                Thread.Sleep(1000);
            });
        }
    }
}