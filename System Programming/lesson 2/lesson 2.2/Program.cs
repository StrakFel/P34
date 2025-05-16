using System;
using System.Diagnostics;
using System.Text;

namespace lesson_2._2
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            ProcessStartInfo startInfo = new ProcessStartInfo("notepad.exe");
            Process child = Process.Start(startInfo);

            Console.WriteLine($"Дочірній процес запущено, PID: {child.Id}");
        }
    }
}