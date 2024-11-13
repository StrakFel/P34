#include <iostream>
#include <string> 
#include <fstream>
using namespace std;

#define MAX_BOOKS 1000 // Константа для максимального количества книг

struct Book {
    string title; // Название книги
    string author; // Автор книги
    int year; // Год издания
    string genre; // Жанр книги
    int id; // Индификатор книги
};

// Переменные для управления коллекцией книг
Book* library = nullptr; // Указатель на динамический массив книг
int bookCount = 0; // Текущее количество книг

// Функция для добавления книги в библиотеку
void addBook() {
    char choice;
    do {
        Book newBook; // Создание временой книги и ввод данных о книге пользывателем
        cout << "Введите название книги: ";
        cin.ignore(); // Функция которая убирает в конце \n
        getline(cin, newBook.title); // Считывает что написал пользыватель и переносит это в временый массив
        cout << "Введите автора книги: ";
        getline(cin, newBook.author);
        cout << "Введите год издания: ";
        cin >> newBook.year;
        cout << "Введите жанр книги: ";
        cin.ignore();
        getline(cin, newBook.genre);
        cout << "Введите индификатор книги: ";
        cin >> newBook.id;

        // Добавляет книгу в библиотеку и увеличивая размер динамического массива
        Book* temp = new Book[bookCount + 1]; // Новый массив который увеличился на 1 книгу
        for (int i = 0; i < bookCount; i++) {
            temp[i] = library[i]; // Копирует все книги которые были в новый массив
        }
        temp[bookCount] = newBook; // Добавляет новую книгу в конец

        // Освобождает старый массив и переназначаем указатель на новый массив
        delete[] library;
        library = temp;
        bookCount++;
        cout << "Книга добавлена" << endl;
        cout << "Хотите добавить еще одну книгу? (y/n): ";
        cin >> choice;
    } while (choice == 'y' || choice == 'Y');
}

// Функция для отображения всех книг
void displayBooks() {
    if (bookCount == 0) {
        cout << "Библиотека пуста" << endl;
        return;
    }
    cout << "----------------------" << endl;
    for (int i = 0; i < bookCount; i++) {
        cout << "ID: " << library[i].id << endl;
        cout << "Название: " << library[i].title << endl;
        cout << "Автор: " << library[i].author << endl;
        cout << "Год издания: " << library[i].year << endl;
        cout << "Жанр: " << library[i].genre << endl;
        cout << "----------------------" << endl;
    }
}

// Функция для поиска книги по индификатору
void findBook() {
    char choice;
    do {
        int id;
        cout << "Введите ID книги для поиска: ";
        cin >> id;
        bool found = false;
        for (int i = 0; i < bookCount; i++) {
            if (library[i].id == id) {
                cout << "Книга найдена:" << endl;
                cout << "Название: " << library[i].title << endl;
                cout << "Автор: " << library[i].author << endl;
                cout << "Год издания: " << library[i].year << endl;
                cout << "Жанр: " << library[i].genre << endl;
                found = true;
                break;
            }
        }
        if (!found) {
            cout << "Книга с ID " << id << " не найдена" << endl;
        }
        cout << "Хотите найти еще одну книгу? (y/n): ";
        cin >> choice;
    } while (choice == 'y' || choice == 'Y');
}

void editBook() {
    int id;
    cout << "Введите ID книги для редактирования: ";
    cin >> id;
    bool found = false;
    for (int i = 0; i < bookCount; i++) {
        if (library[i].id == id) {
            found = true;
            int editChoice;
            do {
                cout << "Что вы хотите отредактировать?" << endl;
                cout << "1. Название\n2. Автор\n3. Год издания\n4. Жанр\n0. Выход\n";
                cout << "Выберите вариант: ";
                cin >> editChoice;
                cin.ignore();
                switch (editChoice) {
                case 1:
                    cout << "Введите новое название: ";
                    getline(cin, library[i].title);
                    break;
                case 2:
                    cout << "Введите нового автора: ";
                    getline(cin, library[i].author);
                    break;
                case 3:
                    cout << "Введите новый год издания: ";
                    cin >> library[i].year;
                    break;
                case 4:
                    cout << "Введите новый жанр: ";
                    cin.ignore();
                    getline(cin, library[i].genre);
                    break;
                case 0:
                    cout << "Выход из редактирования" << endl;
                    break;
                default:
                    cout << "Неверный выбор" << endl;
                }
            } while (editChoice != 0);
            break;
        }
    }
    if (!found) {
        cout << "Книга с ID " << id << " не найдена" << endl;
    }
}

