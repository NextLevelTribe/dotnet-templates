# Clean Architecture

## Solution structure
```powershell
📁
├─📁 .config                             # Desired State Configuration (DSC) scripts to setup the development environment.
├─📁 src                                 # Source code of the application
│ ├─📁 CleanArchitecture.AppHost         # .NET Aspire orchestrator project designed to connect and configure the different projects and services of your app.
│ ├─📁 CleanArchitecture.ServiceDefaults # .NET Aspire shared project to manage configurations that are reused across the projects in your solution related to resilience, service discovery, and telemetry.
│ ├─📁 CleanArchitecture.Weather         # Weather microservice.
│ └─📁 CleanArchitecture.Web             # Presentation layer: Blazor web app.
├─📁 tests                               # Unit and integration tests
│ └─📁 CleanArchitecture.AppHost.IntegrationTests
├─🗎 .editorconfig            # Codeing styles.
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
- In case of the test projects. The usual NuGet update and Visual Studio UI for managing NuGet packages does not work as expected with [MSTest.Sdk](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-sdk). See this issue for more details: [NuGet#13127](https://github.com/NuGet/Home/issues/13127). Dependabot will handle updating the version in the global.json file.

## Build
Run `dotnet build -tl` to build the solution.

## Resources

### Technology
- [.NET Aspire](https://learn.microsoft.com/en-us/dotnet/aspire/get-started/aspire-overview)
- [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-9.0&WT.mc_id=dotnet-35129-website)
- [MSTest.Sdk](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-mstest-sdk)

### Patterns Used