using System;
using System.IO;

namespace _7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\PR\sorted.dat";
            int n = 1000;
            int[] array = new int[n];
            PrintSort(array, path, n);
            
        }
        public static void PrintSort(int[] array, string path, int n)
        {
            Console.WriteLine("1 задание------------------");
            array = RandomArray(array);
            Console.WriteLine("Отсортированный массив (выбор):");
            SelectionSort(array);
            array = RandomArray(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (вставкa):");
            InsertionSort(array);
            array = RandomArray(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (пузырьковая):");
            BubbleSort(array);
            array = RandomArray(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (шейкер):");
            ShakerSort(array);
            array = RandomArray(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (Шелл):");
            ShellSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("2 задание------------------");
            array = IncreaseSort(array);
            Console.WriteLine("Отсортированный массив (выбор):");
            SelectionSort(array);
            array = IncreaseSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (вставкa):");
            InsertionSort(array);
            array = IncreaseSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (пузырьковая):");
            BubbleSort(array);
            array = IncreaseSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (шейкер):");
            ShakerSort(array);
            array = IncreaseSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (Шелл):");
            ShellSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("3 задание------------------");
            array = DecreaseSort(array);
            Console.WriteLine("Отсортированный массив (выбор):");
            SelectionSort(array);
            array = DecreaseSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (вставкa):");
            InsertionSort(array);
            array = DecreaseSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (пузырьковая):");
            BubbleSort(array);
            array = DecreaseSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (шейкер):");
            ShakerSort(array);
            array = DecreaseSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
            Console.WriteLine("Отсортированный массив (Шелл):");
            ShellSort(array);
            WriteFile(path, array);
            ReadFile(path, n);
        }

        public static void WriteFile(string path, int[] array)
        {
            FileStream filestream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryWriter writer = new BinaryWriter(filestream);
            for (int i = 0; i < array.Length; i++)
            {
                writer.Write(array[i]);
            }
            writer.Close();
            filestream.Close();
        }
        public static void ReadFile(string path, int n)
        {
            FileStream filestream = new FileStream(path, FileMode.Open);
            BinaryReader reader = new BinaryReader(filestream); 
            bool chek = true;
            int[] array = new int[n];
            for (int i = 0; i < n - 1; i++)
            {
                array[i] = reader.ReadInt32();
                if (array[i] < array[i + 1])
                {
                    chek = false;
                    break;
                }
            }
            if (chek)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Данные отсортированы");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Данные не отсортированы");
                Console.ForegroundColor = ConsoleColor.White;
            }
            reader.Close();
            filestream.Close();
        }
        public static int[] RandomArray(int[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 100);
            }
            return array;
        }
        public static int[] IncreaseSort(int[] array) //сортировка по возрастанию
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                int tmp = array[min];
                array[min] = array[i];
                array[i] = tmp;
            }
            return array;
        }
        public static int[] DecreaseSort(int[] array) //сортировка по убыванию
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[max])
                    {
                        max = j;
                    }
                }
                int tmp = array[max];
                array[max] = array[i];
                array[i] = tmp;
            }
            return array;
        }
        public static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
            
        }
        public static int[] SelectionSort(int[] array)
        {
            long compar = 0, exchange = 0;
            DateTime start = DateTime.Now;
            for (int i = 0; i < array.Length - 1; i++)
            {
                //поиск минимального числа
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                    compar++;
                }
                Swap(ref array[min], ref array[i]);
                if (min != i)
                {
                    exchange++;
                }
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            Console.WriteLine(span);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Cравнений: " + compar);
            Console.WriteLine("Замен: " + exchange);
            Console.ForegroundColor = ConsoleColor.White;
            return array;
        }
        public static int[] InsertionSort(int[] array)
        {
            long compar = 0, exchange = 0;
            DateTime start = DateTime.Now;
            for (int i = 1; i < array.Length; i++)
            {
                int k = i;
                while ((k > 0) && (array[k - 1] > array[k]))
                {
                     Swap(ref array[k - 1], ref array[k]);
                     exchange++;
                     k--;
                }
                compar++;
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            Console.WriteLine(span);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Cравнений: " + compar);
            Console.WriteLine("Замен: " + exchange);
            Console.ForegroundColor = ConsoleColor.White;
            return array;
        }
        public static int[] BubbleSort(int[] array)
        {
            long compar = 0, exchange = 0;
            DateTime start = DateTime.Now;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        Swap(ref array[i], ref array[j]);
                        exchange++;
                    }
                    compar++;
                }
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            Console.WriteLine(span);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Cравнений: " + compar);
            Console.WriteLine("Замен: " + exchange);
            Console.ForegroundColor = ConsoleColor.White;
            return array;
        }
        public static int[] ShakerSort(int[] array)
        {
            long compar = 0, exchange = 0;
            DateTime start = DateTime.Now;
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool swapFlag = false;
                //проход слева направо
                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        exchange++;
                        swapFlag = true;

                    }
                    compar++;
                }
                //проход справа налево
                for (int j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        exchange++;
                        swapFlag = true;
                    }
                    compar++;
                }
                //если обменов не было выходим
                if (!swapFlag)
                    break;
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            Console.WriteLine(span);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Cравнений: " + compar);
            Console.WriteLine("Замен: " + exchange);
            Console.ForegroundColor = ConsoleColor.White;
            return array;
        }
        static int[] ShellSort(int[] array)
        {
            long compar = 0, exchange = 0;
            DateTime start = DateTime.Now;
            //расстояние между элементами, которые сравниваются
            int d = array.Length / 2;
            while (d >= 1)
            {
                for (int i = d; i < array.Length; i++)
                {
                    int j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        exchange++;
                        j = j - d;
                    }
                    compar++;
                }
                d = d / 2;
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            Console.WriteLine(span);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Cравнений: " + compar);
            Console.WriteLine("Замен: " + exchange);
            Console.ForegroundColor = ConsoleColor.White;
            return array;
        }
    }
}
