using BankAPI.Model.Entities;
using BankAPI.Model.Interface;

namespace BankAPI.Model
{
    public class TransactionService : ITransactionService
    {
        public List<Transaction> Transactions { get; private set; }

        public TransactionService()
        {
            Transactions = new List<Transaction>();
        }
        /// <summary>
        /// Purpose: To do transaction by user requests (Deposit/Withdraw)
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="transType"></param>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public string DoTransaction(TransType transType, Account account, decimal amount)
        {
            if(amount<=0) return "Amount should be grater than $0"; ;

            if (transType == TransType.Deposit)
            {
                account.Balance += amount; //Allow the users to deposit the amount
            }
            if (transType == TransType.Withdraw)
            {
                decimal tempAmount = account.Balance - amount;

                //An account cannot have less than $100 at any time in an account.
                if (tempAmount < 100) return "Given amount is grater than the account minimum balance $100";
                
                //A user cannot withdraw more than 90% of their total balance from an account in a single transaction.
                var temp90Percent = (account.Balance / 10) * 9;
                if (temp90Percent < amount) return "Given amount is grater than the 90% of total account balance."; 
                             
                account.Balance -= amount; //Allow the users to withdraw the amount
            }
            //Add this into transaction
            Transactions.Add(
                    new Transaction
                    {
                        AccountId = account.AccountId,
                        TransactionAmount = amount,
                        TransactionType = transType
                    });
            return "Transaction Success!";
        }
    }
}
