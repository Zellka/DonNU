using System;

namespace Laba_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int item = 0;
            while (item != 11)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("{0,25} {1,9}", "Выберите номер задания", "|");
                Console.WriteLine("{0,-10} {1,21}", "1 - 1 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "2 - 2 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "3 - 3 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "4 - 4 задание", "|");
                Console.WriteLine("{0,-10} {1,22}", "5 - 5 задание", " | ");
                Console.WriteLine("{0,-10} {1,21}", "6 - 6 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "7 - 7 задание", "|");
                Console.WriteLine("{0,-10} {1,21}", "8 - 8 задание", "|");
                Console.WriteLine("{0,-10} {1,2}", "9 - 1 индивидуальное (6 вариант)", "|");
                Console.WriteLine("{0,-10} {1,1}", "10 - 2 индивидуальное (6 вариант)", "|");
                Console.WriteLine("{0,-10} {1,24}", "11 - выход", "|");
                Console.WriteLine("-----------------------------------");
                int number;
                string input = Console.ReadLine();
                bool res = int.TryParse(input, out number);
                if (res == false)
                {
                    Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 11.");
                }
                else
                {
                    item = int.Parse(input);
                    switch (item)
                    {
                        case 1:
                            Console.WriteLine("1 задание"); 
                            Console.Write("Введите количество элементов: ");
                            int n = int.Parse(Console.ReadLine());
                            int[] Array = new int[n];
                            Random rand = new Random();
                            for (int l = 0; l < n; l++)
                            {
                                Array[l] = rand.Next(-30, 45);
                            }
                            for (int l = 0; l < n; l++) 
                            {
                                if ((l % 10) == 0 && l > 0)
                                {
                                    Console.WriteLine();
                                }
                                Console.Write(Array[l] + "\t");
                            }
                            Console.WriteLine();
                            Console.WriteLine("----> обратный массив, исключая отрицательные");
                            int a = n - 1;
                            for (int l = a; l > -1; l--)
                            {
                                if ((a % 10) == 0)
                                {
                                    Console.WriteLine();
                                }
                                if (Array[l] >= 0)
                                {
                                    Console.Write(Array[l] + "\t");
                                    a--;
                                }
                            }
                            break;

                        case 2:
                            Console.WriteLine("2 задание");
                            int N = 7;
                            int i, j, p, tmp;
                            int[,] array = new int[N, N];
                            Random rnd = new Random();
                            for (i = 0; i < N; i++)
                            {
                                for (j = 0; j < N; j++)
                                {
                                    array[i, j] = rnd.Next(1, 10);
                                    Console.Write(array[i, j] + "\t");
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine("------------- а теперь поворачиваем вправо ->");
                            p = N / 2;
                            for (i = 0; i < p; i++)
                            {
                                for (j = i; j < N - 1 - i; j++)
                                {
                                    tmp = array[i, j];
                                    array[i, j] = array[N - j - 1, i];
                                    array[N - j - 1, i] = array[N - i - 1, N - j - 1];
                                    array[N - i - 1, N - j - 1] = array[j, N - i - 1];
                                    array[j, N - i - 1] = tmp;
                                }
                            }
                            for (i = 0; i < N; i++)
                            {
                                for (j = 0; j < N; j++)
                                {
                                    Console.Write(array[i, j] + "\t");
                                }
                                Console.WriteLine();
                            }
                            break;

                        case 3:
                            Console.WriteLine("3 задание");
                            int[] aRRay = { 1, 2, 3, 4, 5 };
                            int size = 5;
                            Console.Write("Введие число, на которое хотите сдвинуть массив влево: ");
                            int k = int.Parse(Console.ReadLine()); // k-сдвиг 
                            Console.WriteLine("Исходный массив");
                            for (int s = 0; s < size; s++)
                            {
                                Console.Write(aRRay[s] + " \t ");
                            }
                            Console.WriteLine();
                            for (int g = 0; g < k; g++)
                            {
                                int A = aRRay[0];
                                for (int s = 0; s < size; s++)
                                {
                                    if (s == size - 1) // заполняем последнюю ячейку массива 
                                    {
                                        aRRay[s] = A;
                                        break;
                                    }
                                    aRRay[s] = aRRay[s + 1];
                                }
                            }
                            Console.WriteLine("Массив со сдвигом влево");
                            for (int s = 0; s < size; s++)
                            {
                                Console.Write(aRRay[s] + " \t ");
                            }
                            Console.WriteLine();
                            ////вправо
                            //for (int g = 0; g < k; g++)
                            //{
                            //    int A = aRRay[size - 1];
                            //    for (int s = 0; s < size; s++)
                            //    {
                            //        if (s == size - 1) // заполняем первую ячейку массива 
                            //        {
                            //            aRRay[0] = A;
                            //            break;
                            //        }
                            //        aRRay[size - 1 - s] = aRRay[size - 1 - 1 - s];
                            //    }
                            //}
                            //Console.WriteLine("Массив со сдвигом вправо");
                            //for (int s = 0; s < size; s++)
                            //{
                            //    Console.Write(aRRay[s] + " \t ");
                            //}
                            //Console.WriteLine();
                            break;

                        case 4: 
                            Console.WriteLine("4 задание");
                            Random rd = new Random();
                            int[,] A1 = new int[3, 3];
                            int[,] B1 = new int[3, 3];
                            int[,] C1, C2;
                            int result;
                            for (int w = 0; w < A1.GetLength(0); w++)
                            {
                                for (int y = 0; y < A1.GetLength(1); y++)
                                {
                                    A1[w, y] = rd.Next(1, 10);
                                }
                            }
                            for (int w = 0; w < B1.GetLength(0); w++)
                            {
                                for (int y = 0; y < B1.GetLength(1); y++)
                                {
                                    B1[w, y] = rd.Next(1, 10);
                                }
                            }
                            Console.WriteLine("\nМатрица A:");
                            Print(A1);
                            Console.WriteLine("\nМатрица B:");
                            Print(B1);
                            Console.WriteLine("\nМатрица C = A + B:");
                            Calcute(A1, B1, out C1, out C2, out result);
                            Print(C1);
                            Console.WriteLine("\nМатрица C = A - B:");
                            Print(C2);
                            Console.WriteLine("Среднее арифметическое: " + result);
                            break;

                        case 5:
                            Console.WriteLine("5 задание");
                            Random rn = new Random();
                            int[,] A2 = new int[5, 5];
                            int[,] B2 = new int[5, 5];
                            for (int f = 0; f < A2.GetLength(0); f++)
                            {
                                for (int v = 0; v < A2.GetLength(1); v++)
                                {
                                    A2[f, v] = rn.Next(1, 10);
                                }
                            }
                            for (int f = 0; f < B2.GetLength(0); f++)
                            {
                                for (int v = 0; v < B2.GetLength(1); v++)
                                {
                                    B2[f, v] = rn.Next(1, 10);
                                }
                            }
                            Console.WriteLine("\nМатрица A:");
                            Print(A2);
                            Console.WriteLine("\nМатрица B:");
                            Print(B2);
                            Console.WriteLine("\nМатрица C = A * B:");
                            int[,] C = Multiplication(A2, B2);
                            Print(C);
                            break;

                        case 6:
                            Console.WriteLine("6 задание");
                            int K;
                            int[] arrAy = { 1, 2, 3, 4, 5 };
                            Console.WriteLine("1, 2, 3, 4, 5");
                            K = sumIterative(arrAy);
                            Console.WriteLine("Сумма итер: " + K);
                            K = sumRecursive(arrAy, 5);
                            Console.WriteLine("Сумма рекур: " + K);
                            K = minIterative(arrAy, 4);
                            Console.WriteLine("Мин итер: " + K);
                            K = minRecursive(arrAy, 4);
                            Console.WriteLine("Мин рекур: " + K);
                            break;

                        case 7:
                            Console.WriteLine("7 задание");
                            Console.WriteLine("Введите n-член последовательности Фибоначчи, который хотите найти: ");
                            int num = int.Parse(Console.ReadLine()); 
                            int elem;
                            elem = Fibo(num);
                            Console.WriteLine("Ваш элемент: " + elem);
                            break;

                        case 8:
                            Console.WriteLine("8 задание");
                            Random Rand = new Random();
                            int L = 3;
                            int[,] F = new int[L, L];
                            int[,] b = new int[L, L];
                            int det;
                            for (int o = 0; o < L; o++)
                            {
                                for (int m = 0; m < L; m++)
                                {
                                    F[o, m] = Rand.Next(1, 10);
                                }
                            }
                            Print(F);
                            det = Det(F, L);
                            Console.WriteLine("Определитель матрицы = " + det);
                            break;

                        case 9:
                            Console.WriteLine("1 индивидуальное (6 вариант)");
                            int tmP = 1;
                            int[,] aRray = new int[9, 9];
                            int Size = 9;
                            int t, d;
                            for (t = 0; t < Size; t++)
                            {
                                for (d = 0; d <= t; d++)
                                {
                                    aRray[t - d, d] = tmP++;
                                }
                            }
                            for (t = 1; t < Size; t++)
                            {
                                for (d = t; d < Size; d++)
                                {
                                    aRray[Size - d + t - 1, d] = tmP++;
                                }
                            }
                            for (t = 0; t < Size; t++)
                            {
                                for (d = 0; d < Size; d++)
                                {
                                    Console.Write(aRray[t, d] + "\t");
                                }
                                Console.WriteLine();
                            }
                            break;

                        case 10:
                            Console.WriteLine("2 индивидуальное (6 вариант)");
                            int D = 0;
                            bool tf = true;
                            int[] ar = { 2, 12, 22, 32, 42 };
                            Console.WriteLine("2, 12, 22, 32, 42");
                            for (int x = 0; x < (ar.Length - 2) && tf == true; x++)
                            {
                                D = ar[x + 1] - ar[x];
                                if (D == (ar[x + 2] - ar[x + 1]))
                                {
                                    D = ar[x + 1] - ar[x];
                                }
                                else
                                {
                                    tf = false;
                                } 
                            }
                            if (tf == false) 
                                Console.WriteLine("FALSE");
                            else 
                                Console.WriteLine("Шаг прогрессии: " + D);
                            break;

                        case 11:
                            Console.WriteLine("Работа завершена.");
                            break;

                        default:
                            Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 11.");
                            break;
                    }
                }
            }
            Console.ReadKey();
        }
        //к 4 заданию
        static int Calcute(int[,] a, int[,] b, out int[,] r1, out int[,] r2, out int result)

        {
            r1 = new int[a.GetLength(0), b.GetLength(1)];
            r2 = new int[a.GetLength(0), b.GetLength(1)];
            result = 0;
            int elem = 18;
            for (int i = 0; i < a.GetLength(0); i++) 

            {
                for (int j = 0; j < b.GetLength(1); j++) 

                {
                    r1[i, j] = a[i, j] + b[i, j]; //сложение
                    result += r1[i, j];
                    r2[i, j] = a[i, j] - b[i, j]; //вычитание
                    elem += 2;
                }
            }
            return result = result / elem;
        }
        static void Print(int[,] a)  //к 4, 5, 8 заданию
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        //к 5 заданию
        static int[,] Multiplication(int[,] a, int[,] b)
        {
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        r[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return r;
        }
        //к 6 заданию
        static int sumIterative(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        static int sumRecursive(int[] array, int size)
        {
            if (size > 0)
            {
                return array[size - 1] + sumRecursive(array, size - 1);
            }
            return 0;
        }
        static int minIterative(int[] array, int size)
        {
            int min;
            min = array[0];
            for (int i = 1; i < size; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            return min;
        }
        static int minRecursive(int[] array, int n)
        {
            if (n == 0)
            {
                return array[0];
            }
            return Math.Min(array[n - 1], minRecursive(array, n - 1));
        }
        //к 7 заданию
        static int Fibo(int k)
        {
            if (k < 3)
            {
                return 1;
            }
            else
            {
                return Fibo(k - 2) + Fibo(k - 1);
            }
        }
        //к 8 заданию
        static int GetMatr(int[,] a, int N, int m, int n, out int k)
        {
            k = n - 1;
            int[,] b = new int[k, k];
            for (int i = 0, h = 0; h < k; i++, h++)
            {
                for (int j = 0, s = 0; s < k; j++, s++)
                {
                    if (i == N) i++;
                    if (j == m) j++;
                    b[h, s] = a[i, j];
                }
            }
            return Det(b, k);
        }
        static int Det(int[,] a, int n)
        {
            int d = 0, k = n;
            if (n == 2) 
            {
                d = a[0, 0] * a[1, 1] - a[1, 0] * a[0, 1];
                return d;
            }
            else
            {
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i + (j % 2) == 0)
                        {
                            d += a[i, j] * GetMatr(a, i, j, n, out n);
                        }
                        else
                        {
                            d -= a[i, j] * GetMatr(a, i, j, n, out n);
                        }
                        n = k;
                    }
                }
            }
            return d;
        }
    }
}
