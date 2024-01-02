## Andrew's Advent of Code common support library for C#

[![Publish Actions Status](https://github.com/AndrewFreemantle/AdventOfCode.Common/actions/workflows/publish.yml/badge.svg)](https://github.com/AndrewFreemantle/AdventOfCode.Common/actions/workflows/publish.yml)

A collection of POCO (Plain Old CLR Object) types and algorithm implementations that support solving [Advent of Code](https://adventofcode.com) puzzles.

### Philosophy

To provide a toolbox of common or generic implementations without detracting from the solving of the puzzle.

### Types

#### `Point`
A simple `x`, `y` (and optional `z`) encapsulation object that implements equality and clone
``` csharp
using AdventOfCode.Types;
...

var point = new Point(x, y[, z]);

var newPoint = point.Clone();
var areEqual = point == newPoint; // true
```

### Algorithms

#### Least Common Multiple <sup><a href="https://en.wikipedia.org/wiki/Least_common_multiple">Wikipedia</a></sup>
> The smallest positive integer that is divisible by both a and b. Useful for finding the alignment of simultaneous moving objects (gears, planets, loops/routes).

``` csharp
using AdventOfCode;
...

var lcm = Utils.LeastCommonMultiple(new long[] {1, 2, 3, 4, n...});
```

#### Greatest Common Divisor <sup><a href="https://en.wikipedia.org/wiki/Greatest_common_divisor">Wikipedia</a></sup>  - Euclid's Algorithm <sup><a href="https://en.wikipedia.org/wiki/Euclidean_algorithm">Wikipedia</a></sup>
> An efficient method for computing the greatest common divisor (GCD) of two integers (numbers), the largest number that divides them both without a remainder.

``` csharp
using AdventOfCode;
...

var gcd = Utils.GreatestCommonDivisor(a, b);
```

### Enumerations

#### Direction
``` csharp
using AdventOfCode;
...
var directionOfTravel = Direction.Up; /* Down, Left, Right or None */
```


### Extension Methods

`string[]` extensions

``` csharp
using AdeventOfCode;
...
string[] rotatedGrid = grid.RotateClockwise();  // 90° to the right
```
