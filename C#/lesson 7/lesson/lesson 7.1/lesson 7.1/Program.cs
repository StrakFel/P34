using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_7._1
{
    //Базовий
    public class Animal
    {
        public Animal() { }
        public virtual void Speak()
        {
            Console.WriteLine("Тварина видає звук");
        }
    }
    //Похідний
    public class Dog : Animal
    {
        public Dog() { }
        public override void Speak()
        {
            Console.WriteLine("Собака видає звук");
        }
    }
    public class Cat : Animal
    {
        public Cat() { }
        public override void Speak()
        {
            Console.WriteLine("Кіт видає звук");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Cat();
            a.Speak();
        }
    }
}
