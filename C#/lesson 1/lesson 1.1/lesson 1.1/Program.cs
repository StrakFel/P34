using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Напишите размер массива: ");
            int array_size = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[array_size];

            Console.WriteLine("\nНапишите целые числа, которые будут находиться в массиве:");
            for (int i = 0; i < array_size; i++) 
            {
                Console.Write($"Введите {i+1} элемент: ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            Console.Write("Введите число: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n1.Ваш массив:");
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            
            //int minValue = array.Min();
            //int maxValue = array.Max();

            int min_number = array[0];
            int max_number = array[0];

            for (int i = 0; i < array_size; i++)
            {
                if (array[i] < min_number){
                    min_number = array[i];
                }
                if (array[i] > max_number){
                    max_number = array[i];
                }
            }
            Console.WriteLine($"\n\n2.Минимальное число - {min_number}\n  Максимальное число - {max_number}\n");

            int sum_array = 0;
            for (int i = 0; i < array_size; i++)
            {
                sum_array += array[i];
            }
            Console.WriteLine($"\n3.Сумма всех элементов массива: {sum_array}");

            int mean_array = sum_array / array_size;
            Console.WriteLine($"\n4.Среднее арифметическое массива: {mean_array}");

            int comparison_array_x = 0;
            for (int i = 0; i < array_size; i++)
            {
                if (array[i] > x){
                    comparison_array_x += 1;
                }
            }
            Console.WriteLine($"\nКоличество чисел больше за ваше число {x}: {comparison_array_x}");
        }
    }
}
