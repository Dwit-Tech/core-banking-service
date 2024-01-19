using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Data
{
    public class StatementDbContext : DbContext
    {
        public StatementDbContext(DbContextOptions<StatementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Statement> Statements { get; set; }
    }
}
