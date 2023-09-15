using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Models
{
    public class Power
    {
        public long Id { get; set; }

        public ICollection<HeroItemPower> HeroPowers { get; set; } = new List<HeroItemPower>();
        public PowerTypes PowerType { get; set; }

        [Required]
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
        public enum PowerTypes
        {
            AstralProjection,
            EnergyMedicine,
            Hydrokinesis,
            Levitation,
            Materialization,
            Mediumship,
            Pyrokinesis,
            Telekinesis,
            Clairvoyance,
            Telepathy,
            Magic,
            SuperhumanStrength,
            TimeTravel,
            WitchCraft,
            Shapeshifting,
            Invisibility,
            Imortality
        }
    }
}
