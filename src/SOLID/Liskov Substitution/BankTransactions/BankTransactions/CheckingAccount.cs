using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    /// <summary>
    /// Class<c>CheckingAccount</c> models Checking types of accounts
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Constructor created an object with the given value 
        /// </summary>
        /// <param name="balance"></param>
        public CheckingAccount(decimal balance) :base(balance) { }
       
        /// <summary>
        /// Method that deposits a sum into the account
        /// </summary>
        /// <param name="amount"></param>
        public override void DepositAmount(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount should be greater than zero.");
                return;
            }

            balance += amount;
            Console.WriteLine($"Deposited: {amount}. New balance: {balance}");
        }

        /// <summary>
        /// Method that withdraws from the account (with overdraft)
        /// </summary>
        /// <param name="amount"></param>
        public override void WithdrawAmount(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount should be greater than zero.");
                return;
            }
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}. New balance: {balance}");
        }
    }
}
