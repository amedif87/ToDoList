using ToDoList.Domain.Entities;
using ToDoList.Domain.IRepositories;
using ToDoList.Infrastructure.Persistance.Database;
using ToDoList.Infrastructure.Persistance.Shared;

namespace ToDoList.Infrastructure.Persistance
{
    public class TaskToDoRepository : GenericRepository<TaskToDo>, ITaskToDoRepository
    {
        private readonly TaskToDoContext _dbContext;
        public TaskToDoRepository(TaskToDoContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
