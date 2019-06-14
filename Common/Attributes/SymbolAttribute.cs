using Common.Primitives;
using System;

namespace Common.Attributes
{
    /// <summary>
    /// Specifies a symbol for a property/field or event.
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class SymbolAttribute : Attribute
    {
        public SymbolAttribute(string symbolValue)
        {
            if (symbolValue.IsValid())
                Symbol = symbolValue;
        }
        public string Symbol { get; set; }
    }
}