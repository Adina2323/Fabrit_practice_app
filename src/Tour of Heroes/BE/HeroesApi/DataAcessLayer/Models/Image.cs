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
        public long Id { get; set; }

        [Required]
        public string? Path { get; set; }
    }
}
