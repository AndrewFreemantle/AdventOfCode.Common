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

    private static readonly List<Point<int>> ComplicatedPolygon =
    [
        new (0, 0), new (1, 0), new (2, 0), new (3, 0), new (4, 0), new (5, 0), new (6, 0),
        new (0, 1),                                                             new (6, 1),
        new (0, 2), new (1, 2), new (2, 2), new (3, 2), new (4, 2),             new (6, 2), new (7, 2), new (8,2),
        new (4, 3),                                                                                     new (8, 3),
        new (0, 4), new (1, 4), new (2, 4),             new (4, 4),                                     new (8, 4), new (9, 4),
        new (0, 5),             new (2, 5),             new (4, 5),                                                 new (9, 5),
        new (0, 6),             new (2, 6), new (3, 6), new (4, 6),                                                 new (9, 6),
        new (0, 7),                                                             new (6, 7), new (7, 7), new (8, 7), new (9, 7),
        new (0, 8), new (1, 8), new (2, 8), new (3, 8), new (4, 8), new (5, 8), new (6, 8)
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
        Assert.False(new Point<int>(7, 0).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(8, 0).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(9, 0).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point<int>(7, 1).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(8, 1).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(9, 1).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point<int>(9, 2).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point<int>(0, 3).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(1, 3).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(2, 3).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(3, 3).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(9, 3).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point<int>(3, 4).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point<int>(3, 5).IsPointInside(ComplicatedPolygon));

        Assert.False(new Point<int>(7, 8).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(8, 8).IsPointInside(ComplicatedPolygon));
        Assert.False(new Point<int>(9, 8).IsPointInside(ComplicatedPolygon));
    }

    [Fact]
    public void PointsInsideAreConsideredInside()
    {
        for (int x = 1; x <= 5; x++)
            Assert.True(new Point<int>(x,1).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point<int>(5,2).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point<int>(5,3).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(6,3).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(7,3).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point<int>(5,4).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(6,4).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(7,4).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point<int>(1,5).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(5,5).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(6,5).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(7,5).IsPointInside(ComplicatedPolygon));

        Assert.True(new Point<int>(1,6).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(5,6).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(6,6).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(7,6).IsPointInside(ComplicatedPolygon));
        Assert.True(new Point<int>(8,6).IsPointInside(ComplicatedPolygon));

        for (int x = 1; x <= 5; x++)
            Assert.True(new Point<int>(x,7).IsPointInside(ComplicatedPolygon));
    }
}
