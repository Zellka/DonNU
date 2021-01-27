using System;
using System.Collections.Generic;

namespace _10_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] adjMatrix = { { 0, 1, 1, 0, 0, 0, 0, 0 }, //1
                               { 1, 0, 0, 0, 0, 1, 1, 0 },  //2
                               { 1, 0, 0, 1, 0, 1, 0, 1 },  //3
                               { 0, 0, 1, 0, 1, 0, 0, 0 },  //4
                               { 0, 0, 0, 1, 0, 1, 0, 0 },  //5
                               { 0, 1, 1, 0, 1, 0, 0, 0 },  //6
                               { 0, 1, 0, 0, 0, 0, 0, 1 },  //7
                               { 0, 0, 1, 0, 0, 0, 1, 0 }}; //8
            
            Console.Write("Введите вершину, с которой нужно начать: ");
            int startPos = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Введите вершину, до которой мы ищем путь: ");
            int endPos = int.Parse(Console.ReadLine()) - 1;

            Stack<int> paths = DFS(startPos, endPos, adjMatrix);
            Console.WriteLine("DFS:");
            int tmp = 0;
            Console.WriteLine("Начинаем с " + (startPos + 1));
            while (paths.Count > 0)
            {
                tmp = paths.Pop() + 1;
                Console.Write(" -> " + tmp);
            }
            Console.WriteLine();

            Stack<int> paths2 = BFS(startPos, endPos, adjMatrix);
            Console.WriteLine("BFS:");
            Console.WriteLine("Начинаем с " + (startPos + 1));
            while (paths2.Count > 0)
            {
                tmp = paths2.Pop() + 1;
                Console.Write(" -> " + tmp);
            }
            Console.WriteLine();
        }
		public static Stack<int> DFS(int startPos, int endPos, int[,] graph)
		{
			Stack<int> st = new Stack<int>();

			int[] pathV = new int[8];
			int[] checkV = new int[8];

			st.Push(startPos);
			checkV[startPos] = 1;

			while (st.Count > 0)
			{
				int i = st.Pop();
				for (int j = 8 - 1; j >= 0; j--)
				{
					if (graph[i, j] == 1 && checkV[j] == 0)
					{
						checkV[j] = 1;
						st.Push(j);
						pathV[j] = i;
						if (j == endPos)
							return BackChain(pathV, startPos, endPos);
					}
				}
			}
			return null;
		}
		public static Stack<int> BFS(int startPos, int endPos, int[,] graph)
		{
			Queue<int> q = new Queue<int>();

			int[] pathV = new int[8];
			int[] checkV = new int[8];

			q.Enqueue(startPos);
			checkV[startPos] = 1;

			while (q.Count > 0)
			{
				int i = q.Dequeue();

				for (int j = 0; j < 8; j++)
				{
					if (graph[i, j] == 1 && checkV[j] == 0)
					{
						checkV[j] = 1;
						q.Enqueue(j);
						pathV[j] = i;
						if (j == endPos)
							return BackChain(pathV, startPos, endPos);
					}
				}
			}
			return null;
		}
		public static Stack<int> BackChain(int[] p, int startPos, int endPos)
		{
			int pos = endPos;
			Stack<int> pathStack = new Stack<int>();
			pathStack.Push(pos);
			while (pos != startPos)
			{
				pos = p[pos];
				pathStack.Push(pos);
			}
			return pathStack;
		}
	}
}
