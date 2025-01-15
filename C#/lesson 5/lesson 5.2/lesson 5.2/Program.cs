using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_5._2
{
    enum Days
    {
        Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }
    enum Colors
    {
        Red = 1, // только int
        Green = 2, 
        Blue = 3,
        BlueGreen = 10, 
        BlueYellow = 12
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Days today = Days.Sunday;
            Colors userThemes = Colors.Red;

            Console.WriteLine(today);
            Console.WriteLine(userThemes);
        }
    }
}
