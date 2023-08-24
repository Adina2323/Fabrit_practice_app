using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a factory for creating units and buildings associated with the Human race.
    /// Inherits from the base <see cref="RaceFactory"/> class.
    /// </summary>
    internal class HumanFactory : RaceFactory
    {
        /// <summary>
        /// Creates a new human unit with the specified name and damage.
        /// </summary>
        /// <param name="name">The name of the human unit.</param>
        /// <param name="damage">The damage dealt by the human unit.</param>
        /// <returns>The created human unit instance.</returns>
        public override Unit CreateUnit(
            string name, 
            double damage) 
        {
            return new HumanUnit(name, damage);
        }

        /// <summary>
        /// Creates a new human building with the specified build time.
        /// </summary>
        /// <param name="buildTime">The time needed to build the human building.</param>
        /// <returns>The created human building instance.</returns>
        public override Building CreateBuilding(int buildTime) 
        {
            return new HumanBuilding(buildTime);
        }
    }
}
