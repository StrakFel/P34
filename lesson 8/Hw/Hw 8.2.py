start = int(input('Введіть початок діапазону: '))
end = int(input('Введіть кінець діапазону: '))

print('Всі числа діапазону:')
for i in range(start, end + 1):
    print(i, end=' ')
print()

print('Всі числа діапазону у спадному порядку: ')
for i in range(end, start - 1, -1):
    print(i, end=' ')
print()

print('Числа якы кратні 7 у цьому діапазоні: ')
for i in range(start, end + 1):
    if i % 7 == 0:
        print(i, end=' ')
print()

print('Числа що кратні 5 у цьому діапазоні: ')
for i in range(start, end + 1):
    if i % 5 == 0:
        print(i, end=' ')
print()