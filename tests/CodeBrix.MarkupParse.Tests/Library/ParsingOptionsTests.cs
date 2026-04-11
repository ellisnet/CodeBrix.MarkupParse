using CodeBrix.MarkupParse.Html.Parser;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class ParsingOptionsTests
{
    [Fact]
    public void PreserveAttributesDisabled_Issue897()
    {
        var source = @"<div *ngIf=""condition"">Content to render when condition is true.</div>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsPreservingAttributeNames = false,
        });
        var document = parser.ParseDocument(source);
        var element = document.QuerySelector("div");
        Assert.Equal(@"<div *ngif=""condition"">Content to render when condition is true.</div>", element.ToHtml());
    }

    [Fact]
    public void PreserveAttributesEnabled_Issue897()
    {
        var source = @"<div *ngIf=""condition"">Content to render when condition is true.</div>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsPreservingAttributeNames = true,
        });
        var document = parser.ParseDocument(source);
        var element = document.QuerySelector("div");
        Assert.Equal(@"<div *ngIf=""condition"">Content to render when condition is true.</div>", element.ToHtml());
    }

    [Fact]
    public void PreserveAttributesEnabledInFullForm_Issue897()
    {
        var source = @"<ng-template [ngIf]=""condition""><div>Content to render when condition is true.</div></ng-template>";
        var parser = new HtmlParser(new HtmlParserOptions
        {
            IsPreservingAttributeNames = true,
        });
        var document = parser.ParseDocument(source);
        var element = document.QuerySelector("ng-template");
        Assert.Equal(@"<ng-template [ngIf]=""condition""><div>Content to render when condition is true.</div></ng-template>", element.ToHtml());
    }
}
