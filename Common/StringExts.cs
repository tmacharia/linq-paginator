using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class StringExts
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
        /// <summary>
        /// Checks if a <see cref="string"/> contains the specified query text
        /// as a substring.
        /// </summary>
        /// <param name="s">String text to check</param>
        /// <param name="q">Substring to check.</param>
        /// <returns>
        ///     <see cref="true"/> if it contains or
        ///     <see cref="false"/> if it doesn't.
        /// </returns>
        public static bool Has(this string s, string q)
        {
            if (s.IsValid() && q.IsValid())
            {
                return s.Contains(q);
            }
            return false;
        }
        /// <summary>
        /// Converts a text <see cref="string"/> to a <see cref="double"/>
        /// </summary>
        /// <param name="doubleAsString">Text to convert</param>
        /// <returns>
        /// A <see cref="double"/> number
        /// </returns>
        public static double ToDouble(this string doubleAsString)
        {
            if (doubleAsString.IsValid())
            {
                return Convert.ToDouble(doubleAsString, Constants.Culture);
            }
            throw new ArgumentNullException(nameof(doubleAsString));
        }
        /// <summary>
        /// Converts a text <see cref="string"/> to a <see cref="decimal"/>
        /// </summary>
        /// <param name="doubleAsString">Text to convert</param>
        /// <returns>
        /// A <see cref="decimal"/> number
        /// </returns>
        public static decimal ToDecimal(this string doubleAsString)
        {
            if (doubleAsString.IsValid())
            {
                return Convert.ToDecimal(doubleAsString, Constants.Culture);
            }
            throw new ArgumentNullException(nameof(doubleAsString));
        }
        /// <summary>
        /// Compares and evaluates if a specific query <see cref="string"/> matches
        /// another one using Regular Expressions.
        /// </summary>
        /// <param name="s">The <see cref="string"/> to check</param>
        /// <param name="q">The query <see cref="string"/></param>
        /// <returns>true or false.</returns>
        public static bool Matches(this string s, string q) => Regex.IsMatch(s, $"({q})", RegexOptions.IgnoreCase);
        public static bool HasDigit(this string s) => s.IsValid() ? s.ToCharArray().Any(c => Char.IsDigit(c)) : false;
        public static bool Is(this string s, string query, bool ignoreCase = true)
        {
            if (s.IsValid())
            {
                return s.Equals(query, ignoreCase ? Constants.StringComparisonIgnoreCase : Constants.StringComparison);
            }
            return false;
        }
        /// <summary>
        /// Shortens a <see cref="string"/> of text to a certain number of characters and
        /// appends trailing dots(...) at the end to show continuation.
        /// </summary>
        /// <param name="s">Text to shorten</param>
        /// <param name="count">Number of characters to take from the first index/start/zero</param>
        /// <returns>
        /// Shortened version of <see cref="string"/> <paramref name="s"/>
        /// </returns>
        public static string Shorten(this string s, int count)
        {
            if (s.IsValid())
            {
                if (count > 0 && s.Length > count)
                {
                    return s.Substring(0, count) + "...";
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Converts a <see cref="string"/> of text to a <see cref="byte[]"/>
        /// </summary>
        /// <param name="s">Text to convert</param>
        /// <returns>
        /// <see cref="byte[]"/>
        /// </returns>
        public static byte[] ToByteArray(this string s) => Constants.Encoding.GetBytes(s);
        /// <summary>
        /// Converts a <see cref="string"/> to a <see cref="byte[]"/> and returns
        /// the result as a Base64 encoded <see cref="string"/> of text.
        /// </summary>
        /// <param name="s">Text to convert</param>
        /// <returns>Base64 encoded <see cref="string"/></returns>
        public static string ToBase64String(this string s) => s.ToByteArray().ToBase64String();
        /// <summary>
        /// Converts a Base64 encoded string to an equivalent <see cref="byte[]"/>
        /// </summary>
        /// <param name="s">base64 encoded string</param>
        /// <returns>byte array</returns>
        public static byte[] FromBase64ToArray(this string s) => Convert.FromBase64String(s);
        /// <summary>
        /// Trims a piece of <see cref="string"/> text from the location/index of where <paramref name="start"/>
        /// is and returns all text after that.
        /// </summary>
        /// <param name="text">
        /// <see cref="string"/> to truncate
        /// </param>
        /// <param name="start">
        /// Text to find in this block and begin from.
        /// </param>
        /// <returns>
        /// Truncated block <see cref="string"/> having removed all text that behind the <paramref name="start"/> location.
        /// </returns>
        public static string GetStringAfter(this string text, string start)
        {
            if (text.IsValid())
            {
                int index = text.IndexOf(start, Constants.StringComparison);
                if (index > -1)
                {
                    return text.Substring(index, text.Length - index).Trim(' ');
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(start));
                }
            }
            throw new ArgumentNullException(nameof(text));
        }
        /// <summary>
        /// Trims a piece of <see cref="string"/> text from the location/index of where <paramref name="end"/>
        /// is and returns all text before that.
        /// </summary>
        /// <param name="text">
        /// <see cref="string"/> to truncate.
        /// </param>
        /// <param name="end">
        /// Text to find in this block and end at.
        /// </param>
        /// <returns>
        /// Truncated block <see cref="string"/> having removed all text after <paramref name="end"/> location
        /// </returns>
        public static string GetStringBefore(this string text, string end)
        {
            if (text.IsValid())
            {
                int index = text.IndexOf(end, Constants.StringComparison);
                if (index > -1)
                {
                    return text.Substring(0, index).Trim(' ');
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(end));
                }
            }
            throw new ArgumentNullException(nameof(text));
        }
    }
}
