﻿using BankAPI.Model.Entities;
using BankAPI.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService=accountService;
        }

        /// <summary>
        /// Purpose: To get all the accounts for the user
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("GetAccountsByUserId/{userId}")]
        [HttpGet]      
        public ActionResult<IEnumerable<object>> GetAccountsByUserId(string userId)
        {
            return _accountService.GetAccounts(userId);
        }

        /// <summary>
        /// Purpose: To add a new account 
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [Route("AddAccount")]
        [HttpPost]
        public ActionResult<IEnumerable<object>> Create([FromBody] Account collection)
        {
            if (!ModelState.IsValid) return BadRequest(collection);
            return _accountService.AddAccount(collection);
        }

        /// <summary>
        /// Purpose: To delete an account when user pass the account id
        /// Created By/On : SK 06/2022
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        [Route("RemoveAccount/{accountId}")]
        [HttpDelete]
        public bool Delete(string accountId)
        {
            return _accountService.DeleteAccount(accountId);
        }
    }
}
