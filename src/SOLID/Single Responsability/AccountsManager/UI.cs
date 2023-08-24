using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountsManager
{
    /// <summary>
    /// Class <c>UI</c> Handles The User options and actions
    /// </summary>
    internal class UI
    {
        /// <summary>
        /// Initializez the list of accounts with some default values.
        /// </summary>
        /// <returns>List with users</returns>
        public List<Account> UIStartup() 
        {
            Account account1 = new Account("user1", "password1", "user1@yahoo.com");
            Account account2 = new Account("user2", "password2", "user2@yahoo.com");
            Account account3 = new Account("user3", "password7", "user3@yahoo.com");
            Account account4 = new Account("user4", "password1", "user4@yahoo.com");
            Account account5 = new Account("user5", "password1", "user5@yahoo.com");

            var accounts = new List<Account>
            {
                account1,
                account2,
                account3,
                account4,
                account5
            };

            return accounts;

        }

        /// <summary>
        /// Prints the Menu for when you open the app 
        /// </summary>
        public void ShowStartUpMenu()
        {
            Console.WriteLine("Welcome to the ???? app! Select one of the options below: ");
            Console.WriteLine("1. Login.");
            Console.WriteLine("2. Sign Up. ");
            Console.WriteLine("3. Im lost. Get me out! ");
            Console.WriteLine("");
        }

        /// <summary>
        /// Prints the menu for when  you are logged in 
        /// </summary>
        public void ShowLoggedInMenu()
        {
            Console.WriteLine("1. Show user info.");
            Console.WriteLine("2. Update user info.");
            Console.WriteLine("Any other key to exit this menu.");
        }

        /// <summary>
        /// Manages the user input to perform the desired actions
        /// </summary>
        public void HandleUserAction()
        {
            List<Account> accounts = UIStartup();
            ShowStartUpMenu();
            Console.WriteLine("Insert the number of the option you want: ");
            var opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1: 
                    HandleLogin(accounts);
                    break;
                case 2: 
                    HandleSignUp(accounts);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid Option. Try Again.");
                    break;
            }

        }

        /// <summary>
        /// Handles the update user info option
        /// </summary>
        /// <param name="accounts"></param>
        /// <param name="user"></param>
        public void HandleUpdateInfo(List<Account> accounts, Account user)
        {
            var authenticationService = new AuthenticationService();
            Console.WriteLine("Insert New Username: ");
            var username = Console.ReadLine().Trim();
            Console.WriteLine("Insert New Password: ");
            var password = Console.ReadLine().Trim();
            Console.WriteLine("Insert New Email: ");
            var email = Console.ReadLine().Trim();
            if(authenticationService.UpdateUser(user.Username, user.Email, username, password, email, accounts))
            {
                var emailNotificationService = new EmailNotificationService();
                emailNotificationService.SendUserInfoEmail("");
            }
        }

        /// <summary>
        /// Handles the login option
        /// </summary>
        /// <param name="accounts"></param>
        public void HandleLogin(List<Account> accounts)
        {
            var authenticationService = new AuthenticationService();
            Console.WriteLine("Insert Username: ");
            var username = Console.ReadLine().Trim();
            Console.WriteLine("Insert Password: ");
            var password = Console.ReadLine().Trim();
            Console.WriteLine(username + password);
            var user = authenticationService.Login(username, password, accounts);
            user.ToString();
            do
            {
                ShowLoggedInMenu();
                Console.WriteLine("Insert the number of the option you want: ");
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1": authenticationService.ShowUserInfo(user);
                        break;
                    case "2": HandleUpdateInfo(accounts, user);
                        break;
                    default: user = null;
                        break;
                }

            } while(user!= null);
        }

        /// <summary>
        /// Handles the Sign up option
        /// </summary>
        /// <param name="accounts"></param>
        public void HandleSignUp(List<Account> accounts)
        {
            var authenticationService = new AuthenticationService();
            Console.WriteLine("Insert Username: ");
            var username = Console.ReadLine().Trim();
            Console.WriteLine("Insert Password: ");
            var password = Console.ReadLine().Trim();
            Console.WriteLine("Insert Email: ");
            var email = Console.ReadLine().Trim();
            var emailNotificationService = new EmailNotificationService();

            if (authenticationService.SignUp(username, password, email,accounts))
            {
                emailNotificationService.SendSignUpConfirmation(email);
            } 
                

        }
    }
}
