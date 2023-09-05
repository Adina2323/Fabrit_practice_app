using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;

namespace BusinessLogicLayer.Token
{
    public interface ITokenService
    {
        TokenDTO GenerateJSONWebToken(string email);
    }
}
