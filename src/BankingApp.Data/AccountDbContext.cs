using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {   
        }
    }
}


