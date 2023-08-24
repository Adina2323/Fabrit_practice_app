using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a base class for buildings in the game.
    /// Contains properties and methods related to building structures.
    /// </summary>
    public abstract class Building
    {
        /// <summary>
        /// Gets or sets the time needed to build the building.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Building"/> class with the specified build time.
        /// </summary>
        /// <param name="time">The time needed to build the building.</param>
        public Building(int time) 
        {
            Time = time;
        }

        /// <summary>
        /// Represents the building's construction behavior.
        /// This method must be implemented by derived classes.
        /// </summary>
        public abstract void BuildHome();
    }
}
