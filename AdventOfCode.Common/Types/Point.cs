// ReSharper disable once CheckNamespace
namespace AdventOfCode;

/// <summary>
/// Represents a single Point or Location in 3-dimensional space
/// </summary>
/// <remarks>This simplified overload represents <see cref="Point{T}"/> where T is <see cref="int"/></remarks>
public class Point : Point<int>
{
    /// <summary>
    /// Represents a single Point or Location in 2-dimensional space
    /// </summary>
    /// <param name="x">X-axis (horizontal)</param>
    /// <param name="y">Y-axis (vertical)</param>
    /// <param name="tile">The character that is located at the Point or Location</param>
    public Point(int x, int y, char tile) : this(x, y, 0, tile) { }

    /// <inheritdoc cref="Point"/>
    /// <param name="x">X-axis (horizontal)</param>
    /// <param name="y">Y-axis (vertical)</param>
    /// <param name="z">Z-axis (depth) - optional</param>
    /// <param name="tile">The character that is located at the Point or Location - optional</param>
    public Point(int x, int y, int z = 0, char tile = ' ') : base(x, y, z, tile) { }
}

/// <summary>
/// Represents a single Point or Location in 3-dimensional space
/// </summary>
/// <param name="x">X-axis (horizontal)</param>
/// <param name="y">Y-axis (vertical)</param>
/// <param name="z">Z-axis (depth)</param>
/// <param name="tile">The character that is located at the Point or Location - optional</param>
public class Point<T>(T x, T y, T? z = default, char tile = ' ') : IEquatable<Point<T>>, ICloneable where T : INumber<T>
{
    /// <summary>
    /// Location on the X-axis (horizontal)
    /// </summary>
    public T X { get; set; } = x;

    /// <summary>
    /// Location on the Y-axis (vertical)
    /// </summary>
    public T Y { get; set; } = y;

    /// <summary>
    /// Location on the Z-axis (depth)
    /// </summary>
    public T? Z { get; set; } = z;

    /// <summary>
    /// The character that is located at the Point or Location
    /// </summary>
    public char Tile { get; set; } = tile;

    /// <summary>
    /// Determines whether the current Point is equal to another Point of the same coordinates.
    /// <remarks>It does NOT compare <see cref="Tile"/></remarks>
    /// </summary>
    public bool Equals(Point<T>? other)
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
        return Equals((Point<T>)obj);
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
        return new Point<T>(X, Y, Z, Tile);
    }

    /// <summary>
    /// Compares two Point objects, returning true if they have the same coordinates
    /// </summary>
    public static bool operator ==(Point<T>? left, Point<T>? right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    /// <summary>
    /// Compares two Point objects, returning true if their coordinates differ
    /// </summary>
    public static bool operator !=(Point<T>? left, Point<T>? right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Returns a string representation of this Point in the format: "(x,y,z:tile)"
    /// </summary>
    public override string ToString()
    {
        return $"({X},{Y},{Z}:{Tile})";
    }
}
