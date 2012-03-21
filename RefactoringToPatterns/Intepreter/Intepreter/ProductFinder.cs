using System.Collections.Generic;
using System.Linq;

namespace Intepreter
{
    public class ProductFinder
    {
        private readonly ProductRepository productRepository;

        public ProductFinder(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> SelectBy(ISpec spec)
        {
            var products = productRepository.GetAllProducts();
            return products.Where(spec.IsSatisfiedBy).ToList();
        }
    }
}