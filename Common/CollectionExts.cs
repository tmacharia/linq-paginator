using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <summary>
        /// Steps through the collection subjecting each item to the <see cref="Action delegate"/>
        /// specified.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action">Function/method to execute on each item in the collection.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            int total = enumerable.Count();
            for (int i = 0; i < total; i++)
            {
                action(enumerable.ElementAt(i));
            }
        }
        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
                => enumerable.IsNotNull() ? enumerable.Any(predicate) ?
                   enumerable.SkipWhile(predicate) : enumerable : null;
    }
}