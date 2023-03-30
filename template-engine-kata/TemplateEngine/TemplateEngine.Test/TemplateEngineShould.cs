
using FluentAssertions;

namespace TemplateEngine.Test;

public class TemplateEngineShould
{
    [Theory]
    [InlineData("Hello world!")]
    [InlineData("Bye bye world!")]
    [InlineData("")]
    public void ParseTemplateWithoutVariables(string expected)
    {
        var templateEngine = new Engine();
        var dictionary = new Dictionary<string, string>();

        var parsedText = templateEngine.Parse(dictionary, expected);
        
        parsedText.Text.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("Hello ${name}", "Hello John")]
    [InlineData("Hello ${name} ${name}", "Hello John John")]
    public void ParseTemplateWithOneVariable(string template, string expectedText)
    {
        var templateEngine = new Engine();
        var dictionary = new Dictionary<string, string>() { { "name", "John"} };

        var parsedText = templateEngine.Parse(dictionary, template);
        
        parsedText.Text.Should().Be(expectedText);
    }
    
    [Fact]
    public void ParseTemplateWithTwoVariables()
    {
        var templateEngine = new Engine();
        var dictionary = new Dictionary<string, string>() { { "name", "John"}, { "lastName", "Smith"} };
        var template = "Hello ${name} ${lastName}";
        
        var parsedText = templateEngine.Parse(dictionary, template);
        
        parsedText.Text.Should().Be("Hello John Smith");
    }
    
    [Fact]
    public void ParseTemplateWithOneMissingVariable()
    {
        var templateEngine = new Engine();
        var dictionary = new Dictionary<string, string>() { { "name", "John"} };
        var template = "Hello ${name} ${lastName}";
        
        var parsedText = templateEngine.Parse(dictionary, template);
        
        parsedText.Text.Should().Be("Hello John ${lastName}");
        parsedText.Error.Should().Be("There is a missing variable on the dictionary");
    }
}