
#include "Matrix.h"
#include "Vector.h"

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <cmath>

using namespace std;


int main()
{
    setlocale(LC_ALL, "Russian");

    Vector arr1D;
    arr1D.initializeArr();
    arr1D.printArr1D();
    arr1D++;
    arr1D.printArr1D();

   
    Matrix arr2D(arr1D.makeArr2D());
    arr2D++;
    arr2D.printArr2D();

    _getch;
    return 0;
}