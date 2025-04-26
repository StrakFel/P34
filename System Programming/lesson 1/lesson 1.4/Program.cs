using System;
using System.Runtime.InteropServices;

namespace lesson_1._4
{
    internal class Program
    {
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern void ShellExecute(IntPtr hwnd, string lpOperion, string lpFile, string lpParametrs, string lpDirectory, int nShowCmd);

        static void Main(string[] args)
        {
            ShellExecute(IntPtr.Zero, "open", "chrome.exe", null, null, 1);
            ShellExecute(IntPtr.Zero, "open", "notepad.exe", null, null, 1);

            Console.ReadLine();
        }
    }
}