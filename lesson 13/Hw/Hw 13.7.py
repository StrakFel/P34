def is_palindrome(text):
    for i in range(len(text) // 2):
        if text[i] != text[-i - 1]:
            return False
    return True

text = input('Введіть рядок:')

if is_palindrome(text):
    print("Цей рядок є паліндромом")
else:
    print("Цей рядок не є паліндромом")