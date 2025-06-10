using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Application;

internal sealed class UseCase(IRepository repository)
{
    private readonly IRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    internal async Task<ToDoItem> Handle(ToDoItem toDoItem, CancellationToken cancellationToken = default)
    {
        ToDoItem savedToDoItem = await _repository.AddNewToDoItem(toDoItem, cancellationToken);
        return savedToDoItem;
    }
}
