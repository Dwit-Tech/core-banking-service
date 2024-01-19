using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Data
{
    public class StatementDbContext : DbContext
    {
        public StatementDbContext(DbContextOptions<StatementDbContext> options)
            : base(options)
        {
        }
    }
}
