using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public static class IEnumerableExtensions
{
    public static bool Multiple<T>(this IEnumerable<T> source, Func<T, bool> predicate = null)
    {
        if (predicate == null)
        {
            return source.Count() > 1;
        }
        else
        {
            return source.Count(predicate) > 1;
        }
    }
}
