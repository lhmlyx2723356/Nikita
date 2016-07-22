





using System;
using System.Linq;
using System.Reflection;

public static partial class Extensions
{
    /// <summary>An object extension method that gets custom attributes by full name.</summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="fullName">Name of the full.</param>
    /// <returns>An array of attribute.</returns>
    public static Attribute[] GetCustomAttributesByFullName(this object @this, string fullName)
    {
        var type = @this.GetType();

        return type.IsEnum ?
            type.GetField(@this.ToString()).GetCustomAttributes().Where(x => x.GetType().FullName == fullName).ToArray() :
            type.GetCustomAttributes().Where(x => x.GetType().FullName == fullName).ToArray();
    }

    /// <summary>An object extension method that gets custom attributes by full name.</summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="fullName">Name of the full.</param>
    /// <param name="inherit">true to inherit.</param>
    /// <returns>An array of attribute.</returns>
    public static object[] GetCustomAttributesByFullName(this object @this, string fullName, bool inherit)
    {
        var type = @this.GetType();

        return type.IsEnum ?
            type.GetField(@this.ToString()).GetCustomAttributes(inherit).Where(x => x.GetType().FullName == fullName).ToArray() :
            type.GetCustomAttributes(inherit).Where(x => x.GetType().FullName == fullName).ToArray();
    }

    /// <summary>An object extension method that gets custom attributes by full name.</summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="fullName">Name of the full.</param>
    /// <returns>An array of attribute.</returns>
    public static Attribute[] GetCustomAttributesByFullName(this MemberInfo @this, string fullName)
    {
        return @this.GetCustomAttributes().Where(x => x.GetType().FullName == fullName).ToArray();
    }

    /// <summary>An object extension method that gets custom attributes by full name.</summary>
    /// <param name="this">The @this to act on.</param>
    /// <param name="fullName">Name of the full.</param>
    /// <param name="inherit">true to inherit.</param>
    /// <returns>An array of attribute.</returns>
    public static object[] GetCustomAttributesByFullName(this MemberInfo @this, string fullName, bool inherit)
    {
        return @this.GetCustomAttributes(inherit).Where(x => x.GetType().FullName == fullName).ToArray();
    }
}