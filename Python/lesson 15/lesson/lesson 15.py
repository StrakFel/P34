def function(count):
    if count <= 0:
        return
    print(f'Hello! {count=}')
    function(count - 1)


def factorial(num):
    if num == 0:
        return 1
    return num * factorial(num -1)

def power(num, degree):
    if degree == 0:
        return 1
    else:
        return num * power(num, degree)


# 5! = 1 * 2 * 3 * 4 * 5
# 4! = 1 * 2 * 3 * 4
# 3! = 1 * 2 * 3

# 5! = 5 * 4!
# 0! = 1

function(10)