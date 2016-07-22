





using System;

public static partial class Extensions
{
    /// <summary>
    ///     Determines whether the specified  instances are the same instance.
    /// </summary>
    /// <param name="objA">The first object to compare.</param>
    /// <param name="objB">The second object  to compare.</param>
    /// <returns>true if  is the same instance as  or if both are null; otherwise, false.</returns>
    public static Boolean ReferenceEquals(this Object objA, Object objB)
    {
        return Object.ReferenceEquals(objA, objB);
    }
}