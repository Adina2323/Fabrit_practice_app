using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Mappings.DTOs
{
    public class RegisterDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }

        public string? Name { get; set;}

    }
}
