using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lesson_3._1
{
    internal class Program
    {
        static void PrintNumbers()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Потік:{i}");
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(PrintNumbers);
            thread.Start();

            thread.Join();
            Console.WriteLine("Головний потік працює...");
        }
    }
}