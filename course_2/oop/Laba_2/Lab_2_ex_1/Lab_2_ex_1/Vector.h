#pragma once
#include <iostream>
#include "Matrix.h"

using namespace std;

#define PI 3.14159265

class Vector 
{
private:

	float* array;
	size_t size = 16;
	size_t N = 4;

public:
	Vector() 
	{
		array = new float[size];
	}
	~Vector() 
	{
		delete[] array;
	}
	float& operator [](int index)const
	{ 
		return array[index]; 
	} 

	Vector& operator++() {
		for (int i = 0; i < size; i++)
			array[i]++;
		return *this;
	}

	Vector& operator--() {
		for (int i = 0; i < size; i++)
			array[i]--;
		return *this;
	}

	Vector& operator++(int a)
	{
		for (int i = 0; i < size; i++)
			array[i]++;
		return * this;
	}
	Vector& operator--(int a)
	{
		for (int i = 0; i < size; i++)
			array[i]--;
		return *this;
	}
	void initializeArr() {

		for (int i = 0; i < size; ++i)
			array[i] = (float)(i * exp((PI * i) / 100));

	}
	void printArr1D()
	{
		cout << "Одномерный массив" << endl;
		for (int i = 0; i < size; ++i)
			cout << array[i] << " ";
		cout << endl;
	}
	float** makeArr2D()
	{
		float** arr2D = new float* [N];
		for (size_t i = 0; i < N; ++i)
			arr2D[i] = new float[N];

		for (size_t i = 0; i < N; ++i)
		{
			for (size_t j = 0; j < N; ++j)
				arr2D[i][j] = array[i * N + j];
		}

		float tmp;                    //первый элемент на каждой строке должен содержать сумму остальных трех
		for (size_t i = 0; i < N; ++i)
		{
			arr2D[i][0] = 0;
			tmp = arr2D[i][0];
			for (size_t j = 0; j < N; ++j)
				tmp += arr2D[i][j];
			arr2D[i][0] = tmp;
		}

		return arr2D;
	}

};
