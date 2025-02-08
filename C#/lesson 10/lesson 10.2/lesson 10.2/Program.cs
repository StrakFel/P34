using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10._2
{
    internal class Program
    {
        public class MyGenericsClass<T> where T : class
        {
            public T Value { get; set; }
        }

        public class MyOtherGenericsClass<T> where T : new()
        {
            public T CreateInstanse()
            {
                return new T();
            }
        }
        static void Main(string[] args)
        {
        }
    }
}
