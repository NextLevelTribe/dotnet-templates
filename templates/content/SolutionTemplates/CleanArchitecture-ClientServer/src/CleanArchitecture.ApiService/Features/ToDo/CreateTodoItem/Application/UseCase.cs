using System;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.CreateTodoItem.Application;

internal sealed class UseCase(IRepository repository)
{
    private readonly IRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    internal async Task<ToDoItem> Handle(ToDoItem toDoItem)
    {
        ToDoItem savedToDoItem = await _repository.AddNewToDoItem(toDoItem);
        return savedToDoItem;
    }
}
