using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Целые числа
            int a1 = 20;
            long a2 = -20;
            byte a3 = 100;
            //Дробные числа
            double a4 = 2.2;
            float a5 = -100.100f;
            decimal a6 = 123.456m;
            //Другие типы
            bool a7 = true;
            char a8 = 'a';
            string a9 = "Hello";

            object a10 = null;

            Console.WriteLine("The first lesson on C#");//Метод для вывода (как print или cout)
            Console.Beep();//Метод, который издает звук

            int number  = Convert.ToInt32(Console.ReadLine());//Преобразует ReadLine(то есть string) в int
            Console.WriteLine(number * number);
            Console.ReadLine();//Метод, который считывает введенный пользователем текст

            int[] numbers;//Инициализация массива
            numbers = new int[10] {9, 8, 7, 6, 5, 4, 3, 2, 1, 0};//Заполнение массива

            //Циклы с одномерным массивом
            for (int i = 0; i < numbers.Length; i++)//Перебирает индексы массива с 0 до его длины(numbers.Length)
            {
                Console.WriteLine(i);
            }
            foreach (int n in numbers)//Перебирает значение элементов массива 
            {
                Console.WriteLine(n);
            }

            int[][] numbers_2 = new int[10][];//Двумерный и ступенчатый массивы

            //Двухмерный массив
            int[,] numbers_3 =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
            };
        }
    }
}
