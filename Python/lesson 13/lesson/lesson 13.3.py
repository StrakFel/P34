def line(length, symbol, direction='1'):
    if direction == '1':
        print(symbol * length)
    elif direction == '2':
        for i in range(length):
            print(symbol)

length = int(input('Введіть довжину лінії: '))
symbol = input('Введіть символ: ')
direction = input('Введіть напрямок (1 - horizontal; 2 - vertical): ')

while direction not in ['1', '2']:
    direction = input('Напрямок може бути тільки 1 (horizontal) або 2 (vertical), спробуйте ще раз: ')

print("Лінія:")
line(length, symbol, direction)