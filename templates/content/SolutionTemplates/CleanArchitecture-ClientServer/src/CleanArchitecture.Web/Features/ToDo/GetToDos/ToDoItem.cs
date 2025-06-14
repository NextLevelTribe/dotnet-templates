namespace CleanArchitecture.Web.Features.ToDo.GetToDos;

public sealed class ToDoItem()
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}