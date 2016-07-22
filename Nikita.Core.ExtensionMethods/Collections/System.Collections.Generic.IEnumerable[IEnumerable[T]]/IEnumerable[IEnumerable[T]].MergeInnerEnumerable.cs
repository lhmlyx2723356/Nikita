





using System.Collections.Generic;
using System.Linq;

public static partial class Extensions
{
    /// <summary>Enumerates merge inner enumerable in this collection.</summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="this">The @this to act on.</param>
    /// <returns>
    ///     An enumerator that allows foreach to be used to process merge inner enumerable in
    ///     this collection.
    /// </returns>
    public static IEnumerable<T> MergeInnerEnumerable<T>(this IEnumerable<IEnumerable<T>> @this)
    {
        List<IEnumerable<T>> listItem = @this.ToList();

        var list = new List<T>();

        foreach (var item in listItem)
        {
            list.AddRange(item);
        }

        return list;
    }
}