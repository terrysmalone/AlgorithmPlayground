using System.Drawing;
using FloodFillAlgorithm;
using NUnit.Framework;

namespace FloodFillAlgorithmTests;

public class FloodFillTests
{
    [TestCase(0, 0, 0)]
    [TestCase(5, 5, 24)]
    public void GetAvailableSpace_EmptyGrid(int width, int height, int expectedResult)
    {
        // Arrange
        var emptyGrid = new bool[height, width];
        var floodFill = new FloodFill(emptyGrid);
        var startPoint = new Point(0, 0);

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

        var floodFill = new FloodFill(grid);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(new Point(2, 2));

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

        var floodFill = new FloodFill(grid);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(new Point(3, 2));

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

        var floodFill = new FloodFill(grid);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(new Point(3, 1));

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

        var floodFill = new FloodFill(grid);

        // Act
        int availableSpace = floodFill.GetAvailableSpace(new Point(0, 3));

        Assert.AreEqual(19, availableSpace);
    }
}