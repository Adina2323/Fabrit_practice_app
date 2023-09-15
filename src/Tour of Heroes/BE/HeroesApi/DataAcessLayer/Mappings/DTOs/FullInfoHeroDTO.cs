using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Mappings.DTOs
{
    public class FullInfoHeroDTO
    {

        public long Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? Health { get; set; }

        public int? BasicDamage { get; set; }

        public int? Armour { get; set; }
        public IEnumerable<string>? Powers { get; set; }

        public IEnumerable<string>? Images { get; set; }

        public string? Picture { get; set; }

    }
}
