import random

numbers = [random.randint(-50, 50) for i in range(10)]

sum_negative = 0
sum_doubles = 0
sum_unpaired = 0

for num in numbers:
    if num < 0:
        sum_negative += num
        if num % 2 == 0:
            sum_doubles += num
    elif num % 2 == 0:
        sum_doubles += num
    else:
        sum_unpaired += num

print(f'Список чисел: {numbers}')
print(f'Сума від`ємних чисел: {sum_negative}')
print(f'Сума парних чисел: {sum_doubles}')
print(f'Сума непарних чисел: {sum_unpaired}')