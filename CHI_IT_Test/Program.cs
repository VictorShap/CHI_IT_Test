namespace CHI_IT_Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<Product> products = CreateProducts();

            DisplayProducts(products);
        }

        public static List<Product> CreateProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product("Laptop", 999.99m));
            products.Add(new Product("Smartphone", 499.50m));
            products.Add(new Product("Headphones", 149.95m));
            products.Add(new Product("Speakers", 200.95m));
            products.Add(new Product("Keyboard", 100.99m));

            return products;
        }

        public static void DisplayProducts(List<Product> products)
        {
            Console.WriteLine("List of available products:");

            foreach (Product product in products)
            {
                Console.WriteLine("Name: " + product.Name + " " + "Price: " + product.Price);
            }
        }
    }
}