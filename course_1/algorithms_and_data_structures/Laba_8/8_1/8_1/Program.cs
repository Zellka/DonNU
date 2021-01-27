using System;
using System.IO;

namespace _8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\PR\sorted.dat";
            int srchElm = 0;
            int[] nums = new int[1000];
            nums = ReadFile(nums, path);  //int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            srchElm = SearchText(srchElm);
            Console.WriteLine("{0,15}","*****");
            Console.WriteLine("Линейный поиск:");
            LinearSearch(nums, srchElm);
            Console.WriteLine("{0,15}", "*****");
            Console.WriteLine("Бинарный поиск:");
            BinarySearch(nums, srchElm);
            Console.WriteLine("{0,15}", "*****");
            Console.WriteLine("Интерполяционный поиск:");
            InterpolationSearch(nums, srchElm);
        }
        public static int SearchText(int searchNum)
        {
            Console.Write("Введите число, которое хотите найти: ");
            searchNum = int.Parse(Console.ReadLine());
            return searchNum;
        }
        public static void LinearSearch(int[] a, int elem)
        {
            DateTime start = DateTime.Now;
            int count = 0;
            long compar = 0, position = 0;
            for (int i = 0; i < a.Length; i++)
            {
                compar++;
                if (elem == a[i])
                {
                    count++;
                    position = i;
                }
            }
            if (count <= 0)
                Console.WriteLine("Ваше число НЕ найдено");
            else
                Console.WriteLine("Позиция найденного элемента: " + (position + 1));
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            Console.WriteLine("Время работы алгоритма: " + span);
            Console.WriteLine("Cравнений: " + compar);
        }
        public static int BinarySearch(int[] a, int elem)
        {
            DateTime start = DateTime.Now;
            long compar = 0, position = 0;
            int left = 0, right = a.Length - 1;
            while(right >= left)
            {
                compar++;
                int mid = (left + right) / 2;
                if (elem == a[mid])
                {
                    position = mid;
                    DateTime Stop = DateTime.Now;
                    TimeSpan Span = Stop.Subtract(start);
                    Found(Span, compar, position);
                    return mid;
                }
                if (elem > a[mid])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            NotFound(span, compar);
            return -1;
        }
        public static int InterpolationSearch(int[] a, int elem)
        {
            DateTime start = DateTime.Now;
            long compar = 0, position = 0;
            int left = 0, right = a.Length - 1;
            try
            {
                while (right >= left)
                {
                    compar++;
                    int mid = left + (right - left) * (elem - a[left]) / (a[right] - a[left]);
                    if (elem == a[mid])
                    {
                        position = mid;
                        DateTime Stop = DateTime.Now;
                        TimeSpan Span = Stop.Subtract(start);
                        Found(Span, compar, position);
                        return mid;
                    }
                    if (elem > a[mid])
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
                DateTime stop = DateTime.Now;
                TimeSpan span = stop.Subtract(start);
                NotFound(span, compar);
                return -1;
            }
            catch
            {
                DateTime stop = DateTime.Now;
                TimeSpan span = stop.Subtract(start);
                NotFound(span, compar);
                return -1;
            }
            
        }
        public static void Found(TimeSpan Span, long Compar, long position)
        {
            Console.WriteLine("Позиция найденного элемента: " + (position + 1));
            Console.WriteLine("Время работы алгоритма: " + Span);
            Console.WriteLine("Cравнений: " + Compar);
        }
        public static void NotFound(TimeSpan span, long compar)
        {
            Console.WriteLine("Ваше число НЕ найдено");
            Console.WriteLine("Время работы алгоритма: " + span);
            Console.WriteLine("Cравнений: " + compar);
        }
        public static int[] ReadFile(int[] n, string path)
        {
            FileStream filestream = new FileStream(path, FileMode.OpenOrCreate);
            BinaryReader reader = new BinaryReader(filestream);
            for (int i = 0; i < n.Length; i++)
                n[i] = reader.ReadInt32();
            reader.Close();
            filestream.Close();
            return n;
        }
    }

}
