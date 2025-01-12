using AdventOfCode.Interfaces;

// ReSharper disable once CheckNamespace
namespace AdventOfCode;

public class PointFactory<T> : IPointFactory<Point<T>, T> where T : INumber<T>
{
    public Point<T> Create(T x, T y, T? z = default, char tile = ' ')
    {
        return new Point<T>(x, y, z, tile);
    }
}
