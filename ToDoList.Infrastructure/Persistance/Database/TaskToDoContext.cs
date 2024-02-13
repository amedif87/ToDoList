
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Persistance.Database
{
    public class TaskToDoContext : IdentityDbContext<User>
    {
        public TaskToDoContext(DbContextOptions<TaskToDoContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        #region DbSets
        public virtual DbSet<TaskToDo> TaskToDos { get; set; }
        // public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskToDo>().ToTable("task");
            //modelBuilder.Entity<RefreshToken>().ToTable("refresh_token");


        }
    }
}
