def is_int(num):
    return num.isnumeric() or num[0] in ('+', '-') and num[1:].isnumeric()


def input_list(message=''):
    while True:
        raw_list = input(message).split()
        list = [int(num) for num in raw_list if is_int(num)]
        if not list:
            print('Некоректний список чисел! Введіть ще раз.')
        else:
            return list


def bubble_sort(list):
    while True:
        is_changed = False
        for i in range(len(list) - 1):
            if list[i] > list[i + 1]:
                list[i], list[i + 1] = list[i + 1], list[i]
                is_changed = True
        if not is_changed:
            break


numbers = input_list('Введіть список чисел через пробіл:')
print(numbers)
bubble_sort(numbers)
print(numbers)