equation = input('Введіть рівняння: ')
if '+' in equation:
    numbers = equation.split('+')
    result = int(numbers[0]) + int(numbers[1])
    print(f'{numbers[0]}+{numbers[1]}={result}')
elif '-' in equation:
    numbers = equation.split('-')
    result = int(numbers[0]) - int(numbers[1])
    print(f'{numbers[0]}-{numbers[1]}={result}')
elif '*' in equation:
    numbers = equation.split('*')
    result = int(numbers[0]) * int(numbers[1])
    print(f'{numbers[0]}*{numbers[1]}={result}')
elif '/' in equation:
    numbers = equation.split('/')
    result = int(numbers[0]) / int(numbers[1])
    print(f'{numbers[0]}/{numbers[1]}={result}')
else:
    print('Недопустимий формат рівняння')