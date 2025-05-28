using CHI_IT_Test.CartDomain;
using CHI_IT_Test.Models;

namespace CHI_IT_Test.Services
{
    internal class CartInteractionService : ICartManager
    {
        private readonly IProductService _productService;
        private readonly ICart _cart;

        public CartInteractionService(IProductService productService, ICart cart)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            _cart = cart ?? throw new ArgumentNullException(nameof(cart));
        }

        public void Run()
        {
            DisplayProducts();
            SelectProducts();
            AskForBudget();
            DisplayCartItems();
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

                string productName = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(productName))
                {
                    Console.WriteLine("There is no such item, please check the spelling and try again.");

                    continue;
                }

                if (productName == "0")
                {
                    if (!_cart.IsCartEmpty)
                    {
                        break;
                    }

                    Console.WriteLine("You have not selected any item. Please, enter an item name, if you want to select any or leave empty to skip");
                    productName = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(productName))
                    {
                        break;
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

                string budget = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(budget))
                {
                    Console.WriteLine("It seems it was an empty string, please try again");
                }
                else
                {
                    if (decimal.TryParse(budget, out decimal budgetDecimal) && budgetDecimal >= 0)
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
            decimal total = _cart.GetTotalAmount();

            if (budget >= total)
            {
                Console.WriteLine($"Great! Your budget({budget}) suffices the total of your cart({total})");
            }
            else
            {
                Console.WriteLine($"Unfortunately, your budget({budget}) does not suffice the total of your cart({total})");
            }
        }

        private void DisplayCartItems()
        {
            Console.WriteLine("Your cart items:");

            foreach (var cartItem in _cart.CartItems)
            {
                Console.WriteLine(cartItem);
            }
        }
    }
}
