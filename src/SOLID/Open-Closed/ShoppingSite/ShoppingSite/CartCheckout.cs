using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSite
{
    /// <summary>
    /// Represents a class responsible for the checkout process of a shopping cart.
    /// </summary>
    internal class CartCheckout
    {
        /// <summary>
        /// Checks out the _items in the shopping cart, applies the appropriate discount, and clears the cart.
        /// </summary>
        /// <param name="shoppingCart">The shopping cart to be checked out.</param>
        /// <param name="discount">The discount to be applied to the cart.</param>
        public decimal Checkout(ShoppingCart shoppingCart, Discount[] discounts)
        {
            if (shoppingCart == null)
            {
                Console.WriteLine("Could not apply discount");
                return 0;
            }

            var discountCheckout = discounts.Sum(discount => CalculateDiscount(discount, shoppingCart));

            shoppingCart.Clear();
            return discountCheckout;
        }

        /// <summary>
        /// Calculates the discount amount based on the provided discount object and shopping cart contents.
        /// </summary>
        /// <param name="discount">The discount object to calculate.</param>
        /// <param name="shoppingCart">The shopping cart containing items.</param>
        /// <returns>The calculated discount amount.</returns>
        private decimal CalculateDiscount(Discount discount, ShoppingCart shoppingCart)
        {
            switch (discount)
            {
                case CategoryDiscount categoryDiscount:
                    return ApplyCategoryDiscount(categoryDiscount, shoppingCart);

                case PercentageDiscount percentageDiscount:
                    return ApplyPercentageDiscount(percentageDiscount, shoppingCart);

                case FixedDiscount fixedDiscount:
                    return ApplyFixedDiscount(fixedDiscount, shoppingCart);

                default:
                    Console.WriteLine("Unknown discount type");
                    return 0;
            }
        }

        /// <summary>
        /// Applies a category-based discount to the shopping cart and returns the calculated discount amount.
        /// </summary>
        /// <param name="categoryDiscount">The category discount object.</param>
        /// <param name="shoppingCart">The shopping cart containing items.</param>
        /// <returns>The calculated category discount amount.</returns>
        private decimal ApplyCategoryDiscount(CategoryDiscount categoryDiscount, ShoppingCart shoppingCart)
        {
            var computedDiscount = categoryDiscount.ComputeDiscount(shoppingCart);
            Console.WriteLine($"Your 20% discount on food is: {computedDiscount}");
            return computedDiscount;
        }

        /// <summary>
        /// Applies a percentage-based discount to the shopping cart and returns the calculated discount amount.
        /// </summary>
        /// <param name="percentageDiscount">The percentage discount object.</param>
        /// <param name="shoppingCart">The shopping cart containing items.</param>
        /// <returns>The calculated percentage discount amount.</returns>
        private decimal ApplyPercentageDiscount(PercentageDiscount percentageDiscount, ShoppingCart shoppingCart)
        {
            var computedDiscount = percentageDiscount.ComputeDiscount(shoppingCart);
            Console.WriteLine($"Your 15% discount on total is: {computedDiscount}");
            return computedDiscount;
        }

        /// <summary>
        /// Applies a fixed discount to the shopping cart and returns the calculated discount amount.
        /// </summary>
        /// <param name="fixedDiscount">The fixed discount object.</param>
        /// <param name="shoppingCart">The shopping cart containing items.</param>
        /// <returns>The calculated fixed discount amount.</returns>
        private decimal ApplyFixedDiscount(FixedDiscount fixedDiscount, ShoppingCart shoppingCart)
        {
            var computedDiscount = fixedDiscount.ComputeDiscount(shoppingCart);
            Console.WriteLine($"Your fixed discount is: {computedDiscount}");
            return computedDiscount;
        }
    }
}
