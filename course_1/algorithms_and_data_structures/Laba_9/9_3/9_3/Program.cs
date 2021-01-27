using System;
using System.IO;
using System.Collections.Generic;

namespace _9_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Участники: Борис, Иван, Саша, Тимур, Влад, Оксана, Питер");
            Console.Write("Введите имя человека, с которого нужно начать: ");
            string name = Console.ReadLine();
            CircularList<string> players = new CircularList<string>();
            string[] names = { "Борис", "Иван", "Саша", "Тимур", "Влад", "Оксана", "Питер" };
            foreach (string i in names)
                players.Add(i);
            if (!players.Contains(name))
                Console.WriteLine("Ошибка. Такого человека нет среди участников.");
            else
                Сounting(players, name);
        }
        public static void Сounting(CircularList<string> players, string name)
        {
            Console.Write("Введите считалочку: ");
            string counting = Console.ReadLine();
            string[] words = counting.Split(' ');
            players.Replace(name);
            int count = 0;
            foreach (string player in players)
            {
                if (count == words.Length)
                    Console.WriteLine(player);
                count++;
            }
        }
    }
}
