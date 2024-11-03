def numbers(a, b):
    if a > b:
        a, b = b, a
    return a, b

a = int(input('Введіть перше число: '))
b = int(input('Введіть друге число: '))

a, b = numbers(a,b)

print(f'Непарні числа між {a} та {b}:')
for i in range(a + 1, b):
    if i % 2 != 0:
        print(i)