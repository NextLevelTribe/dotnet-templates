using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Application;
using CleanArchitecture.Domain.ToDo.Entities;

namespace CleanArchitecture.ApiService.Features.ToDo.UpdateToDoItem.Infrastructure;

internal sealed class Repository(ToDoDbContext toDoDbContext) : IRepository
{
    private readonly ToDoDbContext _toDoDbContext = toDoDbContext ?? throw new ArgumentNullException(nameof(toDoDbContext));

    public async Task<bool> UpdateToDoItem(int id, ToDoItem newToDoItem, CancellationToken cancellationToken = default)
    {
        ToDoItem? toDoItem = await _toDoDbContext.ToDos.FindAsync([id], cancellationToken);
        if (toDoItem is null)
        {
            return false;
        }

        toDoItem.Name = newToDoItem.Name;
        toDoItem.IsComplete = newToDoItem.IsComplete;

        _ = await _toDoDbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
