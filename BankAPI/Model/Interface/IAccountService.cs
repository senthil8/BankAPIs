using BankAPI.Model.Entities;

namespace BankAPI.Model.Interface
{
    public interface IAccountService
    {
        public List<Account> GetAccounts(string userId);
        public List<Account> AddAccount(Account account);
        public bool DeleteAccount(string accountId);
        public Account GetAccountById(string accountId);
    }
}
