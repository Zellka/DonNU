#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <cmath>

#define PI 3.14159265

using std::cout;
using std::endl;
using std::setw;


void initializeArr(float* arr, size_t size)
{
	for (size_t i = 0; i < size; ++i)
		*(arr + i) = (float)(i * exp((PI * i) / 100));
}
void printArr1D(float* arr, size_t size)
{
	cout <<"Одномерный массив" << endl;
	for (size_t i = 0; i < size; ++i)
		cout << *(arr + i) << " ";
	cout << endl;
}
float** makeArr2D(float* arr1D, size_t n)
{
	float** arr2D = new float* [n]; 
	for (size_t i = 0; i < n; ++i) 
		*(arr2D + i) = new float[n];

	for (size_t i = 0; i < n; ++i)
	{
		for (size_t j = 0; j < n; ++j)
			*(*(arr2D + i) + j) = *(arr1D + i * n + j);
	}

	float tmp;                    //первый элемент на каждой строке должен содержать сумму остальных трех
	for (size_t i = 0; i < n; ++i)
	{
		*(*(arr2D + i) + 0) = 0;
		tmp = *(*(arr2D + i) + 0);
		for (size_t j = 0; j < n; ++j)
			tmp += *(*(arr2D + i) + j);
		*(*(arr2D + i) + 0) = tmp;
	}
	return arr2D;
}

void printArr2D(float** arr, size_t n)
{
	cout << "Двумерный массив" << endl;
	for (int i = 0; i < n; ++i)
	{
		for (int j = 0; j < n; ++j)
			cout << setw(10) << *(*(arr + i) + j);
		cout << endl;
	}
}

void freeArr1D(float* arr)
{
	delete[] arr;
}
void freeArr2D(float** arr, size_t n)
{
	for (size_t i = 0; i < n; ++i) //yдаление каждой строки матрицы
		delete[] arr[i];

	delete[] arr; //yдаление массива строк матрицы
}


int main()
{
	setlocale(LC_ALL, "Russian");

	const size_t size = 16;
	const size_t N = 4;

	float* inputArr = new float[size];
	initializeArr(inputArr, size);

	float** outputArr = makeArr2D(inputArr, N);

	printArr1D(inputArr, size);
	printArr2D(outputArr, N);

	freeArr1D(inputArr);
	freeArr2D(outputArr, N);

	_getch;
	return 0;
}
