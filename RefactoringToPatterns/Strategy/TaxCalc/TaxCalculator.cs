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
                return taxbase * 0.03;
            }

            if (taxbase <= 4500)
            {
                return 1500*0.03 + (taxbase - 1500)*0.1;
            }

            if(taxbase <= 9000)
            {
                return 1500*0.03 + (4500 - 1500)*0.1 + (taxbase - 4500)*0.20;
            }

            if (taxbase <= 35000)
            {
                return 1500*0.03 + (4500 - 1500)*0.1 + (9000 - 4500)*0.2 + (taxbase - 9000)*0.25;
            }

            return 0;
        }
    }
}