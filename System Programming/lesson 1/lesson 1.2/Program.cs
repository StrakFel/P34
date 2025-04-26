using System;
using System.Runtime.InteropServices;

namespace lesson_1._2
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowText(IntPtr a, string lpString);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        static void Main(string[] args)
        {
            Console.Write("Enter programm`s name: ");
            string newProgramName = Console.ReadLine();
            IntPtr hWnd = GetForegroundWindow();
            SetWindowText(hWnd, newProgramName);
            Console.ReadLine();
        }
    }
}