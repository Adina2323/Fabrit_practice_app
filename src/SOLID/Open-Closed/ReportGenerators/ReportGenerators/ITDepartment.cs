using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerators
{
    /// <summary>
    /// Class <c>ITDepartment</c> models the ITDepartment data 
    /// </summary>
    internal class ITDepartment:Department
    {
        /// <summary>
        /// Constructs an object of ITDepartment type
        /// </summary>
        public ITDepartment()
        {
            name = "ITDepartment";
            dateGenerated = DateTime.Now;
            description = "IT administrators play an integral role within a company and the IT department itself. They're often the most knowledgeable  person available when someone needs help with a technological issue or has just joined the company and needs help navigating new equipment. ";



        }
    }
}
