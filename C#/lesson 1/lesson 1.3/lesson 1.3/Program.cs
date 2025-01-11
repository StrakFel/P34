using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_1._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("Введите количество строк: ");
            int line = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int column = Convert.ToInt32(Console.ReadLine());

            int[][] array = new int[line][];

            for (int i = 0; i < line; i++)
            {
                array[i] = new int[column];
                for (int j = 0; j < column; j++)
                {
                    array[i][j] = random.Next(-20, 21);
                }
            }

            Console.WriteLine("\n1.Ваш массив в виде таблицы:");
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }

            int array_positive = 0;
            int array_negative = 0;
            int array_zeros = 0;
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (array[i][j] > 0)
                    {
                        array_positive += 1;
                    }
                    else if (array[i][j] < 0)
                    {
                        array_negative += 1;
                    }
                    else if (array[i][j] == 0)
                    {
                        array_zeros += 1;
                    }
                }
            }
            Console.WriteLine($"\n2.Позитивных чисел: {array_positive}\n  Негативных чисел: {array_negative}\n  Нулей: {array_zeros}");

            Console.Write("\n3.Сумма каждого столба в массиве: ");
            for (int i = 0; i < column; i++)
            {
                int sum_column = 0;
                for (int j = 0; j < line; j++)
                {
                    sum_column += array[j][i];
                }
                Console.Write(sum_column + " ");
            }

            Console.WriteLine($"\n\n4.Конвертирует таблицу с {line} рядов и {column} столбцов на {column} рядов и {line} столбцов:");
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < line; j++)
                {
                    Console.Write(array[j][i] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n5.Реверс рядов массива:");
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]); // Реверс строк
                Console.WriteLine(string.Join(" ", array[i]));
            }
        }
    }
}
