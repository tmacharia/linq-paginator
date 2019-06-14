using Common.Language;
using System;

namespace Common.Structs
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
                return Resources.JustNow;

            double delta = ts.TotalSeconds;
            if (delta == 1) return is_past ? Resources.OneSecAgo : Resources.InOneSec;
            if (delta < 60) return is_past ? $"{ts.Seconds} {Resources.SecsAgo}" : $"{Resources.In} {ts.Seconds} {Resources.Secs}";
            if (delta < 3600) return ts.Minutes == 1 ? is_past ? Resources.OneMinAgo : Resources.InOneMin : is_past ? $"{ts.Minutes} {Resources.MinsAgo}" : $"{Resources.In} {ts.Minutes} {Resources.Mins}";
            if (delta < 86400) return ts.Hours == 1 ? is_past ? Resources.OneHrAgo : Resources.InOneHr : is_past ? $"{ts.Hours} {Resources.HoursAgo}" : $"{Resources.In} {ts.Hours} {Resources.Hours}";

            int days = ts.Days;
            if (days == 1) return is_past ? Resources.Yesterday : Resources.Tomorrow;
            if (days < 30) return is_past ? $"{days} {Resources.DaysAgo}" : $"{Resources.In} {days} {Resources.Days}";

            int months = Math.Ceiling((decimal)days / (decimal)30).ToInt().Value;
            if (months < 12) return is_past ? $"{months} {Resources.MonthsAgo}" : $"{Resources.In} {months} {Resources.Months}";

            int yrs = Math.Floor((decimal)months / (decimal)12).ToInt().Value;
            return is_past ? $"{yrs} {Resources.YearsAgo}" : $"{Resources.In} {yrs} {Resources.Years}";
        }
        public static string ToMoment(this TimeSpan span)
        {
            if (span == null)
                throw new ArgumentNullException(nameof(span));

            double delta = span.TotalMilliseconds;
            if (delta < 1000) return $"{span.Milliseconds} {Resources.Ms}";
            if (delta < (1000 * 60)) return $"{span.Seconds} {Resources.Secs}";
            if (delta < (1000 * 3600)) return $"{span.Minutes} {Resources.Mins}";
            if (delta < (1000 * 86400)) return $"{span.Hours} {Resources.Hours}";

            return $"{span.Days} {Resources.Days}";
        }
    }
}