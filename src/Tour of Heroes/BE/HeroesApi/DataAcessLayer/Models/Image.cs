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
        public int Id { get; set; }

        public string? Url { get; set; }
    }
}
