// ReSharper disable once CheckNamespace
namespace AdventOfCode;

/// <summary>
/// Collection of extension methods for LINQ/>
/// </summary>
public static class LinqExtensions
{
    /// <summary>
    /// Projects the source into a function, useful for transforming arrays into classes or records
    /// </summary>
    /// <param name="source">The source object, typically an array</param>
    /// <param name="func">The transformational function</param>
    public static TResult Let<T, TResult>(this T source, Func<T, TResult> func) => func(source);
}
