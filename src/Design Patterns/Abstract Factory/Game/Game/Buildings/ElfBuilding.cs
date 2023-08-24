using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a specific building type in the game, associated with the Elf race.
    /// Inherits from the base <see cref="Building"/> class.
    /// </summary>
    internal class ElfBuilding : Building
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElfBuilding"/> class with the specified build time.
        /// </summary>
        /// <param name="time">The time needed to build the elf building.</param>
        public ElfBuilding(int time) : base(time) { }

        /// <summary>
        /// Represents the elf building's construction behavior.
        /// </summary>
        public override void BuildHome()
        {
            Console.WriteLine($"The elves built a Hut in {Time} minutes.");
        }
    }
}
