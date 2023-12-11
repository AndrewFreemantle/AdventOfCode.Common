namespace AdventOfCode;

public partial class Utils
{
  /// <summary>
  /// The smallest positive integer that is divisible by both a and b. Useful for finding the alignment of the simultaneous moving objects (gears, planets, loops/routes)
  /// </summary>
  public static long LeastCommonMultiple(IEnumerable<long> numbers)
  {
    // source: https://stackoverflow.com/a/29717490/5662
    return numbers.Aggregate(LeastCommonMultiple);
  }

  private static long LeastCommonMultiple(long a, long b)
  {
    return Math.Abs(a * b) / GreatestCommonDivisor(a, b);
  }
}
