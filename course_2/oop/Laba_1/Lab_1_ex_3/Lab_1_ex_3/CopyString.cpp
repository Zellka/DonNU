#define _CRT_SECURE_NO_WARNINGS

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <cstring>
//6 вариант

using std::cout;
using std::cin;
using std::endl;

char* stringCopy(char* dest, const char* src, size_t num) 
{
	for (size_t i = 0; i < num; ++i) 
		dest[i] = src[i];

	return dest;
}

int main()
{
	setlocale(LC_ALL, "Russian");

	char src[] = "Everyone could notice that people often complain and say that it was better before.";
	int num = 26;
	char dest_standart[100];
	char dest[100];

	printf("%s", src);
	
	strncpy(dest_standart, src, num);
	dest_standart[num] = '\0';
	printf("%s %s", "\nИспользуя стандартную функцию:", dest_standart);

	stringCopy(dest, src, num);
	dest[num] = '\0';
	printf("%s %s %s", "\nМоя функция:", dest, "\n");

	_getch;
	return 0;
}
