namespace CHI_IT_Test
{
    internal class Cart
    {
        private List<Product> products;

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
