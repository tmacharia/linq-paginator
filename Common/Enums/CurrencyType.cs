using Common.Attributes;
using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Represents supported current types
    /// </summary>
    public enum CurrencyType
    {
        /// <summary>
        /// Kenyan Shilling.
        /// </summary>
        [Description("Kenyan Shilling.")]
        [Symbol("Kshs")]
        KES=10,
        /// <summary>
        /// United States Dollar.
        /// </summary>
        [Description("US Dollar.")]
        [Symbol("$")]
        USD=20,
        /// <summary>
        /// Euro.
        /// </summary>
        [Description("Euro")]
        [Symbol("€")]
        EUR=30,
        /// <summary>
        /// Japanese Yen.
        /// </summary>
        [Description("Japanese Yen")]
        [Symbol("¥")]
        JPY=40
    }
}