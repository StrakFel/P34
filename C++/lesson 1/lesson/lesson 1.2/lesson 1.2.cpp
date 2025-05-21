#include <iostream>
#include <windows.h>
#include <cstdlib>

using namespace std;

void WriteArray(int n, int* arr) {
	for (int i = 0; i < n; i++) {
		cout << "Введіть " << i + 1 << " число: ";
		cin >> arr[i];
	}
}

void PrintArray(int n, int* arr) {
	cout << "Ваш масив: ";
	for (int i = 0; i < n; i++) {
		cout << arr[i] << " ";
	}
	cout << endl;
}

double ArithmeticMean(int n, int* arr) {
	int sum = 0;
	for (int i = 0; i < n; i++) {
		sum += arr[i];
	}
	return static_cast<double>(sum) / n;
}

int MinArray(int n, int* arr) {
	int min = arr[0];
	for (int i = 1; i < n; i++) {
		if (arr[i] < min) {
			min = arr[i];
		}
	}
	return min;
}

int MaxArray(int n, int* arr) {
	int max = arr[0];
	for (int i = 1; i < n; i++) {
		if (arr[i] > max) {
			max = arr[i];
		}
	}
	return max;
}

int EvenNumbers(int n, int* arr) {
	int count = 0;
	for (int i = 0; i < n; i++) {
		if (arr[i] % 2 == 0) {
			count++;
		}
	}
	return count;
}

void RandArray() {
	int randArr[10];
	for (int i = 0; i < 10; i++) {
		randArr[i] = rand() % 100 + 1;
	}
	cout << "Рандомний массив: ";
	for (int i = 0; i < 10; i++) {
		cout << randArr[i] << " ";
	}
	cout << endl;
	cout << "Цей же массив у зворотному порядку: ";
	for(int i = 9; i >= 0; i--) {
		cout << randArr[i] << " ";
	}
}

int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	
	int n;
	cout << "Напишіть кількість елементів масиву: ";
	cin >> n;
	int* arr = new int[n];

	WriteArray(n, arr);
	cout << endl;
	PrintArray(n, arr);

	double average = ArithmeticMean(n, arr);
	cout << "Середнє арифметичне вашого масиву: " << average << endl;

	int min = MinArray(n, arr);
	int max = MaxArray(n, arr);
	cout << "Максимальне число: " << max << ", мінімальне: " << min << endl;

	int evenNum = EvenNumbers(n, arr);
	cout << "Кількість парних чисел у вашому массиві: " << evenNum << endl << endl;

	srand(time(0));
	RandArray();

	delete[] arr;
	return 0;
}

