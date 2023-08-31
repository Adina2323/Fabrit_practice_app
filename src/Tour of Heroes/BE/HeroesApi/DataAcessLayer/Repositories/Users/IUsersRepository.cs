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

        Task<User> GetUserByEmailAsync(string email);

        Task<User?> GetUserByIdAsync(long id);

        Task<User> AddUserAsync(string email, string password, string username, string name); 
        Task<User> CreateEmptyUser(string email);

        Task UpdateUser(User user);

        Task<bool> SaveAllAsync();

        Task<bool> UserExists(string email);

        Task<bool> UserExistsByIdAync(long id);

        void ChangePassword(User user, string oldPassword, string newPassword);
    }
}
