namespace Intepreter
{
    public class NotSpec : ISpec
    {
        private readonly ISpec _spec;

        public NotSpec(ISpec spec)
        {
            _spec = spec;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return !_spec.IsSatisfiedBy(product);
        }
    }
}