using BankingApp.Core.Interfaces;
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
        public async Task<List<Account>> GetAccounts()
        {
            return await _accountDbContext.Accounts.ToListAsync();

        }
    }
}
