# Импорты
import random
import math
import time

# Вспомогательные функции
def create_random_numbers(): # Функция для задавания случайного числа переменных
    num_1 = random.randint(1, 100)
    num_2 = random.randint(1, 100)
    n = random.randint(1, 10)
    x = random.randint(1, 100)
    y = random.randint(1, 10)
    num = random.randint(1, 1000)
    return num_1, num_2, n, x, y, num


def check_numbers(num_1, num_2, x, y): # Функция для проверки пар чисел
    num_1, num_2 = max(num_1, num_2), min(num_1, num_2)
    x, y = max(x, y), min(x, y)
    return num_1, num_2, x, y


def generate_with_limit(): # Функция для соединения функций create_random_numbers и check_numbers
    num_1, num_2, n, x, y, num = create_random_numbers()
    num_1, num_2, x, y = check_numbers(num_1, num_2, x, y)
    return num_1, num_2, n, x, y, num


def quit_program(): # Функция для выхода из програмы
    end = time.time()
    print(f'\nВремя игры: {round(end - start, 2)} \n')
    print('Удачи!')
    exit()


def menu_program(): # Функция для выход в меню програмы
    print('Спасио за игру!')
    end = time.time()
    print(f'\nВремя игры: {round(end - start, 2)} секунд')


def fail_progam(score, rounds): # Функция для окончания игры поражением
    end = time.time()
    equation_time = round(end - start, 2)
    print('\n  ИГРА ОКОНЧЕНА!')
    print(f'Счёт:{score}')
    print(f'Время игры: {equation_time} секунд')
    print(f'Среднее время решения уравнения: {round(equation_time / rounds)} секунд')


def display_menu(): # Функция дял показа меню
    print('\n1 - тренировка с плюсом')
    print('2 - тренировка с минусом')
    print('3 - тренировка с умножением')
    print('4 - тренировка с делением')
    print('5 - тренировка со всеми стандартными уравнениями')
    print('6 - тренировка для мастеров')
    print('7 - ALL IN!')
    print('0 - Выйти из программы\n')


def value_equation(user_choice):
    if user_choice == '1':
        return create_equation_plus()
    elif user_choice == '2':
        return create_equation_minus()
    elif user_choice == '3':
        return create_equation_multiplication()
    elif user_choice == '4':
        return create_equation_division()
    elif user_choice == '5':
        return create_equation_multi()
    elif user_choice == '6':
        return create_equation_masters()
    elif user_choice == '7':
        return create_equation_all_in()


# Функции для мастеров
def create_equation_factorial(n): # Функция факториала
    if n == 0:
        return 1
    else:
        return n * create_equation_factorial(n - 1)



def create_equation_subfactorial(n): # Функция субфакториала
    equation_result = 0
    for k in range(n + 1):
        equation_result += (-1) ** k / math.factorial(k)
    return round(math.factorial(n) * equation_result)


def create_equation_power(x, y): # Функция воспроизведения в степень
    power_result = 1
    for i in range(y):
        power_result *= x
    return power_result


def create_equation_square_root(num): # Функция для воспроизведения числа в корень
    square_roots = [math.isqrt(i) for i in range(1, 1001)]
    value = random.choice(square_roots)
    return value


# Функции для создания уравнения
def create_equation_plus(): # Функция для тренировки с плюсом
    num_1, num_2, _, _, _, _ = generate_with_limit()
    equation_print = f'{num_1} + {num_2}'
    equation_result = num_1 + num_2
    return equation_print, equation_result


def create_equation_minus(): # Функция для тренировки с минусом
    num_1, num_2, _, _, _, _ = generate_with_limit()
    equation_print = f'{num_1} - {num_2}'
    equation_result = num_1 - num_2
    return equation_print, equation_result


def create_equation_multiplication(): # Функция для тренировки с умножением
    num_1, num_2, _, _, _, _ = generate_with_limit()
    equation_print = f'{num_1} * {num_2}'
    equation_result = num_1 * num_2
    return equation_print, equation_result


def create_equation_division(): # Функция для тренировки с вычитанием
    while True:
        num_1, num_2, _, _, _, _ = generate_with_limit()
        if num_1 % num_2 == 0:
            equation_print = f'{num_1} / {num_2}'
            equation_result = int(num_1 / num_2)
            return equation_print, equation_result


