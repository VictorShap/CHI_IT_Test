using CHI_IT_Test.Models;

namespace CHI_IT_Test.CartDomain
{
    public interface ICart
    {
        IReadOnlyCollection<CartItem> CartItems { get; }
        bool IsCartEmpty { get; }

        void AddProduct(Product product);

        decimal GetTotalAmount();
    }
}
