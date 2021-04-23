from Fraction import*

def task1():
    frac = Fraction (7, 2)
    print('Дробь = ', frac)
    print('Унарный минус = ', -frac)
    print('Инверсия = ', ~frac)
    print('Возведение в степень = ', frac**2)
    print('Приведение к float = ', float(frac))
    print('Приведение к int = ', int(frac))

task1()
