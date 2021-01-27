#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>


int processArray(int* inArr, size_t n, int a, int b)
{
	printf("ВХОД\n");                   
	for (size_t i = 0; i < n; ++i)            //заполнение исходного массива
	{
		inArr[i] = (i % 2 == 0) ? (rand() % (b - a + 1) + a) : 1;
		printf("%d %s", inArr[i], " ");
	}

	int cnt = 0;
	for (size_t i = 0; i < n; ++i)           //подсчёт кол-ва двузначных чисел
	{
		if ((inArr[i] / 100 == 0) && (inArr[i] / 10 != 0))
			cnt++;
	}
          
	printf("\nВЫХОД\n");                      //заполнение массива двузначных чисел
	int* outArr = new int[cnt];
	for (size_t i = 0; i < n; ++i)
	{
		if ((inArr[i] / 100 == 0) && (inArr[i] / 10 != 0))
		{
			for (int j = 0; j < cnt; ++j)
			{
				outArr[j] = inArr[i];
				printf("%d %s", outArr[j], " ");
				break;
			}
		}
	}
	delete[] outArr;
	return cnt;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	const size_t size = 15;

	int inputArr[size];
	for (size_t i = 0; i < size; ++i) 
		inputArr[i] = 1;

	srand(0);

	int a, b;
	printf("Введите диапазон (а < 0), от а = ");
	scanf_s("%d", &a);
	printf("до b = ");
	scanf_s("%d", &b);

	int cnt = processArray(inputArr, size, a, b);
	printf("%s %d %s", "\nКол-во двузначных элементов: ", cnt, "\n");

	_getch;
	return 0;
}