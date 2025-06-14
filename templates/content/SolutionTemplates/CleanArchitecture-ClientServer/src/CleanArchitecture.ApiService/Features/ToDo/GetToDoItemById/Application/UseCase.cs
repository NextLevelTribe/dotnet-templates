using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Application;

internal sealed class UseCase(IRepository repository)
{
    private readonly IRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    internal async ValueTask<ToDoItem?> Handle(int id, CancellationToken cancellationToken = default)
    {
        ToDoItem? toDoItems = await _repository.GetToDoItemById(id, cancellationToken);
        return toDoItems;
    }
}
