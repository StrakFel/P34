using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int? number = null;
            if (number.HasValue) //Проверка является ли number = null
                Console.WriteLine($"Value: {number.HasValue}");
            else
                Console.WriteLine($"NO, value");

            int? number2 = null;
            int res = number2 ?? 10; // if(number2 == null) res = 10
        }
    }
}
