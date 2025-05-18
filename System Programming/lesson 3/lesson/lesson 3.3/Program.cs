using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lesson_3._3
{
    internal class Program
    {
        static bool paused = false;
        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                while (paused)
                {
                    Thread.Sleep(100);
                }
                Console.WriteLine($"Потік:{i}");
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Thread thread = new Thread(PrintNumbers);
            thread.Start();

            Console.WriteLine("Натисніть Enter щоб призупинити потік...");
            Console.ReadLine();
            paused = true;

            Console.WriteLine("Натисніть Enter щоб запустити потік...");
            Console.ReadLine();
            paused = false;
        }
    }
}