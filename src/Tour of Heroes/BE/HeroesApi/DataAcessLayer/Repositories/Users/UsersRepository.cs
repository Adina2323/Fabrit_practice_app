using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAcessLayer.Data;
using DataAcessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAcessLayer.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _userContext;
        private readonly IMapper _mapper;

        public UsersRepository(DataContext context, IMapper mapper)
        {
            _userContext = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _userContext.Users.ToListAsync();
        }


        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userContext.Users.Where(user => user.Email == email).FirstOrDefaultAsync();
        }

        public async Task<User> AddUserAsync(string email, string password, string username, string name)
        {
            using var hmac = new HMACSHA256();
            var user = new User
            {
                Username = username,
                Name = name,
                Email = email,
                CreatedDate = DateTime.UtcNow,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                SaltPassword = hmac.Key
            };
            _userContext.Users.Add(user);
            if (await SaveAllAsync()) return user;
            throw new Exception();

        }

        public async Task<User> CreateEmptyUser(string email)
        {
            using var hmac = new HMACSHA256();
            var user = new User
            {
                Username = "johndoe",
                Name = "John Doe",
                Email = email,
                CreatedDate = DateTime.UtcNow,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password")),
                SaltPassword = hmac.Key
            };
            _userContext.Users.Add(user);
            if (await SaveAllAsync()) return user;
            throw new Exception();
        }

        public async Task UpdateUser(User user)
        {

            user.LastActive = DateTime.UtcNow;

            _userContext.Users.Update(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _userContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> UserExists(string email)
        {
            return await _userContext.Users.AnyAsync(user => user.Email == email); 
        }

        public async Task<bool> UserExistsByIdAync(long id)
        {
            return await _userContext.Users.AnyAsync(user => user.Id == id);
        }

        public async void ChangePassword(User user, string oldPassword, string newPassword)
        {
            if (oldPassword == newPassword)
            {
                return;
            }
            using var hmac = new HMACSHA256(user.SaltPassword);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(oldPassword));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] == user.Password[i]) throw new UnauthorizedAccessException();
            }

            using var newHmac = new HMACSHA256();
            user.Password = newHmac.ComputeHash(Encoding.UTF8.GetBytes(newPassword));
            user.SaltPassword = newHmac.Key;
            user.LastActive = DateTime.UtcNow;

            _userContext.Entry(user).State = EntityState.Modified;
        }

        public async Task<User?> GetUserByIdAsync(long id)
        {
           return await  _userContext
                .Users
                .Where(_user => _user.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
