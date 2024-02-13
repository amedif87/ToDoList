using AutoMapper;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Entities;
using ToDoList.Domain.IRepositories;
using ToDoList.Domain.IServices;
using ToDoList.Domain.Pagination;
using ToDoList.Domain.Pagination.Filters;
using ToDoList.Infrastructure.Persistance.Shared;

namespace ToDoList.Infrastructure.Services
{
    public class TaskToDoService : ITaskToDoService
    {
        private readonly IMapper _mapper;
        private readonly ITaskToDoRepository _repository;
        public TaskToDoService(ITaskToDoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskToDoDTO>> GetAll()
        {
            try
            {
                var result = await _repository.GetAll();
                return _mapper.Map<List<TaskToDoDTO>>(result.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TaskToDoDTO> GetById(long id)
        {
            try
            {
                var result = _mapper.Map<TaskToDoDTO>(await _repository.Find(id));
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TaskToDoDTO?> Create(TaskToDoDTO item)
        {
            try
            {
                var result = await _repository.Create(_mapper.Map<TaskToDo>(item));
                return _mapper.Map<TaskToDoDTO?>(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Update(TaskToDoDTO item)
        {
            try
            {
                await _repository.Update(_mapper.Map<TaskToDo>(item));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Delete(long id)
        {
            try
            {
                await _repository.Delete(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<PaginationDTO<TaskToDoDTO>> GetPage(TaskFilter conditions)
        {
            try
            {
                var where = ConditionBuilder.True<TaskToDo>();

                if (!string.IsNullOrEmpty(conditions.FilterByTitle))
                {
                    where = where.And(s => s.Title.Contains(conditions.FilterByTitle));
                }

                if (!string.IsNullOrEmpty(conditions.FilterByDescription))
                {
                    where = where.And(s => s.Description.Contains(conditions.FilterByDescription));
                }

                if (conditions.FilterByIsCompleted != null)
                {
                    where = where.And(s => s.IsCompleted == conditions.FilterByIsCompleted);
                }
                Expression<Func<TaskToDo, string>> order;
                SortOrder sort;
                switch (conditions.SortBy)
                {
                    case "title":
                        order = item => item.Title;
                        break;
                    case "description":
                        order = item => item.Description;
                        break;
                    case "iscompleted":
                        order = item => item.IsCompleted.ToString();
                        break;
                    default:
                        order = item => item.Title;
                        break;
                }

                switch (conditions.OrderBy)
                {
                    case "ASC":
                        sort = SortOrder.Ascending;
                        break;
                    default:
                        sort = SortOrder.Descending;
                        break;
                }

                var result = await _repository.GetPage(conditions, where, order, sort);

                return new PaginationDTO<TaskToDoDTO>
                {
                    Items = _mapper.Map<IEnumerable<TaskToDoDTO>>(result.Item1),
                    TotalCount = result.Item2
                };
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
