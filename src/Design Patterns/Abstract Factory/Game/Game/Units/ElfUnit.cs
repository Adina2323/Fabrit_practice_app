using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a specific unit type in the game, belonging to the Elf race.
    /// Inherits from the base <see cref="Unit"/> class.
    /// </summary>
    public class ElfUnit:Unit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfUnit"/> class with the specified name and damage.
        /// </summary>
        /// <param name="name">The name of the elf unit.</param>
        /// <param name="damage">The damage dealt by the elf unit.</param>
        public ElfUnit(
            string name, 
            double damage
            ) : base(name, damage){ }

        /// <summary>
        /// Represents the elf unit's attack behavior.
        /// </summary>
        public override void Attack()
        {
            Console.WriteLine($"The elf {Name} has attacked and dealt {Damage}DMG.");
        }
    }
}
