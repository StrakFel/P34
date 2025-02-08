using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_11._1
{
    internal class Program
    {
        class Pair<T1, T2>
        {
            public T1 Item1 { get; set; }
            public T2 Item2 { get; set; }
            public Pair()
            {

            }
            public Pair(T1 item1, T2 item2)
            {
                Item1 = item1;
                Item2 = item2;
            }

            public void Display()
            {
                Console.WriteLine(
                    $"{this.Item1}\n" +
                    $"{this.Item2}"
                    );
            }
        }
        static void Main(string[] args)
        {
            Pair<int, string> n = new Pair<int, string>(123,"abc");
            n.Display();
        }
    }
}
