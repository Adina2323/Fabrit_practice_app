using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a base character in the game with health and damage properties.
    /// </summary>
    public abstract class Character
    {
        public double Health { get; protected set; }
        public double Damage { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class with the specified health and damage.
        /// </summary>
        /// <param name="health">The health value of the character.</param>
        /// <param name="damage">The damage value of the character.</param>
        public Character(
            double health,
            double damage)
        {
            Health = health;
            Damage = damage;
        }

        /// <summary>
        /// Takes damage and reduces the character's health by the specified amount.
        /// </summary>
        /// <param name="amount">The amount of damage to be taken.</param>
        public abstract void TakeDamage(double amount);

        /// <summary>
        /// Inflicts damage on another character.
        /// </summary>
        /// <param name="character">The character to receive the damage.</param>
        public abstract void Attack(Character character);

        /// <summary>
        /// Returns a string representation of the character's health and damage values.
        /// </summary>
        /// <returns>A string representation of the character.</returns>
        public override string ToString()
        {
            return $"{Health}HP\t{Damage} DMG";
        }
    }
}
