namespace TemplateEngine;

public class Engine
{
    public ParsedText Parse(Dictionary<string, string> dictionary, string text)
    {
        if (dictionary == null || dictionary.Count == 0)
        {
            return new ParsedText() { Text = text };
        }

        foreach (var variable in dictionary)
        {
            text = text.Replace("${" + variable.Key + "}", variable.Value);
        }

        if (System.Text.RegularExpressions.Regex.IsMatch(text, @"\${\w+}"))
        {
            return new ParsedText()
            {
                Text = text,
                Error = "There is a missing variable on the dictionary"
            };
        }

        return new ParsedText()
        {
            Text = text
        };
    }
}

public class ParsedText
{
    public string Text { get; set; }
    public string Error { get; set; }
}