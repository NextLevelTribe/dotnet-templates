using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.ApiService.Features.ToDo.DeleteToDoItem.Application;

internal sealed class UseCase(IRepository repository)
{
    private readonly IRepository _repository = repository ?? throw new ArgumentNullException(nameof(repository));

    internal async Task<bool> Handle(int id, CancellationToken cancellationToken = default)
    {
        bool success = await _repository.DeleteToDoItem(id, cancellationToken);
        return success;
    }
}
