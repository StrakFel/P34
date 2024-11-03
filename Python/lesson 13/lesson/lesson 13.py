def show_sum(a, b):
    print(f'{a} + {b} = {a + b}')

def show_diff(a, b):
    print(f'{a} - {b} = {a - b}')

def show_prod(a, b):
    print(f'{a} * {b} = {a * b}')

def show_frac(a, b):
    print(f'{a} / {b} = {a / b}')

a = int(input('Введіть перше число: '))
b = int(input('Введіть друге число: '))

show_sum(a, b)
show_diff(a, b)
show_prod(a, b)
show_frac(a, b)