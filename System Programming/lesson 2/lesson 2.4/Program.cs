using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace lesson_2._4
{
    internal class Program
    {
        static void Main()
        {
            bool sort = false;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Моніторинг завантаженинх процесів");
            Console.WriteLine("Для завершення натисніть Ctrl + C...");
            while (true)
            {
                Process[] processes = Process.GetProcesses();
                Console.Clear();
                foreach (Process p in processes)
                {
                    Console.WriteLine($"{p.ProcessName}");
                    for (int i = 0; i + p.ProcessName.Length < 70; i++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine($"{p.Id}");
                }


                Thread.Sleep(2000);
            }
        }
    }
}