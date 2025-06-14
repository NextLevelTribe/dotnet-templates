﻿namespace CleanArchitecture.Domain.ToDo.Entities;

public sealed class ToDoItem
{
    public int Id { get; private set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
}
