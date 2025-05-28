using CHI_IT_Test.Cart;
using CHI_IT_Test.Models;
using CHI_IT_Test.Services;

namespace CHI_IT_Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            var initialCatalog = new List<Product>
        {
             new Product("Laptop", 999.99m),
             new Product("Smartphone", 499.50m),
             new Product("Headphones", 149.95m),
             new Product("Speakers", 200.95m),
             new Product("Keyboard", 100.99m)
         };

            IProductService productService = new ProductService(initialCatalog);
            ICart cart = new Cart();
            ICartManager cartManager = new CartManager(productService, cart);

            cartManager.Run();
        }
    }
}