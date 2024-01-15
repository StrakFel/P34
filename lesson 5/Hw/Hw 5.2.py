a = int(input('Введіть перше число: '))
b = int(input('Введіть друге число: '))
c = int(input('Введіть третє число: '))
print('1 - Максимальне число')
print('2 - Мінімальне число')
print('3 - Середньоарифметичне')
choice = input('Оберіть дію: ')
if choice == '1':
    if a >= b and a >= c:
        result = a
    elif b >= a and b >= c:
        result = b
    else:
        result = c
    print('Максимальне число:', result)
elif choice == '2':
    if a <= b and a <= c:
        result = a
    elif b <= a and b <= c:
        result = b
    else:
        result = c
    print('Мінімальне число:', result)
elif choice == '3':
    result = (a + b + c) / 3
    print('Середньоарифметичне:', result)
else:
    print('Невірна дія')