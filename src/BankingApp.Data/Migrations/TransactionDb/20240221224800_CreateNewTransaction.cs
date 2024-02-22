using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankingApp.Data.Migrations.TransactionDb
{
    public partial class CreateNewTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Transactions",
                newName: "TransactionType");

            migrationBuilder.RenameColumn(
                name: "TransactionId",
                table: "Transactions",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "ValueDate");

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "ValueDate",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "TransactionType",
                table: "Transactions",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Transactions",
                newName: "TransactionId");
        }
    }
}
