/*Написать тесты с помощью NUnit для решения задачи, в соответствии с вариантом,
 с Assert’ами простых условий и исключений*/

/*(2.1) В Production Code написать класс Rectangle с методом double Diagonal(), который
вычисляет длину диагонали прямоугольника. Стороны вычисляются при установке
координат вершин как в параметризированном конструкторе, так и в методе
SetVertices(double[] x, double [] y), где x и y – это массивы из 4 координат вершин (х,у).
При этом если данные вершины не образуют прямоугольник, бросается исключение
ArgumentException. В Test Code написать тесты, которые проверяют соответствие
результатов метода спецификации требований */

using System;

namespace Lab1
{
    class Rectangle
    {
        private double[] _x;
        private double[] _y;

        private double[] sides;

        public Rectangle() {}

        public Rectangle(double[] x, double[] y)
        {
            SetVertices(x, y);
        }

        public double Diagonal()
        {
            return Math.Sqrt(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2));
        }

        public void SetVertices(double[] x, double[] y)
        {
            IsCreateReqctangle(x, y);
            _x = x;
            _y = y;
        }

        public bool IsCreateReqctangle(double[] x, double[] y)
        {
            int vertexTopLeft = 0;
            int vertexBottomLeft = 0;
            int vertexTopRight = 0; 
            int vertexBottomRight = 0; 

            for (int i = 0; i < 4; i++)
            {
                if (x[vertexTopLeft] >= x[i] && y[vertexTopLeft] <= y[i])
                    vertexTopLeft = i;

                if (x[vertexBottomLeft] >= x[i] && y[vertexBottomLeft] >= y[i])
                    vertexBottomLeft = i;

                if (x[vertexTopRight] <= x[i] && y[vertexTopRight] <= y[i])
                    vertexTopRight = i;

                if (x[vertexBottomRight] <= x[i] && y[vertexBottomRight] >= y[i])
                    vertexBottomRight = i;
            }

            double heightLeft = y[vertexTopLeft] - y[vertexBottomLeft];
            double heightRight = y[vertexTopRight] - y[vertexBottomRight];

            double widthTop = x[vertexTopRight] - x[vertexTopLeft];
            double widthBottom = x[vertexBottomRight] - x[vertexBottomLeft];

            if (heightLeft != heightRight)
                throw new ArgumentException();

            if (widthTop != widthBottom)
                throw new ArgumentException();

           if (widthTop + widthBottom == 0 || heightLeft + heightRight == 0)
                throw new ArgumentException();

            sides = new double[2] { heightLeft, widthTop };
            return true;
        }
    }
}
