using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_10
{
    internal class Program
    {
        /*
        public class NonGenericClass
        {
            
            private object[] items = new object[10];
            private int count;
            public void Add(object item)
            {
                items[count++] = item;
            }
            public object Get(int index)
            {
                return items[index];
            }
            
        }
        */
        public class GenericsClass<T>
        {
            private T[] items = new T[10];
            private int count;
            public void Add(T item)
            {
                items[count++] = item;
            }
            public T Get(int index)
            {
                return items[index];
            }
         }
        static void Main(string[] args)
        {
            GenericsClass<int> genereticsClass = new GenericsClass<int>();
            genereticsClass.Add(1);
        }
    }
}
