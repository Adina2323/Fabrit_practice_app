using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager
{
    /// <summary>
    /// Class <c>Account</c> models the user account
    /// </summary>
    internal class Account
    {
        /// <value>
        /// Property <c>Username</c> the unique name of the account
        /// </value>
        public string Username { set; get; }
        /// <value>
        /// Property<c>password</c> the password for the account
        /// </value>
        public string Password { set; get; }
        /// <value>
        /// Property<c>email</c> the email for the account
        /// </value>
        public string Email { set; get; }

        /// <summary>
        /// Constructor with given parameters
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public Account(string username, string password, string email)
        {
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }
        /// <summary>
        /// Writes the data from the user account in a easier format
        /// </summary>
        /// <returns>a string containing the user info</returns>
        public override string ToString()
        {
            return $"Username: {Username}, Email: {Email}, Password: {Password}";
        }



    }
}
