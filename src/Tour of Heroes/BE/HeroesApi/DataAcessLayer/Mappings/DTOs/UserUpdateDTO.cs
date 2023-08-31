using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Mappings.DTOs
{
    public class UserUpdateDTO
    {
        public string? UserName { get; set; } 
        public string? Name { get; set; }
        public string? Email { get; set; }

    }
}
