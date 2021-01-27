#include "Car.h"
#include "Minibus.h"
#include "PassengerCar.h"
#include "IFuelConsumer.h"

#include <conio.h>
#include <iostream>
#include <cstdio>
#include <iomanip>
#include <fstream>
#include <string>


int main() 
{
	setlocale(LC_ALL, "Russian");

	Car* car[4];
	car[0] = new PassengerCar("Ferrari", "250 GTO", 2566, 10000, 1964, 3000);
	car[0]->printInfo();
	car[1] = new PassengerCar("Audi", "Cabriolet", 6155, 12000, 1991, 5000);
	car[1]->printInfo();
	car[2] = new Minibus("Ford", "Tourneo Custom", 7185, 15000, 2008, 1200);
	car[2]->printInfo();
	car[3] = new Minibus("Hyundai", "H350", 3654, 22000, 2012, 1000);
	car[3]->printInfo();

	for (int i = 0; i < 4; ++i)
	{
		IFuelConsumer* ifc = dynamic_cast<IFuelConsumer*>(car[i]);
		if (ifc)
			cout << "Расход топлива на каждые 100 км: " << car[i]->consume(140) << endl << endl;
	}
	for (size_t i = 0; i < 4; ++i)
		cout << typeid(*car[i]).name() << endl;

	for (size_t i = 0; i < 4; ++i)
		delete car[i];

	_getch;

	return 0;
}