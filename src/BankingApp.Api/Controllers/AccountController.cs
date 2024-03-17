using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using BankingApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Post(CreateAccountRequest createaccountRequest)
        {
            if (createaccountRequest == null)
            {
                return BadRequest("Account request is null");
            }

            var response = await _accountService.CreateAccountFromRequest(createaccountRequest);
            return Ok(response);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateAccountRequest createAccountRequest)
        {
            if (createAccountRequest == null)
            {
                return BadRequest("CreateAccountRequest is null");
            }

            var response = await _accountService.CreateAccount(createAccountRequest);
            return Ok(response);
        }
    }
}
