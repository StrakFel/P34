using System;
using System.Runtime.InteropServices;

namespace lesson_1._3
{
    internal class Program
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string dllToload);

        [DllImport("kernel32.dll")]
        public static extern bool FreeLibrary(IntPtr hModule);

        static void Main(string[] args)
        {
            IntPtr handle = LoadLibrary("user32.dll");

            if (handle != IntPtr.Zero) //Если библиотека успешно загружена
            {
                Console.WriteLine("OK!");
                FreeLibrary(handle);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}