# Функции с несколькоми уравнениями
def create_equation_multi(): # Функция для тренировки со всеми класическими арифметическими уравниями(+, -, *, /)
    num_1, num_2, _, _, _, _ = generate_with_limit()
    operations = random.choice(['+', '-', '*', '/'])
    if operations == '+':
        equation_print = f'{num_1} + {num_2}'
        equation_result = num_1 + num_2
    elif operations == '-':
        equation_print = f'{num_1} - {num_2}'
        equation_result = num_1 - num_2
    elif operations == '*':
        equation_print = f'{num_1} * {num_2}'
        equation_result = num_1 * num_2
    else:
        equation_print = f'{num_1} / {num_2}'
        equation_result = create_equation_division()
    return equation_print, equation_result


def create_equation_masters(): # Функция для тренировки со сложными арифметическими уровнениями
    _, _, n, x, y, num = generate_with_limit()
    operations = random.choice(['! ', ' !', '^', '√'])  #'! ' - factorial, ' !' - subfactorial, '^' - степень
    if operations == '! ':
        equation_print = f'!{n}'
        equation_result = create_equation_factorial(n)
    elif operations == ' !':
        equation_print = f'{n}!'
        equation_result = create_equation_subfactorial(n)
    elif operations == '^':
        equation_print = f'{x}^{y}!'
        equation_result = create_equation_power(x, y)
    elif operations == '√':
        equation_print = f'√{num}'
        equation_result = create_equation_square_root(num)
    return equation_print, equation_result


def create_equation_all_in(): # Функция для тренировки со всеми арифметическими уравнениями
    num_1, num_2, _, _, _, _ = generate_with_limit()
    operations = random.choice(['+', '-', '*', '/', '! ', ' !', '^', '√'])
    if operations in ['+', '-', '*', '/']:
        return create_equation_multi()
    else:
        return create_equation_masters()

# Функция для проверки
def check(user, equation_print, equation_result): # Функция для проверки правильности ответа пользывателя
    equation_print, equation_result = equation_result, equation_print
    if user == equation_result:
        print('  Верно!')
        return True
    else:
        print(f'    Ошибка! {equation_print} = {equation_result}')
        return False



# Основной блок
print('Я вас приветствую! Выберите режим:')
while True: # Меню
    score = 0 # Счёт
    rounds = 0 # Переменная для ращета среднего времени
    lives = 3 # жизни пользывателя
    display_menu()
    user_choice = input('Ваш выбор: ')
    if user_choice == '0':
        print('\nУдачи!')
        exit()
    elif user_choice in ['1', '2', '3', '4', '5', '6', '7']:
        equation_print, equation_result = value_equation(user_choice)
    else:
        print('Вы ввели неверный выбор. Пожалуйста, выберите число от 1 до 7 или 0 для выхода.')
        continue
    start = time.time()
    last_equation_result = None # Установка начального значения предыдущего результата уравня как нету(None)
    while True: # Игра("тренировка")
        if equation_result == last_equation_result:
            equation_print, equation_result = create_equation_plus()
        user = input(f'{equation_print} = ')
        if user.lower() == 'quit' or user.lower() == 'stop':
            quit_program()
        elif user.lower() == 'menu':
            menu_program()
            break
        try:
            user = int(user)
        except ValueError:
            print('Введено некорректное значение. Введите целое число, "quit" для завершения игры или "menu" для возращения в меню.')
            continue
        equation_print, equation_result = equation_result, equation_print # Переворот переменных(если так не сделать код не будет правильно работать)
        if check(user, equation_print, equation_result):
            score += 1
            rounds += 1
            print(f'Счёт: {score}')
            print(f'Осталось жизней: {lives}')
        else:
            lives -= 1
            rounds += 1
            print(f'Счёт: {score}')
            print(f'Осталось жизней: {lives}')
            if lives <= 0:
                fail_progam(score, rounds)
                break
        last_equation_result = equation_result
        equation_print, equation_result = equation_result, equation_print
        while True:  # Проверка условия для генерации нового уравнения
            equation_print, equation_result = value_equation(user_choice)
            if equation_result != last_equation_result:
                break