namespace CleanArchitecture.ApiService.Features.ToDo.CreateTodoItem.Adapters;

internal readonly record struct WebApiVM(int Id, string? Name, bool IsComplete);