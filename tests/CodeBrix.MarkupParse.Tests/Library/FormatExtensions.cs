using CodeBrix.MarkupParse.Html;
using Xunit;
using System.IO;
using System.Text;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class FormatExtensions
{
    [Fact]
    public void ExtensionToHtml()
    {
        var document = ("<!DOCTYPE html><html><head></head><body></body></html>").ToHtmlDocument();
        var html = document.ToHtml();
        Assert.Equal("<!DOCTYPE html><html><head></head><body></body></html>", html);
    }

    [Fact]
    public void ExtensionToHtmlWithFormatter()
    {
        var document = ("<!DOCTYPE html><html><head></head><body></body></html>").ToHtmlDocument();
        var html = document.ToHtml(HtmlMarkupFormatter.Instance);
        Assert.Equal("<!DOCTYPE html><html><head></head><body></body></html>", html);
    }

    [Fact]
    public void ExtensionToHtmlWithTextWriter()
    {
        var builder = new StringBuilder();

        using var writer = new StringWriter(builder);
        var document = ("<!DOCTYPE html><html><head></head><body></body></html>").ToHtmlDocument();
        document.ToHtml(writer);
        Assert.Equal("<!DOCTYPE html><html><head></head><body></body></html>", builder.ToString());
    }
}
