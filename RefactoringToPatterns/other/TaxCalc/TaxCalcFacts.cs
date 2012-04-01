using Xunit;
using Xunit.Extensions;

namespace TaxCalc
{
    public class TaxCalcFacts
    {
        [Theory]
        [InlineData(3000.0, 0)]
        [InlineData(3500.0, 0)]
        [InlineData(4000.0, 15.00)]
        [InlineData(5000.00, 45.00)]
        [InlineData(8000.00, 345.00)]
        [InlineData(10000.00, 745.00)]
        [InlineData(12500.00, 1245.00)]
        [InlineData(20000.00, 3120.00)]
        [InlineData(38500.00, 7745.00)]
        public void should_calculate_tax_according_income(double income, double expectedTax)
        {
            var taxCalc = new TaxCalculator();
            var tax = taxCalc.Calc(income);
            Assert.Equal(expectedTax, tax);
        }
    }
}