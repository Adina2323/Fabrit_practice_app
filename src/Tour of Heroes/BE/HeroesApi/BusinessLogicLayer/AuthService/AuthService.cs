using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer.Users;
using DataAcessLayer.Mappings.DTOs;

namespace BusinessLogicLayer.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;

        public AuthService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<LoginDTO?> AuthenticateUserAsync(LoginDTO login)
        {
            var user = await _userService.GetUserByEmailAsync(login.Email);

            if (user == null)
            {
                Console.WriteLine("User not found!");
                login = null;
                return login;
            }

            using var hmac = new HMACSHA256(user.SaltPassword);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));
            if (computedHash.SequenceEqual(user.Password))
            {
                return login;
            }
            return null;
        }
    }
}
