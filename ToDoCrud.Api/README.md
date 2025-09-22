ToDoCrud.Api

REST Web API for Todo items built with ASP.NET Core 8 and EF Core on SQL Server LocalDB.
On startup the app applies migrations and seeds a few sample rows so GET /api/todos returns data immediately.

<h></h>

🚀 Features

CRUD endpoints for Todo items

EF Core with SQL Server LocalDB

Auto-migrate on startup + seed sample data

Swagger UI for interactive testing

<h></h>

🛠 Tech Stack

.NET 8 (ASP.NET Core Web API)

Entity Framework Core (SqlServer, Design, Tools)

Swagger (Swashbuckle)

<h></h>

📦 Endpoints

GET /api/todos
GET /api/todos/{id}
POST /api/todos { "title": "Buy milk" }
PUT /api/todos/{id} { "title": "Buy milk", "isDone": true }
DELETE /api/todos/{id}

<h></h>

💻 Run Locally

Option A (Visual Studio 2022): open the solution and press F5.
Option B (CLI): dotnet run --project ToDoCrud.Api
Swagger: https://localhost<port>/swagger

<h></h>

⚙️ Configuration

Connection string lives in appsettings.json (key: DefaultConnection).
Server: (localdb)\MSSQLLocalDB
Database: TodoCrudDb

To inspect the DB in SSMS: connect to (localdb)\MSSQLLocalDB → Databases → TodoCrudDb.

<h></h>

🧩 EF Core Migrations

Add-Migration <Name> → create a schema change
Update-Database → apply migrations to the database
Remove-Migration → undo the last migration (if not applied)

<h></h>

📂 Repo Structure

/ToDoCrud.Api – Web API project
/ToDoCrud.Api/Controllers – TodosController
/ToDoCrud.Api/Models – TodoItem entity
/ToDoCrud.Api/Data – TodoDbContext, DbSeeder
/ToDoCrud.Api/Migrations – EF Core migrations
README.md – this file
ToDoCrud.Api.sln – solution file

<h></h>

📜 License

MIT License

Maintained by ES
GitHub: https://github.com/EmsCode82
Repo: https://github.com/EmsCode82/ToDoCrud.Api