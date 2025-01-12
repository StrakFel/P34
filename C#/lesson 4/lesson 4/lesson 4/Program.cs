using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lesson_4
{
    class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int year { get; set; }
        public bool status { get; set; }
        public string user { get; set; }

        public void get_book() 
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.year = year;
            this.status = status;
            this.user = user;
        }
        public void show_info()
        {
            if (status == true)
            {
                Console.WriteLine($"Книга №{id}: Название - {title}, Автор - {author}, Год выпуска - {year}, Статус - занята {user}.");
            }
            else if (status == false)
            {
                Console.WriteLine($"Книга №{id}: Название - {title}, Автор - {author}, Год выпуска - {year}, Статус - свободна.");
            }
        }
    }
    class Library
    {
        public List<Book> books = new List<Book>();
        public int book_count;

        public Library()
        {
            books.Add(new Book { id = 1, title = "Гарри Поттер и философский камень", author = "Дж. К. Роулинг", year = 1997, status = false, user = null });
            books.Add(new Book { id = 2, title = "Властелин колец: Братство кольца", author = "Дж. Р. Р. Толкин", year = 1954, status = false, user = null });
            books.Add(new Book { id = 3, title = "Унесённые ветром", author = "Маргарет Митчелл", year = 1936, status = false, user = null });
            books.Add(new Book { id = 4, title = "Гарри Поттер и кубок огня", author = "Дж. К. Роулинг", year = 2000, status = true, user = "Петр Петров" });
            books.Add(new Book { id = 5, title = "Гарри Поттер и орден Феникса", author = "Дж. К. Роулинг", year = 2003, status = false, user = null });
            books.Add(new Book { id = 6, title = "Гарри Поттер и принц-полукровка", author = "Дж. К. Роулинг", year = 2005, status = true, user = "Анна Смирнова" });
            books.Add(new Book { id = 7, title = "Гарри Поттер и дары смерти", author = "Дж. К. Роулинг", year = 2007, status = false, user = null });
            books.Add(new Book { id = 8, title = "Властелин колец: Братство кольца", author = "Дж. Р. Р. Толкин", year = 1954, status = true, user = "Ольга Сидорова" });
            books.Add(new Book { id = 9, title = "Властелин колец: Две крепости", author = "Дж. Р. Р. Толкин", year = 1954, status = false, user = null });
            books.Add(new Book { id = 10, title = "Властелин колец: Возвращение короля", author = "Дж. Р. Р. Толкин", year = 1955, status = true, user = "Сергей Кузнецов" });
            books.Add(new Book { id = 11, title = "Хоббит, или Туда и обратно", author = "Дж. Р. Р. Толкин", year = 1937, status = false, user = null });
            books.Add(new Book { id = 12, title = "1984", author = "Джордж Оруэлл", year = 1949, status = true, user = "Екатерина Иванова" });
            books.Add(new Book { id = 13, title = "Скотный двор", author = "Джордж Оруэлл", year = 1945, status = false, user = null });
            books.Add(new Book { id = 14, title = "Преступление и наказание", author = "Ф. М. Достоевский", year = 1866, status = true, user = "Дмитрий Павлов" });
            books.Add(new Book { id = 15, title = "Идиот", author = "Ф. М. Достоевский", year = 1869, status = false, user = null });
            books.Add(new Book { id = 16, title = "Братья Карамазовы", author = "Ф. М. Достоевский", year = 1880, status = true, user = "Алексей Николаев" });
            books.Add(new Book { id = 17, title = "Война и мир", author = "Л. Н. Толстой", year = 1869, status = false, user = null });
            books.Add(new Book { id = 18, title = "Анна Каренина", author = "Л. Н. Толстой", year = 1877, status = true, user = "Мария Волкова" });
            books.Add(new Book { id = 19, title = "Гордость и предубеждение", author = "Джейн Остин", year = 1813, status = false, user = null });
            books.Add(new Book { id = 20, title = "Джейн Эйр", author = "Шарлотта Бронте", year = 1847, status = true, user = "Наталья Сергеевна" });
            books.Add(new Book { id = 21, title = "Мастер и Маргарита", author = "М. А. Булгаков", year = 1940, status = false, user = null });
            books.Add(new Book { id = 22, title = "Собачье сердце", author = "М. А. Булгаков", year = 1925, status = true, user = "Константин Иванов" });
            books.Add(new Book { id = 23, title = "Алиса в Стране чудес", author = "Льюис Кэрролл", year = 1865, status = false, user = null });
            books.Add(new Book { id = 24, title = "О дивный новый мир", author = "Олдос Хаксли", year = 1932, status = true, user = "Владимир Сидоров" });
            books.Add(new Book { id = 25, title = "Фауст", author = "Иоганн Вольфганг Гёте", year = 1808, status = false, user = null });
            books.Add(new Book { id = 26, title = "Доктор Живаго", author = "Борис Пастернак", year = 1957, status = true, user = "Ольга Петрова" });
            books.Add(new Book { id = 27, title = "Капитанская дочка", author = "А. С. Пушкин", year = 1836, status = false, user = null });
            books.Add(new Book { id = 28, title = "Евгений Онегин", author = "А. С. Пушкин", year = 1833, status = true, user = "Виктор Андреев" });
            books.Add(new Book { id = 29, title = "Двенадцать стульев", author = "Ильф и Петров", year = 1928, status = false, user = null });
            books.Add(new Book { id = 30, title = "Золотой телёнок", author = "Ильф и Петров", year = 1931, status = true, user = "Анастасия Дмитриева" });

            book_count = books.Count;
        }
        public bool LendBook(User user, int bookId)
        {
            var book = books.FirstOrDefault(b => b.id == bookId);
            if (book != null && !book.status)
            {
                book.status = true;
                book.user = user.name;
                user.books.Add(book);
                Console.WriteLine($"Книга '{book.title}' передана пользователю {user.name}");
                return true;
            }
            else
            {
                Console.WriteLine("Книга недоступна для выдачи.");
                return false;
            }
        }
        public void ReturnBook(User user, int bookId)
        {
            var book = user.books.FirstOrDefault(b => b.id == bookId);
            if (book != null)
            {
                book.status = false;
                book.user = null;
                user.books.Remove(book);
                books.Add(book);
                Console.WriteLine($"Книга '{book.title}' возвращена в библиотеку.");
            }
            else
            {
                Console.WriteLine("У вас нет такой книги.");
            }
        }
        public void all_books()
        {
            Console.WriteLine($"Всего книг в библиотеке {book_count}");
        }
    }
    class User
    {
        public int id { get; }
        public string name { get; set; }
        public List<Book> books = new List<Book>();

        public void ShowBooks()
        {
            if (books.Count > 0)
            {
                Console.WriteLine($"{name} взял(а) следующие книги:");
                foreach (var book in books)
                {
                    Console.WriteLine($"- {book.title}");
                }
            }
            else
            {
                Console.WriteLine($"{name} ещё не взял(а) ни одной книги.");
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            User user1 = new User { name = "Иван Иванов" };
            User user2 = new User { name = "Мария Смирнова" };

            library.LendBook(user1, 1);
            library.LendBook(user2, 2);

            user1.ShowBooks();
            user2.ShowBooks();

            library.ReturnBook(user1, 1);
            library.ReturnBook(user2, 2);

            user1.ShowBooks();
            user2.ShowBooks();
        }
    }
}
