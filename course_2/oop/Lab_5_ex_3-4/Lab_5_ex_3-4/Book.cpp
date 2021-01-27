#include "Book.h"

Book::Book()
{
	name_ = " ";
	author_ = " ";
	year_ = 0;
}

Book::Book(string name, string author, int year)
{
	name_ = name;
	author_ = author;
	year_ = year;
}

string Book::getName()
{
	return name_;
}

string Book::getAuthor()
{
	return author_;
}

int Book::getYear()
{
	return year_;
}
