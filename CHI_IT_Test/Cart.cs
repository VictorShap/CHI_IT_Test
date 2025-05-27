namespace CHI_IT_Test
{
    internal class Cart
    {
        private readonly List<Product> _products;

        public int ProductCount { get { return _products.Count; } }

        public Cart()
        {
            _products = new List<Product>();
        }

        public Cart(List<Product> products)
        {
            _products = products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public decimal GetTotalAmount()
        {
            return _products.Sum(p => p.Price);
        }
    }
}
