using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a factory for creating units and buildings associated with the Dwarf race.
    /// Inherits from the base <see cref="RaceFactory"/> class.
    /// </summary>
    internal class DwarfFactory : RaceFactory
    {
        /// <summary>
        /// Creates a new dwarf unit with the specified name and damage.
        /// </summary>
        /// <param name="name">The name of the dwarf unit.</param>
        /// <param name="damage">The damage dealt by the dwarf unit.</param>
        /// <returns>The created dwarf unit instance.</returns>
        public override Unit CreateUnit(
            string name, 
            double damage) 
        {
            return new DwarfUnit(name,damage);
        }

        /// <summary>
        /// Creates a new dwarf building with the specified build time.
        /// </summary>
        /// <param name="buildTime">The time needed to build the dwarf building.</param>
        /// <returns>The created dwarf building instance.</returns>
        public override Building CreateBuilding(int buildTime) 
        {
            return new DwarfBuilding(buildTime);
        }
    }
}
