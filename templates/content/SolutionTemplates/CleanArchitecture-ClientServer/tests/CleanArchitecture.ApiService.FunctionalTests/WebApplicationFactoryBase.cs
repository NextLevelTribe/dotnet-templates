using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CleanArchitecture.ApiService.FunctionalTests;

public abstract class WebApplicationFactoryBase<TDbContext> : WebApplicationFactory<Program> where TDbContext : DbContext
{
    public WebApplicationFactoryBase(string inMemoryDatabaseName)
    {
        _ = WithWebHostBuilder(builder =>
        {
            _ = builder.ConfigureTestServices(services =>
            {
                RemoveDbServivesAndOptions(services);

                _ = services.AddDbContext<TDbContext>(opt => opt.UseInMemoryDatabase(inMemoryDatabaseName));
            });
        });
    }

    private static void RemoveDbServivesAndOptions(IServiceCollection services)
    {
        _ = services.RemoveAll<TDbContext>()
            .RemoveAll<DbContextOptions>();

        ServiceDescriptor[] dbContextOptions = services.Where(s => s.ServiceType.BaseType == typeof(DbContextOptions)).ToArray();
        foreach (ServiceDescriptor option in dbContextOptions)
        {
            _ = services.Remove(option);
        }
    }
}
