#pragma once

#include <iostream>
#include <fstream>
#include <algorithm>
#include <string>
#include <vector>

using namespace std;

template <typename T>
class DataManager {

private:
	vector<T> data;

public:
	DataManager() { }
	~DataManager() { data.clear(); }

	void push(T elem) { ///********

		if (data.size() < 64) data.insert(data.begin(), elem);
		else {
			seralize();
			data.clear();
			data.push_back(elem);
		}
	}
	void push(T elems[], size_t n) { //********
		if (data.size() + n < 64) {
			for (int i = 0; i < n; i++) push(elems[i]);
		}
		else {
			for (int i = 0; i < n; i++) data.push_back(elems[i]);
		}
		sort(data.begin(), data.end(), [](T a, T b) { return a > b; });
	}

	T peek() {
		if (data.size() <= 2) return 0;
		return data[1];
	}

	T pop() {
		char tmp = data.front();
		data.erase(data.begin());
		if (data.empty()) deserize();
		return tmp;
	}

	void seralize() {
		ofstream stream("dump.dat");
		for (int i = 0; i < data.size(); i++) {
			stream << data[i] << endl;
		}
		stream.close();
	}
	void deserize() {
		ifstream stream("dump.dat");
		string outText;
		if (stream.is_open()) {
			getline(stream, outText);
			while (outText.compare("")) {
				if (typeid(T) == typeid(int))
					push(stoi(outText));
				if (typeid(T) == typeid(double))
					push(stod(outText));
				if (typeid(T) == typeid(char))
					push(*(outText.c_str()));
				getline(stream, outText);
			}
		}
	}
};
//-----------------------------

template <>
class DataManager<char> {

private:
	vector<char> dataCh;

public:
	DataManager() { }
	~DataManager() { dataCh.clear(); }

	void push(char elem) {
		if (elem == ',' || elem == '.' || elem == '!' || elem == '?' || elem == ':' || elem == ';')
			elem = '_';

		if (dataCh.size() < 64) dataCh.insert(dataCh.begin(), elem);
		else {
			seralize();
			dataCh.clear();
			dataCh.push_back(elem);
		}
	}
	void push(char elems[], size_t n) {
		if (dataCh.size() + n < 64) {
			for (int i = 0; i < n; i++) {
				if (elems[i] == '.' || elems[i] == ',' || elems[i] == ':' || elems[i] == ';' || elems[i] == '?' || elems[i] == '!') {
					elems[i] = '_';
				}
				push(elems[i]);
			}
		}
		else {
			for (int i = 0; i < n; i++) dataCh.push_back(elems[i]);
		}
		sort(dataCh.begin(), dataCh.end(), [](char a, char b) { return a > b; });
	}
	char peek() {
		if (dataCh.size() < 2) return 0;
		return dataCh[1];
	}
	char pop() {
		char tmp = dataCh.front();
		dataCh.erase(dataCh.begin());
		if (dataCh.empty()) deserize();
		return tmp;
	}
	char popUpper() { return toupper(pop()); }
	char popLower() { return tolower(pop()); }

	void seralize() {
		ofstream stream("dump.dat");
		for (int i = 0; i < dataCh.size(); i++) {
			stream << dataCh[i] << endl;
		}
		stream.close();
	}
	void deserize() {
		ifstream stream("dump.dat");
		string outText;
		if (stream.is_open()) {
			getline(stream, outText);
			while (outText.compare("")) {
				push(*(outText.c_str()));
				getline(stream, outText);
			}
		}
	}
};
