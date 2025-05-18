using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lesson_3._2
{
    internal class Program
    {
        static bool running = true;
        static void PrintNumbers()
        {
            while (running)
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"Потік:{i}");
                    Thread.Sleep(1000);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread thread = new Thread(PrintNumbers);
            thread.Start();

            Console.ReadLine();
            running = false;
        }
    }
}