import random
import math

#Напишите скрипт, который преобразует введенное с клавиатуры вещественное число в денежный формат. Например, число 12,5 должно
#быть преобразовано к виду «12 руб. 50 коп.». В случае ввода отрицательного числа выдайте сообщение «Некорректный формат!»
#путем обработки исключения в коде. --1

def convert_to_money(num):
    try:
        if num>=0: print(int(num), "руб.", round(num%1*100), "коп.") 
        else: raise Exception
    except Exception:
      print("Некоректный формат")

convert_to_money(float(input("Введите число: ")))

#Написать скрипт, который выводит на экран «True», если элементы программно задаваемого списка представляют собой возрастающую
#последовательность, иначе – «False». --2

def check_increase(list):
    print(False not in (list[i] < list[i+1] for i in range(len(list)-1)))

check_increase([10, 12, 35, 41, 56])

#Напишите скрипт, который позволяет ввести с клавиатуры номер дебетовой карты (16 цифр) и выводит номер в скрытом виде: первые и
#последние 4 цифры отображены нормально, а между ними – символы «*» (например, 5123 **** **** 1212). --3

def hide_numbers(nums):
    print(nums[:4], "**** ****", nums[12:]) if len(nums)==16 else print("Должно быть 16 цифр")

hide_numbers(input("Введите номер дебетовой карты(без пробелов): ")) #"5123456823981212"

#Напишите скрипт, который разделяет введенный с клавиатуры текст на слова и выводит сначала те слова, длина которых превосходит 7
#символов, затем слова размером от 4 до 7 символов, затем – все остальные. --4

def output_word(words):
   words.sort(key=len, reverse=True)
   print(" ".join(words))

output_word(input("Введите предложение: ").split())

#Напишите скрипт, который позволяет ввести с клавиатуры текст предложения и сформировать новую строку на основе исходной, в
#которой все слова, начинающиеся с большой буквы, приведены к верхнему регистру. Слова могут разделяться запятыми или пробелами.
#Например, если пользователь введет строку «город Донецк, река Кальмиус», результирующая строка должна выглядеть так: «город
#ДОНЕЦК, река КАЛЬМИУС». --5

def up_word(words):
    print(" ".join(i.upper() if i[0].isupper() else i for i in words))

up_word(input("Введите предложение: ").split())

#Напишите программу, позволяющую ввести с клавиатуры текст предложения и вывести на консоль все символы, которые входят в этот
#текст ровно по одному разу. --6

def check_frequency(sentence):
    print(" ".join(i for i in sentence if sentence.count(i)==1))

check_frequency(input("Введите предложение: "))

#Напишите скрипт, который обрабатывает список строк-адресов следующим образом: сначала определяет, начинается ли каждая строка
#в списке с префикса «www». Если условие выполняется, то скрипт должен вставить в начало этой строки префикс «http://», а затем
#проверить, что строка заканчивается на «.com». Если у строки другое окончание, то скрипт должен вставить в конец подстроку «.com». В
#итоге скрипт должен вывести на консоль новый список с измененными адресами. Используйте генераторы списков. --7

def change_address(list):

    output_list = [i + ".com" if not i.endswith('.com') else i for i in ["http://" + i if i.startswith('www.') else i for i in list]]
    print("\n".join(output_list))

change_address(["www.tttt.com","nnn.com","www.bbbbb","www.hht", "www.tllt.com"])

#Напишите скрипт, генерирующий случайным образом число n в диапазоне от 1 до 10000. Скрипт должен создать массив из n целых
#чисел, также сгенерированных случайным образом, и дополнить массив нулями до размера, равного ближайшей сверху степени двойки.
#Например, если в массиве было n=100 элементов, то массив нужно дополнить 28 нулями, чтобы в итоге был массив из 28 = 128 элементов
#(ближайшая степень двойки к 100 – это число 128, к 35 – это 64 и т.д.). --8

def generate_array():
    n = random.randrange(1, 10000)
    array = [random.randint(1,100) for i in range(0,n)]
    new_size = 2**math.ceil(math.log2(len(array)))
    for i in range(n,new_size):
        array.append(0)
    print(n, new_size)
   
generate_array()

