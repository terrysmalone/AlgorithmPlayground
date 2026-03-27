using System.Drawing;
using FloodFillAlgorithm;
using NUnit.Framework;

namespace FloodFillAlgorithmTests;

public class SentinelFloodFillTests
{
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

    [TestCase(10, 10, 99)]
    [TestCase(5, 5, 24)]
    public void GetAvailableSpace_EmptyGrid(int width, int height, int expectedResult)
    {
        // Arrange
        var emptyGrid = new bool[height, width];
        bool[,] sentinelGrid = ConvertToSentinelGrid(emptyGrid);
        var floodFill = new SentinelFloodFill(sentinelGrid);
        var startPoint = new Point(1, 1);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(startPoint);

        // Assert
        Assert.AreEqual(expectedResult, availableSpace);
    }

    [Test]
    public void GetAvailableSpace_CompletelySurrounded()
    {
        // Arrange
        /*
         -------
         -     - 
         - XXX -
         - XOX -
         - XXX -
         _     _
         -------
         */
        var grid = new bool[,]
        {
            { false, false, false, false, false },
            { false, true, true, true, false },
            { false, true, false, true, false },
            { false, true, true, true, false },
            { false, false, false, false, false },
        };

        bool[,] sentinelGrid = ConvertToSentinelGrid(grid);

        var floodFill = new SentinelFloodFill(sentinelGrid);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(new Point(3, 3));

        Assert.AreEqual(0, availableSpace);
    }

    [Test]
    public void GetAvailableSpace_HorizontallyBlocked()
    {
        // Arrange
        /*
         -------
         -     -          
         -     -
         -XXXXX-
         -  O  -
         _     _
         -------
         */
        var grid = new bool[,]
        {
            { false, false, false, false, false },
            { false, false, false, false, false },
            { true, true, true, true, true },
            { false, false, false, false, false },
            { false, false, false, false, false },
        };
        bool[,] sentinelGrid = ConvertToSentinelGrid(grid);

        var floodFill = new SentinelFloodFill(sentinelGrid);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(new Point(4, 3));

        Assert.AreEqual(9, availableSpace);
    }


    [Test]
    public void GetAvailableSpace_VerticallyBlocked()
    {
        // Arrange
        /*
         -------
         -  X  -          
         -  X  -
         -  X  -
         - OX  -
         _  X  _
         -------
         */
        var grid = new bool[,]
        {
            { false, false, true, false, false },
            { false, false, true, false, false },
            { false, false, true, false, false },
            { false, false, true, false, false },
            { false, false, true, false, false },
        };
        bool[,] sentinelGrid = ConvertToSentinelGrid(grid);

        var floodFill = new SentinelFloodFill(sentinelGrid);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(new Point(4, 2));

        Assert.AreEqual(9, availableSpace);
    }

    [Test]
    public void GetAvailableSpace_Complex()
    {
        // Arrange
        /*
         -------
         -     -          
         -  X  -
         - X   -
         -O XX -
         _  X  _
         -------
         */
        var grid = new bool[,]
        {
            { false, false, false, false, false },
            { false, false, true, false, false },
            { false, true, false, false, false },
            { false, false, true, true, false },
            { false, false, true, false, false },
        };
        bool[,] sentinelGrid = ConvertToSentinelGrid(grid);

        var floodFill = new SentinelFloodFill(sentinelGrid);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(new Point(1, 4));

        Assert.AreEqual(19, availableSpace);
    }
}