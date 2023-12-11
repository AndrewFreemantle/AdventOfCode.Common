namespace AdventOfCode.Types;

/// <summary>
/// Represents a single Point or Location in 2 dimensional space
/// </summary>
/// <param name="x">X-axis (horizontal)</param>
/// <param name="y">Y-axis (vertical)</param>
public class Point(long x, long y) : IEquatable<Point>
{
    public long X { get; set; } = x;
    public long Y { get; set; } = y;

    public bool Equals(Point? other)
    {
        if (other == null) return false;

        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Point);
    }
}
