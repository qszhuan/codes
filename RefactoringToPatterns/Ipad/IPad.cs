using System.Collections.Generic;

namespace Ipad
{
    public class IPad
    {
        private const int BasePrice = 3688;
        private readonly List<ISpec> _specs = new List<ISpec>();

        public IPad(params ISpec[] specs)
        {
            _specs.AddRange(specs);
        }

        public int Price()
        {
            var price = BasePrice;
            _specs.ForEach(spec => price += spec.GetSpecPrice());
            return price;
        }
    }
}