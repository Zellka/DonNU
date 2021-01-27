using System;

namespace _9_6_1_6_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = new List<int>() { 1, 2, 3, 45 };
            List<int> secondList = new List<int>() { 5, 2, 7, 55 }; //{ 5, 6, 7, 55 };
            int count = 0;
            foreach (int i in secondList)
            {
                if (!firstList.Contains(i))
                    count++;
            }
            if (count == firstList.Count)
                Console.WriteLine("Первый список НЕ содержит элементы второго");
            else
                Console.WriteLine("Первый список содержит элементы второго");
        }
    }
}
