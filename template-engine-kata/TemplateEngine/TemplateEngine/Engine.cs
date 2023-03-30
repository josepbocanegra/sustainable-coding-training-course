namespace TemplateEngine;

public class Engine
{
    public ParsedText Parse(Dictionary<string, string> dictionary, string text)
    {
        if (dictionary == null || dictionary.Count == 0)
        {
            return new ParsedText() { Text = text };
        }
        
        var replacedText = text.Replace("${" + dictionary.First().Key + "}", dictionary.First().Value);
        
        return new ParsedText()
        {
            Text = replacedText
        };
    }
}

public class ParsedText
{
    public string Text { get; set; }
    public string Error { get; set; }
}