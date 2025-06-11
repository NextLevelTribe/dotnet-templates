using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Application;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Adapters;

internal sealed class WebApiAdapter(UseCase useCase)
{
    private readonly UseCase _useCase = useCase;

    internal async Task<(ResponseVM responseVM, bool success)> Handle(int id, CancellationToken cancellationToken = default)
    {
        ToDoItem? toDoItem = await _useCase.Handle(id, cancellationToken);
        if (toDoItem is null)
        {
            return (default, false);
        }

        ResponseVM responseVM = new(toDoItem.Id, toDoItem.Name, toDoItem.IsComplete);
        return (responseVM, true);
    }
}
