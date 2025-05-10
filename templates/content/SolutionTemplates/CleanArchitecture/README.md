# Clean Architecture
The project was generated using the [TemplatePackageId](TemplateRepositoryUrl) version TemplatePackageVersion.

## Solution structure
- `.config`: Desired State Configuration (DSC) scripts to setup the development environment.
- `src`:
  - `CleanArchitecture.AppHost`: .NET Aspire orchestrator project designed to connect and configure the different projects and services of your app.
  - `CleanArchitecture.ServiceDefaults`: .NET Aspire shared project to manage configurations that are reused across the projects in your solution related to [resilience](https://learn.microsoft.com/en-us/dotnet/core/resilience/http-resilience), [service discovery](https://learn.microsoft.com/en-us/dotnet/aspire/service-discovery/overview), and [telemetry](https://learn.microsoft.com/en-us/dotnet/aspire/telemetry).
  - `CleanArchitecture.Weather`: Weather microservice.
  - `CleanArchitecture.Web`: Presentation layer: Blazor web app.
- `tests`
  - `CleanArchitecture.Tests`: Tests for the templates.

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

## Build
Run `dotnet build -tl` to build the solution.

## Resources

### Technology

### Patterns Used