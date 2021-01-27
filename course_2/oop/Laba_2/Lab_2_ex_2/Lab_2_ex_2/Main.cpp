#include "Fraction.h"

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <fstream>

using namespace std;

void printSum(Fraction a, Fraction b)
{
	cout << "Сумма" << endl;
	Fraction sum1 = a + b;
	sum1.print();
	Fraction sum2 = a + 2;
	sum2.print();
	Fraction sum3 = 2 + b;
	sum3.print();
}
void printDif(Fraction a, Fraction b)
{
	cout << "Разность" << endl;
	Fraction dif1 = a - b;
	dif1.print();
	Fraction dif2 = a - 2;
	dif2.print();
	Fraction dif3 = 2 - b;
	dif3.print();
}
void printMult(Fraction a, Fraction b)
{
	cout << "Произведение" << endl;
	Fraction mult1 = a * b;
	mult1.print();
	Fraction mult2 = a * 10;
	mult2.print();
	Fraction mult3 = 10 + b;
	mult3.print();
}
void printDiv(Fraction a, Fraction b)
{
	cout << "Частное" << endl;
	Fraction div1 = a / b;
	div1.print();
	Fraction div2 = a / 2;
	div2.print();
	Fraction div3 = 2 / b;
	div3.print();
}

int main()
{
	setlocale(LC_ALL, "Russian");

	Fraction a(2, 4);
	Fraction b(2, 6);
	a.print();
	b.print();

	cout << a; //пример работы оператора вывода

	printSum(a, b);
	printDif(a, b);
	printMult(a, b);
	printDiv(a, b);

	cout << "Сокращение" << endl;
	a.reduce();
	b.reduce();

	cout << "Из десятичной в обыкновенную дробь" << endl;
	Fraction pr;
	pr.printAsFraction("0,43");
	pr.printAsFraction(0.75);

	cout << "Количество дробей: " << Fraction::count << endl;
	
	_getch;
	return 0;
}
