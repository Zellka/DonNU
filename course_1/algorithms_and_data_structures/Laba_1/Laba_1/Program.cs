using System;

namespace Laba_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1 задание
            Console.WriteLine("Первое задание");
            Console.Write("Введите дробное число: ");
            double x = double.Parse(Console.ReadLine());
            x = x * 10;
            int d = (int)x;
            Console.WriteLine("Первое число после запятой: " + (d %= 10));
            Console.WriteLine();
            //2 задание
            Console.WriteLine("Второе задание");
            Console.WriteLine("Сколько прошло секунд?");
            int total = int.Parse(Console.ReadLine());
            int hour = total / 3600;
            int minute = (total - (hour * 3600)) / 60;
            Console.WriteLine(hour + " ч. " + minute + " мин.");
            Console.WriteLine();
            //3 задание 
            Console.WriteLine("Третье задание");
            Console.Write("Введите час: ");
            int hours = int.Parse(Console.ReadLine());
            Console.Write("Введите минуты: ");
            int minutes = int.Parse(Console.ReadLine());
            Console.Write("Введите секунды: ");
            int seconds = int.Parse(Console.ReadLine());
            double total1 = hours + (minutes / 60.0) + (seconds / 3600.0);
            Console.WriteLine("Угол: " + (total1 * 30) + "°");
            Console.WriteLine();
            //4 задание
            Console.WriteLine("Четвёртое задание");
            Console.Write("Введите первое число: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Введите второе число: ");
            int y = int.Parse(Console.ReadLine());
            k = k + y;
            y = k - y;
            k = k - y;
            Console.WriteLine("Теперь первое число: " + (k) + ", а второе число: " + (y));
            Console.WriteLine();
            //5 задание
            Console.WriteLine("Пятое задание");
            Console.Write("Введите длину первого катета: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите длину второго катета: ");
            int b = int.Parse(Console.ReadLine());
            double c = Math.Sqrt((a * a) + (b * b));
            Console.WriteLine("Площадь: " + (0.5 * a * b));
            Console.WriteLine("Периметр: " + (a + b + c));
            Console.WriteLine();
            //6 задание
            Console.WriteLine("Шестое задание");
            Console.Write("Введите 4-значное число: ");
            int value = int.Parse(Console.ReadLine());
            int n1 = value / 1000;
            int n2 = (value / 100) % 10;
            int n3 = (value / 10) % 10;
            int n4 = value % 10;
            Console.WriteLine("Произведение: " + (n1 * n2 * n3 * n4));
            Console.WriteLine();
            //7 задание
            Console.WriteLine("Седьмое задание");
            Console.Write("Введите 3-значное число: ");
            int input = int.Parse(Console.ReadLine());
            int h1 = input % 10;
            int h2 = (input / 10) % 10;
            int h3 = input / 100;
            int reversed = (h1 * 100) + (h2 * 10) + h3;
            Console.WriteLine("Ваше число в обратном порядке: " + (reversed));
            Console.WriteLine();
            //8 задание
            Console.WriteLine("Восьмое задание");
            Console.Write("Введите число: ");
            int z = int.Parse(Console.ReadLine());
            Console.WriteLine("Итог: " + ((((3 * z - 5) * z + 2) * z - 1) * z + 7));
            Console.WriteLine();
            //9 задание
            Console.WriteLine("Девятое задание");
            Console.Write("Введите a1: "); double a1 = double.Parse(Console.ReadLine());
            Console.Write("Введите a2: "); double a2 = double.Parse(Console.ReadLine());
            Console.Write("Введите a3: "); double a3 = double.Parse(Console.ReadLine());
            Console.Write("Введите b1: "); double b1 = double.Parse(Console.ReadLine());
            Console.Write("Введите b2: "); double b2 = double.Parse(Console.ReadLine());
            Console.Write("Введите b3: "); double b3 = double.Parse(Console.ReadLine());
            Console.Write("Введите c1: "); double c1 = double.Parse(Console.ReadLine());
            Console.Write("Введите c2: "); double c2 = double.Parse(Console.ReadLine());
            Console.Write("Введите c3: "); double c3 = double.Parse(Console.ReadLine());
            Console.Write("Введите d1: "); double d1 = double.Parse(Console.ReadLine());
            Console.Write("Введите d2: "); double d2 = double.Parse(Console.ReadLine());
            Console.Write("Введите d3: "); double d3 = double.Parse(Console.ReadLine());
            double det = a1 * b2 * c3 + a2 * b3 * c1 + b1 * c2 * a3 * -c1 * b2 * a3 - b1 * a2 * c3 - c2 * b3 * a1;
            double det_x = d1 * b2 * c3 + d2 * b3 * c1 + b1 * c2 * d3 * -c1 * b2 * d3 - b1 * d2 * c3 - c2 * b3 * d1;
            double det_y = a1 * d2 * c3 + a2 * d3 * c1 + d1 * c2 * a3 * -c1 * d2 * a3 - d1 * a2 * c3 - c2 * d3 * a1;
            double det_z = a1 * b2 * d3 + a2 * b3 * d1 + b1 * d2 * a3 * -d1 * b2 * a3 - b1 * a2 * d3 - d2 * b3 * a1;
            Console.WriteLine("x = " + (det_x / det));
            Console.WriteLine("y = " + (det_y / det));
            Console.WriteLine("z = " + (det_z / det));
            Console.WriteLine();
            //1 инд (6 вариант)
            Console.WriteLine("Первое индивидуальное (6 вариант)");
            Console.Write("Введите 1-ое наименование сельскохозяйственной культуры: "); string name1 = Console.ReadLine();
            Console.Write("Введите тип 1-ой сельскохозяйственной культуры: ");          string type1 = Console.ReadLine();
            Console.Write("Введите размер посевной площади в га: ");                    int area1 = int.Parse(Console.ReadLine());
            Console.Write("Введите размер урожая: ");                                   int harvest1 = int.Parse(Console.ReadLine());
            Console.Write("Введите 2-ое наименование сельскохозяйственной культуры: "); string name2 = Console.ReadLine();
            Console.Write("Введите тип 2-ой сельскохозяйственной культуры: ");          string type2 = Console.ReadLine();
            Console.Write("Введите размер посевной площади в га: ");                    int area2 = int.Parse(Console.ReadLine());
            Console.Write("Введите размер урожая: ");                                   int harvest2 = int.Parse(Console.ReadLine());
            Console.Write("Введите 3-е наименование сельскохозяйственной культуры: ");  string name3 = Console.ReadLine();
            Console.Write("Введите тип 3-й сельскохозяйственной культуры: ");           string type3 = Console.ReadLine();
            Console.Write("Введите размер посевной площади в га: ");                    int area3 = int.Parse(Console.ReadLine());
            Console.Write("Введите размер урожая: ");                                   int harvest3 = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,20}{1,66}", "Сельскохозяйственные культуры", "|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-20}{1,10}{2,30}{3,30}{4,5}", "Наименование", "Тип", "Посевная площадь (га)", "Урожайность (ц/га)", "|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-20}{1,10}{2,30}{3,30}{4,5}", name1, type1, area1, harvest1, "|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-20}{1,10}{2,30}{3,30}{4,5}", name2, type2, area2, harvest2, "|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,-20}{1,10}{2,30}{3,30}{4,5}", name3, type3, area3, harvest3, "|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine("{0,20}{1,51}", "Перечисляемый тип: З - зерновые, Б - бобовые", "|");
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
            Console.WriteLine();
            //2 инд (6 вариант)
            Console.WriteLine("Второе индивидуальное (6 вариант)");
            Console.Write("Введите х: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.Write("Введите у: ");
            double y1 = double.Parse(Console.ReadLine());
            Console.Write("Введите z: ");
            double z1 = double.Parse(Console.ReadLine());
            double A = (2 * Math.Cos(x1 - (Math.PI) / 6) / (0.5 + Math.Pow(Math.Sin(y1), 2)));
            double B = 1 + (z1 * z1) / (3 + (z1 * z1) / 5);
            Console.WriteLine("a = " + A);
            Console.WriteLine("b = " + B);

            Console.ReadKey();
        }
    }
}
