namespace CHI_IT_Test
{
    public interface IProductService
    {
        IReadOnlyCollection<Product> Catalog { get; }

        Product? FindByName(string name);
    }
}
