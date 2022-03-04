/*Написать тесты с помощью MSTest для решения задачи, в соответствии с вариантом,
со строковыми Assert’ами*/

/* (1-2) В Production Code написать класс StringFormatter с методом string SafeString(string s),
который во входной строке экранирует все одинарные кавычки (дублирует их для
защиты от sql-инъекций в Postgre), а также переводит все ключевые слова select, insert,
update, delete в верхний регистр; если строка пустая, то метод возвращает также пустую
строку; если строка является null, то метод бросает исключение NullReferenceException. 
В Test Code написать тесты, которые проверяют корректность работы метода.*/

using System;

namespace Lab1
{
    class StringFormatter
    {
        public string SafeString(string s)
        {
            if (s == null)
                throw new NullReferenceException();

            s = s.Replace("'", "''");
            s = s.Replace("select", "SELECT").Replace("insert", "INSERT").Replace("update", "UPDATE").Replace("delete", "DELETE");

            return s;
        }
    }
}
