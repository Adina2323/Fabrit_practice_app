using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a Warrior character in the game.
    /// </summary>
    public class WarriorCharacter:Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WarriorCharacter"/> class with the specified health and damage.
        /// </summary>
        /// <param name="health">The health value of the warrior character.</param>
        /// <param name="damage">The damage value of the warrior character.</param>
        public WarriorCharacter(
            double health, 
            double damage
            ):base(health, damage) { }

        /// <summary>
        /// Takes damage and reduces the warrior character's health by the specified amount.
        /// </summary>
        /// <param name="amount">The amount of damage to be taken.</param>
        public override void TakeDamage(double amount)
        {
            Health -= amount;
            Console.WriteLine($"Warrior took {amount} damage! {Health}HP remaining!\n\n");
        }

        /// <summary>
        /// Attacks another character and inflicts damage.
        /// </summary>
        /// <param name="character">The character to receive the damage.</param>
        public override void Attack(Character character)
        {
            
            Console.WriteLine($"Warrior attacked!");
            character.TakeDamage(Damage);
        }
    }
}
