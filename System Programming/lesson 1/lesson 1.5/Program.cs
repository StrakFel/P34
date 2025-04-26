using System;
using System.Runtime.InteropServices;

namespace lesson_1._5
{
    internal class Program
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern void ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParametrs, string lpDirectory, int nShowCmd);

        static void Main(string[] args)
        {
            ShellExecute(IntPtr.Zero, "open", "steam.exe", null, "C:\\Program Files (x86)\\Steam", 1);

            Console.ReadLine();
        }
    }
}