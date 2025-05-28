namespace CHI_IT_Test
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Product name cannot be empty.", nameof(name));
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than zero.");
            }

            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {Name} Price: {Price}";
        }
    }
}
