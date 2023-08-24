using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTransactions
{
    /// <summary>
    /// Class<c>BankAccount</c> models the bank account
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Property<c>balance</c> represents the amount of money in the account.
        /// </summary>
        protected decimal balance;

        /// <summary>
        /// Initialises the amount with the given value
        /// </summary>
        /// <param name="balance"></param>
        public BankAccount(decimal balance)
        { 
            this.balance = balance; 
        }

        /// <summary>
        /// Method for depositing amount
        /// </summary>
        /// <param name="amount"></param>
        public abstract void DepositAmount(decimal amount);

        /// <summary>
        /// Method for withdrawing amount 
        /// </summary>
        /// <param name="amount"></param>
        public abstract void WithdrawAmount(decimal amount);

        /// <summary>
        /// Method that return the bank account info in a more user friendly way
        /// </summary>
        /// <returns>string with the bank account info</returns>
        public override string ToString()
        {
            return $"The balance on this account is: {balance}";
        }
    
    }
}
