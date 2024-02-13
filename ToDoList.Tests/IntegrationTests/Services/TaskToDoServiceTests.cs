using AutoMapper;
using Moq;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Entities;
using ToDoList.Domain.IRepositories;
using ToDoList.Infrastructure.Services;

namespace ToDoList.Tests.IntegrationTests.Services
{
    public class TaskToDoServiceTests
    {
        private readonly TaskToDoService _taskToDoService;
        private readonly Mock<ITaskToDoRepository> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;

        public TaskToDoServiceTests()
        {
            _mockRepository = new Mock<ITaskToDoRepository>();
            _mockMapper = new Mock<IMapper>();
            _taskToDoService = new TaskToDoService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsMappedResults()
        {
            // Arrange
            var fakeEntities = new List<TaskToDo> { /* Simulates entities */ };
            _mockRepository.Setup(repository => repository.GetAll())
                .ReturnsAsync(fakeEntities);

            var fakeDTOs = new List<TaskToDoDTO> { /* Simulates mapped DTOs */ };
            _mockMapper.Setup(mapper => mapper.Map<List<TaskToDoDTO>>(fakeEntities))
                .Returns(fakeDTOs);

            // Act
            var result = await _taskToDoService.GetAll();

            // Assert
            Assert.Equal(fakeDTOs, result);
        }

        [Fact]
        public async Task GetById_ReturnsMappedResult()
        {
            // Arrange
            long taskId = 1;
            var fakeEntity = new TaskToDo { Id = taskId, /* Other properties */ };
            _mockRepository.Setup(repository => repository.Find(taskId))
                .ReturnsAsync(fakeEntity);

            var fakeDTO = new TaskToDoDTO { Id = taskId, /* Other mapped properties */ };
            _mockMapper.Setup(mapper => mapper.Map<TaskToDoDTO>(fakeEntity))
                .Returns(fakeDTO);

            // Act
            var result = await _taskToDoService.GetById(taskId);

            // Assert
            Assert.Equal(fakeDTO, result);
        }

        [Fact]
        public async Task Create_ReturnsMappedResult()
        {
            // Arrange
            var fakeDTO = new TaskToDoDTO { /* DTO properties */ };
            var fakeEntity = new TaskToDo { /* Properties mapped to the entity */ };
            _mockMapper.Setup(mapper => mapper.Map<TaskToDo>(fakeDTO))
                .Returns(fakeEntity);

            _mockRepository.Setup(repository => repository.Create(fakeEntity))
                .ReturnsAsync(fakeEntity);

            var expectedMappedResult = new TaskToDoDTO { /* Properties mapped to DTO */ };
            _mockMapper.Setup(mapper => mapper.Map<TaskToDoDTO?>(fakeEntity))
                .Returns(expectedMappedResult);

            // Act
            var result = await _taskToDoService.Create(fakeDTO);

            // Assert
            Assert.Equal(expectedMappedResult, result);
        }

        [Fact]
        public async Task Update_CallsRepositoryUpdate()
        {
            // Arrange
            var fakeDTO = new TaskToDoDTO { /* DTO properties */ };
            var fakeEntity = new TaskToDo {/* Properties mapped to the entity */ };
            _mockMapper.Setup(mapper => mapper.Map<TaskToDo>(fakeDTO))
                .Returns(fakeEntity);

            // Act
            await _taskToDoService.Update(fakeDTO);

            // Assert
            _mockRepository.Verify(repository => repository.Update(fakeEntity), Times.Once);
        }

        [Fact]
        public async Task Delete_CallsRepositoryDelete()
        {
            // Arrange
            long taskId = 1;

            // Act
            await _taskToDoService.Delete(taskId);

            // Assert
            _mockRepository.Verify(repository => repository.Delete(taskId), Times.Once);
        }
    }


}
