my_list = []

while True:
    number = input("Введіть число (0 завершення вводу): ")
    if number == '0':
        break
    else:
        numbers = number.split()
        for num in numbers:
            my_list.append(int(num))

found_number = int(input("Введіть число яке потрібно знайти: "))

number_1 = my_list.count(found_number)

print(f"Кількість {found_number} у вашому списку: {number_1}")