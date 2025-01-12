// ReSharper disable once CheckNamespace

using AdventOfCode.Interfaces;

namespace AdventOfCode.UnitTests;

public class StringArrayExtensionsTests
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
    public void ToPointsWithoutExclusions()
    {
        var points = Maze.ToPoints();
        Assert.Equal(225, points.Count);
    }

    [Fact]
    public void ToPointsOfLongWithoutExclusions()
    {
        var points = Maze.ToPoints<Point<long>, long>();
        Assert.Equal(225, points.Count);
        Assert.IsType<long>(points.First().X);
    }

    [Fact]
    public void ToPointsWithExclusions()
    {
        var points = Maze.ToPoints(['#']);
        Assert.Equal(104, points.Count);
    }



    [Fact]
    public void ToPointsWithCustomPointType()
    {
        var mazePoints = Maze.ToPoints<MazePoint<int>, int>(null, new MazePointFactory<int>());
        Assert.Equal(1, mazePoints.Count(mp => mp.IsStart));
        Assert.Equal(1, mazePoints.Count(mp => mp.IsEnd));

        Assert.Equal(104, mazePoints.Count(mp => !mp.IsWall));
        Assert.Equal(102, mazePoints.Count(mp => mp.Tile == '.'));
    }

    public class MazePoint<T>(T x, T y, T? z, char tile) : Point<T>(x, y, z, tile) where T : INumber<T>
    {
        public bool IsWall => Tile == '#';
        public bool IsStart => Tile == 'S';
        public bool IsEnd => Tile == 'E';
    }

    public interface IMazePointFactory<T> : IPointFactory<MazePoint<T>, T> where T : INumber<T>
    {
        new MazePoint<T> Create(T x, T y, T? z, char tile);
    }


    // duplicate of the PointFactory
    public class MazePointFactory<T> : IMazePointFactory<T> where T : INumber<T>
    {
        public MazePoint<T> Create(T x, T y, T? z = default, char tile = ' ')
        {
            return new MazePoint<T>(x, y, z, tile);
        }
    }
}
