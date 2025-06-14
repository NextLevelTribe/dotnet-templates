namespace CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Adapters;

public readonly record struct ResponseVM(int Id, string? Name, bool IsComplete);