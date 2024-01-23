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

        public DbSet<Customer> Customers { get; set; }

    
    }
}

