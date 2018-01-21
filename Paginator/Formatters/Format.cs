namespace Paginator.Formatters
{
    /// <summary>
    /// Formatting options for masking numbers using a certain pattern/format
    /// </summary>
    /// <see cref="https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings"/>
    public enum Format
    {
        /// <summary>
        /// Converts a number to a string that represents a currency amount in the 
        /// currency type of the requested user.
        /// </summary>
        Currency,
        /// <summary>
        /// Converts a number to a string of decimal digits (0-9), prefixed by a minus 
        /// sign if the number is negative. This format is supported only for integral 
        /// types.
        /// </summary>
        Decimal,
        /// <summary>
        /// converts a number to a string of the form "-d.ddd…E+ddd" or "-d.ddd…e+ddd", 
        /// where each "d" indicates a digit (0-9). The string starts with a minus sign 
        /// if the number is negative. Exactly one digit always precedes the decimal point.
        /// </summary>
        Exponential,
        /// <summary>
        /// Converts a number to a string of the form "-ddd.ddd…" where each "d" indicates
        /// a digit (0-9). The string starts with a minus sign if the number is negative.
        /// </summary>
        FixedPoint,
        /// <summary>
        /// converts a number to the more compact of either fixed-point or scientific 
        /// notation, depending on the type of the number and whether a precision 
        /// specifier is present.
        /// </summary>
        General,
        /// <summary>
        /// converts a number to a string of the form "-d,ddd,ddd.ddd…", where "-" 
        /// indicates a negative number symbol if required, 
        /// "d" indicates a digit (0-9), "," indicates a group separator, and "." 
        /// indicates a decimal point symbol.
        /// </summary>
        Number
    }
}
