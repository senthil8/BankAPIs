using BankAPI.Model.Entities;
using BankAPI.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;
        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        /// <summary>
        /// Purpose: To do transaction by user requests (Deposit/Withdraw)
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="transType"></param>
        /// <param name="accountId"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [Route("DoTransaction")]
        [HttpGet]
        public bool DoTransaction(TransType transType,string accountId,decimal amount)
        {
            if (!ModelState.IsValid) return false;
            var account =_accountService.GetAccountById(accountId);
           return _transactionService.DoTransaction(transType, account, amount);
        }
    }
}
