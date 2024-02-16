using BankingApp.Core.Interfaces;
using BankingApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
         public AccountController(IAccountService accountService)
        {
          _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            List<Account> accounts = await _accountService.GetAccounts();
            if (accounts == null || accounts.Count == 0)
            {
                return NotFound();
            }
            return Ok(accounts);
        }
    }
}

