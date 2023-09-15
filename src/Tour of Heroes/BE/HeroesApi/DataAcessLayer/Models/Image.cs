using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace DataAcessLayer.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Path { get; set; }

        public long HeroId { get; set; }

        public HeroItem? Hero { get; set; }

        public bool IsMain { get; set; } = false;
    }
}
