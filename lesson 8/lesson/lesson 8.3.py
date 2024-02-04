a = int(input('Введіть перше число: '))
b = int(input('Введіть друге число: '))
for i in range(a, b+1):
    if i % 2 == 0:
        print(i)