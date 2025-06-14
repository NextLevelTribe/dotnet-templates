using CleanArchitecture.Web.Components;
using CleanArchitecture.Web.Features;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.Web;

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
        builder.AddServiceDefaults();
        #if (UseRedisCache)
        builder.AddRedisOutputCache("cache");
        #else
        builder.Services.AddOutputCache();
        #endif

        // Add services to the DI container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        _ = builder.Services.AddFeatures();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseAntiforgery();

        app.UseOutputCache();

        app.MapStaticAssets();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.MapDefaultEndpoints();

        app.Run();
    }
}
