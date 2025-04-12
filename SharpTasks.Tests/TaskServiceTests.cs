using SharpTasks.Models;
using SharpTasks.Services;

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
            // When
            var tasks = _taskService.GetAll().ToList();
            Console.WriteLine(tasks.Count == 0 ? "No tasks found" : $"Found {tasks.Count} tasks");

            // Then
            Assert.Empty(tasks);  // Verifies that the list is empty initially
        }

        [Fact]
        public void GetById_ReturnsAddedTask()
        {
            TaskItem task = new TaskItem { Id = Guid.NewGuid(), Title = "Test Task" };
            _taskService.AddTask(task); // Add a task to the service

            // When
            var foundTask = _taskService.GetById(task.Id);

            // Then
            Console.WriteLine(foundTask == null ? "Task not found" : $"Task found: {foundTask.Title}");
            Assert.NotNull(foundTask);  // Verifies that no task is found for a non-existing ID
        }
        [Fact]
        public void AddTask_AddsTaskSuccessfully()
        {
            // Given
            var task = new TaskItem { Title = "Test Task" };

            // When
            _taskService.AddTask(task);
            var tasks = _taskService.GetAll().ToList();

            // Then
            Assert.Equal("Test Task", tasks[0].Title); // Verifies the title of the added task
        }

        [Fact]
        public void UpdateTask_SuccessfullyUpdatesTask()
        {
            // Given
            var task = new TaskItem { Id = Guid.NewGuid(), Title = "Test Task" };
            _taskService.AddTask(task); // Add a task to the service
            // When
            _taskService.UpdateTask(new TaskItem { Id = task.Id, Title = "Updated Task" }); // Update the task
            // Then
            var retrievedTask = _taskService.GetById(task.Id); // Retrieve the updated task
            Assert.NotNull(retrievedTask); // Ensure the task exists
            Assert.Equal("Updated Task", retrievedTask.Title); // Verifies the title of the updated task
        }

        [Fact]      
    public void DeleteTask_SuccessfullyDeletesTask()
            {
                // Given
                var task = new TaskItem { Id = Guid.NewGuid(), Title = "Test Task" };
                _taskService.AddTask(task); // Add a task to the service
    
                // When
                var result = _taskService.DeleteTask(task.Id); // Delete the task
    
                // Then
                Assert.True(result); // Verifies that the task was deleted successfully
                Assert.Null(_taskService.GetById(task.Id)); // Verifies that the task no longer exists
            }
    }
}
