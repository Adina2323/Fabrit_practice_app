using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    /// <summary>
    /// Class<c>SavingsAccount</c> models Savings types of accounts
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Constructor created an object with the given value 
        /// </summary>
        /// <param name="balance"></param>
        public SavingsAccount(decimal balance):base(balance) { }

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
        /// Method that withdraws from the account (without overdraft)
        /// </summary>
        /// <param name="amount"></param>
        public override void WithdrawAmount(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount should be greater than zero.");
                return;
            }
            if (balance<amount)
            {
                Console.WriteLine($"You do not have enough money to make this transaction. Withdrawal amount should be less than the balance: {balance}");
                return;
            }
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}. New balance: {balance}");

        }
    }
}
