using System;
using System.Threading;

namespace lesson_8._1
{
    internal class Program
    {
        static void DoWork(string text)
        {
            Console.WriteLine("Some one text: " + text);
            Thread.Sleep(1000);
        }
        static void Main(string[] args)
        {
            Thread one = new Thread(() => DoWork("Високий пріоритет"));
            Thread two = new Thread(() => DoWork("Низький пріоритет"));

            one.Priority = ThreadPriority.Highest;
            two.Priority = ThreadPriority.Lowest;

            one.Start();
            two.Start();

            one.Join();
            two.Join();

            Console.WriteLine("End");
        }
    }
}