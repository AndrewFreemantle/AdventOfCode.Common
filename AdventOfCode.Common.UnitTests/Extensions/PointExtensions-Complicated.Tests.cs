using AdventOfCode.Types;
using Xunit;

// ReSharper disable once CheckNamespace
namespace AdventOfCode.UnitTests;

public class PointExtensionsComplicatedTests
{
    /*   0123456789 x
     * 0 #######...
     * 1 #.....#...
     * 2 #####.###.
     * 3 ....#...#.
     * 4 ###.#...##
     * 5 #.#.#....#
     * 6 #.###....#
     * 7 #.....####
     * 8 #######...
     * y
     */

    private static readonly List<Point> ComplicatedPolygon =
    [
        new Point(0, 0), new Point(1, 0), new Point(2, 0), new Point(3, 0), new Point(4, 0), new Point(5, 0), new Point(6, 0),
        new Point(0, 1), new Point(6, 1),
        new Point(0, 2), new Point(1, 2), new Point(2, 2), new Point(3, 2), new Point(4, 2), new Point(6, 2), new Point(7, 2), new Point(8,2),
        new Point(4, 3), new Point(8, 3),
        new Point(0, 4), new Point(1, 4), new Point(2, 4), new Point(4, 4), new Point(8, 4), new Point(9, 4),
        new Point(0, 5), new Point(2, 5), new Point(4, 5), new Point(9, 5),
        new Point(0, 6), new Point(2, 6), new Point(3, 6), new Point(4, 6), new Point(9, 6),
        new Point(0, 7), new Point(6, 7), new Point(7, 7), new Point(8, 7), new Point(9, 7),
        new Point(0, 8), new Point(1, 8), new Point(2, 8), new Point(3, 8), new Point(4, 8), new Point(5, 8), new Point(6, 8)
    ];

    [Fact]
    public void BoundaryIsConsideredInside()
    {
        foreach(var point in ComplicatedPolygon)
            Assert.True(point.IsPointInside(ComplicatedPolygon));
    }

    [Fact]
    public void PointsOutsideAreConsideredOutside()
    {
        Assert.False(new Point(7, 0).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(8, 0).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(9, 0).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point(7, 1).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(8, 1).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(9, 1).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point(9, 2).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point(0, 3).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(1, 3).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(2, 3).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(3, 3).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(9, 3).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point(3, 4).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point(3, 5).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point(7, 8).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(8, 8).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point(9, 8).IsPointInside(ComplicatedPolygon));
    }

    [Fact]
    public void PointsInsideAreConsideredInside()
    {
        for (int x = 1; x <= 5; x++)
            Assert.True(new Point(x,1).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point(5,2).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point(5,3).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(6,3).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(7,3).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point(5,4).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(6,4).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(7,4).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point(1,5).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(5,5).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(6,5).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(7,5).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point(1,6).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(5,6).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(6,6).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(7,6).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point(8,6).IsPointInside(ComplicatedPolygon));

        for (int x = 1; x <= 5; x++)
            Assert.True(new Point(x,7).IsPointInside(ComplicatedPolygon));
    }
}
