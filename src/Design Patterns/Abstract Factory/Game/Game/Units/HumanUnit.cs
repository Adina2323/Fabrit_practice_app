using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a specific unit type in the game, belonging to the Human race.
    /// Inherits from the base <see cref="Unit"/> class.
    /// </summary>
    internal class HumanUnit:Unit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanUnit"/> class with the specified name and damage.
        /// </summary>
        /// <param name="name">The name of the human unit.</param>
        /// <param name="damage">The damage dealt by the human unit.</param>
        public HumanUnit(
            string name, 
            double damage
            ) : base(name, damage) { }

        /// <summary>
        /// Represents the human unit's attack behavior.
        /// </summary>
        public override void Attack()
        {

            Console.WriteLine($"The human {Name} has attacked and dealt {Damage}DMG.");
        }
    }
}
