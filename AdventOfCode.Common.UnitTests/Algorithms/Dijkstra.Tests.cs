using AdventOfCode.Interfaces;

// ReSharper disable once CheckNamespace
namespace AdventOfCode.UnitTests;

public class DijkstraTests
{
    private static readonly string[] Maze = [
        "###############",
        "#.......#....E#",
        "#.#.###.#.###.#",
        "#.....#.#...#.#",
        "#.###.#####.#.#",
        "#.#.#.......#.#",
        "#.#.#####.###.#",
        "#...........#.#",
        "###.#.#####.#.#",
        "#...#.....#.#.#",
        "#.#.#.###.#.#.#",
        "#.....#...#.#.#",
        "#.###.#.#.#.#.#",
        "#S..#.....#...#",
        "###############"];

    [Fact]
    public void DijkstraTestWithSimpleGraphSimpleCostAndCardinalNeighbours()
    {
        var maze = Maze.ToPoints(['#']);
        var start = new Point<int>(1, 13);   // S
        var end = new Point<int>(13, 1);     // E

        var result = Algorithms.Dijkstra(maze, start, end);

        Assert.Equal(28, result.EndCost);
    }

    [Fact]
    public void DijkstraTestWithCustomCostAndNeighbourFunctions()
    {
        // https://adventofcode.com/2024/day/16 - part 1 (example 1)

        var maze = Maze.ToPoints(['#'], new DirectionalPointFactory<int>());
        var start = new DirectionalPoint<int>(1, 13, Direction.Right);   // S
        var end = new DirectionalPoint<int>(13, 1);                      // E

        var result = Algorithms.Dijkstra(maze, start, end, DirectionalCostFunction<DirectionalPoint<int>, int>, GetCardinalNeighboursWithDirection, new DirectionalPointFactory<int>());

        Assert.Equal(7036, result.EndCost);
    }

    public class DirectionalPoint<T>(T x, T y, Direction direction = Direction.None) : Point<T>(x, y) where T : INumber<T>
    {
        public Direction Direction { get; } = direction;
    }

    public interface IDirectionalPointFactory<T> : IPointFactory<DirectionalPoint<T>, T> where T : INumber<T>
    {
        DirectionalPoint<T> CreateWithDirection(T x, T y, Direction direction);
    }

    public class DirectionalPointFactory<T> : IDirectionalPointFactory<T> where T : INumber<T>
    {
        public DirectionalPoint<T> Create(T x, T y, T z, char tile)
        {
            return new DirectionalPoint<T>(x, y);
        }

        public DirectionalPoint<T> CreateWithDirection(T x, T y, Direction direction)
        {
            return new DirectionalPoint<T>(x, y, direction);
        }
    }

    public static List<TPoint> GetCardinalNeighboursWithDirection<TPoint, T>(
        TPoint location,
        HashSet<TPoint> graph,
        IPointFactory<TPoint, T> pointFactory)
        where TPoint : DirectionalPoint<T>
        where T : INumber<T>
    {
        if (pointFactory is not IDirectionalPointFactory<T> factory)
            throw new ArgumentException("PointFactory must implement IDirectionalPointFactory<T>", nameof(pointFactory));

        var neighbours = new List<TPoint>();

        var left = pointFactory.Create(location.X - T.One, location.Y, T.Zero);
        var right = pointFactory.Create(location.X + T.One, location.Y);
        var up = pointFactory.Create(location.X, location.Y - T.One);
        var down = pointFactory.Create(location.X, location.Y + T.One);

        if (graph.Contains(left))
            neighbours.Add((TPoint)factory.CreateWithDirection(left.X, left.Y, Direction.Left));

        if (graph.Contains(right))
            neighbours.Add((TPoint)factory.CreateWithDirection(right.X, right.Y, Direction.Right));

        if (graph.Contains(up))
            neighbours.Add((TPoint)factory.CreateWithDirection(up.X, up.Y, Direction.Up));

        if (graph.Contains(down))
            neighbours.Add((TPoint)factory.CreateWithDirection(down.X, down.Y, Direction.Down));

        return neighbours;
    }

    public static int DirectionalCostFunction<TPoint, T>(
        TPoint current,
        TPoint next,
        int currentCost)
        where TPoint : DirectionalPoint<T>
        where T : INumber<T>
    {
        switch (current.Direction)
        {
            case Direction.Left:
                return currentCost + next.Direction switch
                {
                    Direction.Left => 1,
                    Direction.Right => 2001,
                    Direction.Up => 1001,
                    Direction.Down => 1001,
                    _ => 9999
                };
            case Direction.Right:
                return currentCost + next.Direction switch
                {
                    Direction.Left => 2001,
                    Direction.Right => 1,
                    Direction.Up => 1001,
                    Direction.Down => 1001,
                    _ => 9999
                };
            case Direction.Up:
                return currentCost + next.Direction switch
                {
                    Direction.Left => 1001,
                    Direction.Right => 1001,
                    Direction.Up => 1,
                    Direction.Down => 2001,
                    _ => 9999
                };
            case Direction.Down:
                return currentCost + next.Direction switch
                {
                    Direction.Left => 1001,
                    Direction.Right => 1001,
                    Direction.Up => 2001,
                    Direction.Down => 1,
                    _ => 9999
                };
            default:
                return 9999;
        }
    }

}
