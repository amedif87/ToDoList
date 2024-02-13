#nullable disable

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoList.Domain.Abstract;

namespace ToDoList.Domain.Entities
{
    public class TaskToDo : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public DateTime DueDated { get; set; }

        [DefaultValue(false)]
        public bool IsCompleted { get; set; }

        public string? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual User User { get; set; }

    }
}