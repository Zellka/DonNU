from Fraction import*
from Book import*
from Library import*

def task1():
    frac = Fraction (7, 2)
    print('Дробь = ', frac)
    print('Унарный минус = ', -frac)
    print('Инверсия = ', ~frac)
    print('Возведение в степень = ', frac**2)
    print('Приведение к float = ', float(frac))
    print('Приведение к int = ', int(frac))

task1()

def task2():

    lib = Library(1, '51 Some str., NY')
    lib += Book.Book('Leo Tolstoi', 'War and Peace')
    lib += Book.Book('Charles Dickens', 'David Copperfield')

    for book in lib:
        print(book._id)
        print(book)
        print(book.tag())

task2()
