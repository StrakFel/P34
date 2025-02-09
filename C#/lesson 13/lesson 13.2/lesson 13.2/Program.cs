using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_13._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("C:\\Windows");
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}
