namespace TaxCalc
{
    public class Range
    {
        public double LowerBound { get; set; }
        public double UpperBound { get; set; }
        public double Rate { get; set; }

        public Range(double lowerBound, double upperBound, double rate)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            Rate = rate;
        }
    }
}