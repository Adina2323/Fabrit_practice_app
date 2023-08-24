using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager
{
    internal class Program
    {
        /// <summary>
        /// This method calls the functions for the app to run. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var ui = new UI();
            do
            {
                ui.HandleUserAction();
                Console.ReadKey();
            } while (true);

        }
    }
}
