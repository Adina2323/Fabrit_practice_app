using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerators
{
    /// <summary>
    /// Class <c>Report</c> base class for the report
    /// </summary>
    public abstract class Report
    {
        /// <summary>
        /// Property <c>title</c> represents the title of the Report
        /// </summary>
        public string title = "Requested Report";

        /// <summary>
        /// Property <c>dateGenerated</c> represents the date and time of the generated report
        /// </summary>
        public DateTime dateGenerated;

        /// <summary>
        /// Method to generate the report 
        /// </summary>
        public abstract void GenerateReport();
    }

}
