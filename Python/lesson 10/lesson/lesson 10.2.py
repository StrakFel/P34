while True:
    a = input('Введіть своє ім`я:')
    if a.isalpha():
        while True:
            b = input('Введіть своє прізвище:')
            if b.isalpha():
                while True:
                    c = input('Введіть своє по батькові:')
                    if c.isalpha():
                        print(f'Ваш ПІБ: {b.capitalize()} {a.capitalize()} {c.capitalize()}')
                        break
                break
        break