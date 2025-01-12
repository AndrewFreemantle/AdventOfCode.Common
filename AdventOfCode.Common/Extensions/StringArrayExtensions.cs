using AdventOfCode.Interfaces;

// ReSharper disable once CheckNamespace
namespace AdventOfCode;

/// <summary>
/// Collection of extension methods for <see cref="string"/>[]
/// </summary>
public static class StringArrayExtensions
{
    /// <summary>
    /// Rotates a grid 90&#176; to the right
    /// </summary>
    public static string[] RotateClockwise(this string[] grid)
    {
        // TODO: add bounds checking and throw if all lines aren't the same length
        var newGrid = string.Empty;

        for (int x = 0; x < grid[0].Length; x++)
        {
            for (int y = grid.Length - 1; y >= 0; y--)
                newGrid += grid[y][x];

            newGrid += '\n';
        }

        return newGrid.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }

    /// <summary>
    /// Converts a string array representation of a 2-dimensional graph or maze into a collection of <see cref="Point{T}"/> where T is int
    /// </summary>
    /// /// <remarks>This simplified overload returns <see cref="Point{T}"/> where T is <see cref="int"/></remarks>
    /// <param name="graph">The graph or maze</param>
    /// <param name="excludeChars">Maze characters to exclude (e.g. walls: #)</param>
    /// <returns>HashSet of Points</returns>
    public static HashSet<Point<int>> ToPoints(this string[] graph, char[]? excludeChars = null)
    {
        return graph.ToPoints<Point<int>, int>(excludeChars);
    }

    /// <summary>
    /// Converts a string array representation of a 2-dimensional graph or maze into a collection of <see cref="Point{T}"/> where T is a numeric type (int, long, etc)
    /// </summary>
    /// <param name="graph">The graph or maze</param>
    /// <param name="excludeChars">Maze characters to exclude (e.g. walls: #)</param>
    /// <param name="pointFactory"><see cref="IPointFactory{TPoint,T}"/> implementation to create the Point objects</param>
    /// <returns>HashSet of Points</returns>
    public static HashSet<TPoint> ToPoints<TPoint, T>(
        this string[] graph,
        char[]? excludeChars = null,
        IPointFactory<TPoint, T>? pointFactory = null)
        where TPoint : Point<T>
        where T : INumber<T>
    {
        var factory = pointFactory ?? new PointFactory<T>() as IPointFactory<TPoint, T>;

        if (factory is null)
            throw new InvalidOperationException("Failed to create a PointFactory");

        var mazePoints = new HashSet<TPoint>();

        for (int y = 0; y < graph.Length; y++)
        {
            for (int x = 0; x < graph[y].Length; x++)
            {
                if (excludeChars is null || !excludeChars.Contains(graph[y][x]))
                    mazePoints.Add(factory.Create(T.CreateChecked(x), T.CreateChecked(y), T.Zero, graph[y][x]));
            }
        }

        return mazePoints;
    }

}
