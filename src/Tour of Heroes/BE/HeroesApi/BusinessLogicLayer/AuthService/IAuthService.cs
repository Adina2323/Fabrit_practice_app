using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Mappings.DTOs;

namespace BusinessLogicLayer.AuthService
{
    public interface IAuthService
    {
        Task<LoginDTO?> AuthenticateUserAsync(LoginDTO login);
    }
}
