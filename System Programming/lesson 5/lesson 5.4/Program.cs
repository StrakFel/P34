using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace lesson_5._4
{
    internal class Program
    {
        static async Task DoWorkAsync()
        {
            Console.WriteLine("Початок роботи...");
            await Task.Delay(1000);
            Console.WriteLine("Робота завершена.");
        }
        static async Task Main(string[] args)
        {
            await DoWorkAsync();
            Console.WriteLine("Основний потік не заблокований!");
        }
    }
}