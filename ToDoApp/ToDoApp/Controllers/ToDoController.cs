using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.Controllers;

[ApiController]
[Route("ToDoApp")]

public class TodoController : ControllerBase
{
    private static readonly List<TodoItem> _todos = new()
    {
        new TodoItem { Id = 1, Title = "Купить молоко", IsDone = false },
        new TodoItem { Id = 2, Title = "Написать проект", IsDone = true }
    };

    [HttpGet]
    public ActionResult<IEnumerable<TodoItem>> GetAll()
        => Ok(_todos);

    [HttpGet("{id}")]
    public ActionResult<TodoItem> GetById(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null)
            return NotFound();
        return todo;
    }

    [HttpPost]
    public ActionResult<TodoItem> Create(TodoItem item)
    {
        item.Id = _todos.Max(t => t.Id) + 1;
        _todos.Add(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TodoItem updatedItem)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null) 
            return NotFound();

        todo.Title = updatedItem.Title;
        todo.IsDone = updatedItem.IsDone;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo == null) 
            return NotFound();

        _todos.Remove(todo);
        return NoContent();
    }
}