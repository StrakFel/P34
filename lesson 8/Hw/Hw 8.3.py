start = int(input('Введіть початок діапазону: '))
end = int(input('Введіть кінець діапазону: '))
print(f'Аналіз чисел в діапазоні чисел від {start} до {end}:')
for i in range(start, end + 1):
    if i % 3 == 0 and i % 5 == 0:
        print('Fizz Buzz')
    elif i % 3 == 0:
        print('Fizz')
    elif i % 5 == 0:
        print('Buzz')
    else:
        print(i)