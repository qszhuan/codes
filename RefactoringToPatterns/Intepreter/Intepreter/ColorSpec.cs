namespace Intepreter
{
    public interface ISpec
    {
        bool IsSatisfiedBy(Product product);
    }

    public class ColorSpec : ISpec
    {
        private readonly Color _color;

        public ColorSpec(Color color)
        {
            _color = color;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return product.ProductColor.Equals(_color);
        }
    }
}