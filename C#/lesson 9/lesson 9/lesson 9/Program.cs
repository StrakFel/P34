using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_9
{
    internal class Program
    {
        delegate void ProcessItemDelegate(int item);
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
            void ProcessList(List<int> list, ProcessItemDelegate process)
            {
                foreach (int item in list)
                {
                    process(item);
                }
            }

            ProcessItemDelegate printItem = item => Console.WriteLine($"Елемент: {item}");
            ProcessItemDelegate squareItem = item => Console.WriteLine($"Елемент: {item * item}");

            Console.WriteLine("Вивід елементів:");
            ProcessList(numbers, printItem);

            Console.WriteLine("Квадрати чисел:");
            ProcessList(numbers, squareItem);
        }
    }
}
