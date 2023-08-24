using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a specific building type in the game, associated with the Human race.
    /// Inherits from the base <see cref="Building"/> class.
    /// </summary>
    internal class HumanBuilding : Building
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HumanBuilding"/> class with the specified build time.
        /// </summary>
        /// <param name="time">The time needed to build the human building.</param>
        public HumanBuilding(int time) : base(time) { }

        /// <summary>
        /// Represents the human building's construction behavior.
        /// </summary>
        public override void BuildHome()
        {
            Console.WriteLine($"The humans built a House in {Time} minutes.");
        }
    }
}
