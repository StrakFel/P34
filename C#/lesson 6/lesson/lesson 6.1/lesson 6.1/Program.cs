using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6._1
{
    public class StringCollection
    {
        public const int Count = 10;
        private string[] words = new string[Count];
        public string this[int index]
        {
            get => words[index];
            set => words[index] = value;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StringCollection collection = new StringCollection();

            collection[0] = Console.ReadLine();
            Console.WriteLine(collection[0]);
        }
    }
}
