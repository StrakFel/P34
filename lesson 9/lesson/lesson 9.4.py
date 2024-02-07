import random
import time
start = time.time()
secret_number = random.randint(1, 500)
attemps = 0
while True:
    number = int(input('Введіть число: '))
    if number == 0:
        print('Ви вийшли з гри')
        attemps += 1
        break
    elif number > secret_number and number <= 500:
        attemps += 1
        print('Ви не вгадали. Загадане число меньше ніж ваше')
    elif number < secret_number and number > 0:
        attemps += 1
        print('Ви не вгадали. Загадане число більше ніж ваше')
    elif number == secret_number:
        attemps += 1
        print('Ви вгадали!')
        break
    else:
        attemps += 1
        print('Веденно неправильне число')
end = time.time()
print(f'Час гри:{round(end - start, 2)} сек')
print(f'Витрачено спроб:{attemps}')