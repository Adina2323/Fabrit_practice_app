using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a specific unit type in the game, belonging to the Dwarf race.
    /// Inherits from the base <see cref="Unit"/> class.
    /// </summary>
    internal class DwarfUnit : Unit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DwarfUnit"/> class with the specified name and damage.
        /// </summary>
        /// <param name="name">The name of the dwarf unit.</param>
        /// <param name="damage">The damage dealt by the dwarf unit.</param>
        public DwarfUnit(
            string name, 
            double damage) : base(name, damage) { }

        /// <summary>
        /// Represents the dwarf unit's attack behavior.
        /// </summary>
        public override void Attack()
        {
            Console.WriteLine($"The dwarf {Name} has attacked and dealt {Damage}DMG.");
        }
    }
}
