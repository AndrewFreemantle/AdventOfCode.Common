// ReSharper disable once CheckNamespace
namespace AdventOfCode;

/// <summary>
/// Collection of extension methods for <see cref="System.Collections.Generic.List{Point{T}}"/>
/// </summary>
public static class ListOfPointExtensions
{
    /// <summary>
    /// Returns the points contained within, assuming the given points make a contiguous border
    ///
    /// Source: https://en.wikipedia.org/wiki/Flood_fill
    /// </summary>
    /// <param name="points"></param>
    /// <param name="start"></param>
    /// <returns></returns>
    public static List<Point<T>> FloodFill<T>(this List<Point<T>> points, Point<T> start) where T : INumber<T>, IMinMaxValue<T>
    {
        // 1. Set Q to the empty queue or stack.
        // 2. Add node to the end of Q.
        // 3. While Q is not empty:
        // 4.   Set n equal to the first element of Q.
        // 5.   Remove first element from Q.
        // 6.   If n is Inside:
        // Set the n
        //     Add the node to the west of n to the end of Q.
        //     Add the node to the east of n to the end of Q.
        //     Add the node to the north of n to the end of Q.
        //     Add the node to the south of n to the end of Q.
        // 7. Continue looping until Q is exhausted.
        // 8. Return.

        var pointsInside = new List<Point<T>>();
        var queue = new Queue<Point<T>>();
        queue.Enqueue(start);

        do
        {
            Console.WriteLine($"queue length: {queue.Count}");

            var node = queue.Dequeue();

            // 6. if n is Inside...
            if (node.IsPointInside(points))
            {
                pointsInside.Add(node);

                // check the points around node
                queue.Enqueue(new Point<T>(node.X + T.One, node.Y));
                queue.Enqueue(new Point<T>(node.X - T.One, node.Y));
                queue.Enqueue(new Point<T>(node.X, node.Y + T.One));
                queue.Enqueue(new Point<T>(node.X, node.Y - T.One));
            }
        } while (queue.Count > 0);

        return pointsInside;
    }
}
