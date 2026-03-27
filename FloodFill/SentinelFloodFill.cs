using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FloodFillAlgorithm;

public class SentinelFloodFill
{
    private readonly bool[,] _grid;

    public SentinelFloodFill(bool[,] grid)
    {
        _grid = grid;
    }

    public int GetAvailableSpace(Point point)
    {
        var visited = new HashSet<Point>();
        var toCheck = new Queue<Point>();

        visited.Add(point);
        toCheck.Enqueue(point);

        while (toCheck.Count > 0)
        {
            Point checkPoint = toCheck.Dequeue();

            var adjacentPoints = new List<Point>
            {
                new Point(checkPoint.X, checkPoint.Y - 1),
                new Point(checkPoint.X, checkPoint.Y + 1),
                new Point(checkPoint.X - 1, checkPoint.Y),
                new Point(checkPoint.X + 1, checkPoint.Y)
            };

            foreach (Point adjacentPoint in adjacentPoints)
            {
                if (!visited.Contains(adjacentPoint)
                    && !_grid[adjacentPoint.X, adjacentPoint.Y])
                {
                    toCheck.Enqueue(adjacentPoint);
                    visited.Add(adjacentPoint);
                }
            }
        }

        // -1 because we don't count the initial point
        return visited.Count - 1;
    }
}
