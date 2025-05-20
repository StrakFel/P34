using System;
using System.Threading;
using System.Threading.Tasks;

namespace lesson_5._1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Parallel.For(1, 6, i =>
            {
                Console.WriteLine($"Потік {Thread.CurrentThread.ManagedThreadId} обробляє інтерацію {i}");
                Thread.Sleep(1000);
            });
        }
    }
}