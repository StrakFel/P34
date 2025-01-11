using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6};
            list.Add(100);//Добавляет число в конец листа
            list.Remove(1);//Считается с 1, а не как с компьютером с 0
            list.Insert(2, 300);//Порядковый номер, число которое хотим добавить, а не заменить
            
            foreach(int i in list)//Вывод листа
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("\n\t" + list.Count);//Выдает количество элементов

            list.Sort();//Сортировка
            foreach (int i in list)//Вывод листа (после сортировки)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            List<List<int>> matrix = new List<List<int>>();//Двухмерный
            matrix.Add(new List<int>() { 1, 2, 3 });
            matrix.Add(new List<int>() { 4, 5, 6 });
            matrix.Add(new List<int>() { 7, 8, 9 });

            matrix[2].Add(10);

            foreach (List<int> row in matrix)//Вывод двухмерного листа в виде таблицы
            {
                foreach (int col in row)
                    Console.Write(col + " ");
                Console.WriteLine();
            }

            list.Clear();//Очистка листа
        }
    }
}
