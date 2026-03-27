using BenchmarkDotNet.Attributes;
using EnvDTE;
using FloodFillAlgorithm;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VSDiagnostics;
using System;
using System.Drawing;
using System.Security.Cryptography;

namespace AlgorithmBenchmarks;

[MemoryDiagnoser]
public class FloodFillBenchmarks
{
    private FloodFill _floodFill;
    private SentinelFloodFill _sentinelFloodFill;

    private Point _startPoint;

    [GlobalSetup]
    public void Setup()
    {
        bool[,] grid = GenerateGrid(1000, 1000, 0.2);
        bool[,] sentinelGrid = ConvertToSentinelGrid(grid);

        _floodFill = new FloodFill(grid);
        _sentinelFloodFill = new SentinelFloodFill(sentinelGrid);

        _startPoint = new Point(10, 10); 
    }

    private bool[,] ConvertToSentinelGrid(bool[,] grid)
    {
        bool[,] sentinelGrid = new bool[grid.GetLength(0) + 2, grid.GetLength(1) + 2];

        int height = sentinelGrid.GetLength(0);
        int width = sentinelGrid.GetLength(1);

        // Fill the edges completely to create a sentinel border
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (y == 0 || y == height - 1 || x == 0 || x == width - 1)
                {
                    sentinelGrid[y, x] = true;
                }
                else
                {
                    sentinelGrid[y, x] = grid[y - 1, x - 1];
                }
            }
        }

        return sentinelGrid;
    }

    [Benchmark(Baseline = true)]
    public int BasicFloodFill()
    {
        return _floodFill.GetAvailableSpace(_startPoint);
    }

    [Benchmark]
    public int SentinelFloodFill()
    {
        return _sentinelFloodFill.GetAvailableSpace(new Point(_startPoint.X + 1, _startPoint.Y + 1));
    }

    private static bool[,] GenerateGrid(int width, int height, double fillRatio)
    {
        // Use a consistent seed for reproducibility
        var rand = new Random(42);

        var grid = new bool[height, width];

        for (int y = 0; y < height; y++)
        { 
            for (int x = 0; x < width; x++)
            {
                grid[y, x] = rand.NextDouble() < fillRatio;
            }
        }

        return grid;
    }
}
