a = int(input('Введіть шестизначне число: '))
num_6 = a % 10
num_5 = a // 10 % 10
num_4 = a // 100 % 10
num_3 = a // 1000 % 10
num_2 = a // 10000 % 10
num_1 = a // 100000 % 10
if 100000 > a or a > 999999:
    print('Введено недопустиме число')
else:
    result=(num_6 * 100000 + num_5 * 10000 + num_3 * 1000 + num_4 * 100 + num_2 * 10 + num_1)
    print(result)