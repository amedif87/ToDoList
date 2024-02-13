#nullable disable

namespace ToDoList.Domain.Pagination.Filters
{
    public class TaskFilter : PageInfo
    {
        public string FilterByTitle { get; set; }
        public string FilterByDescription { get; set; }
        public bool? FilterByIsCompleted { get; set; }

    }
}
