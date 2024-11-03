a = int(input('Введіть перше число: '))
b = int(input('Введіть друге число: '))
if a > b:
    for i in range(b, a + 1):
        if i % 2 != 0:
            print(i)
elif a < b:
    for i in range(a, b + 1):
        if i % 2 != 0:
            print(i)
else:
    for i in range(a, b + 1):
        if i % 2 != 0:
            print(i)
        else:
            print(i)