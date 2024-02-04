print('Оберіть ваш мобільний оператор: ')
print('1.Vodafone')
print('2.Kyivstar')
print('3.Lifecell')
choice_1 = input('Введіть номер мобільного оператор: ')
if choice_1 == '1':
    your_operator = 'Vodafone'
    operator_1 = 1
elif choice_1 == '2':
    your_operator = 'Kyivstar'
    operator_1 = 2
elif choice_1 == '3':
    your_operator = 'Lifecell'
    operator_1 = 3
else:
    print('Невірний номер оператора')
    exit()
print('Оберіть мобільного оператора на який ви дзовоните: ')
print('1.Vodafone')
print('2.Kyivstar')
print('3.Lifecell')
choice_2 = input('Введіть номер мобільного оператора: ')
if choice_2 == '1':
    someone_operator = 'Vodafone'
    operator_2 = 1
elif choice_2 == '2':
    someone_operator = 'Kyivstar'
    operator_2 = 2
elif choice_2 == '3':
    someone_operator = 'Lifecell'
    operator_2 = 3
else:
    print('Невірний номер оператора')
    exit()
Time_to_call = int(input('Введіть тривалість розмови у хвилинах: '))
if Time_to_call < 0:
    print('Тривалість звінка не може бути негативним')
    exit()
else:
    if operator_1 == operator_2:
        print(f'Вартість розмови з {your_operator} на {someone_operator}: 0 грн.')
    else:
        call_cost = Time_to_call * 0.69
        print(f'Вартість розмови з {your_operator} на {someone_operator}: {call_cost} грн.')