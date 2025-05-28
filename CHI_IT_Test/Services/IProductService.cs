using CHI_IT_Test.Models;

namespace CHI_IT_Test.Services
{
    public interface IProductService
    {
        IReadOnlyCollection<Product> Catalog { get; }

        Product? FindByName(string name);
    }
}
