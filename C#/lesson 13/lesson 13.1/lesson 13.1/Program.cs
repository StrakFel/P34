using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_13._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string fileName = "content.txt";
            try
            {
                string content = File.ReadAllText(fileName);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Помилка файл не знайдено. {ex.Message}");
                Console.WriteLine("Створити файл?\n0-ні\n1-так");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == 1) File.Create(fileName);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Помилка доступу: {ex.Message}");
            }
        }
    }
}
