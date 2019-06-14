using Common.Enums;

namespace Common.Primitives
{
    public static class CurrencyExts
    {
        #region Current Methods
        /// <summary>
        /// Formats a <see cref="decimal"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="precision">Number of decimal places in the result.</param>
        /// <param name="useFormat">Specify whether to use decimal place checker that formats the results 
        /// independently. Default is <see cref="true"/> to perform formatting. Choosing <see cref="false"/>
        /// will retain all the decimals places in a <see cref="decimal"/> if it has any.
        /// </param>
        /// <returns>Formatted Kenyan money.</returns>
        public static string ToMoney(this decimal d, CurrencyType currency = CurrencyType.USD, bool useFormat = true)
        {
            return $"{currency.GetSymbolAttribute()} " + (useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="double"/> number to Kenyan currency with precision
        /// set by default to 2 decimal places.
        /// </summary>
        /// <param name="d">Decimal amount to format.</param>
        /// <param name="precision">Number of decimal places in the result.</param>
        /// <param name="useFormat">Specify whether to use decimal place checker that formats the results 
        /// independently. Default is <see cref="true"/> to perform formatting. Choosing <see cref="false"/>
        /// will retain all the decimals places in a <see cref="double"/> if it has any.
        /// </param>
        /// <returns>Formatted Kenyan money.</returns>
        public static string ToMoney(this double d, CurrencyType currency = CurrencyType.USD, bool useFormat = true)
        {
            return $"{currency.GetSymbolAttribute()} " + (useFormat ? d.ToString(d % 1 == 0 ? "N0" : "N2", Constants.Culture) : d.ToString("N1", Constants.Culture));
        }
        /// <summary>
        /// Formats a <see cref="decimal"/> number to Kenyan currency.
        /// </summary>
        /// <param name="d">Integer amount to format.</param>
        /// <returns>Formatted Kenyan money.</returns>
        public static string ToMoney(this int n, CurrencyType currency = CurrencyType.USD)
        {
            return $"{currency.GetSymbolAttribute()} " + n.ToString(n % 1 == 0 ? "N0" : "N2", Constants.Culture);
        }
        #endregion
    }
}