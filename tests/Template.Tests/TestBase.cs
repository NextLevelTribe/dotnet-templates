using Microsoft.TemplateEngine.Authoring.TemplateVerifier;

namespace Template.Tests;

abstract public class TestBase(string relativeTemplatePath)
{
    private protected readonly string _templatePath = GetAbsoluteTemplatePath(relativeTemplatePath);

    private protected TemplateVerifierOptions CreateTemplateVerifierOptions(string templateName, string[] templateSpecificArgs) => new(templateName)
    {
        TemplatePath = _templatePath,
        TemplateSpecificArgs = templateSpecificArgs,
        DoNotPrependCallerMethodNameToScenarioName = false,
        DoNotPrependTemplateNameToScenarioName = true,
        DoNotAppendTemplateArgsToScenarioName = true
    };

    private static string GetAbsoluteTemplatePath(string relativeTemplatePath)
    {
        string testBaseDirectory = AppContext.BaseDirectory;
        int testDirectoryIndex = testBaseDirectory.IndexOf(@"\tests\", StringComparison.Ordinal);
        string projectMainDirectory = testBaseDirectory[..testDirectoryIndex];
        string templatePath = Path.Combine(projectMainDirectory, relativeTemplatePath);
        return templatePath;
    }
}
