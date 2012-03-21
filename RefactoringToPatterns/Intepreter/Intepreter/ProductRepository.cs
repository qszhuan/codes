using System.Collections.Generic;

namespace Intepreter
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>();

        public void Add(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }
    }
}