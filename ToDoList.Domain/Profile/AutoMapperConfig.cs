using ToDoList.Domain.DTOs;

namespace ToDoList.Domain.Profile
{
    using AutoMapper;
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Entities.TaskToDo, TaskToDoDTO>()
                  .ForMember(destination => destination.UserName, opt => opt.MapFrom(source => source.User.UserName));
            CreateMap<TaskToDoDTO, Entities.TaskToDo>();
        }
    }
}
