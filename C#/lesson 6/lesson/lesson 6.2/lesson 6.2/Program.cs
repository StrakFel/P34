using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6._2
{
    class Temperature
    {
        private double Celsius;
        public double Fahrenheit
        {
            get => Celsius * 9 / 5 + 32;
            set => Celsius = (value - 32) * 5 / 9;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Temperature temp = new Temperature();

            temp.Fahrenheit = 60.5;
            Console.WriteLine(temp.Fahrenheit);
        }
    }
}
