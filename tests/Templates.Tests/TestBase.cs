using Microsoft.TemplateEngine.Authoring.TemplateVerifier;

namespace Template.Tests;

abstract public class TestBase(string relativeTemplatePath)
{
    // On Windows: \tests\
    // On Linux and Mac: /tests/
    private static readonly string _testFolder = CreateRelativeTestFolderPath();

    // On Windows: templates\content\ItemTemplates\
    // On Linux and Mac: templates/content/ItemTemplates/
    private static readonly string _relativeItemTemplatesFolder = Path.Join("templates", "content", "ItemTemplates");

    private protected readonly string _templatePath = GetAbsoluteTemplatePath(relativeTemplatePath);
    
    private protected TemplateVerifierOptions CreateTemplateVerifierOptions(string templateName, string[] templateSpecificArgs) => new(templateName)
    {
        TemplatePath = _templatePath,
        TemplateSpecificArgs = templateSpecificArgs,
        DoNotPrependCallerMethodNameToScenarioName = false,
        DoNotPrependTemplateNameToScenarioName = true,
        DoNotAppendTemplateArgsToScenarioName = true
    };

    private static string GetAbsoluteTemplatePath(string templateFolderName)
    {
        string currentBaseDirectory = AppContext.BaseDirectory;
        int testDirectoryIndex = currentBaseDirectory.IndexOf(_testFolder, StringComparison.Ordinal);

        ReadOnlySpan<char> currentBaseDirectorySpan = currentBaseDirectory.AsSpan();
        ReadOnlySpan<char> solutionMainDirectoryAbsolutPath = currentBaseDirectorySpan[..testDirectoryIndex];

        return Path.Join(solutionMainDirectoryAbsolutPath, _relativeItemTemplatesFolder, templateFolderName);
    }

    private static string CreateRelativeTestFolderPath()
    {
        ReadOnlySpan<char> directorySeparatorCharAsSpan = new(in Path.DirectorySeparatorChar);
        return Path.Join(directorySeparatorCharAsSpan, "tests", directorySeparatorCharAsSpan);
    }
}
