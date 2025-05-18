using CleanArchitecture.Web.Components;

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
        #endif

        // Add services to the DI container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        #if (!UseRedisCache)
        builder.Services.AddOutputCache();

        #endif
        builder.Services.AddHttpClient<WeatherApiClient>(client =>
            {
                // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
                // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
                client.BaseAddress = new("https+http://apiservice");
            });

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
