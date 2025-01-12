using AdventOfCode.Interfaces;

// ReSharper disable once CheckNamespace
namespace AdventOfCode;

public static partial class Algorithms
{
    /// <summary>
    /// Dijkstra's algorithm is an algorithm for finding the shortest paths between nodes in a weighted graph, which may represent, for example, a road network.
    /// </summary>
    /// <remarks>This simplified overload uses the <see cref="SimpleCostFunction{TPoint,T}"/> (1 move = 1 cost), and <see cref="GetCardinalNeighbours{TPoint,T}"/></remarks>
    /// <seealso cref="https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm"/>
    /// <param name="graph">The points that make up the valid positions in the graph</param>
    /// <param name="start">The starting point</param>
    /// <param name="end">The goal</param>
    /// <returns><see cref="DijkstraResult{TPoint, T}"/></returns>
    public static DijkstraResult<Point<int>, int> Dijkstra(HashSet<Point<int>> graph, Point<int> start, Point<int> end)
    {
        return Dijkstra(graph, start, end, SimpleCostFunction<Point<int>, int>, GetCardinalNeighbours, new PointFactory<int>());
    }

    /// <summary>
    /// Dijkstra's algorithm is an algorithm for finding the shortest paths between nodes in a weighted graph, which may represent, for example, a road network.
    /// </summary>
    /// <seealso cref="https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm"/>
    /// <param name="graph">The points that make up the valid positions in the graph</param>
    /// <param name="start">The starting point</param>
    /// <param name="end">The goal</param>
    /// <param name="costFn">The cost to move from one Point to a neighbouring Point</param>
    /// <param name="getNeighboursFn">Function to return all valid neighbouring Points</param>
    /// <returns><see cref="DijkstraResult{TPoint, T}"/></returns>
    public static DijkstraResult<TPoint, T> Dijkstra<TPoint, T>(
        HashSet<TPoint> graph,
        TPoint start,
        TPoint end,
        Func<TPoint, TPoint, int, int> costFn,
        Func<TPoint, HashSet<TPoint>, IPointFactory<TPoint, T>, List<TPoint>> getNeighboursFn,
        IPointFactory<TPoint, T> pointFactory)
        where TPoint : Point<T>
        where T : INumber<T>
    {
        // Dijkstra's algorithm (with a priority queue)
        var dist = new Dictionary<TPoint, int>();    // used to record the distances / costs as the maze is walked
        dist[start] = 0;

        var prev = new Dictionary<TPoint, TPoint>();      // used to retrace the route back through the maze

        var q = new PriorityQueue<TPoint, int>();
        q.Enqueue(start, 0);

        do  // while Q is not empty
        {
            // find the point in q which has the lowest score in dist
            var u = q.Dequeue();

            // if we've reached the End then we can stop
            if (u == end)
                return new DijkstraResult<TPoint, T>(dist[end], dist, prev);

            var neighbours = getNeighboursFn(u, graph, pointFactory);
            foreach (var v in neighbours)
            {
                var alt = costFn(u, v, dist[u]);

                // have we found a cheaper way to get to v?
                if (!dist.ContainsKey(v) || (dist.ContainsKey(v) && alt < dist[v]))
                {
                    dist[v] = alt;
                    prev[v] = u;
                    q.Enqueue(v, alt);
                }
            }

        } while (q.Count > 0);

        return new DijkstraResult<TPoint, T>(dist[end], dist, prev);
    }

    /// <summary>
    /// The result of the Dijkstra function
    /// </summary>
    /// <param name="EndCost">Cost to reach the goal or end Point</param>
    /// <param name="Dist">The distance costs calculated</param>
    /// <param name="Prev">The path or route through the graph (to retrace, start from end: prev[end])</param>
    public record DijkstraResult<TPoint, T>(int EndCost, Dictionary<TPoint, int> Dist, Dictionary<TPoint, TPoint> Prev) where TPoint : Point<T> where T : INumber<T>;

    /// <summary>
    /// Simple Dijkstra move cost function, adds 1 to move 1 space
    /// </summary>
    /// <param name="current">Current Point</param>
    /// <param name="next">Next or neighbouring Point</param>
    /// <param name="currentCost">The current cumulative cost to Current</param>
    /// <returns>Current cost plus 1</returns>
    public static int SimpleCostFunction<TPoint, T>(
        TPoint current,
        TPoint next,
        int currentCost)
        where TPoint : Point<T>
        where T : INumber<T>
    {
        return currentCost + 1;
    }

    /// <summary>
    /// Returns the cardinal (North/South/East/West) neighbours for the given Point, from the given graph
    /// </summary>
    /// <param name="location">Current location</param>
    /// <param name="graph">Entire graph of possible locations</param>
    /// <returns>Collection of immediate cardinal neighbours</returns>
    public static List<TPoint> GetCardinalNeighbours<TPoint, T>(
        TPoint location,
        HashSet<TPoint> graph,
        IPointFactory<TPoint, T> pointFactory)
        where TPoint : Point<T>
        where T : INumber<T>
    {
        var neighbours = new List<TPoint>();

        var left = pointFactory.Create(location.X - T.One, location.Y);
        var right = pointFactory.Create(location.X + T.One, location.Y);
        var up = pointFactory.Create(location.X, location.Y - T.One);
        var down = pointFactory.Create(location.X, location.Y + T.One);

        if (graph.Contains(left))
            neighbours.Add(graph.First(p => p == left));

        if (graph.Contains(right))
            neighbours.Add(graph.First(p => p == right));

        if (graph.Contains(up))
            neighbours.Add(graph.First(p => p == up));

        if (graph.Contains(down))
            neighbours.Add(graph.First(p => p == down));

        return neighbours;
    }
}
