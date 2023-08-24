using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    /// <summary>
    /// Class <c>Menu</c> handles user operations 
    /// </summary>
    internal class Menu
    {
        /// <summary>
        /// Prints the Menu for when you open the app 
        /// </summary>
        public void ShowStartUpMenu()
        {
            Console.WriteLine("What type of account do you wish to create?");
            Console.WriteLine("1. Savings Account");
            Console.WriteLine("2. CheckingAccount");
            Console.WriteLine("3. Exit.\n");
        }

        /// <summary>
        /// Prints the menu to operate account
        /// </summary>
        public void ShowTransactionsMenu() 
        {
            Console.WriteLine("What actions do you want to perform?");
            Console.WriteLine("1. Withdrawal");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Exit.\n");
        }

        /// <summary>
        /// Manages the user input to create specific account
        /// </summary>
        public void HandleUserOptions()
        {
            Console.WriteLine("Choose an option:");
            ShowStartUpMenu();
            var opt = int.Parse(Console.ReadLine());
            switch(opt)
            {
                case 1:
                    var accountSavings = CreateSavingsAccount();
                    HandleUserOptionsOnAccount(accountSavings);
                    break;
                case 2:
                    var accountChecking = CreateCheckingAccount();
                    HandleUserOptionsOnAccount(accountChecking);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default: Console.WriteLine("Not a valid option. Try again!\n");
                    break;

                
            }
        }

        /// <summary>
        /// Creates a savings account
        /// </summary>
        /// <returns>bank account</returns>
        public BankAccount CreateSavingsAccount()
        {
            var amount = 0;
            var savingsAccount = new SavingsAccount(amount);
            Console.WriteLine(savingsAccount.ToString());
            return savingsAccount;

        }

        /// <summary>
        /// Creates a checking account
        /// </summary>
        /// <returns>bank account</returns>
        public BankAccount CreateCheckingAccount()
        {
            var amount = 0;
            var checkingAccount = new CheckingAccount(amount);
            Console.WriteLine(checkingAccount.ToString());
            return checkingAccount;
        }

        /// <summary>
        /// Method deposits money on a bank account
        /// </summary>
        /// <param name="bankAccount"></param>
        public void HandleDepositOption(BankAccount bankAccount)
        {
            Console.WriteLine("Insert desired amount to deposit: ");
            try
            {
                var amount = decimal.Parse(Console.ReadLine());
                bankAccount.DepositAmount(amount);
                
            }
            catch 
            {
                Console.WriteLine("The amount should be decimal!\n");
            }
        }

        /// <summary>
        /// Method withdraws money from a bank account
        /// </summary>
        /// <param name="bankAccount"></param>
        public void HandleWithdrawalOption(BankAccount bankAccount)
        {
            Console.WriteLine("Insert desired amount to withdraw: ");
            try
            {
                var amount = decimal.Parse(Console.ReadLine());
                bankAccount.WithdrawAmount(amount);
                Console.WriteLine(bankAccount.ToString());
            }
            catch 
            {
                Console.WriteLine("The amount should be decimal!\n");
            }
        }

        /// <summary>
        /// Manages the user input to manage account
        /// </summary>
        public void HandleUserOptionsOnAccount(BankAccount account)
        {
            do
            {
                Console.WriteLine("Choose an option:");
                ShowTransactionsMenu();
                var opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        HandleWithdrawalOption(account);
                        break;
                    case 2:
                        HandleDepositOption(account);
                        break;
                    case 3:
                        Environment.Exit(0);
                        account = null;
                        break;
                    default:
                        Console.WriteLine("Not a valid option. Try again!\n");
                        break;
                }
            }while(account!=null);
            
        }
    }
}
