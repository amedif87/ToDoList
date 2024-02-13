#nullable disable

using System.Text.Json.Serialization;

namespace ToDoList.Domain.DTOs
{
    public class TaskToDoDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDated { get; set; }
        public bool IsCompleted { get; set; }
        public string UserName { get; set; }
        [JsonInclude]
        public DateTime CreatedAt { get; set; }
        [JsonInclude]
        public DateTime UpdatedAt { get; set; }
    }
}