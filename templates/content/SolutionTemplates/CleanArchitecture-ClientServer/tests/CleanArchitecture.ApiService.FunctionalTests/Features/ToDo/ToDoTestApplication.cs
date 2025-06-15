using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

internal class ToDoTestApplication : WebApplicationFactory<Program>
{
    private readonly HttpClient _client;

    internal string RequestUriBase => "/todoitems";

    public ToDoTestApplication(string inMemoryDatabaseName)
    {
        _ = WithWebHostBuilder(builder =>
        {
            _ = builder.ConfigureTestServices(services =>
            {
                RemoveDbServivesAndOptions(services);

                _ = services.AddDbContext<ToDoDbContext>(opt => opt.UseInMemoryDatabase(inMemoryDatabaseName));
            });
        });

        _client = CreateClient();
    }

    private static void RemoveDbServivesAndOptions(IServiceCollection services)
    {
        _ = services.RemoveAll<ToDoDbContext>()
            .RemoveAll<DbContextOptions>();

        ServiceDescriptor[] dbContextOptions = services.Where(s => s.ServiceType.BaseType == typeof(DbContextOptions)).ToArray();
        foreach (ServiceDescriptor option in dbContextOptions)
        {
            _ = services.Remove(option);
        }
    }

    internal async Task<ResponseVM> CreateTodoItem(string? name = "", bool isComplete = false)
    {
        RequestVM request = new(name, isComplete);
        using HttpResponseMessage postResponse = await _client.PostAsJsonAsync(RequestUriBase, request);
        ResponseVM addedToDoItem = await postResponse.Content.ReadFromJsonAsync<ResponseVM>();
        return addedToDoItem;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _client.Dispose();
        }

        base.Dispose(disposing);
    }
}
