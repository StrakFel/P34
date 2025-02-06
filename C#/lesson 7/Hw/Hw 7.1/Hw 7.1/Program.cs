using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw_7._1
{
    public class Book
    {
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual int Year { get; set; }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"\nНазвание: {Title}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Год: {Year}");
        }
    }

    public class EBook : Book
    {
        public double FileSize { get; set; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Вес(МБ): {FileSize}");
        }
    }
    public class PrintedBook : Book
    {
        public double Weight { get; set; }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"Вес(кг): {Weight}");
        }
    }

    public class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void ShowAllBooks()
        {
            if (books.Count == 0) Console.WriteLine("Библиотека пуста");
            else
            {
                foreach (Book book in books)
                {
                    book.ShowInfo();
                    Console.WriteLine("\n");
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            EBook ebook_1 = new EBook
            {
                Title = "Гарри Поттер и философский камень",
                Author = "Дж. К. Роулинг",
                Year = 1997,
                FileSize = 5.6
            };

            EBook ebook_2 = new EBook
            {
                Title = "1984",
                Author = "Джордж Оруэлл",
                Year = 1949,
                FileSize = 3.2
            };

            PrintedBook printedBook_1 = new PrintedBook
            {
                Title = "Властелин колец: Братство кольца",
                Author = "Дж. Р. Р. Толкин",
                Year = 1954,
                Weight = 0.5
            };

            PrintedBook printedBook_2 = new PrintedBook
            {
                Title = "Преступление и наказание",
                Author = "Федор Достоевский",
                Year = 1866,
                Weight = 0.4
            };

            library.ShowAllBooks();
            library.AddBook(ebook_1);
            library.AddBook(ebook_2);
            library.AddBook(printedBook_1);
            library.AddBook(printedBook_2);
            library.ShowAllBooks();
        }
    }
}
