namespace TaxCalc
{
    public class RangeCalculator
    {
        private readonly int UpperBound;
        private readonly int LowerBound;
        private readonly double TaxRate;

        public RangeCalculator(int lowerBound, int upperBound, double taxRate)
        {
            UpperBound = upperBound;
            LowerBound = lowerBound;
            TaxRate = taxRate;
        }

        public double Calc(double taxbase)
        {
            double tax = 0;
            if (taxbase <= UpperBound && taxbase >LowerBound)
            {
                tax = Calc2(taxbase);
            }

            if (taxbase <= 4500 && taxbase > UpperBound)
            {
                tax = Calc1500To4500(taxbase);
            }

            if (taxbase <= 9000 && taxbase > 4500)
            {
                tax = Calc4500To9000(taxbase);
            }

            if (taxbase <= 35000 && taxbase > 9000)
            {
                tax = Calc9000To35000(taxbase);
            }
            return tax;
        }

        private  double Calc9000To35000(double taxbase)
        {
            return Calc4500To9000(9000) + new RangeCalculator(9000,35000,0.25).Calc2(taxbase);
        }

        private  double Calc4500To9000(double taxbase)
        {
            return Calc1500To4500(4500) + new RangeCalculator(4500,9000,0.20).Calc2(taxbase);
        }

        private  double Calc1500To4500(double taxbase)
        {
            return Calc2(1500) + new RangeCalculator(1500, 4500, 0.1).Calc2(taxbase);
        }

        private  double Calc2(double taxbase)
        {
            return (taxbase-LowerBound) * TaxRate;
        }
    }
}