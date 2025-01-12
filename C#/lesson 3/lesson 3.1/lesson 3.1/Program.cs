using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace lesson_3._1
{
    class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int year { get; set; }

        public void set_info()
        {
            try
            {
                Console.Write("Введите название книги: ");
                title = Console.ReadLine();

                Console.Write("Введите автора книги: ");
                author = Console.ReadLine();

                Console.Write("Введите год выпуска книги: ");
                year = int.Parse(Console.ReadLine());

                if (year < 0)
                    throw new ArgumentException("Год выпуска не может быть отрицательным.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Год выпуска должен быть целым числом.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        public void print_info()
        {
            Console.WriteLine($"Название: {title}, Автор: {author}, Год выпуска: {year}.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int user;

            List<Book> books = new List<Book>();

            books.Add(new Book()
            {
                title = "Harry Potter and the Philosopher's Stone",
                author = "J. K. Rowling",
                year = 1997
            });

            books.Add(new Book()
            {
                title = "The Hobbit",
                author = "J. R. R. Tolkien",
                year = 1937
            });

            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1.Добавление книги");
                Console.WriteLine("2.Вывод книг");
                Console.WriteLine("Для выхода нажмите 0");
                Console.Write(" Ваше действие: ");

                try
                {
                    user = int.Parse(Console.ReadLine());

                    if (user == 1)
                    {
                        Book newBook = new Book();
                        newBook.set_info();
                        books.Add(newBook);
                        Console.WriteLine("Книга успешно добавлена!");
                    }
                    else if (user == 2)
                    {
                        if(books.Count == 0)
                        {
                            Console.WriteLine("Список книг пуст");
                        }
                        else
                        {
                            Console.WriteLine("\nСписок книг:");
                            foreach (var book in books)
                            {
                                book.print_info();
                            }
                        }
                    }
                    else if (user == 0)
                    {
                        Console.WriteLine("До свидания!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Выбрано неправильное действие. Попробуйте снова");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите корректное число.");
                }
            }
            
        }
    }
}
