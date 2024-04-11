def is_edge(x, y, length):
    return 0 in (x, y) or length - 1 in (x, y)

def draw_square(length, symbol, is_solid):
    for i in range(length):
        for j in range(length):
            output = '  '
            if is_edge(i, j, length) or is_solid:
                output = f'{symbol} '
            print(output, end='')
        print()

def get_input(text):
    while True:
        user_input = input(text).strip().lower()
        if user_input == 'true':
            return True
        elif user_input == 'false':
            return False
        else:
            print('Ведено недопустиме значення, введіть "true" або "false"')

length = int(input('Введіть сторону квадрата: '))
symbol = input('Введіть символ квадрата: ')
is_solid = get_input('Введіть змінну квадрата (True/False): ')

draw_square(length, symbol, is_solid)