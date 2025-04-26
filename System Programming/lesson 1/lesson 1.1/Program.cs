using System;
using System.Runtime.InteropServices;

namespace lesson_1._1
{
    internal class Program
    {
        [DllImport("user32.dll", EntryPoint = "Beep")] //EntryPoint - точка вхождение в программу
        public static extern bool SystemBeep(uint a, uint b);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr hWnd, string text, string capture, uint type);  //int - потому что функция должна что то возвращать

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Sleep(uint dwMilliseconds);

        static void Main(string[] args)
        {
            MessageBox(IntPtr.Zero, "Привіт", "text", 0);
            Sleep(1000);
        }
    }
}