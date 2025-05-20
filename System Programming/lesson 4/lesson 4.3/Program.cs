using System;
using System.Threading;

namespace lesson_4._3
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false, "MyUniaqeuApp"))
            {
                if (!mutex.WaitOne(TimeSpan.Zero,true))
                {
                    Console.WriteLine("Програма вже завантажена!");
                }
                Console.WriteLine("Програма вже завантажена! Натисніть на кнопку Enter...");
            }
        }
    }
}