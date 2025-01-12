// ReSharper disable once CheckNamespace
namespace AdventOfCode.UnitTests;

public class LinqExtensionsTests
{
    [Fact]
    public void Let_CanCreateAPointFromAStringArray()
    {
        var point = "1,2,3"
            .Split(",")
            .Select(int.Parse)
            .ToArray()
            .Let(arr => new Point(arr[0], arr[1], arr[2]));

        var expectedPoint = new Point(1, 2, 3);
        Assert.Equal(expectedPoint, point);
    }
}
