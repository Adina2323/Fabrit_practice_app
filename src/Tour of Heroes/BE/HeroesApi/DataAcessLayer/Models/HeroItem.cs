using System.ComponentModel.DataAnnotations;

namespace DataAcessLayer.Models
{
    public class HeroItem
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage="Hero name must be 50 characters or shorter!")]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public int? Health { get; set; }

        public int? BasicDamage { get; set; }

        public int? Armour { get; set; }

        [MaxLength(500)]
        public string? HeroPicture { get; set; }
    }
}
