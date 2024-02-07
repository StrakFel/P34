a = int(input('Введіть перше число діапазону: '))
b = int(input('Введіть друге число діапазону: '))
c = int(input('Введіть яке буде в  діапазоні: '))
while c < a or c > b:
    print('Число не потрапляє у діапазон')
    c = int(input('Введіть число ще раз: '))
print('Число у діапазоні:')
for i in range(a, b + 1):
    if i == c:
        print(f'!{i}!', end=' ')
    else:
        print(i, end=' ')