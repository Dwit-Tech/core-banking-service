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
    }
}
