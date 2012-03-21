using System.Linq;

namespace Intepreter
{
    public class AndSpec :ISpec
    {
        private readonly ISpec[] _specs;

        public AndSpec(params ISpec[] specs)
        {
            _specs = specs;
        }

        public bool IsSatisfiedBy(Product product)
        {
            return  _specs.All(spec=> spec.IsSatisfiedBy(product));
        }
    }
}