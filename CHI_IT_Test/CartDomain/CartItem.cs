using CHI_IT_Test.Models;

namespace CHI_IT_Test.CartDomain
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; private set; }
        public decimal Total { get { return Product.Price * Quantity; } }

        public CartItem(Product product, int quantity = 1)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));

            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be at least 1.");
            }

            Quantity = quantity;
        }

        public void IncreaseQuantity(int amount = 1)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be at least 1");
            }

            Quantity += amount;
        }

        public override string ToString()
        {
            return Product.ToString() + $" Item quantity: {Quantity} Item total: {Total}";
        }
    }
}
