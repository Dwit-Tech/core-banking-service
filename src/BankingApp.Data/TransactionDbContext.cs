﻿using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

    }
}
