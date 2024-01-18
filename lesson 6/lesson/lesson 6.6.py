a = int(input('Введіть рік: '))
if a % 400 == 0:
    print(a, 'Високосний рік')
elif a % 4 == 0:
    print(a, 'Високосний рік')
else:
    print(a, 'Звичайний рік')