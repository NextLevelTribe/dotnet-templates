using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.ApiService.Features.ToDo.DeleteToDoItem.Application;

internal interface IRepository
{
    public Task<bool> DeleteToDoItem(int id, CancellationToken cancellationToken = default);
}