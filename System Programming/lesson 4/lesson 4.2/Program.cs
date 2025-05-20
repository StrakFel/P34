using System;
using System.Threading;

namespace lesson_4._2
{
    internal class Program
    {
        static object lockObject = new object();

        static void PrintMessage(string message)
        {
            Monitor.Enter(lockObject);
            try
            {
                Console.WriteLine($"[Потік {Thread.CurrentThread.ManagedThreadId}] {message}");
                Thread.Sleep(1000);
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => PrintMessage("Привіт!"));
            Thread thread2 = new Thread(() => PrintMessage("Як ти?"));

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }
    }
}