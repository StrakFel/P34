using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_12._1
{
    internal class Program
    {
        public class LargeObject : IDisposable
        {
            private byte[] data;
            private bool dispose = false;
            public LargeObject(int size)
            {
                data = new byte[size];
                Console.WriteLine($"LargeObject створено. Покоління: {GC.GetGeneration(this)}");
            }
            public void Dispose()
            {
                if (!dispose)
                {
                    this.data = null;
                    Console.WriteLine("LargeObject звільнено вручну\n");
                    this.dispose = true;
                    GC.SuppressFinalize(this);
                }
            }
            ~LargeObject()
            {
                this.Dispose();
                Console.WriteLine("Фіналізатор LargeObject виконано");
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("===Демонстрація роботи===");
            Console.WriteLine("Кількість зьирать до старту приграми: ");

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Покоління {i}: {GC.CollectionCount(i)}");
            }

            for (int i = 0; i < 5; i++)
            {
                using (var obj = new LargeObject(10_000_000)); //10Mb
                {
                    Console.WriteLine($"Об'єкт {i+1} створено.");
                }
            }

            Console.WriteLine("Примусове збирання сміття...");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine("Кількість збирань після використання:");
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine($"Покоління {i} : {GC.CollectionCount(i)}");
            }

            Console.WriteLine("Програма завершена!");
        }
    }
}
