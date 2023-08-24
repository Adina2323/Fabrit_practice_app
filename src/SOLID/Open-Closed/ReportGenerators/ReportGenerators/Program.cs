using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerators
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
                menu.HandleOptions();
            }while (true);
        }
    }
}
