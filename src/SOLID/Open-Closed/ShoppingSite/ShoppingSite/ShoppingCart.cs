using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents a shopping cart that allows adding, removing, and clearing items.
    /// </summary>
    public class ShoppingCart
    {
        private List<ShoppingItem> _items;
        private Discount[] _discounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCart"/> class with the provided discounts.
        /// </summary>
        /// <param name="discounts">An array of discounts to be applied to the cart.</param>
        public ShoppingCart(Discount[] discounts) 
        {
            _items = new List<ShoppingItem>();
            _discounts = discounts;
        }

        /// <summary>
        /// Adds a shopping item to the cart.
        /// </summary>
        /// <param name="shoppingItem">The shopping item to add.</param>
        public void AddItem(ShoppingItem shoppingItem)
        {
            try
            {
                _items.Add(shoppingItem);
            }
            catch 
            {
                Console.WriteLine("Could not add the item to the cart.");
            }
            
        }

        /// <summary>
        /// Removes a shopping item from the cart.
        /// </summary>
        /// <param name="shoppingItem">The shopping item to remove.</param>
        public void RemoveItem(ShoppingItem shoppingItem)
        {
            try
            {
                _items.Remove(shoppingItem);
            }
            catch
            {
                Console.WriteLine("Could not remove the item from cart.");
            }
        }

        /// <summary>
        /// Clears all items from the cart.
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }

        /// <summary>
        /// Gets the list of items in the cart as a read-only collection.
        /// </summary>
        /// <returns>The read-only list of items in the cart.</returns>
        public List<ShoppingItem> GetItems()
        {
            return _items;
        }

        /// <summary>
        /// Prints on the screen the items in the shopping cart
        /// </summary>
        public void ShowItems()
        {
            _items.ForEach(item => Console.WriteLine(item.ToString()));
        }

        /// <summary>
        /// Returns the discounts available for the shopping cart
        /// </summary>
        /// <returns></returns>
        public Discount[] GetDiscounts()
        {
            return _discounts;
        }
    }
}
