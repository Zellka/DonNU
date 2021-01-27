#pragma once
#include "Book.h"

class BookFinder {

private:

	int prevYear_;
	int nextYear_;

public:

	BookFinder(int, int);
	bool operator() (Book*);
};
