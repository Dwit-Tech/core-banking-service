﻿using BankingApp.Core.Models;
using BankingApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Interfaces
{
    public interface IStatementService
    {
        Task<List<Statement>> GetStatements();
        Task<Statement> RequestStatement(StatementRequest request);
    }
}
