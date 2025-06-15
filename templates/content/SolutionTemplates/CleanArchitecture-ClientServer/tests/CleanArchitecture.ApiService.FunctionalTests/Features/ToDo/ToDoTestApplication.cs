using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CleanArchitecture.ApiService.Features.ToDo.CreateToDoItem.Adapters;
using CleanArchitecture.ApiService.Features.ToDo.Shared.Infrastructure;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.ApiService.FunctionalTests.Features.ToDo;

internal class ToDoTestApplication : WebApplicationFactory<Program>
{
    private readonly string _environment;
    private readonly string _inMemoryDatabaseName;
    private readonly HttpClient _client;

    internal string RequestUriBase => "/todoitems";

    public ToDoTestApplication(string inMemoryDatabaseName, string environment = "Development")
    {
        _inMemoryDatabaseName = inMemoryDatabaseName;
        _environment = environment;

        _client = CreateClient();
    }

    internal async Task<ResponseVM> CreateTodoItem(string? name = "", bool isComplete = false)
    {
        RequestVM request = new(name, isComplete);
        using HttpResponseMessage postResponse = await _client.PostAsJsonAsync(RequestUriBase, request);
        ResponseVM addedToDoItem = await postResponse.Content.ReadFromJsonAsync<ResponseVM>();
        return addedToDoItem;
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        _ = builder.UseEnvironment(_environment);

        // Add mock/test services to the builder here
        _ = builder.ConfigureServices(services =>
        {
            _ = services.AddScoped(serviceProvider =>
            {
                // Replace database with in-memory database for tests
                return new DbContextOptionsBuilder<ToDoDbContext>()
                .UseInMemoryDatabase(_inMemoryDatabaseName)
                .UseApplicationServiceProvider(serviceProvider)
                .Options;
            });
        });

        return base.CreateHost(builder);
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
