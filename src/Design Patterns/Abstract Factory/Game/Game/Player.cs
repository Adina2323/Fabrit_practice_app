using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Class <c>Player</c> represents a player in the game
    /// </summary>
    internal class Player 
    {
        /// <summary>
        /// Parameter that denotes the race chosen by the Player
        /// </summary>
        private RaceFactory _raceFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with a specified race factory.
        /// </summary>
        /// <param name="raceFactory">The race factory to use for creating units and buildings.</param>
        public Player(RaceFactory raceFactory)
        {
            _raceFactory = raceFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with no specified race factory.
        /// </summary>
        public Player()
        {
            _raceFactory = null;
        }

        /// <summary>
        /// Allows the player to choose a race and sets the associated race factory.
        /// </summary>
        /// <param name="race">The chosen race.</param>
        public void ChooseRace(Race race)
        {
            switch (race)
            {
                case Race.elf:
                    _raceFactory = new ElfFactory();
                    break;
                case Race.dwarf:
                    _raceFactory = new DwarfFactory();
                    break;
                case Race.human:
                    _raceFactory = new HumanFactory();
                    break;
                default:
                    _raceFactory = null;
                    Console.WriteLine("Unknown Race!");
                    break;
            }
        }

        /// <summary>
        /// Generates a world by creating a unit and a building using the chosen race factory.
        /// </summary>
        /// <param name="name">The name of the unit to generate.</param>
        /// <param name="damage">The damage of the unit to generate.</param>
        /// <param name="time">The time to build the building.</param>
        public void GenerateWorld(
            string name, 
            double damage, 
            int time)
        {
            Unit unit = _raceFactory.CreateUnit(name, damage);
            Building building = _raceFactory.CreateBuilding(time);

            Console.WriteLine("Units are being generated...");
            unit.Attack();

            Console.WriteLine("Buildings are being generated...");
            building.BuildHome();
        }

        /// <summary>
        /// Retrieves the currently selected race factory.
        /// </summary>
        /// <returns>The currently selected race factory.</returns>
        public RaceFactory GetCurrentRaceFactory()
        {
            return _raceFactory;
        }
    }
}
