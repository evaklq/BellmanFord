using BellmanFordAlgorythm;
using BenchmarkDotNet.Running;

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<BenchmarkTests>();
        int vertexCount = 4;
        int startVertex = 0;
        int[,] edges = new int[4, 3]
        {
            { 0, 1, 2},
            {0, 2, 5},
            {2, 1, -4},
            {1, 3, 2}
        };

        Algoruthm algoruthm = new Algoruthm();
        algoruthm.FindDistancesWithFordFalkerson(edges, vertexCount, startVertex);

        

    }
}