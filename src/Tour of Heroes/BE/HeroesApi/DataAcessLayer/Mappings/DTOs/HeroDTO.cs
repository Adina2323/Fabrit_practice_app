using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Mappings.DTOs
{
    public class HeroDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Powers { get; set; }
    }
}
