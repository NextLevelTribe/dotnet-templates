namespace CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Adapters;

public readonly record struct RequestVM(int Id, string? Name, bool IsComplete);