using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents an abstract factory for creating game units and buildings of a specific race.
    /// </summary>
    public abstract class RaceFactory
    {
        /// <summary>
        /// Creates a new unit of the specified race with the given name and damage.
        /// </summary>
        /// <param name="name">The name of the unit.</param>
        /// <param name="damage">The damage dealt by the unit.</param>
        /// <returns>The created unit instance.</returns>
        public abstract Unit CreateUnit(string name, double damage);

        /// <summary>
        /// Creates a new building of the specified race with the given build time.
        /// </summary>
        /// <param name="buildTime">The time it takes to build the building.</param>
        /// <returns>The created building instance.</returns>
        public abstract Building CreateBuilding(int buildTime);
    }
}
