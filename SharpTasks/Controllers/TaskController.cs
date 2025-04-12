using Microsoft.AspNetCore.Mvc;
using SharpTasks.Services;
using SharpTasks.Models;

namespace SharpTasks.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetAllTasks()
    {
        var tasks = _taskService.GetAll();
        return Ok(tasks);
    }
    //adding new task
    [HttpPost]
    public ActionResult<TaskItem> AddTask([FromBody] TaskItem task)
    {
        _taskService.AddTask(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }
    //getting task by id
    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetTaskById(Guid id)
    {
        var task = _taskService.GetById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }
    //updating task by id
    [HttpPut("{id}")]
    public ActionResult UpdateTask(Guid id, [FromBody] TaskItem task)
    {
        if (id != task.Id)
        {
            return BadRequest("Task ID mismatch.");
        }

        var updated = _taskService.UpdateTask(task);
        if (!updated)
        {
            return NotFound();
        }
        return NoContent();
    }
    //deleting task by id
    [HttpDelete("{id}")]
    public ActionResult DeleteTask(Guid id)
    {
        var deleted = _taskService.DeleteTask(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    //marking task as completed
    [HttpPatch("{id}/complete")]
    public ActionResult CompleteTask(Guid id)
    {
        var task = _taskService.GetById(id);
        if (task == null)
        {
            return NotFound();
        }

        task.IsCompleted = true;
        _taskService.UpdateTask(task);
        return NoContent();
    }
}
