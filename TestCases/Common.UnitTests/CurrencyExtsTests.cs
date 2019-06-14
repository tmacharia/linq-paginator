using Common.Enums;
using Common.Primitives;
using NUnit.Framework;
using System;

namespace Common.UnitTests
{
    public class CurrencyExtsTests
    {
        [Theory]
        [TestCase(arg1: 3500, arg2: CurrencyType.USD, arg3: "$")]
        [TestCase(arg1: 3500, arg2: CurrencyType.EUR, arg3: "€")]
        [TestCase(arg1: 3500, arg2: CurrencyType.JPY, arg3: "¥")]
        [TestCase(arg1: 3500, arg2: CurrencyType.KES, arg3: "Kshs")]
        public void FormatCurrency(double d, CurrencyType type, string symbol)
        {
            // Act
            string res = d.ToMoney(type);

            // Assert
            Console.WriteLine(res);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.StartsWith(symbol));
        }
    }
}