namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;

internal readonly record struct WebApiVM(int Id, string? Name, bool IsComplete);