using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.IServices;
using ToDoList.Domain.Pagination.Filters;

namespace ToDoList.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("TaskToDoCors")]
    //[Authorize]
    public class TaskToDoController : ControllerBase
    {
        protected readonly ITaskToDoService _taskToDoService;

        public TaskToDoController(ITaskToDoService taskToDoService)
        {
            this._taskToDoService = taskToDoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _taskToDoService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            try
            {
                var result = await _taskToDoService.GetById(id);
                if (result != null) return Ok(result);
                return NotFound("The Task doesn't exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskToDoDTO taskToDo)
        {
            try
            {
                taskToDo.CreatedAt = DateTime.Now;
                var result = await _taskToDoService.Create(taskToDo);
                return Ok("Task created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(TaskToDoDTO taskToDo)
        {
            try
            {
                var date = DateTime.Now;
                taskToDo.CreatedAt = date;
                taskToDo.UpdatedAt = date;
                await _taskToDoService.Update(taskToDo);
                return Ok("Task updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var result = await _taskToDoService.GetById(id);
                if (result == null)
                    return NotFound("The Task doesn't exist");

                await _taskToDoService.Delete(id);
                return Ok("Task deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetPage")]
        public async Task<IActionResult> GePage([FromQuery] TaskFilter filter)
        {
            try
            {
                filter = filter ?? new TaskFilter();
                var result = await _taskToDoService.GetPage(filter);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
