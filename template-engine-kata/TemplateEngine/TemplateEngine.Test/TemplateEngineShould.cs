
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
    
    [Fact]
    public void ParseTemplateWithOneVariable()
    {
        var templateEngine = new Engine();
        var dictionary = new Dictionary<string, string>() { { "name", "John"} };
        var template = "Hello ${name}";

        var parsedText = templateEngine.Parse(dictionary, template);
        
        parsedText.Text.Should().Be("Hello John");
    }
}