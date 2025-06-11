using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Application;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Adapters;

internal sealed class WebApiAdapter(UseCase useCase)
{
    private readonly UseCase _useCase = useCase;

    internal async Task<ResponseVM[]> Handle(CancellationToken cancellationToken = default)
    {
        ToDoItem[] allToDoItems = await _useCase.Handle(cancellationToken);
        ResponseVM[] viewModels = new ResponseVM[allToDoItems.Length];

        for (int i = 0; i < allToDoItems.Length; i++)
        {
            viewModels[i] = new(allToDoItems[i].Id, allToDoItems[i].Name, allToDoItems[i].IsComplete);
        }

        return viewModels;
    }
}
