using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Application;

internal sealed class UseCase(IRepository repository)
{
    private readonly IRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    internal async Task<bool> Handle(int id, ToDoItem toDoItem, CancellationToken cancellationToken = default)
    {
        bool success = await _repository.UpdateToDoItem(id, toDoItem, cancellationToken);
        return success;
    }
}
