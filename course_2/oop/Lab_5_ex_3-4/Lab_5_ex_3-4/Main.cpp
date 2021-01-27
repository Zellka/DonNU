#include <iostream>
#include <conio.h>
#include <vector>
#include <algorithm>

#include "Book.h"
#include "BookSorter.h"
#include "BookFinder.h"

using namespace std;

int main()
{
	setlocale(LC_ALL, "Russian");

	vector<Book*> books;
	books.push_back(new Book("Война и мир", "Толстой Л.Н.", 2010));
	books.push_back(new Book("Подросток", "Достоевский Ф.М.", 2004));
	books.push_back(new Book("Обрыв", "Гончаров И.А.", 2010));
	books.push_back(new Book("Анна Каренина", "Толстой Л.Н.", 1999));
	books.push_back(new Book("Обыкновенная история", "Гончаров И.А.", 2011));
	books.push_back(new Book("Утраченные иллюзии", "Бальзак О.", 2009));
	books.push_back(new Book("Оливер Твист", "Диккенс Ч.", 2001));
	books.push_back(new Book("Фауст", "Гёте И.В.", 2010));
	books.push_back(new Book("Лилия долины", "Бальзак О.", 1998));

	cout << "\x1b[32mКниги в алфавитном порядке:\n\n\x1b[0m";
	BookSorter book_sorter;
	sort(books.begin(), books.end(), book_sorter);
	vector<Book*>::iterator i;
	for (i = books.begin(); i != books.end(); ++i){

		cout << "\x1b[33m" << (*i)->getName() << "\x1b[0m" << "  "
			<< (*i)->getAuthor() << "  " << endl;
	}

	BookFinder book_finder(2009, 2014);
	vector<Book*>::iterator finder = find_if(books.begin(), books.end(), book_finder);
	cout << "\x1b[32m\nКниги в диапазоне года издания 2010 - 2014:\n\n\x1b[0m";
	while (finder != books.end()){

		cout << (*finder)->getName() << "  "
		<< (*finder)->getAuthor() << "  " << "\x1b[31m" << (*finder)->getYear() << "\x1b[0m" << endl;

		finder = std::find_if(++finder, books.end(), book_finder);
	}

	for (i = books.begin(); i != books.end(); ++i) delete (*i);

	_getch;
	return 0;
}