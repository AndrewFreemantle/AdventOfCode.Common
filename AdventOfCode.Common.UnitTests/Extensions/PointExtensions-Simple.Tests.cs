using AdventOfCode.Types;
using Xunit;

// ReSharper disable once CheckNamespace
namespace AdventOfCode.UnitTests;

public class PointExtensionsSimpleTests
{
    /*   01234 x
     * 0 .....
     * 1 .###.
     * 2 .#.#.
     * 3 .###.
     * 4 .....
     * y
     */

    private static readonly List<Point> SimpleSquarePolygon =
    [
        new Point(1, 1), new Point(2, 1), new Point(3, 1),
        new Point(1, 2),                      new Point(3, 2),
        new Point(1, 3), new Point(2, 3), new Point(3, 3)
    ];

    [Fact]
    public void BoundaryIsConsideredInside()
    {
        foreach(var point in SimpleSquarePolygon)
            Assert.True(point.IsPointInside(SimpleSquarePolygon));
    }

    [Fact]
    public void PointsAboveAreConsideredOutside()
    {
        for (int x = 0; x <= 4; x++)
            Assert.False(new Point(x, 0).IsPointInside(SimpleSquarePolygon));
    }

    [Fact]
    public void PointsInsideAreConsideredInside()
    {
        Assert.True(new Point(2, 2).IsPointInside(SimpleSquarePolygon));
    }

    [Fact]
    public void PointsBelowAreConsideredOutside()
    {
        for (int x = 0; x <= 4; x++)
            Assert.False(new Point(x, 4).IsPointInside(SimpleSquarePolygon));
    }

    [Fact]
    public void PointsToTheLeftAreConsideredOutside()
    {
        for (int y = 0; y <= 4; y++)
            Assert.False(new Point(0, y).IsPointInside(SimpleSquarePolygon));
    }

    [Fact]
    public void PointsToTheRightAreConsideredOutside()
    {
        for (int y = 0; y <= 4; y++)
            Assert.False(new Point(4, y).IsPointInside(SimpleSquarePolygon));
    }
}
