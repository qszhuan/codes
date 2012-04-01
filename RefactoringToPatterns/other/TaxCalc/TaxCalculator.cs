using System.Collections.Generic;

namespace TaxCalc
{
    public class TaxCalculator
    {
        private const int TaxPoint = 3500;

        public static List<Range> RangeList = new List<Range>
                                                  {
                                                      new Range(0, 1500, 0.03),
                                                      new Range(1500, 4500, 0.1),
                                                      new Range(4500, 9000, 0.2),
                                                      new Range(9000, 35000, 0.25)
                                                  };

        public double Calc(double income)
        {
            if (income <= TaxPoint)
                return 0;

            var taxbase = income - TaxPoint;
            double tax = 0;
            foreach (var range in RangeList)
            {
                if (taxbase > range.LowerBound)
                {
                    tax += new RangeCalculator(range).Calc(taxbase);
                }
            }
            return tax;
        }
    }
}