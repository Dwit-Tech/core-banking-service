using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
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
    public class StatementService : IStatementService
    {
        private readonly StatementDbContext _statementDbContext;

        public StatementService(StatementDbContext statementDbContext)
        {
            _statementDbContext = statementDbContext;
        }

        public async Task<List<Statement>> GetStatements()
        {
            return await _statementDbContext.Statements.ToListAsync();
        }

        public async Task<Statement> RequestStatement(StatementRequest request)
        {
            Statement statement = new Statement()
            {
                CustomerId = request.CustomerId,
                Accounts = request.Accounts,
                Purpose = request.Purpose,
                DeliveryMode = request.DeliveryMode,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                LastUpdatedBy = "system",
                Status = "Pending",
                AddedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var created = await _statementDbContext.AddAsync(statement);
            await _statementDbContext.SaveChangesAsync();
            return created.Entity;
        }
    }
}
