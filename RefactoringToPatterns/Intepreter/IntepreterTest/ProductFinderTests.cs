using Intepreter;
using Xunit;
using System.Linq;

namespace IntepreterTest
{
    public class ProductFinderTests
    {
        private readonly ProductFinder finder;
        private readonly Product fireTruck = new Product("f1234", "Fire Truck", Color.Red, 8.95f, ProductSize.MEDIUM);
        private readonly Product barbieClassic = new Product("b7654", "Barbie Classic", Color.Yellow, 15.95f, ProductSize.SMALL);
        private readonly Product frisbee = new Product("f4321", "Frisbee", Color.Pink, 9.99f, ProductSize.LARGE);
        private readonly Product baseball = new Product("b2343", "Baseball", Color.White, 8.95f, ProductSize.NOT_APPLICABLE);
        private readonly Product toyConvertible = new Product("p1112", "Toy Porsche Convertible", Color.Red, 230.00f, ProductSize.NOT_APPLICABLE);

        public ProductFinderTests()
        {
            finder = new ProductFinder(CreateProductRepository());
        }

        private ProductRepository CreateProductRepository()
        {
            var productRepository = new ProductRepository();
            productRepository.Add(fireTruck);
            productRepository.Add(barbieClassic);
            productRepository.Add(frisbee);
            productRepository.Add(baseball);
            productRepository.Add(toyConvertible);
            return productRepository;
        }

        [Fact]
        public void test_find_by_color()
        {
            var products = finder.ByColor(Color.Red);
            Assert.Equal(2, products.Count);
            Assert.True(products.Contains(fireTruck));
            Assert.True(products.Contains(toyConvertible));
        }

        [Fact]
        public void test_find_by_price()
        {
            var products = finder.ByPrice(8.95f);
            Assert.Equal(2, products.Count);
            Assert.Equal(8.95f, products.ElementAt(0).Price);
            Assert.Equal(8.95f, products.ElementAt(1).Price);
        }

        [Fact]
        public void test_find_by_color_size_and_below_price()
        {
            var products = finder.ByColorSizeAndBelowPrice(Color.Red, ProductSize.SMALL, 10.00F);
            Assert.Equal(0, products.Count);

            products = finder.ByColorSizeAndBelowPrice(Color.Red, ProductSize.MEDIUM, 10.00F);
            Assert.Equal(1, products.Count);
            Assert.Equal(fireTruck, products.ElementAt(0));
        }

        [Fact]
        public void test_find_by_below_price_and_avoid_a_color()
        {
            var products = finder.BelowPriceAvoidingAColor(9.00f, Color.White);
            Assert.Equal(1, products.Count);
            Assert.Equal(fireTruck, products.ElementAt(0));            
            
            products = finder.BelowPriceAvoidingAColor(9.00f, Color.Red);
            Assert.Equal(1, products.Count);
            Assert.Equal(baseball, products.ElementAt(0));
        }
    }
}