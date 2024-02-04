a = int(input('Продажі першого менеджера: '))
if a < 500:
    percent_1 = a / 100 * 3
    sum_1_meneger = a + percent_1
elif 500 <= a < 1000:
    percent_1 = a / 100 * 5
    sum_1_meneger = a + percent_1
else:
    percent_1 = a / 100 * 8
    sum_1_meneger = a + percent_1

b = int(input('Продажі другого менеджера: '))
if b < 500:
    percent_2 = b / 100 * 3
    sum_2_meneger = b + percent_2
elif 500 <= b < 1000:
    percent_2 = b / 100 * 5
    sum_2_meneger = b + percent_2
else:
    percent_2 = b / 100 * 8
    sum_2_meneger = b + percent_2

c = int(input('Продажі третього менеджера: '))
if c < 500:
    percent_3 = c / 100 * 3
    sum_3_meneger = c + percent_3
elif 500 <= c < 1000:
    percent_3 = c / 100 * 5
    sum_3_meneger = c + percent_3
else:
    percent_3 = c / 100 * 8
    sum_3_meneger = c + percent_3

bonus_1 = bonus_2 = bonus_3 = 0

if sum_1_meneger > sum_2_meneger and sum_1_meneger > sum_3_meneger:
    bonus_1 = 200
    print('Кращий менеджер: Перший')
elif sum_2_meneger > sum_1_meneger and sum_2_meneger > sum_3_meneger:
    bonus_2 = 200
    print('Кращий менеджер: Другий')
elif sum_3_meneger > sum_1_meneger and sum_3_meneger > sum_2_meneger:
    bonus_3 = 200
    print('Кращий менеджер: Третій')
elif sum_1_meneger == sum_2_meneger == sum_3_meneger:
    bonus_1 = bonus_2 = bonus_3 = 200
    print('Кращі менеджери: Перший, Другий та Третій')
elif sum_1_meneger == sum_2_meneger:
    bonus_1 = bonus_2 = 200
    print('Кращі менеджери: Перший та Другий')
elif sum_1_meneger == sum_3_meneger:
    bonus_1 = bonus_3 = 200
    print('Кращі менеджери: Перший та Третій')
elif sum_2_meneger == sum_3_meneger:
    bonus_2 = bonus_3 = 200
    print('Кращі менеджери: Другий та Третій')

sum_1 = 200 + percent_1 + bonus_1
sum_2 = 200 + percent_2 + bonus_2
sum_3 = 200 + percent_3 + bonus_3

if sum_1 > sum_2 and sum_1 > sum_3:
    print(f'Перший менеджер: Зарплата 200$ + Відсоток від продажів {percent_1} + Премія 200$ = {sum_1}')
    print(f'Другий менеджер: Зарплата 200$ + Відсоток від продажів {percent_2} = {sum_2}')
    print(f'Третій менеджер: Зарплата 200$ + Відсоток від продажів {percent_3} = {sum_3}')
elif sum_2 > sum_1 and sum_2 > sum_3:
    print(f'Перший менеджер: Зарплата 200$ + Відсоток від продажів {percent_1} = {sum_1}')
    print(f'Другий менеджер: Зарплата 200$ + Відсоток від продажів {percent_2} + Премія 200$ = {sum_2}')
    print(f'Третій менеджер: Зарплата 200$ + Відсоток від продажів {percent_3} = {sum_3}')
elif sum_3 > sum_1 and sum_3 > sum_2:
    print(f'Перший менеджер: Зарплата 200$ + Відсоток від продажів {percent_1} = {sum_1}')
    print(f'Другий менеджер: Зарплата 200$ + Відсоток від продажів {percent_2} = {sum_2}')
    print(f'Третій менеджер: Зарплата 200$ + Відсоток від продажів {percent_3} + Премія 200$ = {sum_3}')
elif sum_1 == sum_2 == sum_3:
    print(f'Перший менеджер: Зарплата 200$ + Відсоток від продажів {percent_1} + Премія 200$ = {sum_1}')
    print(f'Другий менеджер: Зарплата 200$ + Відсоток від продажів {percent_2} + Премія 200$ = {sum_2}')
    print(f'Третій менеджер: Зарплата 200$ + Відсоток від продажів {percent_3} + Премія 200$ = {sum_3}')
elif sum_1 == sum_2:
    print(f'Перший менеджер: Зарплата200$ + Відсоток від продажів{percent_1} + Премія 200$={sum_1}')
    print(f'Другий менеджер: Зарплата200$ + Відсоток від продажів{percent_2} + Премія 200$={sum_2}')
    print(f'Третій менеджер: Зарплата200$ + Відсоток від продажів{percent_3}={sum_3}')
elif sum_1 == sum_3:
    print(f'Перший менеджер: Зарплата200$ + Відсоток від продажів{percent_1} + Премія 200$={sum_1}')
    print(f'Другий менеджер: Зарплата200$ + Відсоток від продажів{percent_2}={sum_2}')
    print(f'Третій менеджер: Зарплата200$ + Відсоток від продажів{percent_3} + Премія 200$={sum_3}')
elif sum_2 == sum_3:
    print(f'Перший менеджер: Зарплата200$ + Відсоток від продажів{percent_1}={sum_1}')
    print(f'Другий менеджер: Зарплата200$ + Відсоток від продажів{percent_2} + Премія 200$={sum_2}')
    print(f'Третій менеджер: Зарплата200$ + Відсоток від продажів{percent_3} + Премія 200$={sum_3}')