Write-Host "Welcome to ToDoList Tool for Database Migrations" -ForegroundColor Green

$migrationName = $args[0]

if ([string]::IsNullOrEmpty($migrationName)) {
    Write-Error "Migration name is empty"
}
else {
    dotnet ef migrations add $migrationName `
        --startup-project ./ToDoList.API/ToDoList.API.csproj `
        --project ./ToDoList.Migrations/ToDoList.Migrations.csproj `

}

