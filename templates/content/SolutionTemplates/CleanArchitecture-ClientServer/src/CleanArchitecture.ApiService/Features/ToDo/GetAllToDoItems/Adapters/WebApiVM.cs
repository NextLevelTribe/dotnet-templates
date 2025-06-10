namespace CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Adapters;

public readonly record struct WebApiVM(int Id, string? Name, bool IsComplete);