print('1 - Завдання 1')
print('2 - Завдання 3')
print('3 - Завдання 3')
print('4 - Завдання 4')
print('5 - Завдання 5')
choice = input('Оберіть завдання: ')
while True:
    if choice == '1':
        task1_a = input('Введіть рядок: ')
        print(f'Перевернутий рядок: {task1_a[::-1]}')
        break
    elif choice == '2':
        task2_a = input('Введіть рядок: ')
        print(f'Кількість символів у рядку: {len(task2_a)}')
        break
    elif choice == '3':
        task3_a = input('Введіть рядок: ')
        task3_b = input('Введіть символ який хочете найти: ')
        print(f'Кількість {task3_b} у рядку: {task3_a.lower().count(task3_b.lower())}')
        break
    elif choice == '4':
        