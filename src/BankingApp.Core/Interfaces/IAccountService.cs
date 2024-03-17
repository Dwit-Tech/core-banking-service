using System.Collections.Generic;
using System.Threading.Tasks;
using BankingApp.Core.Models;
using BankingApp.Data.Entities;

namespace BankingApp.Core.Interfaces
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccounts();
        Task<Account> CreateAccount(CreateAccountRequest createAccountRequest);
    }
}
