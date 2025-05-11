# .NET Templates

The goal of this template is to provide a straightforward and efficient approach to enterprise application development. Using this template, you can create:
- Items
  - Class
  - Enum
  - Interface
  - MSTest Class
  - Record
  - Struct
- Projects
- Solutions
  - Clean Architecture

If you find this project useful, please give it a star! ⭐

# Getting Started

## Installation Instructions
The easiest way to get started is to install the [templates package](https://www.nuget.org/packages/NextLevelTribe.Templates):
```powershell
dotnet new install NextLevelTribe.Templates
```

To list all of our templates:
```
dotnet new list nlt
```

You can see the available options for every template with the `-?` option.
For example in case of the **Clean Architecture** template:
```powershell
dotnet new nlt-clean-arch -?
```

To create a **Clean Architecture** solution named `Your.ProjectName`:
```
dotnet new nlt-clean-arch -n Your.ProjectName
```

### Known Issues
- Don't include hyphens (`-`) in the name. See [dotnet/templating#6853](https://github.com/dotnet/templating/issues/6853).

# Contributing

## Solution structure
```powershell
📁
├─📁 .config               # Desired State Configuration (DSC) scripts to setup the development environment.
├─📁 templates             # Contains the template project.
│ └─📁 content             # The dotnet template engine requires that all templates be stored in the content folder.
│   ├─📁 ItemTemplates     # Class, Enum, Interface, Record, and Struct templates.
│   ├─📁 ProjectTemplates  # Use Case template for Clean Vertical Sliced Architecture.
│   └─📁 SolutionTemplates # Clean Vertical Sliced Architecture solution template.
└─📁 tests                 # Unit and integration tests
```

## Setting up the development environment
The `.config` contains the Desired State Configuration (DSC) scripts to setup the development environment.

### Windows
Run the `Configure-Desired-State.ps1` file in the `.config\windows` directory, which will use the [WinGet](https://learn.microsoft.com/windows/package-manager/winget/) package manager to install the required tools and set up the development environment.

```powershell
cd .\.config\windows\
.\Configure-Desired-State.ps1
```

#### Pack, install, and uninstall
In the `templates` folder.
Run the following command to build template project and create the NuGet package in the `.\bin\Release` folder:

```powershell
dotnet pack
```

Install the template:
```powershell
dotnet new install .\bin\Release\NextLevelTribe.Templates.9.0.0.nupkg
```

Uninstall the template package:
```powershell
dotnet new uninstall NextLevelTribe.Templates
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