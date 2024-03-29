﻿using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using BankingApp.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatementController : ControllerBase
    {
        private readonly IStatementService _statementService;

        public StatementController(IStatementService statementService) 
        {
            _statementService = statementService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Statement> statements = await _statementService.GetStatements();
            if (statements is null || statements.Count == 0)
            {
                return NotFound();
            }
            return Ok(statements);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StatementRequest statementRequest)
        {
            Statement statement = await _statementService.RequestStatement(statementRequest);
            if (statement is null)
            {
                return Problem("Unable to create Statement");
            }
            return Created("", statement);
        }
    }
}
