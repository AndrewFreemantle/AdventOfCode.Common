// ReSharper disable once CheckNamespace
namespace AdventOfCode;

/// <summary>
/// Common utility functions
/// </summary>
public partial class Utils
{
  /// <summary>
  /// An efficient method for computing the greatest common divisor (GCD) of two integers (numbers), the largest number that divides them both without a remainder
  /// </summary>
  public static long GreatestCommonDivisor(long a, long b)
  {
    return b == 0 ? a : GreatestCommonDivisor(b, a % b);
  }
}
