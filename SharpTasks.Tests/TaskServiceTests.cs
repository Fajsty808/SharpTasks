using SharpTasks.Models;
using SharpTasks.Services;
using Xunit;

namespace SharpTasks.Tests
{
    public class TaskServiceTests
    {
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _taskService = new TaskService(); // Initialize the TaskService
        }

        [Fact]
        public void GetAll_ReturnsEmptyList_WhenNoTasksAreAdded()
        {
            // Act
            var tasks = _taskService.GetAll().ToList();

            // Assert
            Assert.Empty(tasks);  // Verifies that the list is empty initially
        }

        [Fact]
        public void AddTask_AddsTaskSuccessfully()
        {
            // Arrange
            var task = new TaskItem { Title = "Test Task" };

            // Act
            _taskService.AddTask(task);
            var tasks = _taskService.GetAll().ToList();

            // Assert
            Assert.Equal("Test Task", tasks[0].Title); // Verifies the title of the added task
        }
    }
}
