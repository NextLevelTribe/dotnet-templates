internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        #if UseRedisCache
        var cache = builder.AddRedis("cache");

        #endif
        var apiService = builder.AddProject<Projects.CleanArchitecture_ApiService>("apiservice");

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