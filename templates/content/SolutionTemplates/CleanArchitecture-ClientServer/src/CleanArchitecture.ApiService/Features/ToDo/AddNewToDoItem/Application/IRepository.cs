using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.AddNewToDoItem.Application;

internal interface IRepository
{
    internal void AddNewToDoItem(ToDoItem toDoItem);
}