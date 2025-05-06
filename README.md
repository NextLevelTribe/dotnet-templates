# .NET Templates
Item, Project, and Solution template including Clean Architecture.

## Solution structure
```powershell
📁
├──📁 .config                 # Desired State Configuration (DSC) scripts to setup the development environment.
├──📁 templates               # Contains the template project.
│  └──📁 content
│     ├──📁 ItemTemplates     # Class, Enum, Interface, Record, and Struct templates.
│     ├──📁 ProjectTemplates  # Use Case template for Clean Vertical Sliced Architecture.
│     └──📁 SolutionTemplates # Clean Vertical Sliced Architecture solution template.
└──📁 tests:                  # Unit and integration tests
```

## Setting up the development environment
The `.config` contains the Desired State Configuration (DSC) scripts to setup the development environment.

### Windows
Run the `Configure-Desired-State.ps1` file in the `.config\windows` directory, which will use the [WinGet](https://learn.microsoft.com/windows/package-manager/winget/) package manager to install the required tools and set up the development environment.

```powershell
cd .\.config\windows\
.\Configure-Desired-State.ps1
```

## Resources for template development
Tutorials
- [Create templates](https://learn.microsoft.com/en-us/dotnet/core/tutorials/cli-templates-create-item-template)
- [How to create custom templates](https://learn.microsoft.com/en-us/dotnet/core/tools/custom-templates)
- [How to create your own templates](https://github.com/sayedihashimi/template-sample)
- [Template authoring docs in dotnet/templating Wiki](https://github.com/dotnet/templating/wiki)
- [Templates Testing Tooling](https://github.com/dotnet/templating/wiki/Templates-Testing-Tooling)

Sample Sources
- [.NET Template Samples](https://github.com/dotnet/templating/tree/main/dotnet-template-samples)
- [Common project and item templates](https://github.com/dotnet/sdk/tree/main/template_feed)
- [ASP.NET and Blazor templates templates](https://github.com/dotnet/aspnetcore/tree/main/src/ProjectTemplates)