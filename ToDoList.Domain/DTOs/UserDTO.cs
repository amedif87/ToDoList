#nullable disable

namespace ToDoList.Domain.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public string Address { get; set; }
        public string UserRole { get; set; }
    }
}
