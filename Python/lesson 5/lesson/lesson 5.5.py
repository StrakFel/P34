a = int(input('Введіть перше число:'))
b = int(input('Введіть дурге число:'))
print('1-Сума')
print('2-Різниця')
print('3-Середньоарифметичне')
print('4-Добуток')
choice = input('Оберіть дію:')
if choice == '1':
    print('Сума:' ,a, '+' ,b, '=' ,a+b)
elif choice == '2':
    print('Різниця:',a, '-' ,b, '=' ,a-b)
elif choice == '3':
    print('Середньоарифметичне:''(', a, '+', b, ')' '/2' '=', (a + b) / 2)
elif choice == '4':
    print('Добуток:',a, '*' ,b, '=' ,a*b)
else:
    print('Невірна дія')