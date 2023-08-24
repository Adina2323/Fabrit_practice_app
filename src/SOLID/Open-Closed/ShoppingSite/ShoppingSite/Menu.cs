using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents the menu of the shopping site.
    /// </summary>
    internal class Menu
    {
        ShoppingCart cart;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        /// </summary>
        public Menu() 
        {
            var percentageDiscount = new PercentageDiscount();
            var fixedDiscount = new FixedDiscount();
            var categoryDiscount = new CategoryDiscount();
            cart = new ShoppingCart(new Discount[] { percentageDiscount,fixedDiscount, categoryDiscount });
        }

        /// <summary>
        /// Displays the main menu options to the user.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("\n  /\\_/\\");
            Console.WriteLine(" ( o.o )          Welcome to the Useless Shop!");
            Console.WriteLine("  > o <");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Buy item.");
            Console.WriteLine("2. Remove item from cart.");
            Console.WriteLine("3. Calculate total cost of cart.");
            Console.WriteLine("4. Checkout cart.");
            Console.WriteLine("5. Supiza!");
            Console.WriteLine("6. Get me out.\n");
        }

        /// <summary>
        /// Handles the user's selected menu option.
        /// </summary>
        public void HandleUserOptions()
        {
            ShowMenu();
            Console.WriteLine("Insert the number of the option you want: ");
            var opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    BuyItem();
                    break;
                case 2:
                    RemoveItem();
                    break;
                case 3:
                    ComputeTotal();
                    break;
                case 4:
                    Checkout(); 
                    break;
                case 5:
                    Supiza();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        /// <summary>
        /// Returns a list of shopping _items in stock.
        /// </summary>
        public List<ShoppingItem> ItemsInStock()
        {
            var items = new List<ShoppingItem>()
            {
                new ShoppingItem("Bread",5.65m, CategoryType.food),
                new ShoppingItem("Tomatoes",10.01m,CategoryType.food),
                new ShoppingItem("Cream",12.06m, CategoryType.food),
                new ShoppingItem("Toilet Paper",25.45m, CategoryType.bath),
                new ShoppingItem("Chips",11.75m, CategoryType.salty),
                new ShoppingItem("Chocolate",6.35m, CategoryType.sweets),
                new ShoppingItem("Candy",0.5m, CategoryType.sweets),
            };
            return items;
        }

        /// <summary>
        /// Allows the user to buy an item and add it to the cart.
        /// </summary>
        public void BuyItem()
        {
            ShowItemsInStock();

            Console.WriteLine("Write the name of the product you want.");
            var wishedItem = Console.ReadLine();
            var selectedItem = ItemsInStock().Where(item => item.Name.Equals(wishedItem)).FirstOrDefault();

            if (selectedItem != null)
            {
                cart.AddItem(selectedItem);
                Console.WriteLine("Your cart now has: ");
                cart.ShowItems();
            }
            else
            {
                Console.WriteLine($"Item not in stock. Could not add {wishedItem} to your cart.");
            }
        }

        /// <summary>
        /// Allows the user to remove an item from the cart.
        /// </summary>
        public void RemoveItem()
        {
            ShowItemsInStock();

            Console.WriteLine("Write the name of the product you want to remove.");
            var removeItem = Console.ReadLine();
            var itemToRemove = cart.GetItems().Where(item => item.Name.Equals(removeItem)).FirstOrDefault();

            if (itemToRemove != null)
            {
                cart.RemoveItem(itemToRemove);
                Console.WriteLine("Your cart now has: ");
                cart.ShowItems();
            }
            else
            {
                Console.WriteLine($"Item not in cart. Could not remove {removeItem} from your cart.");
            }

        }

        /// <summary>
        /// Computes and displays the total cost of _items in the cart.
        /// </summary>
        public void ComputeTotal()
        {
            var cartTotalCalculator = new CartTotalCalculator();
            var total = cartTotalCalculator.CartTotal(cart);

            Console.WriteLine($"Your total is: {total}.");
        }

        /// <summary>
        /// Initiates the checkout process for the _items in the cart.
        /// </summary>
        public void Checkout()
        {
            var cartTotalCalculator = new CartTotalCalculator();
            var cartCheckout = new CartCheckout();

            var total = cartTotalCalculator.CartTotal(cart);
            Console.WriteLine($"Total price: {total}");

            var totalDiscount = cartCheckout.Checkout(cart, cart.GetDiscounts());
            Console.WriteLine($"Total cost after discount is:{total-totalDiscount}");
            cart.Clear();
            Console.WriteLine("Thank you for buying from out useless shop!\n\n");
            
        }


        /// <summary>
        /// Show _items in stock
        /// </summary>
        public void ShowItemsInStock()
        {
            ItemsInStock().ForEach(item =>  Console.WriteLine(item.ToString()));
        }

        /// <summary>
        /// Shows a random surprise ASCII art.
        /// </summary>
        public void Supiza()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 5);
            switch (randomNumber)
            {
                case 1:
                    Console.WriteLine(@"          (\_____/) ");
                    Console.WriteLine(@"          / o\ /o \");
                    Console.WriteLine(@"         (    ^    )");
                    Console.WriteLine(@"          \   o   /");
                    Console.WriteLine(@"           \ ___ /");
                    break;
                case 2:
                    Console.WriteLine("\n\nWhy did the scarecrow win an award?");
                    Console.WriteLine("Because he was outstanding in his field!");
                    Console.WriteLine("             __|__");
                    Console.WriteLine("             (oo)\\_______");
                    Console.WriteLine("             (__)\\       )\\/\\");
                    Console.WriteLine("                 ||----w |");
                    Console.WriteLine("                 ||     ||");
                    break;
                case 3:
                    Console.WriteLine("\n\nWhen you write a bug-free code");
                    Console.WriteLine("and it works perfectly on the first try:");
                    Console.WriteLine("     \\ (>_<) /");
                    Console.WriteLine("      \\     /");
                    Console.WriteLine("       |    |");
                    Console.WriteLine("      /      \\");
                    Console.WriteLine("     /        \\");
                    break;
                case 4:
                    Console.WriteLine("\n\nWhen you finally understand");
                    Console.WriteLine("a complex programming concept:");
                    Console.WriteLine("  ( o_o)");
                    Console.WriteLine("  ( o_o)>⌐■-■");
                    Console.WriteLine("  (⌐■_■)");
                    break;
            }
  
        }

    }
}
