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

            if(taxbase <= 1500)
            {
                return CalcFor0To1500(taxbase);
            }

            if (taxbase <= 4500)
            {
                return Calc1500To4500(taxbase);
            }

            if(taxbase <= 9000)
            {
                return Calc4500To9000(taxbase);
            }

            if (taxbase <= 35000)
            {
                return Calc9000To35000(taxbase);
            }

            return 0;
        }

        private static double Calc9000To35000(double taxbase)
        {
            return Calc4500To9000(9000 - 4500) + (taxbase - 9000)*0.25;
        }

        private static double Calc4500To9000(double taxbase)
        {
            return Calc1500To4500(4500-1500) + (taxbase - 4500)*0.20;
        }

        private static double Calc1500To4500(double taxbase)
        {
            return CalcFor0To1500(1500) + (taxbase - 1500)*0.1;
        }

        private static double CalcFor0To1500(double taxbase)
        {
            return taxbase * 0.03;
        }
    }
}