a = int(input('Enter a number from 1 to 100: '))
if a < 1 or a > 100:
    print('Invalid number entered')
elif a % 3 == 0 and a % 5 == 0:
    print('Fizz Buzz')
elif a % 3 == 0:
    print('Fizz')
elif a % 5 == 0:
    print('Buzz')
else:
    print(a)