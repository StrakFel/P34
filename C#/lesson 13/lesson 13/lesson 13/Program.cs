using System;
using System.IO; //!
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //File.Create("name.txt"); - створити файл
            //FileInfo file = new FileInfo("name.txt"); - інформація про файл
            //Directory.CreateDirectory("Folder"); - створити папку
            //DirectoryInfo directoryInfo = new DirectoryInfo("Folder"); - інформація про папку

            string fileName = "name.txt";

            using (FileStream file = File.Create(fileName))
            {
                Console.WriteLine("File status --- Create!");
                Path.GetExtension(file.Name);
                Console.WriteLine("File free");
            }

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                string text = "test";
                Console.WriteLine("File status --- Write!");
                writer.WriteLine(text);
                Console.WriteLine("File free");
            }

            using (StringReader reader = new StringReader(fileName))
            {
                Console.WriteLine("File status --- Read!");
                Console.WriteLine(reader.ReadToEnd());
                Console.WriteLine("File free");
            }

            Console.WriteLine("\nEnd program");
        }
    }
}
