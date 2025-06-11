namespace CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Adapters;

public readonly record struct ResponseVM(int Id, string? Name, bool IsComplete);