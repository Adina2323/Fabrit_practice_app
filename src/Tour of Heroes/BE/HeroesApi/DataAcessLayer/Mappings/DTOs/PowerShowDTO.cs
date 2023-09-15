using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAcessLayer.Models.Power;

namespace DataAcessLayer.Mappings.DTOs
{
    public class PowerShowDTO
    {


        public PowerTypes PowerType { get; set; }

        public string PowerTypeAsString
        {
            get
            {
                return this.PowerType.ToString();
            }
            set
            {
                PowerType = (PowerTypes)Enum.Parse(typeof(PowerTypes), value, true);
            }
        }


    }
}
