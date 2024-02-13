
#nullable disable

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Address { get; set; }
        public string UserRole { get; set; }
        public virtual ICollection<TaskToDo> TaskToDos { get; set; }
    }
}
