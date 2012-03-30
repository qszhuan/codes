namespace TaxCalc
{
    public class TaxCalculator
    {
        private const int TaxPoint = 3500;

        public double Calc(double income)
        {
            if (income <= TaxPoint)
                return 0;

            var taxbase = income - TaxPoint;

            return new RangeCalculator(0, 1500, 0.03).Calc(taxbase);
        }
    }

}