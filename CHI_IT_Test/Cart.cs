namespace CHI_IT_Test
{
    internal class Cart : ICart
    {
        private readonly List<CartItem> _cartItems;

        public bool IsCartEmpty => _cartItems.Count == 0;
        public IReadOnlyCollection<CartItem> CartItems { get { return _cartItems; } }

        public Cart()
        {
            _cartItems = new List<CartItem>();
        }

        public Cart(List<CartItem> products)
        {
            _cartItems = products ?? throw new ArgumentNullException(nameof(products));
        }

        public void AddProduct(Product product)
        {
            CartItem item = _cartItems.FirstOrDefault(i => i.Product.Name == product.Name);

            if (item != null)
            {
                item.IncreaseQuantity();
            }
            else
            {
                _cartItems.Add(new CartItem(product));
            }
        }

        public decimal GetTotalAmount()
        {
            return _cartItems.Sum(i => i.Total);
        }
    }
}
