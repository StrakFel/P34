a = int(input('Введіть число: '))
b = 1
while True:
    print(a,'*' ,b, '=',a*b)
    b += 1
    if b > 9:
        break