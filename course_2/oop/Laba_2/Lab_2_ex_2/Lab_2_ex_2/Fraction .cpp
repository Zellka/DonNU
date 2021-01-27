#include "Fraction.h"

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <fstream>

using namespace std;

int Fraction::count = 0;

    Fraction:: Fraction()
	{
		numerator = 1;
		denominator = 1;
        count++;
	}
    Fraction::Fraction(int a, int b)
	{
		numerator = (a != 0) ? a : 1;
		denominator = (b != 0) ? b : 1;
        count++;
	}

    ostream& operator<< (ostream& out, const Fraction& fraction)
    {
        out<< "Перегрузка вывода: "<< fraction.numerator << "/" << fraction.denominator << '\n';
        return out;
    }

    Fraction Fraction:: operator+(Fraction& a)
    {
        if (denominator == a.denominator)
            return  Fraction(numerator + a.numerator, denominator);
        else
            return  Fraction(numerator * a.denominator + a.numerator * denominator, denominator * a.denominator);
    }
    Fraction Fraction:: operator+(int a)
    {
        return  Fraction(numerator + a * denominator, denominator );
    }
    Fraction operator+(const int a, const Fraction& b)
    {
        return  Fraction(a * b.denominator + b.numerator, b.denominator);
    }

    Fraction Fraction:: operator-(Fraction& a)
    {
        if (denominator == a.denominator)
            return  Fraction(numerator - a.numerator, denominator);
        else
            return  Fraction(numerator * a.denominator - a.numerator * denominator, denominator * a.denominator);
    }
    Fraction Fraction::  operator-(int a)
    {
        return  Fraction(numerator - a * denominator, denominator);
    }
   
    Fraction operator-(const int a, const Fraction& b)
    {
        return  Fraction(a * b.denominator - b.numerator, b.denominator);
    }

    Fraction Fraction::  operator*(Fraction& a)
    {
        return  Fraction(numerator * a.numerator, denominator * a.denominator);
    }
    Fraction Fraction::  operator*(int a)
    {
        return  Fraction(numerator * a, denominator * a);
    }
    Fraction operator*(const int a, const Fraction& b)
    {
        return  Fraction(a * b.numerator, a * b.denominator);
    }

    Fraction Fraction:: operator/(Fraction& a)
    {
        return  Fraction(numerator * a.denominator,denominator * a.numerator);
    }
    Fraction Fraction:: operator/(int a)
    {
        return  Fraction(numerator, denominator * a);
    }
    Fraction operator/(const int a, const Fraction& b)
    {
        return  Fraction(a * b.denominator, b.numerator);
    }

    int Fraction:: gcd(int n, int m)
    {
        while (n > 0 && m > 0)
            if (n > m)
                n = n % m;
            else m = m % n;
        return n + m;
    }

    void Fraction::reduce()
    {
        for (int i = 999; i > 0; i--)
        {
            if (numerator % i == 0 && denominator % i == 0)
            {
                numerator /= i;
                denominator /= i;
            }
        }
        cout << numerator << "/" << denominator << endl;
    }
    void Fraction::printAsFraction(double decimal_fraction)
    {
        int temp = gcd(abs(decimal_fraction * 1000000), 1000000);
        int num = (decimal_fraction * 1000000) / temp;
        int den = 1000000 / temp;
        cout << "Перегруженный метод вывода (double)\n" << decimal_fraction << " -> " << num << "/" << den << endl;
    }
    void Fraction::printAsFraction(const char* decimal_fraction)
    {
        double num = atof(decimal_fraction);
        int tmp = gcd(abs(num * 1000000), 1000000);
        num = (num * 1000000) / tmp;
        int den = 1000000 / tmp;
        cout << "Перегруженный метод вывода (char*)\n" << decimal_fraction << " -> " << num << "/" << den << endl;
    }

    void Fraction:: print()
    {
        cout << numerator << "/" << denominator << endl;
    }