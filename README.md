# core-banking-service

## Migrations
### From Developer Powershell:

	dotnet ef migrations add <Migration-Name> --startup-project src/BankingApp.Api --project src/BankingApp.Data --context CustomerDbContext

	dotnet ef database update --startup-project src/BankingApp.Api --project src/BankingApp.Data --context StatementDbContext

## Database
### Uses MSSQL Server Database
	On Docker:
	docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=P@ssword" -p 1433:1433 --name corebankdb -d mcr.microsoft.com/mssql/server:2017-latest

