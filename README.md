# .NET Templates
Item, Project, and Solution teamples including Clean Architecture.

## Solution structure
- `.config`: Desired State Configuration (DSC) scripts for the development environment.
- `templates`: The template package project.
- `templates\content`
  - `ItemTemplates`: Class, Enum, Interface, Record, and Struct templates.
  - `ProjectTemplates`: Use Case templates for Clean Architecture.
  - `SolutionTemplates`: Clean Architecture solution template.
- `tests`
  - `Template.Tests`: Tests for the templates.

## Setting up the development environment
Step in the `.config` directory.

### Windows
Run the `Configure-Desired-State.ps1` file which will use the [WinGet](https://learn.microsoft.com/windows/package-manager/winget/) to install the required tools and set up the development environment.