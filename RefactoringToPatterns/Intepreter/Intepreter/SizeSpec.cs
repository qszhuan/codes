namespace Intepreter
{
    public class SizeSpec :ISpec
    {
        public SizeSpec(ProductSize productSize)
        {
            ProductSize = productSize;
        }

        private ProductSize ProductSize { get; set; }

        public bool IsSatisfiedBy(Product product)
        {
            return product.Size.Equals(ProductSize);
        }
    }
}