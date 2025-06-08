namespace CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Adapters;

internal readonly record struct WebApiVM(int Id, string? Name, bool IsComplete);