using System;

namespace Laba_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int item = 0;
            while (item != 9)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("{0,25} {1,8}", "Выберите номер задания", "|");
                Console.WriteLine("{0,-10} {1,20}", "1 - 1 задание", "|");
                Console.WriteLine("{0,-10} {1,20}", "2 - 2 задание", "|");
                Console.WriteLine("{0,-10} {1,20}", "3 - 3 задание", "|");
                Console.WriteLine("{0,-10} {1,20}", "4 - 4 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "5 - 5 задание", " | ");
                Console.WriteLine("{0,-10} {1,20}", "6 - 6 задание", "|");
                Console.WriteLine("{0,-10} {1,1}", "7 - 1 индивидуальное (6 вариант)", "|");
                Console.WriteLine("{0,-10} {1,1}", "8 - 2 индивидуальное (6 вариант)", "|");
                Console.WriteLine("{0,-10} {1,23}", "9 - выход", "|");
                Console.WriteLine("----------------------------------");
                int number;
                string input = Console.ReadLine();
                bool res = int.TryParse(input, out number);
                if (res == false)
                {
                    Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 9.");
                }
                else
                {
                    item = int.Parse(input);
                    switch (item)
                    {
                        case 1:
                            Console.WriteLine("1 задание");
                            Console.Write("Введите значение a: ");
                            double a = double.Parse(Console.ReadLine());
                            Console.Write("Введите значение b: ");
                            double b = double.Parse(Console.ReadLine());
                            Console.Write("Введите значение c: ");
                            double c = double.Parse(Console.ReadLine());
                            double disc = b * b - 4 * a * c;
                            if (disc > 0)
                            {
                                Console.WriteLine("Результат:");
                                Console.WriteLine("x_1 = " + ((-b + Math.Sqrt(disc) / 2 * a)));
                                Console.WriteLine("x_2 = " + ((-b - Math.Sqrt(disc)) / 2 * a));
                            }
                            else if (disc == 0)
                            {
                                Console.WriteLine("Результат:");
                                Console.WriteLine("x = " + (-b / 2 * a));
                            }
                            else
                            {
                                double part1 = -b / 2 * a;
                                double part2 = (Math.Sqrt(Math.Abs(disc)) / 2 * a);
                                Console.WriteLine("Результат:");
                                Console.WriteLine("x_1 = " + part1 + " + " + "i" + part2);
                                Console.WriteLine("x_2 = " + part1 + " - " + "i" + part2);
                            }
                            break;

                        case 2:
                            Console.WriteLine("2 задание");
                            Console.Write("Ввведите количество слагаемых: ");
                            int terms = int.Parse(Console.ReadLine());
                            int x = 1; //определитель знака слагаемых
                            double PI = 0;
                            for (int i = 1; i <= terms; i += 2)
                            {
                                if (x == 1)
                                {
                                    PI += 1.0 / i;
                                }
                                else
                                {
                                    PI -= 1.0 / i;
                                }
                                x = -1 * x; //меняем знак на противоположный
                            }
                            Console.WriteLine("Число пи = " + (PI *= 4));
                            break;

                        case 3:
                            Console.WriteLine("3 задание");
                            int f = 0, n = 1;
                            int fibo = 0; //число в ряду Фибоначчи
                            int count = 0; //счётчик 4-значных чисел
                            int check;
                            while (fibo < 10000) //до первого 5-значного числа
                            {
                                fibo = f + n;
                                f = n;
                                n = fibo;
                                check = fibo / 1000;
                                if (check > 0 && check < 10)
                                {
                                    count += 1;
                                    Console.Write(fibo + "; ");
                                }
                            }
                            Console.WriteLine();
                            Console.WriteLine("Количество 4-значных чисел в ряду Фибоначчи: " + count);
                            break;

                        case 4:
                            Console.WriteLine("4 задание");
                            Console.Write("Введите x: ");
                            double rdx = double.Parse(Console.ReadLine());
                            double X = (rdx * Math.PI) / 180;
                            //Console.Write("Введите q: ");
                            //double q = double.Parse(Console.ReadLine());
                            double q = 0.1; //погрешность
                            double cos = 0, element = 1, prov;
                            int j = 1, N = 2;
                            do
                            {
                                cos += element;
                                element *= -(X * X) / (j * (j + 1));
                                prov = Math.Abs(element);
                                j += 2;
                                N++;
                            }
                            while (prov > q) ;
                            Console.WriteLine("{0,0}{1:0.00}", "cos(x) = ", cos);
                            Console.WriteLine("Количество учтенных слагаемых: " + N);
                            break;

                        case 5:
                            Console.WriteLine("5 задание");
                            Console.WriteLine("Введите натуральное число"); //729, 1028, 19683
                            int num = int.Parse(Console.ReadLine());
                            int counts = Convert.ToInt32(Math.Pow(num, 1d / 3));  //счётчик до какого числа проверять числа
                            int p, y, z, l = 0;
                            double o; //дробная часть z
                            double p3, y3, z3;
                            for (p = 1; p <= counts; p++)
                            {
                                for (y = 1; y <= counts; y++)
                                {
                                    p3 = Math.Pow(p, 3);
                                    y3 = Math.Pow(y, 3);
                                    z3 = num - p3 - y3;
                                    o = (Math.Pow(z3, 1d / 3)) % 1; //дробная часть для проверки (остатка) на целое число
                                    if (o == 0)
                                    {
                                        z = Convert.ToInt32(Math.Pow(z3, 1d / 3));
                                        l++; //счётчик наличия корней
                                        Console.WriteLine("Кубичекие корни N: " + p + " , " + y + " , " + z);
                                    }
                                }
                            }
                            switch (l) //проверка наличия найденных корней
                            {
                                case 0:
                                    Console.WriteLine("Нет комбинаций");
                                    break;
                            }
                            break;

                        case 6:
                            Console.WriteLine("6 задание");
                            Console.Write("Введите ваш возраст: ");
                            int age = int.Parse(Console.ReadLine());
                            //for (int age = 0; age <= 100; age++) //цикл для проверки сразу всех чисел до 100
                            //{
                                int s = age % 10;
                                int r = age % 100;
                                if (s == 1 && r != 11)
                                {
                                    Console.WriteLine("Вам " + age + " год");
                                }
                                else if (s > 1 && s < 5 && (r < 10 || r > 21)  && s != 0)
                                {
                                    Console.WriteLine("Вам " + age + " года");
                                }
                                else
                                {
                                    Console.WriteLine("Вам " + age + " лет");
                                }
                            //}
                            break;

                        case 7:
                            Console.WriteLine("1 индивидуальное (6 вариант)");
                            Console.Write("Введите первое число: ");
                            double x1 = double.Parse(Console.ReadLine());
                            Console.Write("Введите второе число: ");
                            double x2 = double.Parse(Console.ReadLine());
                            Console.Write("Введите третье число: ");
                            double x3 = double.Parse(Console.ReadLine());
                            if (x1 == x2)
                            {
                                if (x1 == x3)
                                    Console.WriteLine("Ошибка. Три одинаковых числа");
                                else
                                {
                                    if (x1 < x3)
                                        Console.WriteLine("Ответ " + (x1 * x2));
                                    else
                                        Console.WriteLine("Ошибка. Два одинаковых числа больше третьего");
                                }
                            }
                            else
                            {
                                if (x1 == x3)
                                {
                                    if (x1 < x2)
                                        Console.WriteLine("Ответ: " + (x1 * x3));
                                    else
                                        Console.WriteLine("Ошибка. Два одинаковых числа больше третьего");
                                }
                                else
                                {
                                    if (x2 == x3)
                                    {
                                        if (x1 > x2)
                                            Console.WriteLine("Ответ: " + (x2 * x3));
                                        else
                                            Console.WriteLine("Ошибка. Два одинаковых числа больше третьего");
                                    }
                                    else if (x1 < x2)
                                    {
                                        if (x2 < x3)
                                            Console.WriteLine("Ответ: " + (x2 * x1));
                                        else
                                            Console.WriteLine("Ответ: " + (x3 * x1));
                                    }
                                    else
                                    {
                                        if (x1 < x3)
                                            Console.WriteLine("Ответ: " + (x2 * x1));
                                        else
                                            Console.WriteLine("Ответ: " + (x3 * x2));
                                    }
                                }
                            }
                            break;

                        case 8:
                            Console.WriteLine("2 индивидуальное (6 вариант)");
                            //int count1 = 2; -- счётчик от 2 до 5
                            //int count2 = 1; -- счётчикот 1 до 10
                            int mult; //произведение множителей
                            for (int count1 = 2; count1 <= 5; count1++)
                            {
                                Console.WriteLine("Таблица умножения на " + count1);
                                for (int count2 = 1; count2 <= 10; count2++)
                                {
                                    mult = count1 * count2;
                                    Console.WriteLine(count1 + " * " + count2 + " = " + mult);
                                }
                            }
                            break;

                        case 9:
                            Console.WriteLine("Работа завершена.");
                            break;

                        default:
                            Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 9.");
                            break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
