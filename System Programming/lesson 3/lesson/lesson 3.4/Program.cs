using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lesson_3._4
{
    internal class Program
    {
        static void CountEvenNumbers()
        {
            for(int i = 2; i <= 10; i += 2)
            {
                Console.WriteLine($"[Парний потік] Число: {i}");
                Thread.Sleep(1000);
            }
        }
        static void CountOddNumbers()
        {
            for (int i = 1; i <= 10; i += 2)
            {
                Console.WriteLine($"[Непарний потік] Число: {i}");
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread evenThread = new Thread(CountEvenNumbers);
            Thread oddThread = new Thread(CountOddNumbers);

            evenThread.Start();
            oddThread.Start();

            evenThread.Join();
            oddThread.Join();

            Console.WriteLine("Усі потоки завершено!");
        }
    }
}