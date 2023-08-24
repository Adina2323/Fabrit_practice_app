using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents a specific type of discount that applies a 15% discount
    /// on the total cost of all _items in the shopping cart.
    /// </summary>
    internal class PercentageDiscount:Discount
    {
        /// <summary>
        /// Computes the 15% discount on the total cost of all _items in the shopping cart.
        /// </summary>
        /// <param name="cart">The shopping cart to apply the discount to.</param>
        /// <returns>The computed discount amount as a decimal.</returns>
        public override decimal ComputeDiscount(ShoppingCart cart) //15% pe toate produsele
        {
            try
            {
                var cartTotalCalculator = new CartTotalCalculator();
                decimal total = cartTotalCalculator.CartTotal(cart);
                return total*0.15m;
            }
            catch 
            {
                Console.WriteLine("Could not apply discount.");
                return 0;
            }
            
            
        }
    }
}
