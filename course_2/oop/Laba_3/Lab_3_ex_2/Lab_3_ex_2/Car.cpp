#include "Car.h"

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <fstream>
#include <string>

using namespace std;

int Car::count = 0;

Car::Car()
{
	firm = " ";
	model = " ";
	number = 0000;
	price = 0.0;
	year = 1900;
	mileage = 0;
	count++;
}
Car::Car(string firm_car, string model_car, int number_car, int price_car, int year_car, int mileage_car)
{
	firm = firm_car;
	model = model_car;
	number = number_car;
	price = price_car;
	year = year_car;
	mileage = mileage_car;
	count++;
}

double Car::consume(double distance_passed)
{
	return 0.0;
}


void Car::setFirm(const string firm_) { firm = firm_; }
void Car::setModel(const string model_) { model = model_; }
void Car::setNumber(const int number_) { number = number_; }
void Car::setPrice(const double price_) { price = price_; }
void Car::setYear(const int year_) { year = year_; }
void Car::setMileage(const int mileage_) { mileage = mileage_; }

string Car::getFirm() { return firm; }
string Car::getModel() { return model; }
int Car::getNumber() { return number; }
double Car::getPrice() { return price; }
int Car::getYear() { return year; }
int Car::getMileage() { return mileage; }

void Car::Imitation()
{
	cout << "\nМашина: " << firm << ", " << model << endl;
	cout << "Пробег: " << mileage << endl;
	cout << "\nПоехали..." << endl;

	distance = rand() % (3000 - 600 + 1) + 600;
	mileage += distance;
	cout << "\nПроехали: " << distance << " км." << endl;
	cout << "Пробег: " << mileage << endl;
	cout << "-----------------------------" << endl;
}

Car* Car::Sort(Car* c)
{
	int left = 1;
	int right = c->count - 1;
	do
	{
		for (int i = right; i >= left; i--)
		{
			if (c[i - 1].mileage < c[i].mileage)
			{
				Car tmp = c[i];
				c[i] = c[i - 1];
				c[i - 1] = tmp;
			}
		}
		left++;
		for (int i = left; i <= right; i++)
		{
			if (c[i - 1].mileage < c[i].mileage)
			{
				Car tmp = c[i];
				c[i] = c[i - 1];
				c[i - 1] = tmp;
			}
		}
		right--;
	} while (left <= right);

	return c;
}


void Car::printSortInfo(Car* cars)
{
	system("pause");
	system("cls");
	cout << "Отсортированный список (пробег по убыванию)" << endl;
	Sort(cars);
	for (int i = 0; i < cars->count; i++)
		cars[i].printInfo();
}

void Car::serialize(const string& filename) const
{
	system("cls");

	ofstream out(filename);

	if (out.is_open())
	{
		out << endl;
		out << "Фирма: " << firm << endl;
		out << "Модель: " << model << endl;
		out << "Номер: " << number << endl;
		out << "Цена: " << price << endl;
		out << "Год выпуска: " << year << endl;
		out << "Пробег: " << mileage << endl;
	}
	out.close();

	cout << "Данные успешно сохранены" << endl;
}
void Car::deserialize(const string& filename)
{
	cout << "\nСчитываем данные..." << endl;
	string line;
	ifstream in(filename);
	if (in.is_open()) {
		while (getline(in, line))
			cout << line << endl;
	}

}
void Car::serialize() const
{
	ofstream out("car.txt");

	if (out.is_open()) {
		out << endl;
		out << "Фирма: " << firm << endl;
		out << "Модель: " << model << endl;
		out << "Номер: " << number << endl;
		out << "Цена: " << price << endl;
		out << "Год выпуска: " << year << endl;
		out << "Пробег: " << mileage << endl;
	}
	out.close();

	cout << "Данные успешно сохранены" << endl;
}
void Car::deserialize()
{
	cout << "\nСчитываем данные..." << endl;
	string line;
	ifstream in("car.txt");
	if (in.is_open()) {
		while (getline(in, line)) {
			cout << line << endl;
		}
	}
}
void Car::printInfo()
{
	cout << endl;
	cout << "Фирма: " << firm << endl;
	cout << "Модель: " << model << endl;
	cout << "Номер: " << number << endl;
	cout << "Цена: " << price << " $" << endl;
	cout << "Год выпуска: " << year << " г." << endl;
	cout << "Пробег: " << mileage << " км." << endl;
}