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

        public List<Product> ByColor(Color color)
        {
            var colorSpec = new ColorSpec(color);
            var products = productRepository.GetAllProducts();
            return products.Where(colorSpec.IsSatisfiedBy).ToList();
        }

        public List<Product> ByPrice(float price)
        {
            var products = productRepository.GetAllProducts();
            return products.Where(p => p.Price.Equals(price)).ToList();
        }

        public List<Product> ByColorSizeAndBelowPrice(Color color, ProductSize productSize, float price)
        {
            var products = productRepository.GetAllProducts();
            return products.Where(p => p.ProductColor.Equals(color) && p.Size.Equals(productSize) && p.Price < price).ToList();
        }

        public List<Product> BelowPriceAvoidingAColor(float price, Color color)
        {
            var products = productRepository.GetAllProducts();
            return products.Where(p => p.Price < price && !p.ProductColor.Equals(color)).ToList();
        }
    }
}