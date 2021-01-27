#include "BookSorter.h"

bool BookSorter::operator()(Book* prevBook, Book* nextBook)
{
	return (prevBook->getName() < nextBook->getName());
}
