namespace Intepreter
{
    public class Product
    {
        private readonly string code;
        private readonly string name;
        private readonly Color color;
        private readonly float price;
        private readonly ProductSize productSize;

        public Product(string code, string name, Color color, float price, ProductSize productSize)
        {
            this.code = code;
            this.name = name;
            this.color = color;
            this.price = price;
            this.productSize = productSize;
        }

        public ProductSize Size
        {
            get { return productSize; }
        }

        public float Price
        {
            get { return price; }
        }

        public Color ProductColor
        {
            get { return color; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Code
        {
            get { return code; }
        }
    }
}