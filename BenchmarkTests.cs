using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BellmanFordAlgorythm
{
    public class BenchmarkTests
    {
        static Random random = new Random();

        static int[,] GenerateGraph(int vertexCount, int edgeCount)
        {
            int[,] graph = new int[edgeCount, 3];

            HashSet<string> edgeSet = new HashSet<string>();

            int count = 0;
            while (count < edgeCount)
            {
                int u = random.Next(vertexCount);
                int v = random.Next(vertexCount);
                int weight = random.Next(1, 10);

                string edgeKey = u + "-" + v;

                if (u != v && !edgeSet.Contains(edgeKey))
                {
                    graph[count, 0] = u;
                    graph[count, 1] = v;
                    graph[count, 2] = weight;

                    edgeSet.Add(edgeKey);
                    count++;
                }
            }

            return graph;
        }

        int[,] FirstEdgesCount = GenerateGraph(10, 10);
        int[,] SecoundEdgesCount = GenerateGraph(100, 100);
        int[,] ThirdEdgesCount = GenerateGraph(1000, 1000);
        int[,] FourthEdgesCount = GenerateGraph(10000, 10000);
        int[,] FifthEdgesCount = GenerateGraph(100000, 100000);
        int[,] SixthEdgesCount = GenerateGraph(1000000, 1000000);

        int FirstVertexCount = 10;
        int SecoundVertexCount = 100;
        int ThirdVertexCount = 1000;
        int FourthVertexCount = 10000;
        int FifthVertexCount = 100000;
        int SixthVertexCount = 1000000;

        int StartVertex = 0;

        Algoruthm algoruthm = new Algoruthm();

        [Benchmark(Description = "10")]
        public void FirstMethodForTest()
        {
            algoruthm.FindDistancesWithFordFalkerson(FirstEdgesCount, FirstVertexCount, StartVertex);
        }

        [Benchmark(Description = "100")]
        public void SecoundMethodForTest()
        {
            algoruthm.FindDistancesWithFordFalkerson(SecoundEdgesCount, SecoundVertexCount, StartVertex);
        }

        [Benchmark(Description = "1000")]
        public void ThirdMethodForTest()
        {
            algoruthm.FindDistancesWithFordFalkerson(ThirdEdgesCount, ThirdVertexCount, StartVertex);
        }

        [Benchmark(Description = "10000")]
        public void FourthMethodForTest()
        {
            algoruthm.FindDistancesWithFordFalkerson(FourthEdgesCount, FourthVertexCount, StartVertex);
        }




        
    }


}
