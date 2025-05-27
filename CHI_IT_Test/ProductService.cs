namespace CHI_IT_Test
{
    internal class ProductService
    {
        private readonly List<Product> catalog;

        public IEnumerable<Product> Catalog { get { return catalog; } }

        public ProductService(List<Product> catalog)
        {
            this.catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        }
    }
}
