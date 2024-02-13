Write-Host "Welcome to ToDoList Tool for Database Migrations" -ForegroundColor Green

$connectionString = $args[0]

if ([string]::IsNullOrEmpty($connectionString)) {
    Write-Error "Connection string is empty"
}
else {
    dotnet ef database update `
        --startup-project ./ToDoList.API/ToDoList.API.csproj `
        --project ./ToDoList.Migrations/ToDoList.Migrations.csproj `
        --connection $connectionString
}

