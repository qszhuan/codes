namespace Intepreter
{
    public class BelowPriceSpec :ISpec
    {
        private readonly float _price;

        public BelowPriceSpec(float price)
        {
            _price = price;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return product.Price < _price;
        }
    }
}