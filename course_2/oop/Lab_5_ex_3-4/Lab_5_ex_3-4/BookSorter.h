#pragma once
#include "Book.h"

class BookSorter {

public:
	bool operator() (Book*, Book*);
};
