using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents a specific type of discount that applies a 20% discount
    /// on the total cost of _items in the "food" category of the shopping cart.
    /// </summary>
    internal class CategoryDiscount:Discount
    {
        /// <summary>
        /// Computes the 20% discount on the total cost of "food" category _items in the shopping cart.
        /// </summary>
        /// <param name="cart">The shopping cart to apply the discount to.</param>
        /// <returns>The computed discount amount as a decimal.</returns>
        public override decimal ComputeDiscount(ShoppingCart cart) //20% discount
        {
            try
            {
                var categoryItems = cart.GetItems().Where(item => item.Type.Equals(CategoryType.food));
                var totalCategory = categoryItems.Sum(item => item.Price);
                return totalCategory *0.2m;
            }
            catch 
            {
                Console.WriteLine("Could not apply discount.");
                return 0;
            }
            
        }
    }
}
