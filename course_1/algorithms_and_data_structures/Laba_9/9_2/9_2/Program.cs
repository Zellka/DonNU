using System;
using System.Collections.Generic;

namespace _9_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> brackets = new Stack<char>();
            Console.Write("Введите математическое выражение: ");
            string expression = Console.ReadLine();
            foreach (char i in expression)
            {
                if (i == '(')
                    brackets.Push(i);
                if (i == ')')
                    brackets.Pop();
            }
            if (brackets.Count == 0)
                Console.Write("Выражение - корректно");
            else
                Console.Write("Выражение - некорректно");
        }
    }
}
