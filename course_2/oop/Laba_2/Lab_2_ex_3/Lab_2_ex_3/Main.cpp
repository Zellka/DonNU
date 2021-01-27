#include "Car.h"

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <fstream>
#include <string>

using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	Car car("Ferrari", "250 GTO", 2566, 10000, 1964, 3000);
	car.Imitation();

	Car my_car[3] = { Car(), Car(), Car() };

	my_car[0].setFirm("Audi");
	my_car[0].setModel("Cabriolet");
	my_car[0].setNumber(6155);
	my_car[0].setPrice(12000);
	my_car[0].setYear(1991);
	my_car[0].setMileage(5000);
	my_car[0].Imitation();

	my_car[1].setFirm("BMW");
	my_car[1].setModel("M2");
	my_car[1].setNumber(2659);
	my_car[1].setPrice(11000);
	my_car[1].setYear(2015);
	my_car[1].setMileage(30);
	my_car[1].Imitation();

	my_car[2].setFirm("Chevrolet");
	my_car[2].setModel("Impala");
	my_car[2].setNumber(8003);
	my_car[2].setPrice(8000);
	my_car[2].setYear(1967);
	my_car[2].setMileage(20000);
	my_car[2].Imitation();

	Car list_car[] = {car, my_car[0], my_car[1], my_car[2] };
	Car::printSortInfo(list_car);
	car.serialize();

	_getch;
	return 0;
}
