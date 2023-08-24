using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    internal class Program
    {
        /// <summary>
        /// This method calls the functions for the app to run. 
        /// </summary>
        /// <param Name="args"></param>
        static void Main(string[] args)
        {
            var menu = new Menu();
            var books = menu.AppStart();
            do
            {
                menu.HandleUserOptions(books);
            } while (true);

        }
    }
}
