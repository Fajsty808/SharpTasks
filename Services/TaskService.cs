namespace SharpTasks.Services;

using SharpTasks.Models;

public class TaskService
{
    private readonly List<TaskItem> _tasks = new();

    // Next, we’ll implement:
    // - GetAll()
    public IEnumerable<TaskItem> GetAll()
    {
        return _tasks;
    }   
    // - GetById(Guid id)
    public TaskItem? GetById(Guid id)
    {
        return _tasks.FirstOrDefault(task => task.Id == id);
    }
    // - Add(TaskItem task)
    public void AddTask(TaskItem task)
    {
        _tasks.Add(task);
    }
    // - Update(TaskItem task)
    public bool UpdateTask(TaskItem task)
    {
        var index = _tasks.FindIndex(t => t.Id == task.Id);
        if (index == -1) return false;

        _tasks[index] = task;
        return true;
    }
    // - Delete(Guid id)
    public bool DeleteTask(Guid id)
    {
        var index = _tasks.FindIndex(t => t.Id == id);
        if (index == -1) return false;

        _tasks.RemoveAt(index);
        return true;
    }
}
