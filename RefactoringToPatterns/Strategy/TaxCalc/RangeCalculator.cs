using System;

namespace TaxCalc
{
    public class RangeCalculator
    {
        private readonly double UpperBound;
        private readonly double LowerBound;
        private readonly double TaxRate;

        public RangeCalculator(Range range)
        {
            UpperBound = range.UpperBound;
            LowerBound = range.LowerBound;
            TaxRate = range.Rate;
        }

        public double Calc(double taxbase)
        {
            double tax = 0;
            if (taxbase > LowerBound)
            {
                var min = Math.Min(taxbase, UpperBound);
                tax = (min-LowerBound) * TaxRate;
            }
            return tax;
        }
    }
}