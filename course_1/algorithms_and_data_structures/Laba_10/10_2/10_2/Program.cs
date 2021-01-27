using System;

namespace _10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bills = new int[100];
            bills = RandomBills(bills);
            CountingSort(bills);
            for (int i = 0; i < bills.Length; i++)
                Console.WriteLine(bills[i]);
        }
        public static int[] RandomBills(int[] bills)
        {
            Random rand = new Random();
            for (int i = 0; i < bills.Length; i++)
            {
                bills[i] = rand.Next(7); //7, т.к. 7 видов купюр (1, 2, 5, 10, 20, 50, 100)
                switch (bills[i])
                {
                    case 1:
                        bills[i] = 1;
                        break;
                    case 2:
                        bills[i] = 2;
                        break;
                    case 3:
                        bills[i] = 5;
                        break;
                    case 4:
                        bills[i] = 10;
                        break;
                    case 5:
                        bills[i] = 20;
                        break;
                    case 6:
                        bills[i] = 50;
                        break;
                    case 0:
                        bills[i] = 100;
                        break;
                }
            }
            return bills;
        }
        public static void CountingSort(int[] a)
        {
            int left = 0, right = a.Length - 1;
            int min = 0, max = 0;
            for (int i = left; i <= right; i++)
            {
                if (a[i] < min) min = a[i];
                else if (a[i] > max) max = a[i];
            }
            int bn = max - min + 1;
            int[] buckets = new int[bn];
            for (int i = left; i <= right; i++)
                buckets[a[i] - min]++;
            int idx = 0;
            for (int i = min; i <= max; i++)
                for (int j = 0; j < buckets[i - min]; j++)
                    a[idx++] = i;
        }
    }
}
