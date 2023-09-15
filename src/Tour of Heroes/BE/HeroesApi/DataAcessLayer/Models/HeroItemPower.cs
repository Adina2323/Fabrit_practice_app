using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAcessLayer.Models
{
    public class HeroItemPower
    {
        public long Id { get; set; }

        public HeroItem Hero { get; set; }

        public long HeroId { get; set; }

        public Power Power { get; set; }
        public long PowerId { get; set; }
    }
}
