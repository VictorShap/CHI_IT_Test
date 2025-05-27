namespace CHI_IT_Test
{
    internal class Cart
    {
        private readonly List<Product> products;

        public Cart()
        {
            products = new List<Product>();
        }

        public Cart(List<Product> products)
        {
            this.products = products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public decimal GetTotalAmount()
        {
            return 0;
        }
    }
}
