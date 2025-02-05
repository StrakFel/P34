using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_7._2
{
    //Базовий
    public abstract class Animal
    {
        public abstract string Name { get; set; }
        public abstract void Speak();
    }
    //Похідний
    public class Dog : Animal
    {
        public override string Name { get; set; } = "";

        public override void Speak()
        {
            Console.WriteLine("Собака видає звук");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
