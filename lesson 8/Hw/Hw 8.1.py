start = int(input('Введіть початок діапазону: '))
end = int(input('Введіть кінець діапазону: '))
print('Числа кратні 7 у вашомі діапазоні:')
for i in range(start, end + 1):
    if i % 7 == 0:
        print(i)