using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lessom_8._2
{
    public interface IAnimal
    {
        void Speak();
        void Move();
    }

    public class Dog : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Собака гавкає");
        }
        public void Move()
        {
            Console.WriteLine("Собака біжить");
        }
    }
    public class Bird : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Пташка співає");
        }
        public void Move()
        {
            Console.WriteLine("Пташка летить");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            IAnimal dog = new Dog();
            IAnimal bird = new Bird();

            dog.Speak();
            dog.Move();

            bird.Speak();
            bird.Move();
        }
    }
}

