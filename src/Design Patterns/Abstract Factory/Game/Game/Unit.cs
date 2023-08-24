using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// The base class <c>Unit</c> for representing a game unit.
    /// Contains properties and methods common to all units.
    /// </summary>
    public abstract class Unit
    {
        /// <summary>
        /// Gets or sets the name of the unit.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the damage dealt by the unit.
        /// </summary>
        public double Damage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Unit"/> class with the specified name and damage.
        /// </summary>
        /// <param name="name">The name of the unit.</param>
        /// <param name="damage">The damage dealt by the unit.</param>
        public Unit(
            string name, 
            double damage) 
        {
            Name = name;
            Damage = damage;
        }

        /// <summary>
        /// Represents the unit's attack behavior.
        /// This method must be implemented by derived classes.
        /// </summary>
        public abstract void Attack();
    }
}
