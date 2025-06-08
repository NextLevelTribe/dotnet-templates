using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;

internal class ToDoDb : DbContext
{
    public ToDoDb(DbContextOptions<ToDoDb> options) : base(options)
    { }

    public DbSet<ToDoItem> ToDos => Set<ToDoItem>();
}
