using CleanArchitecture.Domain.ToDo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;

internal class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
    { }

    public DbSet<ToDoItem> ToDos => Set<ToDoItem>();
}