#Напишите программу, имитирующую работу банкомата. Выберите структуру данных для хранения купюр разного достоинства в заданном
#количестве. При вводе пользователем запрашиваемой суммы денег, скрипт должен вывести на консоль количество купюр подходящего
#достоинства. Если имеющихся денег не хватает, то необходимо напечатать сообщение «Операция не может быть выполнена!».
#Например, при сумме 5370 рублей на консоль должно быть выведено «5*1000 + 3*100 + 1*50 + 2*10». --9

def imitation_bank(money):

    bank_money = {1000: 7, 500: 4, 100: 8, 50: 4, 10: 2}
    output_money = []

    for value, quantity in bank_money.items():
        if money < value * quantity and quantity != 0:
            quantity = money//value
            
        output_money.append((quantity, value))
        money -= value * quantity
        bank_money[value] -= quantity
     
    if money!=0:
        print("Операция не может быть выполнена!")

    [print(f"{i}*{j}", end=" ") for i, j in output_money if money == 0]
    

imitation_bank(int(input("Введите сумму: ")))

#Напишите скрипт, позволяющий определить надежность вводимого пользователем пароля. Это задание является творческим: алгоритм
#определения надежности разработайте самостоятельно. --10

def validation(password):
    if len(password)>9 and not password.isdigit() and password.startswith('!'):
        print("Пароль надёжный")
    else:
        print("Плохой пароль!")


validation(input("Введите пароль: "))

#Напишите генератор frange как аналог range() с дробным шагом. --11

def frange(start, stop, step):
    while start < stop - step:
        yield round(start, 1)
        start += step

[print(i, end = "\n") for i in frange(1, 5, 0.1)]

#Напишите генератор get_frames(), который производит «оконную декомпозицию» сигнала: на основе входного списка генерирует набор
#списков – перекрывающихся отдельных фрагментов сигнала размера size со степенью перекрытия overlap. --12 

def get_frames(signal, size, overlap):
    step = int(size * overlap)
    stop = len(signal) - 1
    for start in range(0, stop, step):
        yield [i for i in signal[start : start + size] ]

[print(frame) for frame in get_frames(range(10),2,0.5)]

#Напишите собственную версию генератора enumerate под названием extra_enumerate. В переменной cum хранится накопленная сумма на момент текущей
#итерации, в переменной frac – доля накопленной суммы от общей суммы на момент текущей итерации. Например, для списка x=[1,3,4,2]
#вывод будет таким: (1, 1, 0.1) (3, 4, 0.4) (4, 8, 0.8) (2, 10, 1). --13

def extra_enumerate(list):
    cum = 0
    frac = 0
    sum_elem = 0
    for i in list:
        sum_elem += i 
    for i in list:
        cum += i
        frac = cum / sum_elem
        yield i, cum, frac

[print((elem, cum, frac), end="  ") for elem, cum, frac in extra_enumerate([1, 3, 4, 2])]

#Напишите декоратор non_empty, который дополнительно проверяет списковый результат любой функции: если в нем содержатся пустые
#строки или значение None, то они удаляются. Пример кода:
#@non_empty
#def get_pages():
 #return ['chapter1', '', 'contents', '', 'line1']. --14

def non_empty(fn):
    def wrapped():
        return list(filter(None, fn()))
    return wrapped


@non_empty
def get_pages():
    return ['chapter1', '', 'contents', '', 'line1']


print(get_pages())

#Напишите параметризированный декоратор pre_process, который осуществляет предварительную обработку (цифровую фильтрацию)
#списка по алгоритму: s[i] = s[i]–a∙s[i–1]. Параметр а можно задать в коде (по умолчанию равен 0.97). --15
    
def pre_process(a):
    def decorator(fn):
        def wrapped(list):
             return  fn([round(list[i]-a*list[i-1],2) for i in range(len(list))])
        return wrapped
    return decorator

@pre_process(0.97)
def plot_signal(list):
    [print(sample) for sample in list]

plot_signal([i for i in range(15)])

#Напишите скрипт, который на основе списка из 16 названий футбольных команд случайным образом формирует 4 группы по 4
#команды, а также выводит на консоль календарь всех игр (игры должны проходить по средам, раз в 2 недели, начиная с 14 сентября
#текущего года). Даты игр необходимо выводить в формате «14/09/2016, 22:45». Используйте модули random и itertools. --16
    
