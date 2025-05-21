#include <iostream>

using namespace std;

int sum(int a, int b) {
    return a + b;
}


class Person {
public:
    string name;
    int age;

    void introsuce() {
        cout << "My name is " << name << ", I`m am " << age << " years old.";
    }
};

class Animal {
public:
    void speak() {
        cout << "Animal is speak" << endl;
    }
};

class Dog : public Animal {
public:
    void bark() {
        cout << "Dog is bark" << endl;
    }
};

int main()
{
    Dog dog;
    dog.speak();
    dog.bark();

    Person p1;
    p1.age = 20;
    p1.name = "Olga";
    p1.introsuce();

    int age = 25;
    float height = 1.75f;
    double width = 68.6;
    char grade = 'A';
    bool isStudent = true;

    cout << age << endl;
    cout << height << endl;
    cout << width << endl;
    cout << grade << endl;
    cout << isStudent << endl;

    //static array 
    int numbers[5] = { 10, 20, 30, 40, 50 };
    for (int i = 0; i < 5; i++) {
        cout << "Element" << i + 1 << " " << numbers[i] << endl;
    }

    //dynamic array
    int size;
    cout << "Enter size arr:";
    cin >> size;

    int* arr = new int[size];

    for (int i = 0; i < size; i++) {
        arr[i] = i * 2;
    }

    for (int i = 0; i < size; i++) {
        cout << "Element" << i + 1 << " " << arr[i] << endl;
    }

    delete []arr;

    int number = 10;
    int* ptr = &number;

    cout << "number: " << number << endl;
    cout << "adress: " << ptr << endl;
    cout << "number with ptr" << *ptr << endl;

    *ptr = 20;

    cout << "New number: " << number << endl;
}

