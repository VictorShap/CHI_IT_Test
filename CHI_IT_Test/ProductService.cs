namespace CHI_IT_Test
{
    internal class ProductService : IProductService
    {
        private readonly List<Product> _catalog;

        public IReadOnlyCollection<Product> Catalog { get { return _catalog; } }

        public ProductService(List<Product> catalog)
        {
            _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        }

        public Product? FindByName(string name)
        {
            return Catalog.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));  
        }
    }
}
