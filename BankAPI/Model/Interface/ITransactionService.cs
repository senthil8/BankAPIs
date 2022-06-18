using BankAPI.Model.Entities;

namespace BankAPI.Model.Interface
{
    public interface ITransactionService
    {
        public bool DoTransaction(TransType transType,Account account,decimal amount);
    }

}
