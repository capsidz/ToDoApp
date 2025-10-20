using System.ComponentModel.DataAnnotations;

namespace ToDoApp;

public class TodoItem
{
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    public string Title { get; set; }

    public bool IsDone { get; set; }
}