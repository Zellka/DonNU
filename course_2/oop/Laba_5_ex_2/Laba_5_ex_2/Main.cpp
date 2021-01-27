#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <map>
#include <fstream>
#include <string>
#include <algorithm>
#include <conio.h>

using namespace std;

map<string, int> readFile(map<string, int> map, std::map<string, int>::iterator iter);
multimap<int, string, greater<>> createOutMap(map<string, int> map, std::map<string, int>::iterator iter);
void printData(multimap<int, string, greater<>> outMap);

int main() {
	
	setlocale(LC_ALL, "Russian");
	map<string, int> map;	  
	std::map<string, int>::iterator iter;
	printData(createOutMap(readFile(map, iter), iter));

	_getch;
	return 0;
}

map<string, int> readFile(map<string, int> map, std::map<string, int>::iterator iter) {
	ifstream stream("Sonnets.txt", ios_base::in);
	const size_t MAXLEN = 1000;

	char text[MAXLEN];

	while (!stream.eof()) {
		stream.getline(text, MAXLEN);
		char* substr = strtok(text, ".,:!;? ");

		while (substr != 0)
		{
			string word = substr;
			transform(word.begin(), word.end(), word.begin(), tolower);
			iter = map.find(word);

			if (iter == map.end()) {
				map.insert(std::pair<std::string, int>(word, 1));
			} 
			else iter->second++;

			substr = strtok(NULL, ".,:!;? ");
		}
	}
	return map;
}

multimap<int, string, greater<>> createOutMap(map<string, int> map, std::map<string, int>::iterator iter) {
	multimap<int, string, greater<>> outMap;
	for (iter = map.begin(); iter != map.end(); iter++) {
		if (iter->first.size() > 3 && iter->second >= 7)
			outMap.insert(pair<int, string>(iter->second, iter->first));
	}
	return outMap;
}

void printData(multimap<int, string, greater<>> outMap) {
	multimap<int, string, greater<>>::iterator i;
	for (i = outMap.begin(); i != outMap.end(); i++) {
		cout << i->second << "  " << i->first << endl;
	}
}