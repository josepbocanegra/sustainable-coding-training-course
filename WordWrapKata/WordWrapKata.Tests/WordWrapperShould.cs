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
    [InlineData("hola", "hola")]
    [InlineData("jose", "jose")]
    public void NotWrapText(string text, string expected)
    {
        var wordWrapper = new WordWrapper();
        
        var wrappedText = wordWrapper.Wrap(text, 4);
        
        wrappedText.Should().Be(expected);
    }
    

}