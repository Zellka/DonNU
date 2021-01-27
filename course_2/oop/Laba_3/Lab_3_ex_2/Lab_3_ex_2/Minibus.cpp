#include "Minibus.h"

#include <string>

Minibus::Minibus():Minibus
(
	" ", " ", 0000, 0.0, 1900, 0
)
{}
Minibus::Minibus(string firm_car, string model_car, int number_car, int price_car, int year_car, int mileage_car): Car
(
	firm_car, model_car, number_car, price_car, year_car, mileage_car
)
{}
double Minibus::consume(double distance_passed) 
{
	return 60*100/distance_passed;
}