#pragma once
#include <string>
using namespace std;

class Book {

private:
	string name_;
	string author_;
	int year_;

public:

	Book();
	Book(string, string, int);
	string getName();
	string getAuthor();
	int getYear();
};
