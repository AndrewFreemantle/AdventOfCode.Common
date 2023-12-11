## Andrew's Advent of Code common support library for C#

A collection of <abbr>POCO</abbr> (Plain Old <abbr title="Common Language Runtime">CLR</abbr> Object) types and algorithm implementations that support solving [Advent of Code](https://adventofcode.com) puzzles.

### Philosophy

To provide a toolbox of common or generic implementations without detracting from the solving of the puzzle.

### Types

#### `Point`
``` csharp
var point = new Point(x, y);
```

### Utils / Algorithms

#### Least Common Multiple <sup><a href="https://en.wikipedia.org/wiki/Least_common_multiple">Wikipedia</a></sup>
> The smallest positive integer that is divisible by both a and b. Useful for finding the alignment of the simultaneous moving objects (gears, planets, loops/routes).

``` csharp
var lcm = LeastCommonMultiple(new long[] {1, 2, 3, 4, n...});
```

#### Greatest Common Divisor <sup><a href="https://en.wikipedia.org/wiki/Greatest_common_divisor">Wikipedia</a></sup>  - Euclid's Algorithm <sup><a href="https://en.wikipedia.org/wiki/Euclidean_algorithm">Wikipedia</a></sup>
> An efficient method for computing the greatest common divisor (GCD) of two integers (numbers), the largest number that divides them both without a remainder.

``` csharp
var gcd = GreatestCommonDivisor(a, b);
```
