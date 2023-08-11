using jim.hex.common.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace jim.hex.common.test.Extensions
{
    public class DecimalExtensionTest
    {
        [Theory]
        [MemberData(nameof(ListOfDecimalWithPartDecimal))]
        public void WhenDecimalHasDecimal_ContainsDecimal_ReturnTrue(decimal value)
        {
            Assert.True(value.HasDecimal(), $"The value {value} should contains decimals");
        }


        [Theory]
        [MemberData(nameof(ListOfDecimalWith_NO_PartDecimal))]
        public void WhenDecimalHasDecimal_ContainsDecimal_ReturnFalse(decimal value)
        {
            Assert.False(value.HasDecimal(),$"The value {value} should not contains decimals");
        }

        public static IEnumerable<object[]> ListOfDecimalWithPartDecimal()
        {
            yield return new object[]{ 10.5m};
            yield return new object[] { 0.1m };
            yield return new object[] { 1000.00001m };
            yield return new object[] { -1000.00001m };

        }

        public static IEnumerable<object[]> ListOfDecimalWith_NO_PartDecimal()
        {
            yield return new object[] { 10.0m };
            yield return new object[] { 0m };
            yield return new object[] { -500m };
            yield return new object[] { 1000.00000m };
            yield return new object[] { 5432 };

        }
    }
}
