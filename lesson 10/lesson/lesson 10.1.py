while True:
    name = input('Введіть ваше ім`я:')
    if name.isalpha():
        break
    else:
        print('Введено невірне ім`я')
print(f'Ваше ім`я:{name.capitalize()}')