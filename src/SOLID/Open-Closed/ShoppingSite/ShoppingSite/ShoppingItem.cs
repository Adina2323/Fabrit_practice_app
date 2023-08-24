using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents a shopping item with a name and price.
    /// </summary>
    public class ShoppingItem
    {
        /// <summary>
        /// Gets or sets the name of the shopping item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price of the shopping item.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the Type of the shopping item.
        /// </summary>
        public CategoryType Type { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingItem"/> class with the specified name and price.
        /// </summary>
        /// <param name="name">The name of the shopping item.</param>
        /// <param name="price">The price of the shopping item.</param>
        /// <param name="type">The type of the shopping item.</param>
        public ShoppingItem(string name, decimal price, CategoryType type) 
        {
            Name = name;
            Price = price;
            Type = type;
        }

        /// <summary>
        /// Returns a string representation of the shopping item.
        /// </summary>
        /// <returns>A string containing the name and price of the shopping item.</returns>
        public override string ToString()
        {
            return $"Item: {Name}\tPrice: {Price}";
        }


    }
}


