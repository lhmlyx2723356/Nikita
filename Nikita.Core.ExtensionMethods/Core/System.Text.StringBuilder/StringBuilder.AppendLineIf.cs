





using System;
using System.Text;

public static partial class Extensions
{
    /// <summary>A StringBuilder extension method that appends a line when.</summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="predicate">The predicate.</param>
    /// <param name="values">A variable-length parameters list containing values.</param>
    /// <returns>A StringBuilder.</returns>
    public static StringBuilder AppendLineIf<T>(this StringBuilder @this, Func<T, bool> predicate, params T[] values)
    {
        foreach (var value in values)
        {
            if (predicate(value))
            {
                @this.AppendLine(value.ToString());
            }
        }

        return @this;
    }
}