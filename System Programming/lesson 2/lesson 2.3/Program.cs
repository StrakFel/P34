using System;
using System.Diagnostics;
using System.Text;

namespace lesson_2._3
{
    internal class Program
    {
        static void Main()
        {
            foreach (var process in Process.GetProcesses())
            {
                Console.WriteLine(process.Id + " " + process.ProcessName);
            }
        }
    }
}