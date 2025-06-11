namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;

public readonly record struct RequestVM(string? Name, bool IsComplete);