marks = []
while True:
    mark = int(input('Введіть оцінку: '))
    if mark == 0:
        break
    elif mark < 0:
        print('Недопустима оцніка')
    elif mark > 12:
        print('Недопустима оцніка')
    else:
        marks.append(mark)
print(f'Ващі оцінки:{marks}')