using System;

namespace _8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку, в которой будет осуществляться поиск(на англ): ");
            string text = Console.ReadLine();
            Console.Write("Введите подстроку для поиска(на англ): ");
            string pattern = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Простой поиск подстроки в строке");
            SimpleSearch1(text, pattern);
            Console.WriteLine("Кнут-Моррис-Пратт");
            KMPSearch(text, pattern);
            Console.WriteLine("Бойера-Мура-Хорспула");
            BMHSearch(text, pattern);
        }
        public static int SimpleSearch1(string t, string p) //1 вариант простого поиска подстроки (быстрее второго)
        {
            DateTime start = DateTime.Now;
            int compar = 0, position = -1;
            int n = t.Length;
            int m = p.Length;
            int j = 0;
            for (int i = 0; i <= n - m; i++)
            {
                compar++; position++;
                while (j < m && t[position + j] == p[j]) j++;
                if (j == m)
                {
                    DateTime Stop = DateTime.Now;
                    TimeSpan Span = Stop.Subtract(start);
                    Found(Span, compar, position);
                    return position;
                }
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            NotFound(span, compar);
            return -1;
        }
        public static int SimpleSearch2(string t, string p) //2 вариант простого поиска подстроки
        {
            DateTime start = DateTime.Now;
            int compar = 0, position = 0;
            for (int i = 0; i < t.Length; i++)
            {
                compar++; 
                if (t.Contains(p) == true)
                {
                    position = t.IndexOf(p);
                    DateTime Stop = DateTime.Now;
                    TimeSpan Span = Stop.Subtract(start);
                    Found(Span, compar, position);
                    return position;
                }
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            NotFound(span, compar);
            return -1;
        }

        public static int KMPSearch(string text, string pattern)
        {
            DateTime start = DateTime.Now;
            int compar = 0, position = 0;
            int n = text.Length;
            int m = pattern.Length;

            int[] prefix = PrefixFunction(pattern);
            int j = 0;
            for (int i = 1; i <= n; i++)
            {
                compar++; 
                while (j > 0 && pattern[j] != text[i - 1]) j = prefix[j - 1];
                if (pattern[j] == text[i - 1])  j++;
                if (j == m)
                {
                    position = i - m;
                    DateTime Stop = DateTime.Now;
                    TimeSpan Span = Stop.Subtract(start);
                    Found(Span, compar, position);
                    return position;	
                }
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            NotFound(span, compar);
            return -1;
        }
        public static int[] PrefixFunction(string s)
        {
            int m = s.Length;
            int[] pi = new int[m];
            int j = 0;
            pi[0] = 0;
            for (int i = 1; i < m; i++)
            {
                while (j > 0 && s[j] != s[i]) j = pi[j];
                if (s[j] == s[i]) j++;
                pi[i] = j;
            }
            return pi;
        }
        public static int BMHSearch(string text, string pattern) //для проверки нужно использовать англ. текст, т.к. используется таблица ASCII
        {
            DateTime start = DateTime.Now;
            int compar = 0, position = 0;

            int n = text.Length;
            int m = pattern.Length;

            if (m > n) return -1;
            int[] badShift = ShiftTable(pattern);

            int offset = 0;
            while (offset <= n - m)
            {
                compar++; 
                int i;
                for (i = m - 1; i >= 0 && pattern[i] == text[i + offset]; i--);
                if (i < 0)
                {
                    position = offset;
                    DateTime Stop = DateTime.Now;
                    TimeSpan Span = Stop.Subtract(start);
                    Found(Span, compar, position);
                    return position;
                }      
                offset += badShift[(int)text[offset + m - 1]];
            }
            DateTime stop = DateTime.Now;
            TimeSpan span = stop.Subtract(start);
            NotFound(span, compar);
            return -1;
        }
        public static int[] ShiftTable(string pattern)
        {
            int m = pattern.Length;
            int[] badShift = new int[256]; //таблица ASCII
            for (int i = 0; i < 256; i++) badShift[i] = m;
            for (int i = 0; i < m - 1; i++) badShift[(int)pattern[i]] = m - 1 - i;
            return badShift;
        }
        public static void Found(TimeSpan Span, int Compar, int position)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Позиция найденного элемента: " + (position));
            Console.WriteLine("Время работы алгоритма: " + Span);
            Console.WriteLine("Cравнений: " + Compar);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public static void NotFound(TimeSpan span, int compar)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ваше число НЕ найдено");
            Console.WriteLine("Время работы алгоритма: " + span);
            Console.WriteLine("Cравнений: " + compar);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }




    }
}
