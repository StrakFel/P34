a = int(input('Введіть перше число:'))
b = int(input('Введіть дурге число:'))
c = int(input('Введіть третє число:'))
print('1-Сума')
print('2-Добуток')
choice = input('Оберіть дію:')
if choice == '1':
    print('Сума:',a,'+',b,'+',c,'=',a+b+c)
elif choice == '2':
    print('Добуток:',a,'*',b,'*',c,'=',a*b*c)
else:
    print('Невірна дія')