using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Html.Parser.Tokens;
using CodeBrix.MarkupParse.Text;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Examples; //Was previously: namespace AngleSharp.Core.Tests.Examples

public class Questions
{
    [Fact]
    public void GetPositionViaCallback()
    {
        var bodyPos = TextPosition.Empty;
        var parser = new HtmlParser(new HtmlParserOptions
        {
            OnCreated = (IElement element, TextPosition position) =>
            {
                if (element.TagName == "BODY")
                {
                    bodyPos = position;
                }
            },
        });
        parser.ParseDocument("<!doctype html><body>");
        Assert.Equal(new TextPosition(1, 16, 16), bodyPos);
    }

    [Fact]
    public void GetPositionViaSourceReference()
    {
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsKeepingSourceReferences = true,
        });
        var document = parser.ParseDocument("<!doctype html><body>");
        var bodyPos = document.Body.SourceReference.Position;
        Assert.Equal(new TextPosition(1, 16, 16), bodyPos);
    }

    [Fact]
    public void GetPositionViaTokenCallback()
    {
        var bodyStartPos = TextPosition.Empty;
        var bodyEndPos = TextPosition.Empty;
        var parser = new HtmlParser(new HtmlParserOptions
        {
            OnToken = (HtmlToken token, TextRange range) =>
            {
                if (token.Name == "body")
                {
                    bodyStartPos = range.Start;
                    bodyEndPos = range.End;
                }
            },
        });
        parser.ParseDocument("<!doctype html><body>");
        Assert.Equal(new TextPosition(1, 16, 16), bodyStartPos);
        Assert.Equal(new TextPosition(1, 22, 22), bodyEndPos);
    }
}
