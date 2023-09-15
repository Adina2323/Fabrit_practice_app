using System.ComponentModel.DataAnnotations;

namespace DataAcessLayer.Models
{
    public class HeroItem
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage="Hero name must be 500 characters or shorter!")]
        public string? Name { get; set; }

        [MaxLength(500000000)]
        public string? Description { get; set; }

        public int? Health { get; set; }

        public int? BasicDamage { get; set; }

        public int? Armour { get; set; }


        public ICollection<Image> Images { get; set; }

        public ICollection<HeroItemPower> Powers { get; set; }
    }
}
