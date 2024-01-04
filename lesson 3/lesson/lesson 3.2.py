number = int(input('Введіть тризначне число:'))
a = number // 100
b = number // 10 % 10
c = number % 10
print(a)
print(b)
print(c)
print(a*b*c)