using BankAPI.Model.Entities;
using BankAPI.Model.Interface;

namespace BankAPI.Model
{
    public class AccountService : IAccountService
    {
        public List<Account> Accounts { get; private set; }
        public AccountService()
        {
            Accounts = new List<Account>
            {
                //Adding default account for testing
                new Account() { UserId = "SEN100", AccountType = AccountType.Savings, Balance = 100, HolderName = "Senthil" }
            };
        }

        /// <summary>
        /// Purpose: To add a new account 
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public List<Account> AddAccount(Account account)
        {
            Accounts.Add(account); //Add transaction right after this

            return Accounts;
        }

        /// <summary>
        /// Purpose: To delete an account when user pass the account id
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public bool DeleteAccount(string accountId)
        {
            //check the account is exists
            var account = Accounts.FirstOrDefault(acc => acc.AccountId == accountId);
            //if account doesn't exists throw false
            if (account == null) throw new ApplicationException("Account does not exist");
            Accounts.Remove(account);
            return true;
        }

        /// <summary>
        /// Purpose: To get an account when user pass the account id
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public Account GetAccountById(string accountId)
        {
            //check the account is exists
            var account = Accounts.FirstOrDefault(acc => acc.AccountId == accountId);
            if (account == null) throw new ApplicationException("Account does not exist");
            return account;
        }

        public bool IsAccountValid(string accountId)
        {
            //check the account is exists
            var account = Accounts.FirstOrDefault(acc => acc.AccountId == accountId);
            if (account == null) return false;
            return true;
        }

        /// <summary>
        /// Purpose: To get all the accounts for the user
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Account> GetAccounts(string userId)
        {
            return Accounts.Where(acc => acc.UserId == userId).ToList();
        }

        /// <summary>
        /// Purpose: To check if give user id exists
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsUserIdExists(string userId)
        {
            bool isUserExists = Accounts.Any(item => item.UserId == userId);
            if (!isUserExists) return false;
            return true;            
        }
    }
}
