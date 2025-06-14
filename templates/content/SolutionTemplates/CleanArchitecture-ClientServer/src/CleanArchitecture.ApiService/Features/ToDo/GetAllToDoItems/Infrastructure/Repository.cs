using System;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Application;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ApiService.Features.ToDo.GetAllToDoItems.Infrastructure;

internal sealed class Repository(ToDoDbContext toDoDbContext) : IRepository
{
    private readonly ToDoDbContext _toDoDbContext = toDoDbContext ?? throw new ArgumentNullException(nameof(toDoDbContext));

    public async Task<ToDoItem[]> GetAllToDoItems(CancellationToken cancellationToken = default)
    {
        ToDoItem[] allToDoItems = await _toDoDbContext.ToDos.ToArrayAsync(cancellationToken);
        return allToDoItems;
    }
}
