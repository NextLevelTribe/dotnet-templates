using Aspire.Hosting;

namespace CleanArchitecture.AppHost.IntegrationTests;

[TestClass]
public sealed class WebTests
{
    [TestMethod]
    public async Task GetWebResourceRoot_ReturnsOkStatusCode()
    {
        // Arrange
        IDistributedApplicationTestingBuilder appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.CleanArchitecture_AppHost>();
        _ = appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        {
            _ = clientBuilder.AddStandardResilienceHandler();
        });

        await using DistributedApplication app = await appHost.BuildAsync();
        ResourceNotificationService resourceNotificationService = app.Services.GetRequiredService<ResourceNotificationService>();
        await app.StartAsync();

        // Act
        HttpClient httpClient = app.CreateHttpClient("webfrontend");
        await resourceNotificationService.WaitForResourceAsync("webfrontend", KnownResourceStates.Running).WaitAsync(TimeSpan.FromSeconds(30));
        HttpResponseMessage response = await httpClient.GetAsync("/");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public async Task GetHealthEndpoint_ReturnsHealtyStatus()
    {
        // Arrange
        IDistributedApplicationTestingBuilder appHost = await DistributedApplicationTestingBuilder.CreateAsync<Projects.CleanArchitecture_AppHost>();
        IServiceCollection serviceCollection = appHost.Services.ConfigureHttpClientDefaults(clientBuilder =>
        {
            _ = clientBuilder.AddStandardResilienceHandler();
        });

        await using DistributedApplication app = await appHost.BuildAsync();
        ResourceNotificationService resourceNotificationService = app.Services.GetRequiredService<ResourceNotificationService>();
        await app.StartAsync();

        // Act
        HttpClient httpClient = app.CreateHttpClient("webfrontend");
        await resourceNotificationService.WaitForResourceAsync("webfrontend", KnownResourceStates.Running).WaitAsync(TimeSpan.FromSeconds(30));
        HttpResponseMessage response = await httpClient.GetAsync("/health");

        // Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        string healthStatus = await response.Content.ReadAsStringAsync();
        Assert.AreEqual("Healthy", healthStatus);
    }

}
