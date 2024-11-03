def min_of_five_numbers(numbers):
    min_num = numbers[0]
    for num in numbers[1:6]:
        if num < min_num:
            min_num = num
    return min_num


numbers = input('Введіть 5 числ(далі вони будуть ігноруватися):')
numbers = [int(num) for num in numbers.split()]
min_number = min_of_five_numbers(numbers)
print(f'Мінімальне число: {min_number}')