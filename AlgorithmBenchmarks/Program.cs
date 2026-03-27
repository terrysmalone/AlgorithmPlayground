using BenchmarkDotNet.Running;

namespace AlgorithmBenchmarks;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<FloodFillBenchmarks>();
    }
}
