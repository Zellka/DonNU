import numpy as np
from numpy import linalg as LA
import math


def gilbert(n):
    matrix=[[]]*n
    for i in range(n):
        for j in range(n):
            el = math.pow((i+j+1),-1)
            matrix[i].append(el)
    return matrix


print(LA.cond(gilbert(7)))
