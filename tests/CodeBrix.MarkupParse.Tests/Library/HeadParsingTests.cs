using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Html.Parser;
using Xunit;
using System.Text;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class HeadParsingTests
{
    [Fact]
    public async Task TestAsyncHeadParsingFromStream()
    {
        var text = "<html><head><title>My test</title></head><body><p>Some text</p></body></html>";
        var source = new DelayedStream(Encoding.UTF8.GetBytes(text));
        var parser = new HtmlParser();

        using var task = parser.ParseHeadAsync(source);
        Assert.False(task.IsCompleted);
        var result = await task;

        Assert.True(task.IsCompleted);
        Assert.Equal("head", result.LocalName);
        Assert.Equal(1, result.ChildElementCount);
        Assert.Equal("My test", result.Children[0].TextContent);
    }

    [Fact]
    public async Task TestAsyncHeadParsingFromString()
    {
        var source = "<html><head><title>My test</title></head><body><p>Some text</p></body></html>";
        var parser = new HtmlParser();

        using var task = parser.ParseHeadAsync(source);
        Assert.True(task.IsCompleted);
        var result = await task;

        Assert.Equal("head", result.LocalName);
        Assert.Equal(1, result.ChildElementCount);
        Assert.Equal("My test", result.Children[0].TextContent);
    }

    [Fact]
    public void TestSyncHeadParsingFromStream()
    {
        var text = "<html><head><title>My test</title></head><body><p>Some text</p></body></html>";
        var source = new DelayedStream(Encoding.UTF8.GetBytes(text));
        var parser = new HtmlParser();
        var result = parser.ParseHead(source);
        Assert.Equal("head", result.LocalName);
        Assert.Equal(1, result.ChildElementCount);
        Assert.Equal("My test", result.Children[0].TextContent);
    }

    [Fact]
    public void TestSyncHeadParsingFromString()
    {
        var source = "<html><head><title>My test</title></head><body><p>Some text</p></body></html>";
        var parser = new HtmlParser();
        var result = parser.ParseHead(source);
        Assert.Equal("head", result.LocalName);
        Assert.Equal(1, result.ChildElementCount);
        Assert.Equal("My test", result.Children[0].TextContent);
    }

    [Fact]
    public void CustomElementsInHeadShouldByDefaultBeMovedToBody_Issue1035()
    {
        var source = @"<html>
  <head>
    <site-include type=""partial"" name=""scripts""></site-include>
  </head>
</html>";
        var parser = new HtmlParser();
        var document = parser.ParseDocument(source);
        var isInHead = document.Head.QuerySelector("site-include");
        var isInBody = document.Body?.QuerySelector("site-include");
        Assert.Null(isInHead);
        Assert.NotNull(isInBody);
    }

    [Fact]
    public void CustomElementsInHeadShouldBeKeptIfActivated_Issue1035()
    {
        var source = @"<html>
  <head>
    <site-include type=""partial"" name=""scripts""></site-include>
  </head>
</html>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsAcceptingCustomElementsEverywhere = true,
        });
        var document = parser.ParseDocument(source);
        var isInHead = document.Head.QuerySelector("site-include");
        var isInBody = document.Body?.QuerySelector("site-include");
        Assert.NotNull(isInHead);
        Assert.Null(isInBody);
    }

    [Fact]
    public void CustomElementsInHeadWithChildrenIfActivated_Issue1035()
    {
        var source = @"<html>
  <head>
  </head>
  <body>
    <site-include type=""partial"" name=""scripts""><div>Yes</div></site-include>
  </body>
</html>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsAcceptingCustomElementsEverywhere = true,
        });
        var document = parser.ParseDocument(source);
        var element = document.Body.QuerySelector("site-include");
        Assert.Equal(@"<site-include type=""partial"" name=""scripts""><div>Yes</div></site-include>", element.ToHtml());
    }

    [Fact]
    public void CustomElementsInTableWithChildrenIfActivated_Issue1035()
    {
        var source = @"<html>
  <head>
  </head>
  <body>
    <table>
      <my-table-head></my-table-head>
    </table>
  </body>
</html>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsAcceptingCustomElementsEverywhere = true,
        });
        var document = parser.ParseDocument(source);
        var element = document.Body;
        Assert.Equal("<body>\n    <table>\n      <my-table-head></my-table-head>\n    </table>\n  \n</body>", element.ToHtml());
    }
}
