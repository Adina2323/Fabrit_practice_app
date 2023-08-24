using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents a specific type of discount that provides a fixed discount amount of 20 on the total cost of all _items in the shopping cart.
    /// </summary>
    internal class FixedDiscount:Discount
    {
        /// <summary>
        /// Computes the fixed discount amount of 20 on the total cost of all _items in the shopping cart.
        /// </summary>
        /// <param name="cart">The shopping cart to apply the discount to.</param>
        /// <returns>The computed discount amount as a decimal.</returns>
        public override decimal ComputeDiscount(ShoppingCart cart)
        {
            return 5;

        }
    }
}
