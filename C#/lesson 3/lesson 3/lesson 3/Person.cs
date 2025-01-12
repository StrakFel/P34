using System;

namespace lesson_3
{
    internal class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public void Say_Hello()
        {
            Console.WriteLine($"Hi, my name is {name}. I`m {age} years old.");
        }
    }
}
