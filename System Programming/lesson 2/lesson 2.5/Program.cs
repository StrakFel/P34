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
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Моніторинг завантаженинх процесів");
            Console.WriteLine("Для завершення натисніть Ctrl + C...");
            while (true)
            {
                Process[] processes = Process.GetProcesses();
                Console.Clear();
                foreach (Process p in processes.OrderBy(p => p.Id))
                {
                    Console.WriteLine($"{p.ProcessName,-40} {p.Id,-10}");
                }
                Thread.Sleep(5000);
            }
        }
    }
}