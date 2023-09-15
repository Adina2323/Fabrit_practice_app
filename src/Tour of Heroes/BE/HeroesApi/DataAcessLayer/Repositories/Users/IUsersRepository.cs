using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer.Repositories.Users
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();

        Task<User?> GetUserByEmailAsync(string? email);

        Task<User?> GetUserByIdAsync(long id);

        Task<User> AddUserAsync(User user); 
        Task<User> CreateEmptyUser(string email);

        Task UpdateUser(User user);

        Task<bool> SaveAllAsync();

        Task<bool> UserExists(string email);

        Task<bool> UserExistsByIdAync(long id);

        void ChangePassword(User user, string oldPassword, string newPassword);
        Task DeleteUser(User user);

        Task<long> GetIdByEmailAsync(string? email);

        Task<HeroItem?> GetHeroOfUser(User user);
    }
}
