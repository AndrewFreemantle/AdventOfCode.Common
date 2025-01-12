## Andrew's Advent of Code common support library for C#

[![Unit Tests Status](https://github.com/AndrewFreemantle/AdventOfCode.Common/actions/workflows/unit-tests.yml/badge.svg)](https://github.com/AndrewFreemantle/AdventOfCode.Common/actions/workflows/unit-tests.yml) [![Publish Actions Status](https://github.com/AndrewFreemantle/AdventOfCode.Common/actions/workflows/publish.yml/badge.svg)](https://github.com/AndrewFreemantle/AdventOfCode.Common/actions/workflows/publish.yml)

A collection of POCO (Plain Old CLR Object) types and algorithm implementations that support solving [Advent of Code](https://adventofcode.com) puzzles.

### Philosophy

To provide a toolbox of common or generic implementations without detracting from the solving of the puzzle.

### Types

#### `Point`
A simple `x`, `y` (and optional `z`) encapsulation object that implements equality and clone
``` csharp
using AdventOfCode;
...

var point = new Point(x, y[, z]);

var newPoint = point.Clone();
var areEqual = point == newPoint; // true
```

#### `Point<T>`
The underlying implementation of `Point` that allows for the `x`, `y` (and optional `z` and char `tile`) values to be any numeric data type, such as `long` or `double`
``` csharp
using AdventOfCode;
...

var point = new Point<long>(x, y[, z, '.']);

var newPoint = point.Clone();
var areEqual = point == newPoint; // true
```
This allows for custom implementations of `Point<T>` where additional metadata about each point is required, for example so:
``` csharp
public class DirectionalPoint<T>(T x, T y, Direction direction = Direction.None) : Point<T>(x, y) where T : INumber<T>
{
    public Direction Direction { get; } = direction;
}
```
***Note:** equality doesn't compare `char tile` - it is based on the location (`x`, `y`[, `z`]) **only***
``` csharp
var point1 = new Point(1, 2, '.');
var point2 = new Point(1, 2, '#');

var areEqual = point1 == point2; // true;
```

### Algorithms

#### Least Common Multiple <sup><a href="https://en.wikipedia.org/wiki/Least_common_multiple">Wikipedia</a></sup>
> The smallest positive integer that is divisible by both a and b. Useful for finding the alignment of simultaneous moving objects (gears, planets, loops/routes).

``` csharp
using AdventOfCode;
...

var lcm = Utils.LeastCommonMultiple(new long[] {1, 2, 3, 4, n...});
```

#### Greatest Common Divisor <sup><a href="https://en.wikipedia.org/wiki/Greatest_common_divisor">Wikipedia</a></sup> - Euclid's Algorithm <sup><a href="https://en.wikipedia.org/wiki/Euclidean_algorithm">Wikipedia</a></sup>
> An efficient method for computing the greatest common divisor (GCD) of two integers (numbers), the largest number that divides them both without a remainder.

``` csharp
using AdventOfCode;
...

var gcd = Utils.GreatestCommonDivisor(a, b);
```

#### Dijkstra's Algorithm <sup><a href="https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm">Wikipedia</a></sup>
Dijkstra's algorithm is an algorithm for finding the shortest paths between nodes in a weighted graph, which may represent, for example, a road network.

``` csharp
using AdventOfCode;

var maze = Maze.ToPoints(['#']);     // Maze is a string[] maze representation
var start = new Point<int>(1, 13);   // Start
var end = new Point<int>(13, 1);     // End

var result = Algorithms.Dijkstra(graph, start, end);
```
The result is an object that contains the following:

``` csharp
public record DijkstraResult<TPoint, T>(
    int EndCost,                     // Cost to reach the goal or end Point
    Dictionary<TPoint, int> Dist,    // The distance costs calculated
    Dictionary<TPoint, TPoint> Prev  // The path or route through the graph (to retrace, start from end: prev[end])
) where TPoint : Point<T> where T : INumber<T>;
```
Included is an overload that allows for `costFn` and `getNeighboursFn` implementations to be passed in, simple implementations are provided:
- `SimpleCostFunction()` adds 1 for each step taken from start to end
- `GetCardinalNeighboursFunction()` returns the cardinal neighbours for the given point

`Dijkstra()` is also generic, and accepts inherited types of `Point<T>` to allow for metadata about each point, such as direction or their map/char value which can then be used by custom `costFn` and `getNeighboursFn`. Note that when using this overload, an implementation of `IPointFactory<TPoint, T>` must also be provided, which is passed to the `getNeighboursFn` to create the neighbouring points. 

### Enumerations

#### Direction
``` csharp
using AdventOfCode;
...
var directionOfTravel = Direction.Up; /* Down, Left, Right or None */
```

### Extension Methods

#### `string[]` extensions

##### `ToPoints()`
``` csharp
using AdeventOfCode;
...
var points = maze.ToPoints()    // returns a HashSet<Point<int>>
```
Includes overloads for `Point<T>` where `T` is a numeric datatype (i.e. `long`, `decimal`, etc)

##### `RotateClockwise()`

``` csharp
using AdeventOfCode;
...
string[] rotatedGrid = grid.RotateClockwise();  // 90° to the right
```
