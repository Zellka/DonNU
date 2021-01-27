using System;
using System.Collections.Generic;

namespace _10_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] roadSystem = { { -1, 250, -1, -1, -1},
                                  {250, -1, 50, 120, 100},
                                  {-1, 50, -1, 170, 150},
                                  {220, 120, 170, -1, 78},
                                  {-1, 100, 150, 78, -1 }};
            int numСities = 5;
            Console.Write("С какого города начнём? Введите номер от 1 до 5: ");
            int s = int.Parse(Console.ReadLine()) - 1;
            for (int i = 0; i < numСities; i++)
            {
                int path = ShortestPath(s, i, roadSystem, numСities);
                if (path <= 200 && path > 0)
                            Console.WriteLine("Расстояние от " + (s + 1) + " до " + (i + 1) + " = " + path);
            }
        }
        public static int ShortestPath(int s, int v, int[,] graph, int V)
        {
            List<int> distances = new List<int>();
            List<int> q = new List<int>();
            for (int i = 0; i < V; i++)
            {
                distances.Add(int.MaxValue);
                q.Add(i);
            }
            distances[s] = 0;
            while (q.Count > 0)
            {
                int u = -1, min = int.MaxValue;

                for (int i = 0; i < q.Count; i++)
                {
                    if (distances[q[i]] <= min)
                    {
                        min = distances[q[i]];
                        u = q[i];
                    }
                }
                q.Remove(u);
                for (int i = 0; i < V; i++)
                    if (graph[u, i] > 0)
                        if (distances[i] > graph[u, i] + distances[u])
                            distances[i] = graph[u, i] + distances[u];
            }
            return distances[v];
        }
    }
}
