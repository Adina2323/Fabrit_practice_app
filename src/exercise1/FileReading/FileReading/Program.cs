using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReading
{
    internal class Program
    {
        /// <summary>
        /// This method calls the functions for the app to run. 
        /// </summary>
        static void Main()
        { 
            var menu = new Menu();
            do
            {
                menu.HandleMenu();
                Console.ReadKey();
            } while (true);

        }
    }
}
