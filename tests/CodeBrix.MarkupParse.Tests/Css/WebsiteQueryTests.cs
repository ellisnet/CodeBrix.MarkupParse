using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Css; //Was previously: namespace AngleSharp.Core.Tests.Css

public class WebsiteQueryTests
{
    [Fact]
    public void HtmlCodeTutorialFindTableChildren()
    {
        var content = Helper.StreamFromBytes(Assets.htmlcodetutorial);
        var document = content.ToHtmlDocument();
        var query = "table:nth-child(21)";
        var result = document.QuerySelectorAll(query);
        Assert.Single(result);
    }

    [Fact]
    public void HtmlCodeTutorialTableInParagraphElement()
    {
        var content = Helper.StreamFromBytes(Assets.htmlcodetutorial);
        var document = content.ToHtmlDocument();
        var cell = document.QuerySelector("td.content");
        Assert.Equal(22, cell.ChildElementCount);
        Assert.IsAssignableFrom<HtmlTableElement>(cell.Children[7]);
        Assert.IsAssignableFrom<HtmlTableElement>(cell.Children[13]);
        Assert.IsAssignableFrom<HtmlTableElement>(cell.Children[20]);
    }
}
