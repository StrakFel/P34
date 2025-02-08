using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_11._3
{
    internal class Program
    {
        public static T FindMax<T>(List<T> values) where T : IComparable<T>
        {
            if (values == null || values.Count == 0) throw new ArgumentException("List is empty");
            T max = values[0];
            foreach (T item in values)
            {
                if (item.CompareTo(max) > 0) max = item;
            }
            return max;
        }
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 5, 3 };
            int max = FindMax(numbers);
            Console.WriteLine(max);
        }
    }
}
