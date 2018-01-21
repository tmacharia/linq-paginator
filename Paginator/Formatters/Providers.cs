using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Paginator.Formatters
{
    public static class Providers
    {
        public static string ToString(this int i)
        {
            return ToNumber(i);
        }
        public static string ToString(this int i, Format format)
        {
            return Format(format, i);
        }
        private static string Format(Format format,object o)
        {
            switch (format)
            {
                case Formatters.Format.Currency:
                    return ToCurrency(o);
                case Formatters.Format.Decimal:
                    return ToDecimal(o);
                case Formatters.Format.Exponential:
                    return ToExponential(o);
                case Formatters.Format.FixedPoint:
                    return ToFixedPoint(o);
                case Formatters.Format.General:
                    return ToGeneral(o);
                case Formatters.Format.Number:
                    return ToNumber(o);
                default:
                    return Basic(o);
            }
        }
        private static string Basic(object o)
        {
            return o.ToString();
        }

        private static string CommaSeparatedInt(int i)
        {
            return i.ToString("###,###,###,###");
        }
        private static string ToCurrency(object o)
        {
            if (o is decimal)
                return ((decimal)o).ToString("C", CultureInfo.CurrentCulture);
            else if (o is int)
                return ((int)o).ToString("C", CultureInfo.CurrentCulture);
            else
                return ((double)o).ToString("C", CultureInfo.CurrentCulture);
        }
        private static string ToDecimal(object o)
        {
            if (o is decimal)
                return ((decimal)o).ToString("D", CultureInfo.CurrentCulture);
            else if (o is int)
                return ((int)o).ToString("D", CultureInfo.CurrentCulture);
            else
                return ((double)o).ToString("D", CultureInfo.CurrentCulture);
        }
        private static string ToExponential(object o)
        {
            if (o is decimal)
                return ((decimal)o).ToString("E", CultureInfo.CurrentCulture);
            else if (o is int)
                return ((int)o).ToString("E", CultureInfo.CurrentCulture);
            else
                return ((double)o).ToString("E", CultureInfo.CurrentCulture);
        }
        private static string ToFixedPoint(object o)
        {
            if (o is decimal)
                return ((decimal)o).ToString("F", CultureInfo.CurrentCulture);
            else if (o is int)
                return ((int)o).ToString("F", CultureInfo.CurrentCulture);
            else
                return ((double)o).ToString("F", CultureInfo.CurrentCulture);
        }
        private static string ToGeneral(object o)
        {
            if(o is decimal)
                return ((decimal)o).ToString("G", CultureInfo.CurrentCulture);
            else if(o is int)
                return ((int)o).ToString("G", CultureInfo.CurrentCulture);
            else
                return ((double)o).ToString("G", CultureInfo.CurrentCulture);
        }
        private static string ToNumber(object o)
        {
            if (o is decimal)
                return ((decimal)o).ToString("N", CultureInfo.CurrentCulture);
            else if (o is int)
                return ((int)o).ToString("N0", CultureInfo.CurrentCulture);
            else
                return ((double)o).ToString("N", CultureInfo.CurrentCulture);
        }
    }
}
