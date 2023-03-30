namespace WordWrapKata;

public class WordWrapper
{
    public string Wrap(string text, int columns)
    {
        if (text.Length <= columns)
        {
            return text; 
        }

        return text.Substring(0, columns) + "\n" + text.Substring(columns, text.Length-columns);
    }
}