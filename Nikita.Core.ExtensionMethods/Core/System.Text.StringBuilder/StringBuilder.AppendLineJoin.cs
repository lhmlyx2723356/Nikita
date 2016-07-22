






using System.Collections.Generic;
using System.Text;

public static partial class Extensions
{
    /// <summary>A StringBuilder extension method that appends a line join.</summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <param name="separator">The separator.</param>
    /// <param name="values">The values.</param>
    public static StringBuilder AppendLineJoin<T>(this StringBuilder @this, string separator, IEnumerable<T> values)
    {
        @this.AppendLine(string.Join(separator, values));

        return @this;
    }

    /// <summary>A StringBuilder extension method that appends a line join.</summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="separator">The separator.</param>
    /// <param name="values">The values.</param>
    public static StringBuilder AppendLineJoin(this StringBuilder @this, string separator, params object[] values)
    {
        @this.AppendLine(string.Join(separator, values));

        return @this;
    }
}