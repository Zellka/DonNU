#pragma once

#include "Car.h";
#include "IFuelConsumer.h";


class PassengerCar : public IFuelConsumer, public Car
{
public:
	PassengerCar();
	PassengerCar(string firm_car, string model_car, int number_car, int price_car, int year_car, int mileage_car);
	

	double consume(double distance_passed) override;
};


