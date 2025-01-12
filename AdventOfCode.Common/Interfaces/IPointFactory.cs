namespace AdventOfCode.Interfaces;

public interface IPointFactory<TPoint, T> where TPoint : Point<T> where T : INumber<T>
{
    TPoint Create(T x, T y, T? z = default, char tile = ' ');
}
