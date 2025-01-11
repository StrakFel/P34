using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_1._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Console.Write("1.Введите количество строк: ");
            int line = Convert.ToInt32(Console.ReadLine());

            Console.Write("  Введите количество столбцов: ");
            int column = Convert.ToInt32(Console.ReadLine());

            //Создание массивов
            int[][] array_1 = new int[line][];
            int[][] array_2 = new int[line][];
            int[][] array_3 = new int[line][];
            int[][] array_4 = new int[line][];

            //Заполнение массивов
            for (int i = 0; i < line; i++)
            {
                array_1[i] = new int[column];
                for (int j = 0; j < column; j++)
                {
                    array_1[i][j] = random.Next(-10, 11);
                }
            }
            for (int i = 0; i < line; i++)
            {
                array_2[i] = new int[column];
                for (int j = 0; j < column; j++)
                {
                    array_2[i][j] = random.Next(-20, 21);
                }
            }
            for (int i = 0; i < line; i++)
            {
                array_3[i] = new int[column];
                for (int j = 0; j < column; j++)
                {
                    array_3[i][j] = array_1[i][j] + array_2[i][j];
                }
            }
            for (int i = 0; i < line; i++)
            {
                array_4[i] = new int[column];
                for (int j = 0; j < column; j++)
                {
                    array_4[i][j] = array_1[i][j] * array_2[i][j];
                }
            }

            //Вывод массивов
            Console.WriteLine("\n2.Первый массив в виде таблицы:");
            for (int i = 0; i < line; i++)
            {
                
                for (int j = 0; j < column; j++)
                {
                    Console.Write(array_1[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("3.Второй массив в виде таблицы:");
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(array_2[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("4.Третий массив в виде таблицы:");
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(array_3[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("5.Четвертый массив в виде таблицы:");
            for (int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Console.Write(array_4[i][j] + " ");
                }
                Console.WriteLine();
            }
            int common_count = 0;
            for (int i = 0; i < array_1.Length; i++)
            {
                for (int j = 0; j < array_2.Length; j++)
                {
                    if (array_1[i][j] == array_2[i][j])
                    {
                        common_count++;
                    }
                }
            }
            Console.WriteLine($"6.Количество одинаковых элементов: {common_count}");
            Console.WriteLine("7.Третий массив проверка на четное число в виде таблицы:");
            for(int i = 0; i < line; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (array_3[i][j] % 2 == 0)
                    {
                        Console.Write("Да" + " ");
                    }
                    else if (array_3[i][j] % 2 != 0)
                    {
                        Console.Write("Нет" + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        
    }
}
