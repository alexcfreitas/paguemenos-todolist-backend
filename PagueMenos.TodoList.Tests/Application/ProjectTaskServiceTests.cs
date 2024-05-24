using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using PagueMenos.TodoList.Application.Services;
using PagueMenos.TodoList.Domain.Entities;
using PagueMenos.TodoList.Domain.Repositories;
using Xunit;

namespace PagueMenos.TodoList.Tests.Application.Services
{
    public class ProjectTaskServiceTests
    {
        private readonly Mock<IProjectTaskRepository> _mockRepo;
        private readonly ProjectTaskService _service;

        public ProjectTaskServiceTests()
        {
            _mockRepo = new Mock<IProjectTaskRepository>();
            _service = new ProjectTaskService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllProjectTasksAsync_ReturnsAllProjectTasks()
        {
            // Arrange
            var projectTasks = new List<ProjectTask> { new ProjectTask("Task 1", "Description 1"), new ProjectTask("Task 2", "Description 2") };
            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(projectTasks);

            // Act
            var result = await _service.GetAllProjectTasksAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetProjectTaskByIdAsync_ReturnsProjectTask()
        {
            // Arrange
            var projectTask = new ProjectTask("Task", "Description");
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(projectTask);

            // Act
            var result = await _service.GetProjectTaskByIdAsync(1);

            // Assert
            Assert.Equal(projectTask, result);
        }

        [Fact]
        public async Task AddProjectTaskAsync_AddsProjectTask()
        {
            // Arrange
            var title = "New Task";
            var description = "New Description";

            // Act
            await _service.AddProjectTaskAsync(title, description);

            // Assert
            _mockRepo.Verify(repo => repo.AddAsync(It.IsAny<ProjectTask>()), Times.Once);
        }

        [Fact]
        public async Task UpdateProjectTaskStatusAsync_UpdatesProjectTaskStatus()
        {
            // Arrange
            var projectTask = new ProjectTask("Task", "Description");
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(projectTask);

            // Act
            await _service.UpdateProjectTaskStatusAsync(1, true);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateAsync(It.Is<ProjectTask>(t => t.IsCompleted)), Times.Once);
        }

        [Fact]
        public async Task DeleteProjectTaskAsync_DeletesProjectTask()
        {
            // Arrange
            var projectTask = new ProjectTask("Task", "Description");
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(projectTask);

            // Act
            await _service.DeleteProjectTaskAsync(1);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAsync(It.IsAny<int>()), Times.Once);
        }
    }
}
