using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_2._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            List<List<string>> data = new List<List<string>>();

            data.Add(new List<string>() { "Максим", "7", "10", "4", "12", "11" });
            data.Add(new List<string>() { "Олег", "12", "10", "9", "9", "11" });
            data.Add(new List<string>() { "Захар", "5", "6", "3", "6", "9" });

            while (true)
            {
                Console.WriteLine("\nМеню");
                Console.WriteLine("1.Добавление студента");
                Console.WriteLine("2.Обновление оценок");
                Console.WriteLine("3.Вывод таблицы");
                Console.WriteLine("4.Найти студента с самым высшим средним балом");
                Console.WriteLine("Нажмите 0 для выхода");
                Console.Write("\nВыберете действие: ");
                int user = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                if (user == 1)
                {
                    Console.Write("Введите имя нового студента: ");
                    string newStudentName = Console.ReadLine();

                    // Запрашиваем оценки студента
                    Console.WriteLine("Введите оценки студента (разделенные пробелами): ");
                    string[] grades = Console.ReadLine().Split(' ');

                    // Добавляем нового студента в список данных
                    List<string> newStudent = new List<string> { newStudentName };
                    newStudent.AddRange(grades);  // Добавляем оценки

                    data.Add(newStudent);  // Добавляем студента в общий список данных

                    Console.WriteLine($"Студент {newStudentName} успешно добавлен!");
                }
                else if (user == 2)
                {
                    Console.Write("Введите имя студента, чьи оценки хотите обновить: ");
                    string student_name = Console.ReadLine();

                    List<string> student = null;

                    // Ищем студента с введенным именем с помощью цикла
                    for (int i = 0; i < data.Count; i++)
                    {
                        if (data[i][0] == student_name)
                        {
                            student = data[i];
                            break;
                        }
                    }

                    if (student != null)
                    {
                        Console.WriteLine($"Оценки студента {student_name}: {string.Join(", ", student.GetRange(1, student.Count - 1))}");
                        Console.WriteLine("Введите новые оценки (разделенные пробелами):");
                        string[] newGrades = Console.ReadLine().Split(' ');

                        // Обновляем оценки студента (не обновляем имя)
                        for (int i = 0; i < newGrades.Length; i++)
                        {
                            student[i + 1] = newGrades[i]; // Обновляем оценки, начиная с 1-го индекса
                        }

                        Console.WriteLine($"Оценки студента {student_name} обновлены!");
                    }
                    else
                    {
                        Console.WriteLine("Студент с таким именем не найден.");
                    }
                }
                else if (user == 3)
                {
                    foreach (List<string> row in data)
                    {
                        foreach (string col in row)
                            Console.Write(col + " ");
                        Console.WriteLine();
                    }
                }
                else if (user == 4)
                {
                    string top_student = "";
                    double max_average = 0;

                    foreach (List<string> row in data)
                    {
                        string student_name = row[0];
                        double sum = 0;
                        int num_grades = row.Count - 1; //Количество оценок (исключая имя)

                        // Суммируем оценки студента
                        for (int i = 1; i < row.Count; i++)
                        {
                            sum += Convert.ToDouble(row[i]);
                        }

                        double average = sum / num_grades; // Вычисляем средний балл

                        // Сравниваем и обновляем максимальный балл
                        if (average > max_average)
                        {
                            max_average = average;
                            top_student = student_name;
                        }
                    }
                    Console.WriteLine($"Студент с самым высоким средним баллом: {top_student} ({max_average})");
                }
                else if (user == 0)
                {
                    Console.WriteLine("До свидание!");
                    break;
                }
            }
        }
    }
}
