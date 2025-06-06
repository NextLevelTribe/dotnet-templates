using CleanArchitecture.ApiService.Features;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.ApiService;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        _ = builder.Host.UseDefaultServiceProvider(services =>
        {
            services.ValidateScopes = true;
            services.ValidateOnBuild = true;
        });

        // Add service defaults & Aspire client integrations.
        _ = builder.AddServiceDefaults();

        // Add services to the container.
        _ = builder.Services.AddProblemDetails();

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        _ = builder.Services.AddOpenApi();

        _ = builder.Services.AddFeatures();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        _ = app.UseExceptionHandler();

        if (app.Environment.IsDevelopment())
        {
            _ = app.MapOpenApi();
        }

        _ = app.MapFeaturesEndpoints();

        _ = app.MapDefaultEndpoints();

        app.Run();
    }
}
