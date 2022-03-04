/*Написать тесты с помощью NUnit для решения задачи, в соответствии с вариантом, с
Assert’ами коллекций*/

/*(2-3) В Production Code написать класс ArrayProcessor с методом int[] SortAndFilter(int[] a),
который формирует новый массив на основе входного: сортирует массив (не затрагивая
исходный) и удаляет из него все повторяющиеся отрицательные элементы (оставляя по
одному). В Test Code написать тесты, которые проверяют соответствие результатов
метода спецификации требований */

using System;
using System.Linq;

namespace Lab1
{
    class ArrayProcessor
    {
        public int[] SortAndFilter(int[] a)
        {
            int[] arrayNegative = Array.FindAll(a, (val) => val < 0).Distinct().ToArray();
            int[] b = Array.FindAll(a, (val) => val >= 0).Concat(arrayNegative).ToArray();
            Sort(ref b);
            return b;
        }


        public void Sort(ref int[] a)
        {
            int tmp;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] < a[j])
                    {
                        tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
                }
            }
        }
    }
}
