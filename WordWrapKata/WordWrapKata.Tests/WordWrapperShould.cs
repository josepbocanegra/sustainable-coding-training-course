using FluentAssertions;

namespace WordWrapKata.Tests;

public class WordWrapperShould
{
    // TODO:
// "hola", 2 -> "ho\nla"
// "ohlala", 2 -> "oh\nla\nla"
// "hola", 3 -> "hol\na"
// "hola", 4 -> "hola"
// "hola mundo", 7 -> "hola\nmundo"
// "hola", -5 -> ???
// "", 4 -> ???
// "hola", 0 -> ???

    [Theory]
    [InlineData("hola", "hola", 4)]
    [InlineData("jose", "jose", 4)]
    [InlineData("jose", "jose", 8)]
    [InlineData("Jonathan", "Jonathan", 8)]
    public void NotWrapTextWhenTextLengthIsLessThanColumns(string text, string expected, int columns)
    {
        var wordWrapper = new WordWrapper();
        
        var wrappedText = wordWrapper.Wrap(text, columns);
        
        wrappedText.Should().Be(expected);
    }
    
    // "hola", 2 -> "ho\nla"
    [Theory]
    [InlineData("hola", "ho\nla", 2)]
    public void WrapTextWhenTextLengthIsLongerThanColumns(string text, string expected, int columns)
    {
        var wordWrapper = new WordWrapper();
        
        var wrappedText = wordWrapper.Wrap(text, columns);
        
        wrappedText.Should().Be(expected);
    }
}