using System;
using System.Collections.Generic;

namespace _9_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> data = new Dictionary<string, int> { };
            int counts = Convert.ToInt32(Math.Pow(100000, 1d / 3));
            CubSum(data, counts);
            CubCheck(data);
        }
        public static void CubSum(Dictionary<string, int> data, int counts)
        {
            for (int p = 1; p <= counts; p++)
            {
                for (int y = 1; y <= counts; y++)
                {
                    for (int z = 1; z <= counts; z++)
                    {
                        double p3 = Math.Pow(p, 3), y3 = Math.Pow(y, 3), z3 = Math.Pow(z, 3);
                        int cubSum = Convert.ToInt32(p3 + y3 + z3);
                        string strSum = "Кубичекие корни N: " + p + " , " + y + " , " + z;
                        data.Add(strSum, cubSum);
                    }
                }
            }
        }
        public static void CubCheck(Dictionary<string, int> data)
        {
            int[] check = new int[100001];
            foreach (KeyValuePair<string, int> N in data)
            {
                if (N.Value < check.Length)
                    check[N.Value]++;
            }
            for (int i = 0; i < check.Length; i++)
            {
                if (check[i] >= 6)
                    Console.WriteLine(i);
            }
        }
    }
}
