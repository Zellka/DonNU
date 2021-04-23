from Fraction import*
from Book import*
from Library import*
from StringFormatter import*

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

def task4():

    text = 'Tim1 Pike 19Svetlana23 Leo David56 Charles Jk Cho Lera'

    format = StringFormatter(text);
    print(text)
    print(format.del_word(5))
    print(format.replace_digit())
    print(format.insert_space())
    print(format.sort_size())
    print(format.sort_alphabet())

task4()
