#include <iostream>
#include <math.h>
#include <cmath>

using namespace std;

double f(double x) {
    return log(x) * cos(x);
}

int main() {
    setlocale(LC_ALL, "ru");

    double a = 0.5;
    double b = 5;
    double eps = 0.001;
    int n = 1;
    double lastValue = eps + 1, newValue = 0; // lastValue - ���������� ���������� ���������, newValue - ����� ���������� ���������
    for (int i = 2; (i <= 4) || (fabs(newValue - lastValue) > eps); i *= 2) {
        double h, sum2 = 0, sum4 = 0, sum = 0;
        n = 2 * i;
        h = (b - a) / n; //��� ��������������.
        for (int j = 1; j <= 2 * i - 1; j += 2) {
            sum4 += f(a + h * j); //�������� � ��������� ���������, ������� ����� �������� �� 4.
            sum2 += f(a + h * (j + 1)); //�������� � ������� ���������, ������� ����� �������� �� 2.
        }
        sum = f(a) + 4 * sum4 + 2 * sum2 - f(b); //�������� �������� f(b), �.�. ����� ��������� ��� ������.
        lastValue = newValue;
        newValue = (h / 3) * sum;
    }
    cout << "��������: " << newValue << endl;
    cout << "���-�� ���������: " << n << endl;
}