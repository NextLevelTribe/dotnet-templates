internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var cache = builder.AddRedis("cache");

        var apiService = builder.AddProject<Projects.CleanVerticalSliceArchitecture_ApiService>("apiservice");

        builder.AddProject<Projects.CleanVerticalSliceArchitecture_Web>("webfrontend")
            .WithExternalHttpEndpoints()
            .WithReference(cache)
            .WaitFor(cache)
            .WithReference(apiService)
            .WaitFor(apiService);

        builder.Build().Run();
    }
}