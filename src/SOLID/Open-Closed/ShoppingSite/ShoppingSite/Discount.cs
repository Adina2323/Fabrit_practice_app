using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents an abstract discount strategy for a shopping cart.
    /// </summary>
    public abstract class Discount
    {
        /// <summary>
        /// Computes the discount amount for the shopping cart.
        /// </summary>
        /// <param name="cart">The shopping cart to apply the discount to.</param>
        /// <returns>The computed discount amount as a decimal.</returns>
        public abstract decimal ComputeDiscount(ShoppingCart cart);
    }
}
