using System;
using System.IO;

namespace _10_1
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] array = new long[100000];
            Console.WriteLine("У нас есть 3 вида сортировок. Нужно выбрать...");
            Сhoice(array);
        }
        public static void Сhoice(long[] array)
        {
            long choice = 0, left = 0, right = array.Length - 1;
            long compar = 0, swap = 0;
            PrintMenu();
            string input = Console.ReadLine();
            try
            {
                choice = long.Parse(input);
                switch (choice)
                {
                     case 1:
                        Console.Clear();
                        array = RandomArray(array);
                        Console.WriteLine("Сортировка слиянием");
                        Console.WriteLine("Исходные данные: массив из 100 000 элементов, сгенерированный случайным образом");
                        PrintData(MergeSort(array, left, right, ref compar, ref swap), ref compar, ref swap);

                        compar = 0;
                        swap = 0;
                        Console.WriteLine("Исходные данные: тот же массив, отсортированный в порядке возрастания элементов");
                        PrintData(MergeSort(array, left, right, ref compar, ref swap), ref compar, ref swap);

                        compar = 0;
                        swap = 0;
                        Console.WriteLine("Исходные данные: тот же массив, отсортированный в порядке убывания элементов");
                        array = SortDescending(array);
                        PrintData(MergeSort(array, left, right, ref compar, ref swap), ref compar, ref swap);
                        break;
                     case 2:
                        Console.Clear();
                        array = RandomArray(array);
                        Console.WriteLine("Пирамидальная сортировка");
                        Console.WriteLine("Исходные данные: массив из 100 000 элементов, сгенерированный случайным образом");
                        PrintData(HeapSort(array, left, right, ref compar, ref swap), ref compar, ref swap);

                        compar = 0;
                        swap = 0;
                        Console.WriteLine("Исходные данные: тот же массив, отсортированный в порядке возрастания элементов");
                        PrintData(HeapSort(array, left, right, ref compar, ref swap), ref compar, ref swap);

                        compar = 0;
                        swap = 0;
                        Console.WriteLine("Исходные данные: тот же массив, отсортированный в порядке убывания элементов");
                        array = SortDescending(array);
                        PrintData(HeapSort(array, left, right, ref compar, ref swap), ref compar, ref swap);
                        break;
                     case 3:
                        Console.Clear();
                        array = RandomArray(array);
                        Console.WriteLine("Исходные данные: массив из 100 000 элементов, сгенерированный случайным образом");
                        PrintData(QuickSort(array, left, right, ref compar, ref swap), ref compar, ref swap);

                        compar = 0;
                        swap = 0;
                        Console.WriteLine("Исходные данные: тот же массив, отсортированный в порядке возрастания элементов");
                        PrintData(QuickSort(array, left, right, ref compar, ref swap), ref compar, ref swap);

                        compar = 0;
                        swap = 0;
                        Console.WriteLine("Исходные данные: тот же массив, отсортированный в порядке убывания элементов");
                        array = SortDescending(array);
                        PrintData(QuickSort(array, left, right, ref compar, ref swap), ref compar, ref swap);
                        break;
                     default:
                        Console.WriteLine("Ошибка. Вы ввели неправильное значение. Рекомендуем ввести число от 1 до 3.");
                        break;
                }
            }
            catch
            { 
                Console.WriteLine("Ошибка. Неверный формат."); 
            }
        }
        public static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------------------");
            Console.WriteLine("{0,18} {1,8}", "Выберите вид сортировки", "|");
            Console.WriteLine("{0,-10} {1,8}", "1 - Сортировка слиянием", "|");
            Console.WriteLine("{0,-10} {1,3}", "2 - Пирамидальная сортировка", " |");
            Console.WriteLine("{0,-10} {1,9}", "3 - Быстрая сортировка", " |");
            Console.WriteLine("--------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintData(long[] array, ref long compar, ref long swap)
        {
            string path = @"C:\PR\sorted.dat";
            DateTime start = DateTime.Now;
            WriteFile(path, array);
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(span);
            Console.WriteLine("Cравнений: " + compar);
            Console.WriteLine("Замен: " + swap);
            Console.ForegroundColor = ConsoleColor.White;
            ReadFile(path, array.Length);
        }
        public static long[] MergeSort(long[] array, long l, long r, ref long compar, ref long swap)
        {
            if (r <= l)
                return array;
            long mid = (l + r) / 2;
            MergeSort(array, l, mid, ref compar, ref swap);
            MergeSort(array, mid + 1, r, ref compar, ref swap);

            Merge(array, l, mid, r, ref compar, ref swap);
            return array;
        }
        public static void Merge(long[] array, long l, long mid, long r, ref long compar, ref long swap) //compar-сравнений, swap-перестановок
        {
            long[] tmp = new long[r - l + 1];
            long i = l, j = mid + 1; // i - индекс текущего элемента 1 части, j - индекс текущего элемента 2 части
            int k = 0;
            for (k = 0; k < tmp.Length; k++)
            {
                compar++;
                if (i > mid)
                    tmp[k] = array[j++];

                else if (j > r)
                    tmp[k] = array[i++];
                   
                else
                {
                    compar++;
                    if(array[i] < array[j])
                        tmp[k] = array[i++];
                    else
                    {
                        tmp[k] = array[j++];
                        swap++;
                    }
                }
            }
            k = 0;
            i = l;
            while (k < tmp.Length && i <= r)  // копируем временный массив в изначальный
                array[i++] = tmp[k++]; 
        }
        public static void Swap(ref long a, ref long b)
        {
            long tmp = a;
            a = b;
            b = tmp;
        }
        public static long[] HeapSort(long[] array, long l, long r, ref long compar, ref long swap) //compar-сравнений, swap-перестановок
        {
            long N = r - l + 1;
            for (long i = r; i >= l; i--)
                Heapify(array, i, N, ref compar, ref swap);
            while (N > 0)
            {
                swap++;
                Swap(ref array[l], ref array[N - 1]);
                Heapify(array, l, --N, ref compar, ref swap);
            }
            return array;
        }
        public static void Heapify(long[] a, long i, long N, ref long compar, ref long swap)
        {
            while (2 * i + 1 < N)
            {
                long k = 2 * i + 1;
                compar++;
                if (2 * i + 2 < N && a[2 * i + 2] >= a[k])
                    k = 2 * i + 2;
                compar++;
                if (a[i] < a[k])
                {
                    swap++;
                    Swap(ref a[i], ref a[k]);
                    i = k;
                }
                else
                    break;
            }
        }
        public static long[] QuickSort(long[] array, long l, long r, ref long compar, ref long swap)
        {
            if (r <= l)
                return array;
            long p = Partition(array, l, r, ref compar, ref swap);
            QuickSort(array, l, p - 1, ref compar, ref swap);
            QuickSort(array, p + 1, r, ref compar, ref swap);
            return array;
        }
        public static long Partition(long[] array, long l, long r, ref long compar, ref long swap)
        {
            long mid = (l + r) / 2;
            long pivot = array[mid];
            long i = l - 1, j = r;
            while (i < j)
            {
                while (array[++i] < pivot) ;
                while (array[--j] > pivot)
                {
                    compar++;
                    if (j == l)
                        break;
                }
                compar++;
                if (i < j)
                {
                    swap++;
                    Swap(ref array[i], ref array[j]);
                }
                else
                    break;
            }
            Swap(ref array[i], ref array[r]);
            return i;
        }
        
        public static long[] RandomArray(long[] array)
        {
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rand.Next(0, 100000);
            return array;
        }
        public static long[] SortDescending(long[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int max = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j] > a[max]) 
                        max = j;
                }
                Swap(ref a[max], ref a[i]);
            }
            return a;

        }
        public static void WriteFile(string path, long[] array) 
        {
            FileStream filestream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryWriter writer = new BinaryWriter(filestream);
            for (int i = 0; i < array.Length; i++)
                writer.Write(array[i] + "\n");
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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Данные отсортированы");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Данные не отсортированы");
                Console.ForegroundColor = ConsoleColor.White;
            }
            reader.Close();
            filestream.Close();
        }

    }
}
