using CodeBrix.MarkupParse.Html.Parser;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

public class CharacterReferenceTests
{
    [Fact]
    public void ParseNormalCharacterReference()
    {
        var source = "<div>&lt;</div>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsNotConsumingCharacterReferences = false,
        });
        var document = parser.ParseDocument(source);
        var content = document.QuerySelector("div").TextContent;
        Assert.Equal("<", content);
    }

    [Fact]
    public void ParseAvoidedCharacterReference()
    {
        var source = "<div>&lt;</div>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsNotConsumingCharacterReferences = true,
        });
        var document = parser.ParseDocument(source);
        var content = document.QuerySelector("div").TextContent;
        Assert.Equal("&lt;", content);
    }
}
