namespace CHI_IT_Test
{
    internal class CartManager
    {
        private readonly ProductService _productService;
        private readonly Cart _cart;

        public CartManager(ProductService productService, Cart cart)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _cart = cart ?? throw new ArgumentNullException(nameof(cart));
        }

        public void Run()
        {
            DisplayProducts();
            SelectProducts();
            AskForBudget();
        }

        private void DisplayProducts()
        {
            Console.WriteLine("List of available products:");

            foreach (var product in _productService.Catalog)
            {
                Console.WriteLine(product);
            }
        }

        private void SelectProducts()
        {

            while (true)
            {
                Console.WriteLine("Select the product by wrtiting its name. Type \"0\" in order to proceed to enter your budget");

                string productName = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(productName))
                {
                    continue;
                }

                if (productName == "0")
                {
                    if (_cart.ProductCount != 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You have not selected any item. Please, enter an item name, if you want to select any or leave empty to skip");
                        productName = Console.ReadLine();

                        if (String.IsNullOrEmpty(productName))
                        {
                            break;
                        }
                    }
                }

                Product selectedProduct = _productService.FindByName(productName);

                if (selectedProduct != null)
                {
                    _cart.AddProduct(selectedProduct);

                    Console.WriteLine($"The item {selectedProduct.Name} has been successfully added to your cart");
                }
                else
                {
                    Console.WriteLine("There is no such item, please check the spelling and try again.");
                }
            }
        }

        private void AskForBudget()
        {
            while (true)
            {
                Console.WriteLine("Please enter your budget, so that we will be able to calculate if it exceeds the total");

                string budget = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(budget))
                {
                    Console.WriteLine("It seems it was an empty string, please try again");
                }
                else
                {
                    if (Decimal.TryParse(budget, out decimal budgetDecimal) && budgetDecimal >= 0)
                    {
                        DisplayBudgetComparison(budgetDecimal);

                        break;
                    }
                    else
                    {
                        Console.WriteLine("It seems it wasn't a number or the value was less then 0, please try again");
                    }
                }
            }
        }

        private void DisplayBudgetComparison(decimal budget)
        {
            if (budget >= _cart.GetTotalAmount())
            {
                Console.WriteLine($"Great! Your budget({budget}) suffices the total of your cart({_cart.GetTotalAmount()})");
            }
            else
            {
                Console.WriteLine($"Unfortunately, your budget({budget}) does not suffice the total of your cart({_cart.GetTotalAmount()})");
            }
        }
    }
}
