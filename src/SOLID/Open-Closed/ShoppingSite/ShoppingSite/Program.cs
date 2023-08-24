using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSite
{
    /// <summary>
    /// Represents the main entry point of the ShoppingSite application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method of the application.
        /// </summary>
        /// <param name="args">Command-line arguments (not used in this application).</param>
        static void Main(string[] args)
        {
            var menu= new Menu();
            do
            {
                menu.HandleUserOptions();
            } while (true);
            
        }
    }
}
