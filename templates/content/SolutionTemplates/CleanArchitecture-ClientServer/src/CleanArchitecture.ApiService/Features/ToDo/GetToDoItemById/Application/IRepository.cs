using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.GetToDoItemById.Application;

internal interface IRepository
{
    public ValueTask<ToDoItem?> GetToDoItemById(int id, CancellationToken cancellationToken = default);
}