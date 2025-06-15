# Clean Architecture

## Solution structure
```powershell
📁
├─📁 .config                             # Desired State Configuration (DSC) scripts to setup the development environment.
├─📁 src                                 # Source code of the application
│ ├─📁 CleanArchitecture.ApiService      # ASP.NET Core Web API project that serves as the backend. Contains the Presentation (API), Infrastucture, Adapter, and the Application layers.
│ ├─📁 CleanArchitecture.AppHost         # .NET Aspire orchestrator project designed to connect and configure the different projects and services of your app.
│ ├─📁 CleanArchitecture.Domain          # Domain layer.
│ ├─📁 CleanArchitecture.ServiceDefaults # .NET Aspire shared project to manage configurations that are reused across the projects in your solution related to resilience, service discovery, and telemetry.
│ └─📁 CleanArchitecture.Web             # Blazor Web App project that serves as the Client app.
├─📁 tests
│ ├─📁 CleanArchitecture.ApiService.FunctionalTests
│ └─📁 CleanArchitecture.AppHost.IntegrationTests
├─🗎 .editorconfig            # Coding styles.
├─🗎 .gitignore
├─🗎 Directory.Build.props    # Solution level project settings.
├─🗎 Directory.Packages.props # Solution level Central Package Management.
├─🗎 global.json              # Controls the .NET SDK version used when building the solution. Mainly used to centrally manage the versioning of the MSTest.Sdk.
└─🗎 README.md                # You're reading this right now.
```

## Application defaults

**Blazor Web App:**
- Interactive render mode: Server.
- Interactivity location: Per page/component.

## Setting up the development environment
The `.config` contains the Desired State Configuration (DSC) scripts to setup the development environment.

### Windows
Run the `Configure-Desired-State.ps1` file in the `.config\windows` directory, which will use the [WinGet](https://learn.microsoft.com/windows/package-manager/winget/) package manager to install the required tools and set up the development environment.

```powershell
cd .\.config\windows\
.\Configure-Desired-State.ps1
```

## Known Issues
- The usual NuGet update and Visual Studio UI for managing NuGet packages does not work as expected with [MSTest.Sdk](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-sdk). See this issue for more details: [NuGet#13127](https://github.com/NuGet/Home/issues/13127). Dependabot will handle updating the version in the global.json file.

## Build
Run `dotnet build` to build the solution.

## Resources

### Technology
- [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
- [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-9.0&WT.mc_id=dotnet-35129-website)
- [ASP.NET API](https://dotnet.microsoft.com/en-us/apps/aspnet/apis)
- [MSTest.Sdk](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-sdk)

### Patterns Used
- [REPR Design Pattern (Request-Endpoint-Response)](https://deviq.com/design-patterns/repr-design-pattern)