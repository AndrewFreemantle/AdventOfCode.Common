// ReSharper disable once CheckNamespace
namespace AdventOfCode.UnitTests;

public class PointTests
{
    [Fact]
    public void PointDefaultsToInt()
    {
        var point = new Point(1, 2);
        Assert.IsType<int>(point.X);
    }

    [Fact]
    public void PointEqualityIsBasedOnXAndY()
    {
        Point<int> pointA = new (1, 2);
        Point<int> pointB = new (1, 2);

        Assert.True(pointA.Equals(pointB));
        Assert.True(pointA == pointB);
        Assert.False(pointA != pointB);
    }

    [Fact]
    public void PointEqualityIsBasedOnXAndYAndZ()
    {
        Point<int> pointA = new (1, 2, 3);
        Point<int> pointB = new (1, 2, 3);

        Assert.True(pointA.Equals(pointB));
        Assert.True(pointA == pointB);
        Assert.False(pointA != pointB);
    }

    [Fact]
    public void CanCreatePointOfLong()
    {
        var pointLongA = new Point<long>(2, 3);
        var pointLongB = new Point<long>(2, 3);

        Assert.True(pointLongA == pointLongB);
        Assert.IsType<long>(pointLongA.X);
    }

}
