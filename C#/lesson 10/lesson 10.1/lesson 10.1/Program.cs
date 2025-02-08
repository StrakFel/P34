using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static lesson_10._1.Program;

namespace lesson_10._1
{
    internal class Program
    {
        public class MyGenericsClass<T>
        {
            public T Value { get; set; }
            public void Display()
            {
                Console.WriteLine($"Item: {Value}");
            }
        }
        public class MyGenericsMethods
        {
            public void Display<T>(T Item)
            {
                Console.WriteLine($"Item: {Item}");
            }
        }
        static void Main(string[] args)
        {
            //MyGenericsClass
            MyGenericsClass<int> myInt = new MyGenericsClass<int> { Value = 123 };
            myInt.Display();
            MyGenericsClass<string> myString = new MyGenericsClass<string> { Value = "abc" };
            myString.Display();

            //MyGenericsMethods
            MyGenericsMethods methods = new MyGenericsMethods();
            methods.Display(321);
            methods.Display("test");
        }
    }
}
