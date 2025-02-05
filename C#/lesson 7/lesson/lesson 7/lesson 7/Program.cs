using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_7
{
    //Базовий
    public class Animal
    {
        public string Name { get; set; }
        public void Eat()
        {
            Console.WriteLine($"{Name} їсть");
        }
    }
    //Похідний
    public class Dog : Animal
    {
        public void Bark()
        {
            Console.WriteLine($"{Name} гавкає");
        }
    }
    public class Cat : Animal
    {
        public void Mew()
        {
            Console.WriteLine($"{Name} мявчить");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog d = new Dog();
            d.Name = "Макс";
            d.Eat();
            d.Bark();
            Cat c = new Cat();
            c.Name = "Тіма";
            c.Eat();
            c.Mew();
        }
    }
}
