a = input("Введіть рядок: ")
b = True
for i in range(len(a) // 2):
    if a[i] != a[-i - 1]:
        b = False
        break
if b:
    print("Цей рядок є паліндромом")
else:
    print("Цей рядок не є паліндромом")