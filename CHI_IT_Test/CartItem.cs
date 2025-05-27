namespace CHI_IT_Test
{
    internal class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; private set; }

        public CartItem(Product product, int quantity = 1)
        {
            Product = product;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int amount = 1) => Quantity += amount;
        public decimal Total => Product.Price * Quantity;
    }
}
