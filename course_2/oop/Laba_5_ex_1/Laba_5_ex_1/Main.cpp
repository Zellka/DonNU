#include "DataManager.h"

int main() {

	DataManager<int> manager;
	manager.push(-9);
	int a[60] = { 0 };
	manager.push(a, 60); 
	int x = manager.peek(); 
	for (int i = 1; i < 15; ++i) manager.push(i); 
	x = manager.pop(); 

	DataManager<char> char_manager; // явная специализация шаблона для char
	char_manager.push('h');
	char_manager.push('e');
	char_manager.push('l');
	char_manager.push('l');
	char_manager.push('o');
	char ch = char_manager.popUpper(); // этот метод есть только для char
	std::cout << ch << std::endl;

	return 0;
}