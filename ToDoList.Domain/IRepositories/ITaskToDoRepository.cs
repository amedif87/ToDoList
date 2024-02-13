using ToDoList.Domain.Entities;
using ToDoList.Domain.IRepositories.Shared;

namespace ToDoList.Domain.IRepositories
{
    public interface ITaskToDoRepository : ICrudRepository<TaskToDo>
    {

    }
}
