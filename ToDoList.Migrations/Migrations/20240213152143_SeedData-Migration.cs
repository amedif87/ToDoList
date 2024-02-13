using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.InsertData(
          schema: "public",
          table: "task",
          columns: new[] { "Title", "Description", "DueDated", "IsCompleted", "CreatedAt", "UpdatedAt" },
          values: new object[,]
          {
                { "Task 1", "Description for Task 1", DateTime.Now.AddDays(5), false, DateTime.Now, DateTime.Now },
                { "Task 2", "Description for Task 2", DateTime.Now.AddDays(7), true, DateTime.Now, DateTime.Now },
                { "Task 3", "Description for Task 3", DateTime.Now.AddDays(6), false, DateTime.Now, DateTime.Now },
                { "Task 4", "Description for Task 4", DateTime.Now.AddDays(8), true, DateTime.Now, DateTime.Now },
                { "Task 5", "Description for Task 5", DateTime.Now.AddDays(2), false, DateTime.Now, DateTime.Now },
                { "Task 6", "Description for Task 6", DateTime.Now.AddDays(9), true, DateTime.Now, DateTime.Now },
                { "Task 7", "Description for Task 7", DateTime.Now.AddDays(2), false, DateTime.Now, DateTime.Now },
                { "Task 8", "Description for Task 8", DateTime.Now.AddDays(5), true, DateTime.Now, DateTime.Now },
                { "Task 9", "Description for Task 9", DateTime.Now.AddDays(3), false, DateTime.Now, DateTime.Now },
                { "Task 10","Description for Task 10", DateTime.Now.AddDays(6), true, DateTime.Now, DateTime.Now }
             
          });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