// Функция для удаления книги по индификатору
void deleteBook() {
    char choice;
    do {
        int id;
        cout << "Введите ID книги для удаления: ";
        cin >> id;
        bool found = false; // Переменная указывает была ли найдета такая книга
        Book* temp = new Book[bookCount - 1]; // Создание временного массива для хранения всех книг кроме тех которую нужно будет удалить
        int j = 0;
        for (int i = 0; i < bookCount; i++) { // Проходит по всем книгах из массива
            if (library[i].id == id) { // Совпадает ли индификатор с введеным от пользывателя
                found = true;
                continue;
            }
            temp[j++] = library[i]; // Копирует текущую книгу в временый массив
        }

        if (found) { // Если книга была найдена
            delete[] library;
            library = temp;
            bookCount--;
            cout << "Книга удалена" << endl;
        }
        else {
            delete[] temp;
            cout << "Книга с ID " << id << " не найдена" << endl;
        }
        cout << "Хотите удалить еще одну книгу? (y/n): ";
        cin >> choice;
    } while (choice == 'y' || choice == 'Y');
}

// Функция для сохранения данных в файл
void saveToFile() {
    ofstream file("library.txt");
    if (file.is_open()) {
        file << bookCount << "\n";
        for (int i = 0; i < bookCount; i++) {
            file << library[i].id << endl
                << library[i].title << endl
                << library[i].author << endl
                << library[i].year << endl
                << library[i].genre << endl;
        }
        file.close();
        cout << "Данные сохранены в файл" << endl;
    }
    else {
        cout << "Ошибка при открытии файла" << endl;
    }
}

// Функция для загрузки данных из файла
void loadFromFile() {
    ifstream file("library.txt"); // Открывает файл для чтения
    if (file.is_open()) { // Проверка открыт ли файл
        file >> bookCount; // Считывает количество книг
        file.ignore(); // Игнорирует символ новой строки
        library = new Book[bookCount]; // Создание массива для хранения книг
        for (int i = 0; i < bookCount; i++) {
            file >> library[i].id; // Считывает индификатор книги
            file.ignore();
            getline(file, library[i].title); // Считывание название книги
            getline(file, library[i].author); // Считывание автора книги
            file >> library[i].year; // Считывание год создания книги
            file.ignore();
            getline(file, library[i].genre); // Считывание жанр книги
        }
        file.close(); // Закрытия файла
        cout << "Данные загружены из файла" << endl;
    }
    else {
        cout << "Файл не найден, создана новая библиотека" << endl;
    }
}

// Меню программы
void menu() {
    int choice;
    do {
        cout << "1. Добавить книгу" << endl
            << "2. Отобразить все книги" << endl
            << "3. Найти книгу" << endl
            << "4. Удалить книгу" << endl
            << "5. Редактировать книгу" << endl
            << "6. Сохранить и выйти" << endl;
        cout << "Выберите действие: ";
        cin >> choice;

        switch (choice) {
        case 1: addBook(); 
            break;
        case 2: displayBooks(); 
            break;
        case 3: findBook(); 
            break;
        case 4: deleteBook(); 
            break;
        case 5: editBook(); 
            break;
        case 6: saveToFile(); 
            break;
        default: cout << "Неверный выбор" << endl;
        }
    } while (choice != 6);
}

int main() {
    setlocale(LC_ALL, "RU"); //Функция для кириллицы
    loadFromFile(); // Загружает данные из файла при запуске
    menu();         // Запускает главное меню
    return 0;
}