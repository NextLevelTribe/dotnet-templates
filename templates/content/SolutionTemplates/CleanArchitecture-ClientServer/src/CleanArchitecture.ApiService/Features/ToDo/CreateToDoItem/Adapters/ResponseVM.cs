namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;

public readonly record struct ResponseVM(int Id, string? Name, bool IsComplete);