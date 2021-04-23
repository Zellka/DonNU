from Fraction import*
from Book import*
from Library import*
from Task3 import*
from StringFormatter import*
from Task5 import*
import wx

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

def task3():

    app = wx.App()
    frame = Task3()
    frame.Show()
    app.MainLoop()

task3()

def task4():

    text = 'Tim1 Pike 19Svetlana23 Leo David56 Charles Jk Cho Lera'

    format = StringFormatter();
    print(text)
    print(format.del_word(text, 5))
    print(format.replace_digit(text))
    print(format.insert_space(text))
    print(format.sort_size(text))
    print(format.sort_alphabet(text))

task4()

def task5():

    app = wx.App()
    frame = Task5()
    frame.Show()
    app.MainLoop()

task5()
