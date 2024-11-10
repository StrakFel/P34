#include <iostream>
using namespace std;

void check_even_odd(int* arr, int user) {
    int even_count = 0, odd_count = 0;
    for (int i = 0; i < user; i++) {
        if (arr[i] % 2 == 0) {
            even_count++;
        }
        else {
            odd_count++;
        }
    }
    cout << "Четных чисел: " << even_count << endl;
    cout << "Нечетных чисел: " << odd_count << endl;
    cout << endl;
}

void check_negative(int* arr, int user) {
    int negative_count = 0;
    for (int i = 0; i < user; i++) {
        if (arr[i] < 0) {
            negative_count++;
        }
    }
    int* negative_arr = new int[negative_count];
    int index = 0;
    for (int i = 0; i < user; i++) {
        if (arr[i] < 0) {
            negative_arr[index] = arr[i];
            index++;
        }
    }
    cout << "Отрицательных чисел: " << negative_count << endl;
    cout << "Отрицательные числа: ";
    for (int i = 0; i < negative_count; i++) {
        cout << negative_arr[i] << " ";
    }
    cout << endl;
    delete[] negative_arr;
}

bool is_prime(int n) {
    if (n <= 1) return false;
    for (int i = 2; i * i <= n; i++) {
        if (n % i == 0) {
            return false;
        }
    }
    return true;
}


int count_primes(int* arr, int user) {
    int prime_count = 0;
    for (int i = 0; i < user; i++) {
        if (is_prime(arr[i])) {
            prime_count++;
        }
    }
    return prime_count;
}

int find_min_positive(int* arr, int user) {
    int min_positive = -1;
    for (int i = 0; i < user; i++) {
        if (arr[i] > 0 && (min_positive == -1 || arr[i] < min_positive)) {
            min_positive = arr[i];
        }
    }
    return min_positive;
}

int sum_even_indices(int* arr, int user) {
    int sum = 0;
    for (int i = 0; i < user; i++) {
        if (i % 2 == 0) { 
            sum += arr[i];
        }
    }
    return sum;
}

bool are_all_positive(int* arr, int user) {
    for (int i = 0; i < user; i++) {
        if (arr[i] <= 0) { 
            return false;
        }
    }
    return true;
}

int sum_negative(int* arr, int user) {
    int sum = 0;
    for (int i = 0; i < user; i++) {
        if (arr[i] < 0) {
            sum += arr[i];
        }
    }
    return sum;
}

int count_unique_elements(int* arr, int user) {
    int unique_count = 0;

    for (int i = 0; i < user; i++) {
        bool is_unique = true;
        for (int j = 0; j < user; j++) {
            if (i != j && arr[i] == arr[j]) {
                is_unique = false;
                break;
            }
        }
        if (is_unique) {
            unique_count++;
        }
    }
    return unique_count;
}

int main() {
    setlocale(LC_ALL, "RU");
    srand(time(NULL));

    int user;
    

    while(true){
        cout << "Введите количество элементов массива(от 5 до 20): ";
        cin >> user;

        if (user >= 5 && user <= 20) {
            break;
        }
        else {
            cout << "Некорректное количество элементов, повторите еще раз" << endl;
        }
    }

    int* arr = new int[user];

    for (int i = 0; i < user; i++) {
        arr[i] = rand() % 101 - 50;
    }

    cout << endl;
    cout << "Массив: ";

    for (int i = 0; i < user; i++) {
        cout << arr[i];
        if (i < user - 1) {
            cout << ", ";
        }
    }
    cout << endl;
    cout << endl;

    check_even_odd(arr, user);
    check_negative(arr, user);
    cout << "Сума отрицательных элементов: " << sum_negative(arr, user) << endl;
    cout << endl;
    cout << "Количество простых чисел в массиве: " << count_primes(arr, user) << endl;
    cout << endl;
    int min_pos = find_min_positive(arr, user);
    if (min_pos != -1) {
        cout << "Минимальный положительный элемент: " << min_pos << endl;
    }
    else {
        cout << "В массиве нет положительных чисел" << endl;
    }
    cout << endl;
    cout << "Сума элементов на парных индексах: " << sum_even_indices(arr, user) << endl;
    cout << endl;
    if (are_all_positive(arr, user)) {
        cout << "Все элементы є позитивные" << endl;
    }
    else {
        cout << "Не все элементы позитивные" << endl;
    }
    cout << endl;
    cout << "Количество уникальных элементов: " << count_unique_elements(arr, user) << endl;

    delete[] arr;
    return 0;
}
