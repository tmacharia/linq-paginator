using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Paginator
{
    public static class Extensions
    {
        /// <summary>
        /// Checks if a <see cref="string"/> is valid by whether it's empty, null 
        /// or whitespace.
        /// </summary>
        /// <param name="s">Text to evaluate.</param>
        /// <returns>
        /// <see cref="true"/> or <see cref="false"/>
        /// </returns>
        public static bool IsValid(this string s)
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                if (s.Length > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool Matches(this string s, string q)
        {
            if (s.IsValid() && q.IsValid())
                return Regex.IsMatch(s, $"({q})", RegexOptions.IgnoreCase);
            return false;
        }
        public static string CastToString(this object obj)
        {
            if(obj != null)
            {
                return obj.ToString();
            }
            return string.Empty;
        }
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
            where T : class {
            foreach (T item in enumerable)
                action(item);
        }
    }
}
