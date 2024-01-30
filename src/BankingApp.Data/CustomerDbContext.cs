using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace BankingApp.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options)
            : base(options)
        {
        }
    }
}


