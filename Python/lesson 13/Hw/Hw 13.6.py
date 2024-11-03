def count_digits(number):
    count = 0
    while number != 0:
        count += 1
        number //= 10
    return count


number = int(input('Введіть число:'))
print("Кількість цифр у числі", number, ":", count_digits(number))