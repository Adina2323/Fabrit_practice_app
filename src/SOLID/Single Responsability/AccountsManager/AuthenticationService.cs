using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager
{
    internal class AuthenticationService
    {
        /// <summary>
        /// Method that tries to create a new user and add it to list
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="accounts"></param>
        /// <returns>True if succsessful, flase otherwise</returns>
        public bool SignUp(
            string username,
            string password,
            string email,
            List<Account> accounts)
        {
            foreach (var account in accounts)
            {
                if(account.Equals(username))
                {
                    Console.WriteLine("Username already taken!");
                    return false;
                }
                if(account.Equals(email)) 
                {
                    Console.WriteLine("There is another account linked to this email.");
                    return false;
                }
            }
            var newUser = new Account(username, password, email);
            try
            {
                accounts.Add(newUser);
                Console.WriteLine($"\nSign Up complete! An email confirmation will arrive shortly on: {email}\n");
                return true;
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("There was a problem adding the user!" + "Exception: " + ex);
                return false;
            };

        }

        /// <summary>
        /// Method that searches for the credentials in the list in order to login the user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="accounts"></param>
        /// <returns>The account linked to the given Username and password</returns>
        public Account Login(
            string username,
            string password,
            List<Account> accounts)
        {
            foreach(var user in accounts)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    Console.WriteLine($"Login Succesful!\nWelcome, {username}!");
                    return user;
                }
                else if(user.Username.Equals(username) && !user.Password.Equals(password)) 
                {
                    Console.WriteLine($"Login Unsuccesful!\nThe Username and password do not match!");
                }
            }
            Console.WriteLine($"Login Unsuccesful!\nThere was no account with those credentials.");
            return null;
        }

        /// <summary>
        /// Method shows user info 
        /// </summary>
        /// <param name="user"></param>
        public void ShowUserInfo(Account user)
        {
            Console.WriteLine(user.ToString());
        }

        /// <summary>
        /// Method finds the user in lsit and updates the data with new one
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="newUsername"></param>
        /// <param name="newPassword"></param>
        /// <param name="newEmail"></param>
        /// <param name="accounts"></param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateUser(
            string username,
            string email, 
            string newUsername,
            string newPassword,
            string newEmail,
            List<Account> accounts)
        {

            var user = accounts.Find(u => u.Username == username && u.Email == email);

            if (user == null)
            {
                Console.WriteLine("The user was not found!");
                return false;
            }

            foreach (var account in accounts)
            {
                if (account.Email.Equals(newEmail) )
                {
                    Console.WriteLine("Email is already used.");
                    return false;
                }
                if (account.Username.Equals(newUsername))
                {
                    Console.WriteLine("There is another account linked to this Username.");
                    return false ;
                }
            }

            user.Email = newEmail;
            user.Username = newUsername;
            user.Password = newPassword;
            return true;
        }
    }
}
