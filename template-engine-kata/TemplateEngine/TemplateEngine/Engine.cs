namespace TemplateEngine;

public class Engine
{
    public ParsedText Parse(Dictionary<string, string> dictionary, string text)
    {
        return new ParsedText()
        {
            Text = text.Replace("${" + dictionary.First().Key + "}", dictionary.First().Value)
        };
    }
}

public class ParsedText
{
    public string Text { get; set; }
    public string Error { get; set; }
}