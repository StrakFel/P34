using System;
using System.Threading;

namespace lesson_4._1
{
    internal class Program
    {
        static int counter = 0;
        static object lockObject = new object();

        static void Increment()
        {
            for (int i = 0; i < 1000; i++)
                lock(lockObject) // lock Гарантує що тільки 1 потік буде змінювати counter
                    counter++;
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Increment);
            Thread thread2 = new Thread(Increment);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine($"Фінальне значення: {counter}");
        }
    }
}