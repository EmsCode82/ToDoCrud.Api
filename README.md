To-Do CRUD API

ASP.NET Core 8 Web API with EF Core + SQL Server LocalDB.
On startup the app applies migrations and seeds a few rows so GET /api/todos returns data immediately.

Status: In Progress · Live: (TBD)

🚀 Features

Async EF Core CRUD with DbContext

Auto-migrate on startup + seed sample data

DTOs for clean requests/responses

🛠 Tech Stack

ASP.NET Core

EF Core

SQL

Swagger

📦 Endpoints

GET /api/todos

GET /api/todos/{id}

POST /api/todos { "title": "Buy milk" }

PUT /api/todos/{id} { "title": "Buy milk", "isDone": true }

DELETE /api/todos/{id}

💻 Run Locally

Visual Studio 2022: open solution → F5
CLI: dotnet run --project ToDoCrud.Api
Swagger: https://localhost:<port>/swagger

⚙️ Configuration

Connection string in appsettings.json (key: DefaultConnection)
Server: (localdb)\MSSQLLocalDB · Database: TodoCrudDb

View in SSMS: connect to (localdb)\MSSQLLocalDB → Databases → TodoCrudDb

🧩 EF Core Migrations

Add-Migration <Name> – create schema change
Update-Database – apply migrations
Remove-Migration – undo last (if not applied)

📂 Repo Structure

/ToDoCrud.Api – Web API project

/ToDoCrud.Api/Controllers – TodosController

/ToDoCrud.Api/Models – TodoItem entity

/ToDoCrud.Api/Data – TodoDbContext, DbSeeder

/ToDoCrud.Api/Migrations – EF Core migrations

README.md – this file

ToDoCrud.Api.sln – solution

🔗 Links

GitHub Code: https://github.com/EmsCode82/ToDoCrud.Api
Case Study: https://emscode82.github.io/todo-crud.html

📜 License

MIT

Maintained by ES
GitHub: https://github.com/EmsCode82
Repo: https://github.com/EmsCode82/ToDoCrud.Api
