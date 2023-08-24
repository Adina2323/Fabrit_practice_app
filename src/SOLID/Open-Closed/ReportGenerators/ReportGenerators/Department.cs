using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerators
{
    /// <summary>
    /// Class<c>Department</c> models the data of a department
    /// </summary>
    public abstract class Department : Report
    {
        /// <summary>
        /// Property <c>name</c> represents the name of the department
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Property <c>description</c> gives a short description of the department
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Method that generates the report based on the dept information.
        /// </summary>
        public override void GenerateReport()
        {
            Console.WriteLine($"\n{title}\n");
            Console.WriteLine($"The Report was generated at: {dateGenerated}.");
            Console.WriteLine($"Here is the Report for the: {name} department.");
            Console.WriteLine($"{description}\n");

        }




    }
}
