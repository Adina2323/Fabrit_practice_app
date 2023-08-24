using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Represents a Tank character in the game with additional armor.
    /// </summary>
    public class TankCharacter:Character
    {
        public double Armor { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TankCharacter"/> class with the specified health, armor, and damage.
        /// </summary>
        /// <param name="health">The health value of the tank character.</param>
        /// <param name="armor">The armor value of the tank character.</param>
        /// <param name="damage">The damage value of the tank character.</param>
        public TankCharacter(
            double health, 
            double armour, 
            double damage
            ) : base(health, damage) 
        {
            Armor = armour;
        }

        /// <summary>
        /// Takes damage and reduces the tank character's health by the specified amount after considering armor.
        /// </summary>
        /// <param name="amount">The amount of damage to be taken.</param>
        public override void TakeDamage(double amount)
        {
            amount -= Armor;
            Health -= amount;
            Console.WriteLine($"Tank took {amount} damage! {Health}HP remaining!\n\n");
        }

        /// <summary>
        /// Attacks another character and inflicts damage.
        /// </summary>
        /// <param name="character">The character to receive the damage.</param>
        public override void Attack(Character character)
        {
            
            Console.WriteLine($"Tank attacked!");
            character.TakeDamage(Damage);
        }


    }
}
