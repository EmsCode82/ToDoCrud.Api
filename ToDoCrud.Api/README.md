ToDoCrud.Api

	ASP.NET Core 8 Web API for Todo items using EF Core + SQL Server LocalDB.
	On startup the app runs migrations and seeds a few sample rows so GET /api/todos returns data immediately.

Quick start

	Prereqs: .NET 8 SDK, Visual Studio 2022 (includes LocalDB).

	Run: dotnet run --project ToDoCrud.Api
	Swagger: https://localhost

Endpoints

	GET /api/todos

	GET /api/todos/{id}

	POST /api/todos { "title": "Buy milk" }

	PUT /api/todos/{id} { "title": "Buy milk", "isDone": true }

	DELETE /api/todos/{id}

Config

	Connection string is in appsettings.json (key: DefaultConnection).
	Server: (localdb)\MSSQLLocalDB
	Database: TodoCrudDb

Migrations (EF Core)

	Add-Migration <Name> → create a schema change

	Update-Database → apply migrations to the database

	Remove-Migration → undo the last migration (if not applied)