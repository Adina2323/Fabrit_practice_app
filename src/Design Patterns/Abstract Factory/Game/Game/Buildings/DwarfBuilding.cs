using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a specific building type in the game, associated with the Dwarf race.
    /// Inherits from the base <see cref="Building"/> class.
    /// </summary>
    internal class DwarfBuilding : Building
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DwarfBuilding"/> class with the specified build time.
        /// </summary>
        /// <param name="time">The time needed to build the dwarf building.</param>
        public DwarfBuilding(int time) : base(time) { }

        /// <summary>
        /// Represents the dwarf building's construction behavior.
        /// </summary>
        public override void BuildHome()
        {
            Console.WriteLine($"The dwarfs built a Cottage in {Time} minutes.");
        }
    }
}
