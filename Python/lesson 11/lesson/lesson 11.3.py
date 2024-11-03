numbers = []

numbers_1 = input("Введіть елементи списку цілих чисел: ")

for num in numbers_1.split():
    numbers.append(int(num))

total = sum(numbers)
average = total / len(numbers)

print(f"Сума всіх елементів списку: {total}")
print(f"Середнє арифметичне: {average}")