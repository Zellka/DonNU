#pragma once

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <cmath>

using namespace std;


class Matrix
{
private:
	float** matrix;
	size_t N = 4;
	int a;

public:
	Matrix(float** arr2D)
	{
		//выделение динам. памяти
		matrix = new float*[N];
		for (int i = 0; i < N; i++)
			matrix[i] = new float[N];

		matrix = arr2D;
	}
	~Matrix()
	{
		//освобождение динам. памяти
		for (size_t i = 0; i < N; ++i) //yдаление каждой строки матрицы
			delete[] matrix[i];

		delete[] matrix; //yдаление массива строк матрицы
	}

	float at(int i, int j) const 
	{
		return matrix[i][j];
	}

	void setAt(int i, int j, float value) 
	{
		matrix[i][j] = value;
	}

	Matrix& operator++() 
	{
		for (int i = 0; i < N; i++)
			for (int j = 0; j < N; j++)
				matrix[i][j]++;
		return *this;
	}

	Matrix& operator--() 
	{
		for (int i = 0; i < N; i++)
			for (int j = 0; j < N; j++)
				matrix[i][j]--;
		return *this;
	}

	Matrix& operator++(int a)
	{
		return ++ *this;
	}
	Matrix& operator--(int a)
	{
		return -- * this;
	}
	void printArr2D()
	{
		cout << "Двумерный массив" << endl;
		for (int i = 0; i < N; ++i)
		{
			for (int j = 0; j < N; ++j)
				cout << setw(10) << matrix[i][j];
			cout << endl;
		}
	}
};
