#include <iostream>
#include <string>
#include "ILoggable.h"
#include "IShuffle.h"
#include "Summator.h"
#include "Multiplier.h"
#include "CustomExpressionEvaluator.h"

int main()
{
	ExpressionEvaluator* ex[3];

	ex[0] = new Summator(6);
	double* ops_sum = new double[6]{ 2.6, -8.1, 13.2, 1.5, 3.4, -4 };
	ex[0]->setOperands(ops_sum, 6);

	ex[1] = new Multiplier(4);
	double* ops_mult = new double[4]{ -0.5, -8, 1.5, 16 };
	ex[1]->setOperands(ops_mult, 4);

	ex[2] = new CustomExpressionEvaluator(4);
	double* ops_custom = new double[4]{ 50, 40, -10, -2 };
	for(int i = 0; i < 4; ++i)
		ex[2]->setOperand(i, ops_custom[i]);

	for(int i = 0; i < 3; ++i)
	{
		ex[i]->logToScreen();
		ex[i]->logToFile("LogEx.txt");
	}

	for (int i = 0; i < 3; ++i) 
	{
		IShuffle* is = dynamic_cast<IShuffle*>(ex[i]);
		if (is) 
		{
			is->shuffle();
			ex[i]->logToScreen();
		}
	}
	
	for (int i = 0; i < 3; i++)	
		delete ex[i];


	return 0;
}