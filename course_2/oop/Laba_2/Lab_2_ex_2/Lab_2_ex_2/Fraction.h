#pragma once

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>

using namespace std;

class Fraction
{
private:
	int numerator,
		denominator;
public:
	static int count; //счётчик кол-ва созданных дробей

	Fraction();
	Fraction(int, int);

	friend ostream& operator<<(ostream& out, const Fraction& fraction); //перугрузка операции вывода

	Fraction operator+(Fraction&); //сложение двух дробей
	Fraction operator+(int);       //сложение дроби и числа
	friend Fraction operator+(const int, const Fraction&); //сложение числа и дроби

	Fraction operator-(Fraction&); //вычитание двух дробей
	Fraction operator-(int);       //вычитание числа из дроби
	friend Fraction operator-(const int, const Fraction&); //вычитание дроби из числа

	Fraction operator*(Fraction&); //умножение двух дробей
	Fraction operator*(int);       //умножение дроби на число
	friend Fraction operator*(const int, const Fraction&); //умножение числа на дробь


	Fraction operator/(Fraction&); //деление двух дробей
	Fraction operator/(int);       //деление дроби на число
	friend Fraction operator/(const int, const Fraction&); //деление числа на дробь

	static int gcd(int, int); //НОД
	void reduce(); //сокращение
	void print();  //вывод на консоль

	static void printAsFraction(double);
	static void printAsFraction(const char*);
};

