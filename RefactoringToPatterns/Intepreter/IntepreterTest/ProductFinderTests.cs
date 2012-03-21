using System.Collections.Generic;
using Intepreter;
using Xunit;
using System.Linq;
using Xunit.Extensions;

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
            var colorSpec = new ColorSpec(Color.Red);
            var products = finder.SelectBy(colorSpec);
            Assert.Equal(2, products.Count);
            Assert.True(products.Contains(fireTruck));
            Assert.True(products.Contains(toyConvertible));
        }

        [Fact]
        public void test_find_by_price()
        {
            var priceSpec = new OfPriceSpec(8.95f);
            var products = finder.SelectBy(priceSpec);
            Assert.Equal(2, products.Count);
            Assert.Equal(8.95f, products.ElementAt(0).Price);
            Assert.Equal(8.95f, products.ElementAt(1).Price);
        }

        [Fact]
        public void test_find_by_color_size_and_below_price()
        {
            var andSpec = new AndSpec(new ColorSpec(Color.Red), new SizeSpec(ProductSize.SMALL), new BelowPriceSpec(10.00F));
            var products = finder.SelectBy(andSpec);
            Assert.Equal(0, products.Count);

            var andSpec1 = new AndSpec(new ColorSpec(Color.Red), new SizeSpec(ProductSize.MEDIUM), new BelowPriceSpec(10.00F));
            products = finder.SelectBy(andSpec1);
            Assert.Equal(1, products.Count);
            Assert.Equal(fireTruck, products.ElementAt(0));
        }

        [Fact]
        public void test_find_by_below_price_and_avoid_a_color()
        {
            var andSpec = new AndSpec(new NotSpec(new ColorSpec(Color.White)), new BelowPriceSpec(9.00f));
            var products = finder.SelectBy(andSpec);
            Assert.Equal(1, products.Count);
            Assert.Equal(fireTruck, products.ElementAt(0));

            var andSpec1 = new AndSpec(new NotSpec(new ColorSpec(Color.Red)), new BelowPriceSpec(9.00f));

            products = finder.SelectBy(andSpec1);
            Assert.Equal(1, products.Count);
            Assert.Equal(baseball, products.ElementAt(0));
        }
    }
}