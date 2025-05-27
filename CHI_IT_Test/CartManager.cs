namespace CHI_IT_Test
{
    internal class CartManager
    {
        private readonly ProductService _productService;
        private readonly Cart _cart;

        public CartManager(ProductService productService, Cart cart)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _cart = cart ?? throw new ArgumentNullException(nameof(cart));
        }
    }
}
