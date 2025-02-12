using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Exam
{
    // Интерфейс для книг которые можно брать в аренду
    public interface IBorrowable
    {
        bool IsAvailable { get; set; } // Определяет доступен ли объект
    }

    // Класс книги с перегрузкой и реализацией IEquatable
    public class Book : IBorrowable, IEquatable<Book> // Этот класс реализует интерфейсы для заимствования и сравнения книг
    {
        public int Id { get; set; } // Айди книги
        public string Title { get; set; } // Название 
        public string Author { get; set; } // Автор
        public int Year { get; set; } // Год создания
        public string Genre { get; set; } // Жанр
        public bool Is_Available { get; set; } = true; // Доступность книги

        // Реализация свойства интерфейса IBorrowable
        public bool IsAvailable
        {
            get { return Is_Available; } // Возвращает текущие состояние книги
            set { Is_Available = value; } // Позволяет изменять доступность книги
        }

        // Переписание метода в строку для отображение информации о книге
        public override string ToString()
        {
            return $"{Id}. Название: {Title}, Автор: {Author}, Год выпуска: {Year}, Жанр: {Genre} -- " + // Выводит данные о книге
                (Is_Available ? "Доступно" : "Не доступно"); // Проверяет доступна ли книга
        }

        // Метод для сравнения книг по айди
        public bool Equals(Book other)
        {
            if (other == null) return false; // Если другой книги нету возращаеться false
            return this.Id == other.Id; // Сравнение айди этой и другой книги
        }

        // Перезапись метода для сравнения обьекта
        public override bool Equals(object obj)
        {
            if (obj is Book otherBook) // Если введеный объект являеться книгой
            {
                return Equals(otherBook); // Возращаеться результат сравнения 
            }
            return false; // Если obj не являетсья книгой то возращаетсья false
        }

        // Перезапись механизм получения хеш-уода
        public override int GetHashCode()
        {
            return Id.GetHashCode(); // Возвращает хеш-код на основе айди
        }

        // Перегрузка оператора равенства
        public static bool operator ==(Book left, Book right)
        {
            if (ReferenceEquals(left, null)) // Проверка являетсья ли left null
                return ReferenceEquals(right, null); // Если первый объект null то проверка right являетсья null
            return left.Equals(right); // Если оба объекта не null то вызываем метод для их сравнения
        }

        // Перегрузка оператора неравенства для сравнения книгн
        public static bool operator !=(Book left, Book right)
        {
            return !(left == right); // Возращаем противоположное значение
        }
    }

    // Класс для электронных книг унаследовав Book
    public class EBook : Book
    {
        public double FileSize_MB { get; set; } // Размер электронной книги в мегабайтах
        public string Format { get; set; } // Формат эллектронной книги

        // Перезапись метода дял отображения информации об электронной книге
        public override string ToString()
        {
            return base.ToString() + $" [Электронная книга: {FileSize_MB} MB, Формат: {Format}]"; // Возвращает строку с доп информацией об электронной книге
        }
    }

    // Класс пользователя с регистрацией
    public class User
    {
        public int Id { get; set; } // Айди пользователя
        public string FirstName { get; set; } // Имя
        public string LastName { get; set; } // Фамилия
        public List<int> BorrowedBooks { get; set; } = new List<int>(); // Список айди книг которые были взяты пользователем

        public string FullName => $"{FirstName} {LastName}"; // Возвращает имя и фамилию пользователя

        // Метод для вывода информации о пользователе 
        public override string ToString()
        {
            return $"{Id}. {FullName}, Книг позаимствовал: {string.Join(", ", BorrowedBooks)}"; // Возврощает строку с информацией о пользователе
        }
    }

    // Класс библиотеки (Singleton) с индексатором для доступа по айди книги
    [XmlInclude(typeof(Book))] // Указывает то что при сериализации XML этот класс может содержать объекты типа Book
    [XmlInclude(typeof(EBook))] // Указывает то что при сериализации XML этот класс может содержать объекты типа ЕBook
    public class Library
    {
        private static Library _instance; // Для хранения экземпляр класса

        // Свойство для доступа к экземпляу библиотеки
        public static Library Instance
        {
            get
            {
                if (_instance == null) // Если экземпляр не существует
                {
                    _instance = new Library(); // Создать эземпляр
                }
                return _instance; // Возращение экзенпляра библиотеки
            }
        }

        public List<Book> Books { get; set; } = new List<Book>(); // Список книг в библиотеке
        public List<User> Users { get; set; } = new List<User>(); // Список пользователей

        // Доступ к книге по ее айди
        public Book this[int id]
        {
            get { return Books.FirstOrDefault(b => b.Id == id); } // Возвращает книгу по айди или null если книга не найдена
        }

        private Library() { } // Приватный конструктор что бы нельзя было создать экземпляр вне этого класса
    }

    // Класс для управления файловой системой XML
    public static class DataManager
    {
        private static string filePath = "library.xml"; // Путь к файлу в котором храниться библиотека

        // Метод для сохранения библиотеки в файл
        public static void SaveLibrary()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Library)); // Создание сериализатора для типа Library
                using (StreamWriter writer = new StreamWriter(filePath)) // открывает поток для записи в файл
                {
                    serializer.Serialize(writer, Library.Instance); // Сериализуем обьект Library и записуем в файл
                }
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка сохранения библиотеки: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Методя для загрузки библиотеки из файла
        public static void LoadLibrary()
        {
            try
            {
                if (!File.Exists(filePath)) return; // Если файла не существует то ничего не возращаеться
                XmlSerializer serializer = new XmlSerializer(typeof(Library)); // Создаеться сериализатор для типа Library
                using (StreamReader reader = new StreamReader(filePath)) // Открываеться поток для чтения файла
                {
                    var loadedLibrary = (Library)serializer.Deserialize(reader); // Десириализует данные из файла в объект типа Library
                    Library.Instance.Books = loadedLibrary.Books; // Копирует книги из загруженной библиотекки
                    Library.Instance.Users = loadedLibrary.Users; // Копирует пользователей
                }
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка загрущки библиотеки: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }
    }

    // Класс для логирования операций в файл
    public static class Logger
    {
        private static readonly string logFilePath = "library.log"; // Путь к файлу для хранения логов (создан так что нельзя изменить после инициализации)
        // Метод для записи сообщения в лог
        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true)) // Добовляет поток дял записи в файл в режиме добавления
                {
                    writer.WriteLine($"{DateTime.Now}: {message}"); // Записует текущие время и сообщение в файл
                }
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при записи лога: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }
    }

    // Вспомогательный класс для работы с коллекциями
    public static class GenericHelper
    {
        // Метод по нахождению элементов в коллекции по заданому условию
        public static List<T> FindItems<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(predicate).ToList(); // Фильтрует элементы по предикату и возрващает список
        }
    }

    // Делегаты и события для уведомлений об операциях с книгами
    public static class LibraryEvents
    {
        public delegate void BookOperationHandler(Book book, User user); // Опредиление делегата для обработки операций с книгами
        public static event BookOperationHandler BookBorrowed; // Событие вызывающейся при выдаче книги польователю
        public static event BookOperationHandler BookReturned; // Событие вызывающейся при возврате книги польователю

        // Метод для вызова события выдачи книги
        public static void OnBookBorrowed(Book book, User user)
        {
            BookBorrowed?.Invoke(book, user); // Если есть подписчик то вызываеться событие
        }

        // Метод для вызова события возврата книги
        public static void OnBookReturned(Book book, User user)
        {
            BookReturned?.Invoke(book, user);// Если есть подписчик то вызываеться событие
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DataManager.LoadLibrary(); // Загружает данные из файла
            SubscribeEvents(); // Подписываемся на события
            Console.WriteLine("Добро пожаловать в систему управлением библиотекой!\n"); // Привествие при запуске программы

            bool exit = false; // Для выхода из цикла
            // Основной цикл меню
            while (!exit)
            {
                // Вывод меню с выбором действий
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Добавить электронную книгу");
                Console.WriteLine("3. Обновить книгу");
                Console.WriteLine("4. Удалить книгу");
                Console.WriteLine("5. Список всех книг");
                Console.WriteLine("6. Фильтрация по жанру или году публикации");
                Console.WriteLine("7. Поиск книги по названию или автору");
                Console.WriteLine("8. Регистрация пользователя");
                Console.WriteLine("9. Удалить пользователя");
                Console.WriteLine("10. Список всех пользователей");
                Console.WriteLine("11. Список всех книг взятых пользователями");
                Console.WriteLine("12. Взять книгу");
                Console.WriteLine("13. Вернуть книгу");
                Console.WriteLine("14. Выход");
                Console.Write("Выберите действие: ");

                // Обработка выбора действия из меню
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out int choice)) // Пробует считать ввод пользователя и преобразить его в целое число
                    {
                        Console.WriteLine("Неверный ввод, введите число\n");
                        continue; // Если ввод не являеться числом то продолжаеться цикл
                    }
                    // Обработка выбора пользователя
                    switch (choice)
                    {
                        case 1:
                            AddBook(); // Добавить книгу
                            break;
                        case 2:
                            AddEBook(); // Добавить электронную книгу
                            break;
                        case 3:
                            UpdateBook(); // Обновить книг
                            break;
                        case 4:
                            DeleteBook(); // Удалить книг
                            break;
                        case 5:
                            ListBooks(); // Список всех книг
                            break;
                        case 6:
                            FilterBooks(); // Фильтрация по жанру или году публикации
                            break;
                        case 7:
                            SearchBook(); // Поиск книги по названию или автору
                            break;
                        case 8:
                            RegisterUser(); // Регистрация пользователя
                            break;
                        case 9:
                            DeleteUser(); // Удалить пользователя
                            break;
                        case 10:
                            ListUsers(); // Список всех пользователей
                            break;
                        case 11:
                            ListUserBorrowedBooks(); // Список всех книг взятых пользователями
                            break;
                        case 12:
                            BorrowBook(); // Взять книгу
                            break;
                        case 13:
                            ReturnBook(); // Вернуть книгу
                            break;
                        case 14:
                            DataManager.SaveLibrary(); // Сохранение данных библиотеки
                            Console.WriteLine("Данные библиотеки были удачно сохранены. Досвидания!"); // Сообщение об успешном сохранении
                            exit = true; // Выход
                            break;
                        default:
                            Console.WriteLine("Невозможное действие, попробуйте снова\n"); // Неверное действие
                            break;
                    }
                }
                catch (Exception ex) // Прописания исключения
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}"); // Вывод сообщения об ошибке
                }
            }
        }

        // Подписка на события аренды и возврата книги
        static void SubscribeEvents()
        {
            // Подписка на событие об выдачи книги
            LibraryEvents.BookBorrowed += (book, user) =>
            {
                // Формируеться сообщение о то что книга была взята
                string message = $"Книга '{book.Title}' (ID: {book.Id}) была взята {user.FullName} (ID: {user.Id})"; 
                Console.WriteLine(message); // Вывод сообщения на экран
                Logger.Log(message); // Логируеться данные в файл
            };

            // Подписка на событие по возврату книги
            LibraryEvents.BookReturned += (book, user) =>
            {
                // Формируеться сообщение о то что книга была возвращена
                string message = $"Книга '{book.Title}' (ID: {book.Id}) была возвращена {user.FullName} (ID: {user.Id})";
                Console.WriteLine(message); // Вывод сообщения на экран
                Logger.Log(message); // Логируеться данные в файл
            };
        }

        // Метод добавления обычной книги в библиотеку
        static void AddBook()
        {
            try
            {
                Console.Write("Введите название книги: ");
                string title = Console.ReadLine();

                Console.Write("Введите автора: ");
                string author = Console.ReadLine();

                Console.Write("Введите жанр: ");
                string genre = Console.ReadLine();

                Console.Write("Введите год издания: ");
                if (!int.TryParse(Console.ReadLine(), out int year)) // Проверка являетсья ли введеное значение числом
                {
                    Console.WriteLine("Неверный ввод года\n"); // Вывод об неверном вводе если значение не являеться число
                    return; // Прерываеться выполнение метода
                }
                int newId = Library.Instance.Books.Count > 0 ? Library.Instance.Books.Max(b => b.Id) + 1 : 1; // Генирация нового айди для книги

                // Добавление новой книги в список книг
                Library.Instance.Books.Add(new Book 
                { 
                    Id = newId, 
                    Title = title, 
                    Author = author,
                    Year = year,
                    Genre = genre  
                });
                Console.WriteLine("Книга успешно добавлена!\n"); // Вывод сообщение об успехе
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при добавлении книги: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод добавления электронной книги в библиотеку
        static void AddEBook()
        {
            try
            {
                Console.Write("Введите название книги: ");
                string title = Console.ReadLine();

                Console.Write("Введите автора: ");
                string author = Console.ReadLine();

                Console.Write("Введите жанр: ");
                string genre = Console.ReadLine();

                Console.Write("Введите год издания: ");
                if (!int.TryParse(Console.ReadLine(), out int year)) // Проверка являетсья ли введеное значение числом
                {
                    Console.WriteLine("Неверный ввод года\n"); // Вывод об неверном вводе если значение не являеться число
                    return; // Прерываеться выполнение метода
                }

                Console.Write("Введите сколько весит книга(MB): ");
                if (!double.TryParse(Console.ReadLine(), out double fileSize)) // Проверка являеться ли введеное значаение числом
                {
                    Console.WriteLine("Неверные размер файла\n"); // Вывод об неверном вводе если значение не являеться число
                    return; // Завершение выполнение метода
                }

                Console.Write("Введите её формат: ");
                string format = Console.ReadLine();

                int newId = Library.Instance.Books.Count > 0 ? Library.Instance.Books.Max(b => b.Id) + 1 : 1; // Генирация нового айди для электронной книги

                // Добавление новой электронной книги в список книг
                Library.Instance.Books.Add(new EBook
                {
                    Id = newId,
                    Title = title,
                    Author = author,
                    Year = year,
                    Genre = genre,
                    FileSize_MB = fileSize,
                    Format = format
                });
                Console.WriteLine("Книга успешно добавлена!\n"); // Вывод сообщение об успехе
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при добавлении книги: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод обновления информации о книге
        static void UpdateBook()
        {
            try
            {
                Console.Write("Введите ID книги для обновления: ");
                if (!int.TryParse(Console.ReadLine(), out int bookId)) // Проверка являеться ли введеное значаение числом
                {
                    Console.WriteLine("Неверный ввод\n"); // Вывод об неверном вводе если значение не являеться число
                    return; // Завершение выполнение метода
                }

                var book = Library.Instance.Books.FirstOrDefault(b => b.Id == bookId); // Поиск книги в библиотеке по айди
                if (book == null) // Если книги нету
                {
                    Console.WriteLine("Книга не найдена\n"); // Вывод текста об этом
                    return; // Завершение выполнение метода
                }

                Console.WriteLine("Оставте поле пустым если хотите сохранить текущее значение");

                Console.Write($"Введите новое название(текущее: {book.Title}): ");
                string title = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(title)) // Если введено новое значение
                    book.Title = title; // Обновление названия

                Console.Write($"Введите нового автора(текущий: {book.Author}): ");
                string author = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(author)) // Если введено новое значение
                    book.Author = author; // Обновление автора

                Console.Write($"Введите новый жанр(текущий: {book.Genre}): ");
                string genre = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(genre)) // Если введено новое значение
                    book.Genre = genre; // Обновление жанра

                Console.Write($"Введите новый год издания(текущий: {book.Year}): ");
                string yearInput = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(yearInput) && int.TryParse(yearInput, out int year)) // Если введено новое правильное(int) значение
                    book.Year = year; // Обновление года издания
                Console.WriteLine("Книга успешно добавлена!\n"); // Вывод сообщение об успехе
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при обновлении книги: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод удаления книги
        static void DeleteBook()
        {
            try
            {
                Console.Write("Введите ID книги для удаления: ");

                if (!int.TryParse(Console.ReadLine(), out int bookId)) // Проверка правльно ли введено айди
                {
                    Console.WriteLine("Неверный ввод\n"); // Вывод об неверном вводе если значение не являеться число
                    return; // Завершение выполнение метода
                }

                var book = Library.Instance.Books.FirstOrDefault(b => b.Id == bookId); // Поиск книги по айди в колекции

                if (book == null) // Если книга не найдена
                {
                    Console.WriteLine("Книга не найдена\n");
                    return; // Завершение выполнение метода
                }

                Library.Instance.Books.Remove(book); // Удаление книги из колекции
                Console.WriteLine("Книга успешно удалена!\n");
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при удалении книги: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод вывода списка всех книг
        static void ListBooks()
        {
            try
            {
                if (!Library.Instance.Books.Any()) // Проверка если книги в библиотеке
                {
                    Console.WriteLine("Книг нету\n");
                    return; // Завершение выполнение метода
                }

                // Перебирание и вывод всех книг
                foreach (var book in Library.Instance.Books) 
                {
                    Console.WriteLine(book);
                }

                Console.WriteLine();
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при выводе списка книг: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод фильтрации книг по жанру или году издания
        static void FilterBooks()
        {
            try
            {
                Console.WriteLine("Фильтровать по: 1. Жанр, 2. Год издания");
                Console.Write("Выберите действие: ");

                if (!int.TryParse(Console.ReadLine(), out int option)) // Проверка на коректный ввод
                {
                    Console.WriteLine("Неверный ввод\n");
                    return; // Завершение выполнение метода
                }

                List<Book> results = new List<Book>(); // Список для харанения сфильтрованых книг

                if (option == 1) // Если фильтрация по жанру
                {
                    Console.Write("Введите жанр: ");
                    string genre = Console.ReadLine();
                    results = Library.Instance.Books // Получение доступа к списку книг в библиотеке
                        .Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)) // Фильтуреться книги где жанр совпадает игнорируя заглавные буквы
                        .ToList(); // Переобразование результата фильтрации в список и присваивает его переменной results
                }
                else if (option == 2) // Если фильтрация по году издания
                {
                    Console.Write("Введите год издания: ");
                    if (!int.TryParse(Console.ReadLine(), out int year)) // Проверка на коректный ввод
                    {
                        Console.WriteLine("Неверный ввод.\n");
                        return; // Завершение выполнение метода
                    }
                    results = Library.Instance.Books
                        .Where(b => b.Year == year) // Фильтрация по году
                        .ToList(); // Переобразование результата фильтрации в список и присваивает его переменной results
                }
                else
                {
                    Console.WriteLine("Неверное действие\n");
                    return; // Завершение выполнение метода
                }

                if (!results.Any()) // Если список книг пуст
                {
                    Console.WriteLine("Не найдено книг по данным критериям\n");
                }
                else
                {
                    foreach (var book in results) // Перебор отфильтрованых книг
                    {
                        Console.WriteLine(book); // Вывод отфильтрованых книг
                    } 
                    Console.WriteLine();
                }
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка фильтрации книг: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод поиска книги по названию или автору с использованием генерализованного метода
        static void SearchBook()
        {
            try
            {
                Console.Write("Введите название или автора дял поиска: ");
                string search = Console.ReadLine();
                // Вызов метода FindItems из класса GenericHelper для поиска по книгам
                var results = GenericHelper.FindItems(Library.Instance.Books, b =>
                    b.Title.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 || // Если в названии книги найдено вхождение строки поиска
                    b.Author.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0); // Если в имени автора найдено вхождение строки поиска

                if (!results.Any()) // Если результат поиска ничего не выдает
                {
                    Console.WriteLine("Книги не найдены\n");
                }
                else // Если книги есть
                {
                    foreach (var book in results) // Перебор каждой найденой книги
                    {
                        Console.WriteLine(book); // Вывод книги
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при поиске книг: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод регистрации пользователя
        static void RegisterUser()
        {
            try
            {
                Console.Write("Введите ваше имя: ");
                string firstName = Console.ReadLine();

                Console.Write("Введите вашу фамилию: ");
                string lastName = Console.ReadLine();

                // Создание нового айди(если пользователи уже есть, то береться максимальный айди + 1, если же нету то 1) 
                int newId = Library.Instance.Users.Count > 0 ? Library.Instance.Users.Max(u => u.Id) + 1 : 1;

                // Добовление нового пользователя в список пользователй библиотеку со всеми его данными
                Library.Instance.Users.Add(new User
                {
                    Id = newId,
                    FirstName = firstName,
                    LastName = lastName
                });
                Console.WriteLine("Пользователь успешно зарегистрирован!\n"); // Прописания исключения
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при регистрации пользователя: {ex.Message} "); // Вывод сообщения об ошибке
            }
        }

        // Метод удаления пользователя
        static void DeleteUser()
        {
            try
            {
                Console.Write("Введите ID пользователя для удаления: ");

                if (!int.TryParse(Console.ReadLine(), out int userId)) // Проверка на коректный ввод
                {
                    Console.WriteLine("Неверный ввод.\n");
                    return; // Завершение выполнение метода
                }

                var user = Library.Instance.Users.FirstOrDefault(u => u.Id == userId); // Поиск пользователя с заданым айди в списке

                if (user == null) // Если пользователь не найден
                {
                    Console.WriteLine("ПОльзователь не найден\n"); 
                    return; // Завершение выполнение метода
                }

                Library.Instance.Users.Remove(user); // Удаление пользователя из списка
                Console.WriteLine("Вользовальтель был успешно удален!\n");
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при удалении пользователя: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод вывода списка всех пользователей
        static void ListUsers()
        {
            try
            {
                if (!Library.Instance.Users.Any()) // Проверка естьб ли пользователи в библиотеке
                {
                    Console.WriteLine("Нет доступных пользователей\n");
                    return; // Завершение выполнение метода
                }
                foreach (var user in Library.Instance.Users) // Перебор каждого пользователя
                {
                    Console.WriteLine(user); // Вывод информации о пользователе
                }
                Console.WriteLine();
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Error listing users: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод для отображения списка книг взятых конкретным пользователем
        static void ListUserBorrowedBooks()
        {
            try
            {
                Console.Write("Введите ID пользователя: ");

                if (!int.TryParse(Console.ReadLine(), out int userId)) // Проверка на коректный ввод
                {
                    Console.WriteLine("Неверный ввод\n");
                    return; // Завершение выполнение метода
                }

                var user = Library.Instance.Users.FirstOrDefault(u => u.Id == userId); // Поиск пользователя по введеному айдм

                if (user == null) // Если пользователь не найден
                {
                    Console.WriteLine("Пользователь не найден\n");
                    return; // Завершение выполнение метода
                }

                if (!user.BorrowedBooks.Any()) // Проверка на то что у пользователя нету взятых книг
                {
                    Console.WriteLine($"{user.FullName} не взял ни одной книги\n");
                    return; // Завершение выполнение метода
                }

                Console.WriteLine($"Книги взятые {user.FullName}:");

                foreach (var bookId in user.BorrowedBooks) // Перебор списка книг взятых этим пользователем
                {
                    var book = Library.Instance.Books.FirstOrDefault(b => b.Id == bookId); // Поиск книги по ее айди в библиотеке
                    if (book != null) // Если книга сущетсвует
                    {
                        Console.WriteLine(book); // Вывод книги
                    }
                }
                Console.WriteLine();
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при получении списка взятых книг: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }

        // Метод для аренды книги
        static void BorrowBook()
        {
            try
            {
                Console.Write("Введите ID пользователя: ");

                if (!int.TryParse(Console.ReadLine(), out int userId)) // Проверка на коректный ввод
                {
                    Console.WriteLine("Неверный ввод\n");
                    return; // Завершение выполнение метода
                }

                var user = Library.Instance.Users.FirstOrDefault(u => u.Id == userId); // Поиск пользователя по айди

                if (user == null) // Если пользователь не найден
                {
                    Console.WriteLine("Пользователь не найден\n");
                    return; // Завершение выполнение метода
                }

                Console.Write("Введите ID книги: ");

                if (!int.TryParse(Console.ReadLine(), out int bookId)) // Проверка на коректный ввод
                {
                    Console.WriteLine("Неверный ввод\n");
                    return; // Завершение выполнение метода
                }

                var book = Library.Instance.Books.FirstOrDefault(b => b.Id == bookId); // Поиск книги по айди

                if (book == null) // Если книга не найдена
                {
                    Console.WriteLine("Книга не найдена\n");
                    return; // Завершение выполнение метода
                }

                if (!book.Is_Available) // Проверка доступна ли книга
                {
                    Console.WriteLine("Книга не доступна\n");
                    return; // Завершение выполнение метода
                }

                book.Is_Available = false; // Установление статуса книги как занято
                user.BorrowedBooks.Add(bookId); // Добавление книги в списох взятых книг пользователя
                Console.WriteLine("Книга успешно выдана!\n"); 
                LibraryEvents.OnBookBorrowed(book, user); // Вызов события книга взята
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Error borrowing book: {ex.Message} "); // Вывод сообщения об ошибке
            }
        }

        // Метод для возврата книги
        static void ReturnBook()
        {
            try
            {
                Console.Write("Введите ID пользователя: ");

                if (!int.TryParse(Console.ReadLine(), out int userId)) // Проверка на коректный ввод
                {
                    Console.WriteLine("Неверный ввод\n");
                    return; // Завершение выполнение метода
                }

                var user = Library.Instance.Users.FirstOrDefault(u => u.Id == userId); // Ищет пользователя в библиотеке

                if (user == null) // Если пользователь не найден
                {
                    Console.WriteLine("Пользователь не найден\n");
                    return; // Завершение выполнение метода
                }

                Console.Write("Введите ID книги: ");

                if (!int.TryParse(Console.ReadLine(), out int bookId)) // Проверка на коректный ввод
                {
                    Console.WriteLine("Неверный ввод\n");
                    return; // Завершение выполнение метода
                }

                var book = Library.Instance.Books.FirstOrDefault(b => b.Id == bookId); // Ищеи книгу в библиотеке

                if (book == null) // Если книга не найдена
                {
                    Console.WriteLine("Книга не найдена\n");
                    return; // Завершение выполнение метода
                }

                if (!user.BorrowedBooks.Contains(bookId)) // Проверка брал ли пользователь эту книгу
                {
                    Console.WriteLine($"Пользователь {user.FullName} не брал эту книгу\n");
                    return; // Завершение выполнение метода
                }

                book.Is_Available = true; // Делает книгу доступной для других пользователей
                user.BorrowedBooks.Remove(bookId); // Удаляет книгу из списка взятых пользователем
                Console.WriteLine($"Книга '{book.Title}' успешно возвращена пользователем {user.FullName}!\n");
                LibraryEvents.OnBookReturned(book, user); // Вызывает событие возврата книги
            }
            catch (Exception ex) // Прописания исключения
            {
                Console.WriteLine($"Ошибка при возврате книги: {ex.Message}"); // Вывод сообщения об ошибке
            }
        }
    }
}