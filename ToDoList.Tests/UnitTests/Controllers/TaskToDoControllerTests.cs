#nullable disable

using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoList.API.Controllers;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.IServices;

namespace ToDoList.Tests.UnitTests.Controllers
{
    public class TaskToDoControllerTests
    {
        private readonly TaskToDoController _controller;
        private readonly Mock<ITaskToDoService> _mockTaskToDoService;

        public TaskToDoControllerTests()
        {
            _mockTaskToDoService = new Mock<ITaskToDoService>();
            _controller = new TaskToDoController(_mockTaskToDoService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult()
        {
            // Arrange
            TaskToDoDTO taskToDoDTO = new TaskToDoDTO
            {
                Title = "Sample Title",
                Description = "Sample Description"
            };
            _mockTaskToDoService.Setup(service => service.GetAll())
                .ReturnsAsync(new List<TaskToDoDTO> { taskToDoDTO });

            // Act
            var result = await _controller.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<TaskToDoDTO>>(okResult.Value);
            Assert.NotEmpty(model);
        }

        [Fact]
        public async Task GetById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            long taskId = 1;
            _mockTaskToDoService.Setup(service => service.GetById(taskId))
                .ReturnsAsync(new TaskToDoDTO { Id = taskId, Title = "Test Task" });

            // Act
            var result = await _controller.GetById(taskId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<TaskToDoDTO>(okResult.Value);
            Assert.Equal(taskId, model.Id);
        }

        [Fact]
        public async Task GetById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            long invalidId = 999; // An ID that we know does not exist
            _mockTaskToDoService.Setup(service => service.GetById(invalidId))
                .ReturnsAsync((TaskToDoDTO)null);

            // Act
            var result = await _controller.GetById(invalidId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_ValidTask_ReturnsOkResult()
        {
            // Arrange
            var newTask = new TaskToDoDTO { Title = "New Task" };

            _mockTaskToDoService.Setup(service => service.Create(It.IsAny<TaskToDoDTO>()))
                .ReturnsAsync(newTask);

            // Act
            var result = await _controller.Create(newTask);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("Task created successfully", okResult.Value);
        }

    }
}
