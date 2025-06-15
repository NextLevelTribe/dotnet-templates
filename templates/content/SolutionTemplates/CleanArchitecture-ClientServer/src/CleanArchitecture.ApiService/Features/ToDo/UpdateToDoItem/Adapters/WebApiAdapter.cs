using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Application;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Adapters;

internal sealed class WebApiAdapter(UseCase useCase)
{
    private readonly UseCase _useCase = useCase;

    internal async Task<bool> Handle(RequestVM requestVM, CancellationToken cancellationToken = default)
    {
        ToDoItem toDoItem = new() { Name = requestVM.Name, IsComplete = requestVM.IsComplete };

        bool success = await _useCase.Handle(requestVM.Id, toDoItem, cancellationToken);
        return success;
    }
}
