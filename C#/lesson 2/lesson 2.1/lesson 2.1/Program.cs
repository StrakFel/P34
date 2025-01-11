using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            //Создание массивов
            List<List<int>> array_A = new List<List<int>>();
            List<List<int>> array_B = new List<List<int>>();
            List<List<int>> array_C = new List<List<int>>();
            List<List<int>> matrix = new List<List<int>>();

            //Заполнение рандомными числами 3 массива
            for (int i = 0; i < 3; i++)
            {
                array_A.Add(new List<int>());
                array_B.Add(new List<int>());
                array_C.Add(new List<int>());
                for (int j = 0; j < 3; j++)
                {
                    array_A[i].Add(rnd.Next(0, 100));
                    array_B[i].Add(rnd.Next(0, 100));
                    array_C[i].Add(rnd.Next(0, 100));
                }
            }

            //Нахождение(с основными условиями) большего числа среди 3 массивов и переписанние его в массив matrix
            for (int i = 0; i < 3; i++)
            {
                List<int> row = new List<int>();
                for (int j = 0; j < 3; j++)
                {
                    if (array_A[i][j] > array_B[i][j] && array_A[i][j] > array_C[i][j])
                    {
                        row.Add(array_A[i][j]);
                    }
                    else if (array_B[i][j] > array_A[i][j] && array_B[i][j] > array_C[i][j])
                    {
                        row.Add(array_B[i][j]);
                    }
                    else if (array_C[i][j] > array_A[i][j] && array_C[i][j] > array_B[i][j])
                    {
                        row.Add(array_C[i][j]);
                    }
                }
                matrix.Add(row);
            }

            //Вывод массивов
            Console.WriteLine("Массив №1:");
            foreach (List<int> row in array_A)
            {
                foreach (int col in row)
                    Console.Write(col + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Массив №2:");
            foreach (List<int> row in array_B)
            {
                foreach (int col in row)
                    Console.Write(col + " ");
                Console.WriteLine();
            }
            Console.WriteLine("Массив №3:");
            foreach (List<int> row in array_C)
            {
                foreach (int col in row)
                    Console.Write(col + " ");
                Console.WriteLine();
            }
            Console.WriteLine("\nМассив №4:");
            foreach (List<int> row in matrix)
            {
                foreach (int col in row)
                    Console.Write(col + " ");
                Console.WriteLine();
            }
        }
    }
}
