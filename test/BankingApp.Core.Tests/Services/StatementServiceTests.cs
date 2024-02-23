using BankingApp.Core.Services;
using BankingApp.Data;
using BankingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using BankingApp.Core.Models;
using System.Runtime.CompilerServices;

namespace BankingApp.Core.Tests.Services
{
    public class StatementServiceTests
    {
        [Fact]
        public async Task GetStatements_Returns_Data()
        {
            // Arrange
            var expectedStatement = new Statement
            {
                CustomerId = 1,
                Accounts = "1234567890",
                AddedAt = DateTime.UtcNow,
                DeliveryMode = "email",
                EndDate = DateTime.UtcNow,
                Purpose = "Embassy",
                LastUpdatedBy = "",
                StartDate = DateTime.UtcNow.AddDays(-2),
                Status = "InProgress",
                UpdatedAt = DateTime.UtcNow,
            };

            StatementDbContext dbContext = GetStatementDbContext();

            dbContext.Statements.Add(expectedStatement);
            dbContext.SaveChanges();

            var statementService = new StatementService(dbContext);

            // Act
            var actual = await statementService.GetStatements();

            // Assert
            actual.Should().BeEquivalentTo(new[] { expectedStatement });
        }

        [Fact]
        public async Task RequestStatement_Is_Successful()
        {
            // Arrange
            var dbContext = GetStatementDbContext();
            var statementService = new StatementService(dbContext);

            // Act
            StatementRequest statementRequest = new StatementRequest
            {
                CustomerId = 1, 
                Accounts = "1234567890",
                DeliveryMode = "email",
                StartDate = DateTime.UtcNow.AddDays(-2),
                EndDate = DateTime.UtcNow,
                Purpose = "Embassy",
            };
            var actual = await statementService.RequestStatement(statementRequest);

            // Assert
            actual.Should().BeEquivalentTo(statementRequest,
                options => options
                .Including(sr => sr.CustomerId)
                .Including(sr => sr.Accounts)
                .Including(sr => sr.DeliveryMode)
                .Including(sr => sr.StartDate)
                .Including(sr => sr.EndDate)
                .Including(sr => sr.Purpose)
                );
        }

        private StatementDbContext GetStatementDbContext([CallerMemberName] string testName="")
        {
            var options = new DbContextOptionsBuilder<StatementDbContext>()
                .UseInMemoryDatabase(databaseName: testName)
                .Options;
            StatementDbContext dbContext = new StatementDbContext(options);
            return dbContext;
        }
    }
}
