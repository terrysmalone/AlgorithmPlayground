using System.Drawing;

namespace FloodFillAlgorithm;

public class FloodFill
{
    private readonly bool[,] _grid;

    public FloodFill(bool[,] grid)
    {
        _grid = grid;
    }

    public int GetAvailableSpace(Point point)
    {
        // Bounds check
        if (point.X < 0 || point.X >= _grid.GetLength(0) || point.Y < 0 || point.Y >= _grid.GetLength(1))
        {
            return 0;
        }

        var visited = new HashSet<Point>();
        var toCheck = new Queue<Point>();

        visited.Add(point);
        toCheck.Enqueue(point);

        while (toCheck.Count > 0)
        {
            Point checkPoint = toCheck.Dequeue();

            foreach (Point adjacentPoint in GetAdjacentPoints(checkPoint))
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

    private List<Point> GetAdjacentPoints(Point checkPoint)
    {
        var adjacentPoints = new List<Point>();

        // Up
        if (checkPoint.Y > 0)
        {
            adjacentPoints.Add(new Point(checkPoint.X, checkPoint.Y - 1));
        }

        // Down
        if (checkPoint.Y < _grid.GetLength(1) - 1)
        {
            adjacentPoints.Add(new Point(checkPoint.X, checkPoint.Y + 1));
        }

        // Left
        if (checkPoint.X > 0)
        {
            adjacentPoints.Add(new Point(checkPoint.X - 1, checkPoint.Y));
        }

        // Right
        if (checkPoint.X < _grid.GetLength(0) - 1)
        {
            adjacentPoints.Add(new Point(checkPoint.X + 1, checkPoint.Y));
        }

        return adjacentPoints;
    }
}
