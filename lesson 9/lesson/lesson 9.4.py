import random
import time
start = time.time()
secret_number = random.randint(1, 500)
attemps = 0
while True:
    number = int(input('Введіть число: '))
    attemps += 1
    if number == 0:
        print('Ви вийшли з гри')
        break
    elif number > secret_number and number <= 500:
        print('Ви не вгадали. Загадане число меньше ніж ваше')
    elif number < secret_number and number > 0:
        print('Ви не вгадали. Загадане число більше ніж ваше')
    elif number == secret_number:
        print('Ви вгадали!')
        break
    else:
        print('Веденно неправильне число')
end = time.time()
print(f'Час гри:{round(end - start, 2)} сек')
print(f'Витрачено спроб:{attemps}')