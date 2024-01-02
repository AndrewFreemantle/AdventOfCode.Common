namespace AdventOfCode.Types;

/// <summary>
/// Represents a single Point or Location in 2 dimensional space
/// </summary>
/// <param name="x">X-axis (horizontal)</param>
/// <param name="y">Y-axis (vertical)</param>
/// <param name="z">Z-axis (depth)</param>
public class Point(int x, int y, int z = 0) : IEquatable<Point>, ICloneable
{
    /// <summary>
    /// Location on the X-axis (horizontal)
    /// </summary>
    public int X { get; set; } = x;

    /// <summary>
    /// Location on the Y-axis (vertical)
    /// </summary>
    public int Y { get; set; } = y;

    /// <summary>
    /// Location on the Z-axis (depth)
    /// </summary>
    public int Z { get; set; } = z;

    /// <summary>
    /// Determines whether the current Point is equal to another Point of the same coordinates.
    /// </summary>
    public bool Equals(Point? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y && Z == other.Z;
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current Point
    /// </summary>
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Point)obj);
    }

    /// <summary>
    /// Returns the hashcode for this Point
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y, Z);
    }

    /// <summary>
    /// Creates a new object that is a copy of the current instance
    /// </summary>
    /// <returns>A new Point instance with the same coordinates (x, y, z)</returns>
    public object Clone()
    {
        return new Point(X, Y, Z);
    }

    /// <summary>
    /// Compares two Point objects, returning true if they have the same coordinates
    /// </summary>
    public static bool operator ==(Point? left, Point? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// Compares two Point objects, returning true if their coordinates differ
    /// </summary>
    public static bool operator !=(Point? left, Point? right)
    {
        return !Equals(left, right);
    }
}
