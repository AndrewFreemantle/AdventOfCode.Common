// ReSharper disable once CheckNamespace
namespace AdventOfCode;

/// <summary>
/// Collection of extension methods for <see cref="Point{T}"/>
/// </summary>
public static class PointExtensions
{
    /// <summary>
    /// Returns true if the <see cref="Point{T}"/> is contained within a given polygon
    /// source: https://en.wikipedia.org/wiki/Even–odd_rule
    /// </summary>
   public static bool IsPointInside<T>(this Point<T> point, List<Point<T>> polygon) where T : INumber<T>, IMinMaxValue<T>
   {
        if (polygon.Contains(point))
            return true; // point is on the boundary

        // any points to the left?  (if not, we can't be inside)
        if (!polygon.Any(p => p.Y == point.Y && p.X < point.X))
            return false;

        var pointsToTheRight = polygon
            .Where(p => p.Y == point.Y && p.X > point.X)
            .OrderBy(p => p.X);

        if (!pointsToTheRight.Any())
            return false; // no points to the right either (so we're above or below the polygon)

        var lastX = T.MinValue;
        var numIntersections = 0;
        var isLine = false;         // used to collapse continuous points to their corners/ends
        foreach (var p in pointsToTheRight)
        {
            if (isLine && lastX != p.X - T.One)
                numIntersections++;

            isLine = lastX == p.X - T.One;

            if (lastX == T.MinValue || !isLine)
                numIntersections++;

            lastX = p.X;
        }

        return numIntersections % 2 == 1;
    }
}
