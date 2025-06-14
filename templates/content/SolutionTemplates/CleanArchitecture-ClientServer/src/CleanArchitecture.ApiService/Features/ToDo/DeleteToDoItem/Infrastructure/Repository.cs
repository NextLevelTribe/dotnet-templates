using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.DeleteToDoItem.Application;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.DeleteToDoItem.Infrastructure;

internal sealed class Repository(ToDoDbContext toDoDbContext) : IRepository
{
    private readonly ToDoDbContext _toDoDbContext = toDoDbContext ?? throw new ArgumentNullException(nameof(toDoDbContext));

    public async Task<bool> DeleteToDoItem(int id, CancellationToken cancellationToken = default)
    {
        ToDoItem? toDoItem = await _toDoDbContext.ToDos.FindAsync([id], cancellationToken);
        if (toDoItem is null)
        {
            return false;
        }

        _ = _toDoDbContext.ToDos.Remove(toDoItem);
        int changedEntities = await _toDoDbContext.SaveChangesAsync(cancellationToken);

        // If one entity was changed, the deletion was successful.
        return changedEntities == 1;
    }
}
