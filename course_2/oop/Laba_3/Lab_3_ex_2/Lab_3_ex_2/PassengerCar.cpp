#include "PassengerCar.h"

#include <string>

PassengerCar::PassengerCar() :PassengerCar
(
	" ", " ", 0000, 0.0, 1900, 0
)
{}
PassengerCar::PassengerCar(string firm_car, string model_car, int number_car, int price_car, int year_car, int mileage_car) : Car
(
	firm_car, model_car, number_car, price_car, year_car, mileage_car
)
{}
double PassengerCar::consume(double distance_passed)
{
	return 40*100/distance_passed;
}