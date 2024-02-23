using BankingApp.Api.Controllers;
using BankingApp.Core.Interfaces;
using BankingApp.Core.Models;
using BankingApp.Data.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BankingApp.Api.Tests.Controllers
{
    public class StatementControllerTests
    {
        [Fact]
        public async Task GetStatement_Returns_Ok_WhenThereIsStatement()
        {
            // Arrange
            List<Statement> expectedStatementResult = new List<Statement>()
            {
                new Statement
                {
                    CustomerId = 1,
                    Accounts = "1234567890",
                    AddedAt = DateTime.UtcNow,
                    DeliveryMode = "email",
                    EndDate = DateTime.UtcNow,
                    Purpose = "Embassy",
                    Id = 1,
                }
            };

            Mock<IStatementService> mockStatementService = new Mock<IStatementService>();
            mockStatementService.Setup(mss => mss.GetStatements()).ReturnsAsync(expectedStatementResult);

            var statementController = new StatementController(mockStatementService.Object);

            // Act
            var actionResult = await statementController.Get();

            // Assert
            actionResult.Should().BeOfType<OkObjectResult>();
            var okResult = actionResult as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().NotBeNull();
            okResult.Value.Should().BeEquivalentTo(expectedStatementResult);

            mockStatementService.Verify(mss => mss.GetStatements(), Times.Once());
        }

        [Fact]
        public async Task GetStatement_Returns_NotFound_WhenThereIsNoStatement()
        {
            // Arrange
            Mock<IStatementService> mockStatementService = new Mock<IStatementService>();

            var statementController = new StatementController(mockStatementService.Object);

            // Act
            var actionResult = await statementController.Get();

            // Assert
            actionResult.Should().BeOfType<NotFoundResult>();

            mockStatementService.Verify(mss => mss.GetStatements(), Times.Once());
        }

        [Fact]
        public async Task PostStatement_Returns_Created_WhenSuccessful()
        {
            // Arrange
            StatementRequest statementRequest = new StatementRequest()
            {
                CustomerId = 1,
                Accounts = "1234567890",
                DeliveryMode = "email",
                EndDate = DateTime.UtcNow,
                Purpose = "Embassy",
            };

            Statement expectedStatement = new Statement
            {
                CustomerId = 1,
                Accounts = "1234567890",
                AddedAt = DateTime.UtcNow,
                DeliveryMode = "email",
                EndDate = DateTime.UtcNow,
                Purpose = "Embassy",
                Id = 1,
            };          

            Mock<IStatementService> mockStatementService = new Mock<IStatementService>();
            mockStatementService.Setup(mss => mss.RequestStatement(It.IsAny<StatementRequest>()))
                .ReturnsAsync(expectedStatement);

            var statementController = new StatementController(mockStatementService.Object);

            // Act
            var actionResult = await statementController.Post(statementRequest);

            // Assert
            actionResult.Should().BeOfType<CreatedResult>();
            var okResult = actionResult as CreatedResult;
            okResult.Should().NotBeNull();
            okResult.Value.Should().NotBeNull();
            okResult.Value.Should().BeEquivalentTo(expectedStatement);

            mockStatementService.Verify(mss => mss.RequestStatement(It.IsAny<StatementRequest>()), Times.Once());
        }

        [Fact]
        public async Task PostStatement_Returns_Problem_WhenFails()
        {
            // Arrange
            StatementRequest statementRequest = new StatementRequest()
            {
                CustomerId = 1,
                Accounts = "1234567890",
                DeliveryMode = "email",
                EndDate = DateTime.UtcNow,
                Purpose = "Embassy",
            };

            Mock<IStatementService> mockStatementService = new Mock<IStatementService>();

            var statementController = new StatementController(mockStatementService.Object);

            // Act
            var actionResult = await statementController.Post(statementRequest);

            // Assert
            actionResult.Should().BeOfType<ObjectResult>();
            var objectResult = actionResult as ObjectResult;
            ((ProblemDetails)objectResult.Value).Detail.Should().Be("Unable to create Statement");
            objectResult.StatusCode.Should().Be(500);

            mockStatementService.Verify(mss => mss.RequestStatement(It.IsAny<StatementRequest>()), Times.Once());
        }
    }
}
