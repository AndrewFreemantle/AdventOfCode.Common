namespace AdventOfCode;

public static class StringArrayExtensions
{
    /// <summary>
    /// Rotates a grid 90&#176; to the right
    /// </summary>
    public static string[] RotateClockwise(this string[] grid)
    {
        // TODO: add bounds checking and throw if all lines aren't the same length
        var newGrid = string.Empty;

        for (int x = 0; x < grid[0].Length; x++)
        {
            for (int y = grid.Length - 1; y >= 0; y--)
                newGrid += grid[y][x];

            newGrid += '\n';
        }

        return newGrid.Split('\n', StringSplitOptions.RemoveEmptyEntries);
    }
}