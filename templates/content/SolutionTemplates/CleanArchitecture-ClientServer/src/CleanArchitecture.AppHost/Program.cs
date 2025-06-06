using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

namespace CleanArchitecture.AppHost;

public class Program
{
    public static void Main(string[] args)
    {
        IDistributedApplicationBuilder builder = DistributedApplication.CreateBuilder(args);

        #if UseRedisCache
        var cache = builder.AddRedis("cache");

        #endif
        IResourceBuilder<ProjectResource> apiService = builder.AddProject<Projects.CleanArchitecture_ApiService>("apiservice");

        builder.AddProject<Projects.CleanArchitecture_Web>("webfrontend")
            .WithExternalHttpEndpoints()
        #if UseRedisCache
            .WithReference(cache)
            .WaitFor(cache)
        #endif
            .WithReference(apiService)
            .WaitFor(apiService);

        builder.Build().Run();
    }
}