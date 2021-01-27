#include "Cache.h"
#include <iostream>
#include <string>

using namespace std;

int main()
{
    setlocale(LC_ALL, "Russian");

    Cache<int> cache;
    cache.put(1); 
    cache.put(2);
    cache.put(3);
    cache += 5; 

    Cache<string> voc;
    voc.put("OK");

    cout << voc.contains("Only") << endl; 
    cout << cache.contains(5) << endl; 
    return 0;
}