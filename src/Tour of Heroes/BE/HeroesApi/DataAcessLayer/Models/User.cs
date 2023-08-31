using System.ComponentModel.DataAnnotations;


namespace DataAcessLayer.Models
{
    public class User
    {
        [Key]
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



    }
}
