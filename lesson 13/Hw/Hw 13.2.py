def find_paired_numbers(a, b):
    if a > b:
        a, b = b, a
    return a, b

a = int(input('Введіть перше число: '))
b = int(input('Введіть друге число: '))

a, b = find_paired_numbers(a,b)

print(f'Парні числа між {a} та {b}:')
for num in range(a, b + 1):
    if num % 2 == 0:
        print(num)