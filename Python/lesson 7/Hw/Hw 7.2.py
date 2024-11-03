number = int(input('Введіть число: '))
print('a)-Піднесення до 0 степення')
print('b)-Піднесення до 1 степення')
print('c)-Піднесення до 2 степення')
print('d)-Піднесення до 3 степення')
print('e)-Піднесення до 4 степення')
print('f)-Піднесення до 5 степення')
print('g)-Піднесення до 6 степення')
print('h)-Піднесення до 7 степення')
choice = input('Оберіть дію: ')
if choice == 'a':
    print(f'{number}^0={number**0}')
elif choice == 'b':
    print(f'{number}^1={number**1}')
elif choice == 'c':
    print(f'{number}^2={number**2}')
elif choice == 'd':
    print(f'{number}^3={number**3}')
elif choice == 'e':
    print(f'{number}^4={number**4}')
elif choice == 'f':
    print(f'{number}^5={number**5}')
elif choice == 'g':
    print(f'{number}^6={number**6}')
elif choice == 'h':
    print(f'{number}^7={number**7}')
else:
    print('Невірна дія')