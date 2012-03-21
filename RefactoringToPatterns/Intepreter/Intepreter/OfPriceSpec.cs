namespace Intepreter
{
    public class OfPriceSpec :ISpec
    {
        private readonly float _price;

        public OfPriceSpec(float price)
        {
            _price = price;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return product.Price.Equals(_price);
        }
    }
}