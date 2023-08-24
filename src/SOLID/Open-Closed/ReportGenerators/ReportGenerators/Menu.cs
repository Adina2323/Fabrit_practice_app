using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerators
{
    /// <summary>
    /// Class <c>Menu</c> models the menu.
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Displays the options for the user.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine("\nChoose what report to see:\n");
            Console.WriteLine("1. HR Dept Report");
            Console.WriteLine("2. IT Dept Report");

        }

        /// <summary>
        /// Handles the cases for each option.
        /// </summary>
        public void HandleOptions()
        {
            ShowMenu();
            var opt = int.Parse(Console.ReadLine());
            switch(opt) 
            {
                case 1: 
                    var hrDept = new HRDepartment();
                    hrDept.GenerateReport();
                    break;
                case 2:
                    var itDept = new ITDepartment();
                    itDept.GenerateReport();
                    break;
            }

        }
    }
}
