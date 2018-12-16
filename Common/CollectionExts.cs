using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public static class CollectionExts
    {
        /// <summary>
        /// Checks if the current collection has an item that matches the specified predicate.
        /// </summary>
        /// <typeparam name="T">Type of collection</typeparam>
        /// <param name="enumerable">Collection</param>
        /// <param name="predicate">Predicate function for evaluation.</param>
        /// <returns>true or false.</returns>
        public static bool Contains<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
                => enumerable.IsNotNull() ? enumerable.Any(predicate) : false;

        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
                => enumerable.IsNotNull() ? enumerable.Any(predicate) ?
                   enumerable.SkipWhile(predicate) : enumerable : null;
    }
}
