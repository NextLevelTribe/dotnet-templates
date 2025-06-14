using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Application;

internal sealed class UseCase(IRepository repository)
{
    private readonly IRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    internal async Task<ToDoItem[]> Handle(CancellationToken cancellationToken = default)
    {
        ToDoItem[] allToDoItems = await _repository.GetAllToDoItems(cancellationToken);
        return allToDoItems;
    }
}
