using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents a class responsible for calculating the total cost of _items in a shopping cart.
    /// </summary>
    internal class CartTotalCalculator
    {
        /// <summary>
        /// Calculates the total cost of _items in the shopping cart.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart for which to calculate the total.</param>
        /// <returns>The total cost of _items in the shopping cart.</returns>
        public decimal CartTotal(ShoppingCart shoppingCart) 
        {
            return shoppingCart.GetItems().Sum(item => item.Price);
        }
    }
}
