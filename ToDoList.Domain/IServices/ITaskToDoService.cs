using ToDoList.Domain.DTOs;
using ToDoList.Domain.IServices.Shared;
using ToDoList.Domain.Pagination;
using ToDoList.Domain.Pagination.Filters;

namespace ToDoList.Domain.IServices
{
    public interface ITaskToDoService : ICrudService<TaskToDoDTO>
    {
        Task<PaginationDTO<TaskToDoDTO>> GetPage(TaskFilter conditions);
    }
}
