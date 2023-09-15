using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAcessLayer.Models
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        public byte[]? Password { get; set; }

        public byte[]? SaltPassword { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? LastActive { get; set; } = null;
        

        [ForeignKey(nameof(Hero))]
        public long? HeroId { get; set; }

        public HeroItem? Hero { get; set; }


        [ForeignKey(nameof(ProfilePicture))]
        public int? ProfilePictureId { get; set; }
        public Image? ProfilePicture { get; set; }



    }
}
