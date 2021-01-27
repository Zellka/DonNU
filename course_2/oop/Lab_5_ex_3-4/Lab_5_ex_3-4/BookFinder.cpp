#include "BookFinder.h"

BookFinder::BookFinder(int prevYear, int nextYear)
{
	prevYear_ = prevYear;
	nextYear_ = nextYear;
}

bool BookFinder::operator()(Book* book)
{
	return (prevYear_ < book->getYear() && book->getYear() < nextYear_);;
}
