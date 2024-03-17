using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using BankingApp.Data;
using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<AccountResponse> CreateAccount(CreateAccountRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string accountNumber = GenerateAccountNumber();

            var newAccount = new Account
            {
                CustomerID = request.CustomerId,
                AccountType = request.AccountType,
                AccountName = request.AccountName,
                AccountNumber = accountNumber,
                Balance = 0,
                CreatedDate = DateTime.UtcNow
            };

            _accountDbContext.Accounts.Add(newAccount);
            await _accountDbContext.SaveChangesAsync();

            return new AccountResponse
            {
                CustomerId = newAccount.CustomerID,
                AccountNumber = newAccount.AccountNumber,
                AccountType = newAccount.AccountType,
                AccountName = newAccount.AccountName,
                Balance = newAccount.Balance,
                CreatedDate = newAccount.CreatedDate
            };
        }
    }
}
