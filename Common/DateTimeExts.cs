using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class DateTimeExts
    {
        /// <summary>
        /// Returns a human readable and comprehensible time format to know the exact
        /// relative time in the past.
        /// </summary>
        /// <param name="pastDate">This DateTime instance that should represent a time in the past
        /// <paramref name="currentTime">Current datetime instance to compare to. If not specified
        /// <see cref="DateTime.Now"/> will be used by default.
        /// </paramref>
        /// <paramref name="includeTime">Should the timestamp be included for differences of more than
        /// two days. If unset, timestamp is included by default.
        /// </paramref>
        /// or the future.
        /// </param>
        /// <returns>Human readable time</returns>
        public static string ToMoment(this DateTime pastDate, DateTime? currentTime = null, bool includeTime = true)
        {
            if (pastDate == null)
                throw new ArgumentNullException(nameof(pastDate));

            TimeSpan ts;
            bool is_past = true;

            // check if datetime is in the past or the future
            if (currentTime.HasValue)
            {
                is_past = pastDate < currentTime;
                ts = is_past ? currentTime.Value.Subtract(pastDate) : pastDate.Subtract(currentTime.Value);
            }
            else
            {
                is_past = pastDate < DateTime.Now;
                ts = is_past ? DateTime.Now.Subtract(pastDate) : pastDate.Subtract(DateTime.Now);
            }

            if (ts.TotalSeconds < 1)
                return "just now";

            double delta = ts.TotalSeconds;
            if (delta == 1) return is_past ? "1 sec ago" : "in 1 sec";
            if (delta < 60) return is_past ? $"{ts.Seconds} secs ago" : $"in {ts.Seconds} secs";
            if (delta < 3600) return ts.Minutes == 1 ? is_past ? "1 min ago" : "in 1 min" : is_past ? $"{ts.Minutes} mins ago" : $"in {ts.Minutes} mins";
            if (delta < 86400) return ts.Hours == 1 ? is_past ? "1 hour ago" : "in 1 hour" : is_past ? $"{ts.Hours} hours ago" : $"in {ts.Hours} hours";

            int days = ts.Days;
            if (days == 1) return is_past ? "yesterday" : "tomorrow";
            if (days < 30) return is_past ? $"{days} days ago" : $"in {days} days";

            int months = Math.Ceiling((decimal)days / (decimal)30).ToInt().Value;
            if (months < 12) return is_past ? $"{months} months ago" : $"in {months} months";

            int yrs = Math.Floor((decimal)months / (decimal)12).ToInt().Value;
            return is_past ? $"{yrs} yrs ago" : $"in {yrs} ysr";
        }
    }
}
