a = int(input('Введіть кількість годин: '))
if 0 <= a < 6:
    print('Good Night')
elif 6 <= a < 13:
    print('Good Morning')
elif 13 <= a < 17:
    print('Good Day')
elif 17 <= a < 24:
    print('Good Evening')
else:
    print('Недопустима кількість годин')