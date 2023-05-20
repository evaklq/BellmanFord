using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellmanFordAlgorythm
{
    public class Algoruthm
    {
        /// <summary>
        /// На вход подаётся массив рёбер, состоящий из начальной-вершины, вершины, куда нужно попасть и расстоянием между ними;
        /// количество вершин;
        /// количество рёбер;
        /// стартовая вершина;
        /// </summary>
        public void FindDistancesWithFordFalkerson(int[,] edges, int vertexCount, int startVertex)
        {
            int edgesCount = edges.GetUpperBound(0) + 1;
            int[] distances = new int[vertexCount]; // массив, который будет ответом
            int inf = int.MaxValue; // условно бесконечность

            for (int i = 0; i < distances.Length; i++) // заполняем массив
            {
                distances[i] = inf;
            }
            distances[startVertex] = 0;

            for (int i = 0; i < vertexCount - 1; i++)
            {
                for (int j = 0; j < edgesCount; j++)
                {
                    int startVertexIndex = edges[j, 0];
                    int endVertexIndex = edges[j, 1];
                    int weight = edges[j, 2];

                    // если до вершины есть путь, то есть != int.MaxValue и есть какой-то путь короче, чем нынешний до неё
                    if (distances[startVertexIndex] != int.MaxValue && distances[startVertexIndex] + weight < distances[endVertexIndex])
                    {
                        distances[endVertexIndex] = distances[startVertexIndex] + weight;
                    }
                }
            }

            for (int i = 0; i < edgesCount; i++)
            {
                int startVertexIndex = edges[i, 0];
                int endVertexIndex = edges[i, 1];
                int weight = edges[i, 2];

                // если мы добавляем какое-то расстояние и путь становится меньше =>  есть отрицательный цикл
                if (distances[startVertexIndex] != int.MaxValue && distances[startVertexIndex] + weight < distances[endVertexIndex])
                {
                    Console.WriteLine("Граф содержит циклы с отрицательным весом");
                    return;
                }
            }

            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine(@"Расстоняние от стартовой вершины {0} до {1} = {2}", startVertex, i, distances[i]);
            }

        }
    }
}
