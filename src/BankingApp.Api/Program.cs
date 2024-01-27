using BankingApp.Core.Interfaces;
using BankingApp.Core.Services;
using BankingApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BankingApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StatementDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("StatementConnection")));
            builder.Services.AddDbContext<TransactionDbContext>(
               options => options.UseSqlServer(builder.Configuration.GetConnectionString("TransactionConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IStatementService, StatementService>();
            builder.Services.AddScoped<ITransactionService, TransactionService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}