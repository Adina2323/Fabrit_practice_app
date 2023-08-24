using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerators
{
    /// <summary>
    /// Class <c>HRDepartment</c> models the HRDepartment data 
    /// </summary>
    public class HRDepartment : Department
    {
        /// <summary>
        /// Constructs an object of HRDepartment type
        /// </summary>
        public HRDepartment() 
        {
            name = "Human Resources";
            dateGenerated = DateTime.Now;
            description = "Human resources (HR) is the division of a business responsible for finding, recruiting, screening, and training job applicants.\r\nHR departments also handle employee compensation, benefits, and terminations.\r\nHuman resource management (HRM) strategies focus on actively advancing and improving an organization's workforce with the long-term goal of improving the organization itself.";

        }

        
       
        
    }
}
