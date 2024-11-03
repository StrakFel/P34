def factorial(a, b):
    if a > b:
        a, b = b, a
    result = 1
    for i in range(a, b + 1):
        result *= i
    return result


a = int(input('Введіть перше число: '))
b = int(input('Введіть друге число: '))

result = factorial(a, b)

if a < b:
    print(f'Факторіал між числами {a} и {b} дорівнює: {result}')
else:
    print(f'Факторіал між числами {b} и {a} дорівнює: {result}')


