using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_1._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();//Создание объекта Random

            Console.Write("Введите количество строк: ");
            int line = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int column = Convert.ToInt32(Console.ReadLine());

            int[][] array = new int[line][];//Создание jagged(зубчатый или ступенчатый) массива

            for (int i = 0; i < line; i++)// Заполнение массива случайными числами
            {
                array[i] = new int[column];//Создание массива в i ячейке

                for (int j = 0; j < column; j++)
                {
                    array[i][j] = rnd.Next(-10, 11);//Создание числа от -10 до 10 включительно
                }
            }

            Console.WriteLine($"\n1.Ваш массив в виде таблицы:\n");
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }

            int sum_array = 0;
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    sum_array += array[i][j];
                }
            }
            Console.WriteLine($"\n2.Сумма массива: {sum_array}");

            int min_number = array[0][0];
            int max_number = array[0][0];

            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (array[i][j] < min_number) { 
                    min_number = array[i][j];}
                    if (array[i][j] > max_number)
                    {
                        max_number = array[i][j];
                    }
                }
            }
            Console.WriteLine($"\n3.Максимальное число - {max_number}\n  Минимальное число - {min_number}");

            int mean_array = sum_array / (line * column);
            Console.WriteLine($"\n4.Среднее арифметическое: {mean_array}");

            Console.Write("\n5.Сумма каждого ряда массива: ");
            for (int i = 0; i < line; i++)
            {
                int sum_line = 0;
                for (int j = 0; j < column; j++)
                {
                    sum_line += array[i][j];
                }
                Console.Write(sum_line + " ");
            }
        }
    }
}
