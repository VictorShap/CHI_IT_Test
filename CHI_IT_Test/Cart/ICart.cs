using CHI_IT_Test.Models;

namespace CHI_IT_Test.Cart
{
    public interface ICart
    {
        void AddProduct(Product product);

        decimal GetTotalAmount();

        IReadOnlyCollection<CartItem> CartItems { get; }

        bool IsCartEmpty { get; }
    }
}
