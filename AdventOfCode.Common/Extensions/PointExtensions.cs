namespace AdventOfCode;
using Types;

/// <summary>
/// Collection of extension methods for <see cref="Point"/>
/// </summary>
public static class PointExtensions
{
    /// <summary>
    /// Returns true if the Point is contained within a given polygon
    /// source: https://en.wikipedia.org/wiki/Even–odd_rule
    /// </summary>
   public static bool IsPointInside(this Point point, List<Point> polygon)
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

        var lastX = int.MinValue;
        var numIntersections = 0;
        var isLine = false;         // used to collapse continuous points to their corners/ends
        foreach (var p in pointsToTheRight)
        {
            if (isLine && lastX != p.X - 1)
                numIntersections++;

            isLine = lastX == p.X - 1;

            if (lastX == int.MinValue || !isLine)
                numIntersections++;

            lastX = p.X;
        }

        return numIntersections % 2 == 1;
    }
}
