age=int(input('Скільки вам років?:'))
if age <0:
    print('Некоректний вік')
elif age <=3:
    print('Малюк')
elif age <= 11:
    print('Дитина')
elif age <= 18:
    print('Підліток')
elif age <=59:
    print('Дорослий')
elif age <=120:
    print('Пенсіонер')
else:
    print('Некоректний вік')