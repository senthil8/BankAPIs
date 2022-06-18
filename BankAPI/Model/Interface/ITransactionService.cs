using BankAPI.Model.Entities;

namespace BankAPI.Model.Interface
{
    public interface ITransactionService
    {
        public string DoTransaction(TransType transType,Account account,decimal amount);
    }

}
