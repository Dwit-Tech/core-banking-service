using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using BankingApp.Data;
using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountDbContext _accountDbContext;

        public AccountService(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        private string GenerateAccountNumber()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        public async Task<List<Account>> GetAccounts()
        {
            return await _accountDbContext.Accounts.ToListAsync();
        }

        public async Task<Account> CreateAccount(CreateAccountRequest createAccountRequest)
        {
            if (createAccountRequest == null)
            {
                throw new ArgumentNullException(nameof(createAccountRequest));
            }

            string accountNumber = GenerateAccountNumber();

            var newAccount = new Account
            {
                CustomerID = createAccountRequest.CustomerId,
                AccountType = createAccountRequest.AccountType,
                AccountName = createAccountRequest.AccountName,
                AccountNumber = accountNumber,
                Balance = 0,
                CreatedDate = DateTime.UtcNow
            };

            _accountDbContext.Accounts.Add(newAccount);
            await _accountDbContext.SaveChangesAsync();

            return newAccount;
        }
    }
}
