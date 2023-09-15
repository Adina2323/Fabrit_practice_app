using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;
using DataAcessLayer.Repositories.Users;
using HeroesApi.Migrations;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Users
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserService(
            IUsersRepository usersRepository,
            IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<User> AddUserAsync(RegisterDTO register)
        {
            using var hmac = new HMACSHA256();
            var user = new User
            {
                Username = register.UserName,
                Name = register.Name,
                Email = register.Email,
                CreatedDate = DateTime.UtcNow,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),
                SaltPassword = hmac.Key
            };
            return await _usersRepository.AddUserAsync(user);

        }

        public async Task DeleteUserAsync(string email)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);
            _usersRepository.DeleteUser(user);
        }

        public async Task<User?> GetUserByEmailAsync(string? email)
        {
            return await _usersRepository.GetUserByEmailAsync(email);
        }


        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _usersRepository.GetUsersAsync();
        }

        public async Task<int> UpdatePassword(
            User user,
            string newPassword)
        {
            _usersRepository.ChangePassword(user, Convert.ToHexString(user.Password), newPassword);
            if (await _usersRepository.SaveAllAsync())
            {
                return StatusCodes.Status200OK;
            }
            return StatusCodes.Status400BadRequest;

        }

        public async Task<bool> UpdateUser(
            UserUpdateDTO updatedUser,
            string email)
        {
            var exists = await _usersRepository.UserExists(email);

            if (exists == false)
            {
                throw new Exception(message: "Not found");
            }

            var updatedEntity = _mapper.Map<User>(updatedUser);

            updatedEntity.Id = await _usersRepository.GetIdByEmailAsync(email);
            await _usersRepository.UpdateUser(updatedEntity);
            

            if (await _usersRepository.SaveAllAsync())
            {
                return true;
            }
            return false;
        }


    }
}
