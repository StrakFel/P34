#include <iostream>
#include <string>
#include <Windows.h>
using namespace std;

class Phone {
public:
    int year;
    string name;
    string color;
    int cameras;
    string display;
    string chargers;
    string number;
    bool cracked;
    bool Case;
    int memory;
    Phone(int a, string b, string c, int d, string e, string f, string g, bool h, bool i, int j) {
        year = a;
        name = b;
        color = c;
        cameras = d;
        display = e;
        chargers = f;
        number = g;
        cracked = h;
        Case = i;
        memory = j;
    }
    void showAboutPhone() {
        cout << "Данные о вашем телефоне:" << endl;
        cout << "Название телефона -  " << name << endl;
        cout << "Год " << year << endl;
        cout << "Цвет " << color << endl;
        cout << "Количество камер " << cameras << endl;
        cout << "Диагональ экрана " << display << endl;
        cout << "Тип зарядного устройства " << chargers << endl;
        cout << "Номер телефона " << number << endl;
        if (cracked == true) {
            cout << "Ваш телефон имеет трещины на экране" << endl;
        }
        else {
            cout << "Ваш телефон не имеет трещины на экране" << endl;
        }
        if (Case == true) {
            cout << "У вас есть чехол для телефона" << endl;
        }
        else {
            cout << "У вас нету чехла для телефона" << endl;
        }
        cout << memory <<  "Гб памяти в телефоне" << endl;
    }
    void changeNumber(string newNumber) {
        number = newNumber;
    }
};

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);

    string user;

    Phone Huawei(2021, "Huawei P Smart 2021", "Gold", 4, "6.67", "Type-C", "+380993427865", true, true, 128);

    Huawei.showAboutPhone();
    cout << "Введите новый номер телефона: ";
    cin >> user;
    Huawei.changeNumber(user);
    Huawei.showAboutPhone();
}
