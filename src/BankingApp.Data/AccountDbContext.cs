using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options)
            : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
    }
}
