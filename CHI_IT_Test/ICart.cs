namespace CHI_IT_Test
{
    public interface ICart
    {
        void AddProduct(Product product);

        decimal GetTotalAmount();

        IReadOnlyCollection<CartItem> CartItems { get; }

        bool IsCartEmpty { get; }
    }
}
