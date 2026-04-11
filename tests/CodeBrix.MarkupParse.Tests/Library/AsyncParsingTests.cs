using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Html.Parser;
using Xunit;
using System.Text;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class AsyncParsingTests
{
    [Fact]
    public async Task TestAsyncHtmlParsingFromStream()
    {
        var text = "<html><head><title>My test</title></head><body><p>Some text</p></body></html>";
        var source = new DelayedStream(Encoding.UTF8.GetBytes(text));
        var parser = new HtmlParser();

        using var task = parser.ParseDocumentAsync(source);
        Assert.False(task.IsCompleted);
        var result = await task;

        Assert.True(task.IsCompleted);
        Assert.Equal("My test", result.Title);
        Assert.Equal(1, result.Body.ChildElementCount);
        Assert.Equal("Some text", result.Body.Children[0].TextContent);
    }

    [Fact]
    public async Task TestAsyncHtmlParsingFromString()
    {
        var source = "<html><head><title>My test</title></head><body><p>Some text</p></body></html>";
        var parser = new HtmlParser();

        using var task = parser.ParseDocumentAsync(source);
        Assert.True(task.IsCompleted);
        var result = await task;

        Assert.Equal("My test", result.Title);
        Assert.Equal(1, result.Body.ChildElementCount);
        Assert.Equal("Some text", result.Body.Children[0].TextContent);
    }
}
