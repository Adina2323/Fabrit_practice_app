using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Mappings.DTOs
{
    public class InviteMailDTO
    {
        [Required]
        public string? EmailTo { get; set; }
        public string? ReceiverName { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
    }
}
