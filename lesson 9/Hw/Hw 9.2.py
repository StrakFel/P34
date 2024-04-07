import random
random_list = [random.randint(-100, 100) for i in range(10)]
min_elements = min(random_list)
max_elements = max(random_list)
negative_elements = 0
positive_elements = 0
zero_elements = 0
for num in random_list:
    if num < 0:
        negative_elements += 1
    elif num > 0:
        positive_elements += 1
    else:
        zero_elements += 1
print('Список:', random_list)
print('Мінімальний елемент:', min_elements)
print('Максимальний елемент:', max_elements)
print('Кількість від`ємних елементів:', negative_elements)
print('Кількість додатніх елементів:', positive_elements)
print('Кількість нулів:', zero_elements)