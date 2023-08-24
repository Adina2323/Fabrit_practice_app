using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create instances of characters
            var tank = new TankCharacter(150, 15, 40);
            var warrior = new WarriorCharacter(120, 50);

            // Print Warrior's initial stats and apply damage from the Tank
            Console.WriteLine("Warrior stats:");
            Console.WriteLine(warrior.ToString());
            tank.Attack(warrior);

            // Print Tank's initial stats and apply damage from the Warrior
            Console.WriteLine("Tank stats:");
            Console.WriteLine(tank.ToString());
            warrior.Attack(tank);

            Console.ReadKey();
                    

        }
    }
}
