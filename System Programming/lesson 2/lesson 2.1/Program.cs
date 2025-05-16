using System;
using System.Diagnostics;

namespace lesson_2._1
{
    /*
             * Життєвий цикл процесу:
             * Створення
             * Очікування
             * Виконання
             * Призупинення
             * Завершення 
     */
    internal class Program
    {
        static void Main()
        {
            Process process = Process.Start("notepad.exe");
            Console.WriteLine($"Процес створенно! {process.Id}");

            process.WaitForExit();
            Console.WriteLine("Процес завершено!");
        }
    }
}