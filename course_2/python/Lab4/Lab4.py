from Task6 import *

#С помощью модуля numPy реализуйте следующие операции: 
#1) умножение произвольных матриц А (размерности 3х5) и В (5х2); 
#2) умножение матрицы (5х3) на трехмерный вектор; 
#3) решение произвольной системы линейных уравнений; 
#4) расчет определителя матрицы; 
#5) получение обратной и транспонированной матриц.
#Также продемонстрируйте на примере матрицы 5х5 тот факт, что определитель равен произведению собственных значений матрицы.

def task6():

    matrix_multiplication()
    vector_multiplication()
    linear_equation()
    det_matrix()
    inverse_matrix()
    transposed_matrix()

task6()