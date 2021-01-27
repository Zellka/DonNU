using System;
using System.Collections.Generic;

namespace _10_3_2
{
    class Program
    {
		public static List<int>[] adjList = null;
		public static int V = 8;
		static void Main(string[] args)
        {
            adjList = new List<int>[V];
			Add(1, new int[] { 2, 3 });
			Add(2, new int[] { 1, 6, 7 });
			Add(3, new int[] { 1, 4, 6, 8 });
			Add(4, new int[] { 3, 5 });
			Add(5, new int[] { 4, 6 });
			Add(6, new int[] { 2, 3, 5 });
			Add(7, new int[] { 2, 8 });
			Add(8, new int[] { 3, 7 });

            Console.Write("Введите вершину, с которой нужно начать: ");
            int startPos = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Введите вершину, до которой мы ищем путь: ");
            int endPos = int.Parse(Console.ReadLine()) - 1;

            Stack<int> paths = DFS(startPos, endPos);
            Console.WriteLine("DFS:");
            int tmp = 0;
			Console.WriteLine("Начинаем с " + (startPos + 1));
			while (paths.Count > 0)
            {
                tmp = paths.Pop() + 1;
                Console.Write(" -> " + tmp);
            }
            Console.WriteLine();

            Stack<int> paths2 = BFS(startPos, endPos);
            Console.WriteLine("BFS:");
			Console.WriteLine("Начинаем с " + (startPos + 1));
			while (paths2.Count > 0)
            {
                tmp = paths2.Pop() + 1;
                Console.Write(" -> " + tmp);
            }
            Console.WriteLine();

        }
        public static void Add(int v, int[] n) // v - вершины, n - соседи
		{
            v--;
            for (int i = 0; i < n.Length; i++)
                n[i] = n[i] - 1;
            adjList[v] = new List<int>(n);
        }
		public static Stack<int> DFS(int startPos, int endPos)
		{
			Stack<int> st = new Stack<int>();

			int[] pathV = new int[V];
			int[] checkV = new int[V];

			st.Push(startPos);
			checkV[startPos] = 1;

			while (st.Count > 0)
			{
				int i = st.Pop();

				for (int j = V - 1; j >= 0; j--)
				{
					if (adjList[i].IndexOf(j) != -1 && checkV[j] == 0)
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
		public static Stack<int> BFS(int startPos, int endPos)
		{
			Queue<int> q = new Queue<int>();

			int[] pathV = new int[V];
			int[] checkV = new int[V];

			q.Enqueue(startPos);
			checkV[startPos] = 1;

			while (q.Count > 0)
			{
				int i = q.Dequeue();

				for (int j = 0; j < V; j++)
				{
					if (adjList[i].IndexOf(j) != -1 && checkV[j] == 0)
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
