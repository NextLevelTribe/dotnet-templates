# Clean Vertical Slice Architecture
The project was generated using the [TemplatePackageId](TemplateRepositoryUrl) version TemplatePackageVersion.

## Solution structure
- `.config`: Desired State Configuration (DSC) scripts to setup the development environment.
- `src`:
  - `CleanVerticalSliceArchitecture.AppHost`: .NET Aspire orchestrator project designed to connect and configure the different projects and services of your app.
  - `CleanVerticalSliceArchitecture.ServiceDefaults`: .NET Aspire shared project to manage configurations that are reused across the projects in your solution related to [resilience](https://learn.microsoft.com/en-us/dotnet/core/resilience/http-resilience), [service discovery](https://learn.microsoft.com/en-us/dotnet/aspire/service-discovery/overview), and [telemetry](https://learn.microsoft.com/en-us/dotnet/aspire/telemetry).
  - `CleanVerticalSliceArchitecture.Weather`: Weather microservice.
  - `CleanVerticalSliceArchitecture.Web`: Presentation layer: Blazor web frontend.
- `tests`
  - `CleanVerticalSliceArchitecture.Tests`: Tests for the templates.

## Setting up the development environment
The `.config` contains the directory the Desired State Configuration (DSC) scripts to setup the development environment.

### Windows
We use [WinGet](https://learn.microsoft.com/windows/package-manager/winget/) package manager to install the required tools and set up the development environment.

```powershell
winget configure .\.config\configuration.winget
```

## Build
Run `dotnet build -tl` to build the solution.

## Resources

### Technology

### Patterns