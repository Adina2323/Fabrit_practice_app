using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;
using DataAcessLayer.Repositories.Users;
using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Users
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UserService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<User> AddUserAsync(string email, string password, string username, string name)
        {
            return await _usersRepository.AddUserAsync(email, password, username, name);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _usersRepository.GetUserByEmailAsync(email);
        }


        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _usersRepository.GetUsersAsync();
        }

        public async Task<int> UpdatePassword(User user, string newPassword)
        {
            _usersRepository.ChangePassword(user, Convert.ToHexString(user.Password), newPassword);
            if (await _usersRepository.SaveAllAsync()) return StatusCodes.Status200OK;
            return StatusCodes.Status400BadRequest;

        }

        public async Task<bool> UpdateUser(UserUpdateDTO updatedUser, long id)
        {
            var exists = await _usersRepository.UserExistsByIdAync(id);

            if (exists == false)
            {
                throw new Exception(message: "Not found");
            }

            var updatedEntity = _mapper.Map<User>(updatedUser);
            updatedEntity.Id = id;

            await _usersRepository.UpdateUser(updatedEntity);


            if (await _usersRepository.SaveAllAsync())
                return true;
            return false;

        }

    }
}
