
# ToDoList API

Small test project


## Environment Variables

To run the mainToDOList.API project, you must search within this project for the Properties/launchSettings.json file, you must modify the following environment variables with the values corresponding to your database connection. The database name can be whatever you want. When you run the migration, the database will be created automatically.

`DATABASE_CONNECTION`


## Previous Requirements

Before you begin, make sure you have completed the following items

- You must have [.NET Core SDK 7](https://dotnet.microsoft.com/download) - Version 7.0.0
- You must have [PostgreSQL](https://www.postgresql.org/download/) - Version >= 14
- Restore NuGet Packages
- See the Environment Variables section
- Run the following command in the Package Management Console to run the migration ./migrate-database.ps1 "Host=***;Database=***;Username=***;Password=***"


## API Reference

Use the swagger incorporated in the project for better understanding

#### Get all Tasks

```https
  GET /api/TaskToDo
```

#### Create Task

```https
  POST /api/TaskToDo
```

#### Update Task

```https
  PUT /api/TaskToDo
```
#### Get Task By Id

```https
  GET /api/TaskToDo/{id}
```

#### Delete Task By Id

```https
  DELETE /api/TaskToDo/{id}
```

#### Get Tasks using Pagination

```https
  GET /api/TaskToDo/GetPage
```


## Running Tests

To run tests, run the following command

```bash
  dotnet test
```


## Available Scripts

### Create migration
To create a new migration run the following PowerShell script.
```powershell
./create-migration.ps1 "Migration name"
```
### Migrate DB
To migrate DB run the following PowerShell script.
```powershell
./migrate-database.ps1 "Host=***;Database=***;Username=***;Password=**"
```


## Authors

- [@amedif87](https://www.github.com/amedif87)


## Architecture
Architecture pattern: [Clean Architecture with DDD by Microsoft](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice)