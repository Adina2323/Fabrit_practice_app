using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a factory for creating units and buildings associated with the Elf race.
    /// Inherits from the base <see cref="RaceFactory"/> class.
    /// </summary>

    internal class ElfFactory : RaceFactory
    {
        /// <summary>
        /// Creates a new elf unit with the specified name and damage.
        /// </summary>
        /// <param name="name">The name of the elf unit.</param>
        /// <param name="damage">The damage dealt by the elf unit.</param>
        /// <returns>The created elf unit instance.</returns>
        public override Unit CreateUnit(
            string name, 
            double damage)
        {
            return new ElfUnit(name,damage);
        }

        /// <summary>
        /// Creates a new elf building with the specified build time.
        /// </summary>
        /// <param name="buildTime">The time needed to build the elf building.</param>
        /// <returns>The created elf building instance.</returns>
        public override Building CreateBuilding(int buildTime)
        {
            return new ElfBuilding(buildTime);
        }
    }
}
