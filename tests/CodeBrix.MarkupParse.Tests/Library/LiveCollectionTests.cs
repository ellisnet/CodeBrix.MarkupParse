using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Library; //Was previously: namespace AngleSharp.Core.Tests.Library

public class LiveCollectionTests
{
    private static IDocument Html(string code)
    {
        return code.ToHtmlDocument();
    }

    [Fact]
    public void HtmlLiveCollectionUpdates()
    {
        var document = Html("<ul><li>A<li>B<li>C<li>D</ul>");

        var body = document.Body;
        Assert.NotNull(body);
        Assert.Single(body.ChildNodes);

        var ul = body.ChildNodes[0];
        Assert.Equal("ul", ul.GetTagName());
        Assert.Equal(NodeType.Element, ul.NodeType);

        var live = ((Element)ul).Children;
        Assert.Equal(4, live.Length);
        Assert.Equal("A", live[0].TextContent);
        Assert.Equal("B", live[1].TextContent);
        Assert.Equal("C", live[2].TextContent);
        Assert.Equal("D", live[3].TextContent);

        var newElement = document.CreateElement(TagNames.Li);
        newElement.TextContent = "E";
        ul.AppendChild(newElement);

        Assert.Equal(5, live.Length);
        Assert.Equal("E", live[4].TextContent);
    }

    [Fact]
    public void HtmlLiveCollectionCompleteDOMRebuildWithInnerHtml()
    {
        var document = Html("<p><p><p><p><p>");

        var body = document.Body;
        Assert.NotNull(body);
        Assert.Equal(5, body.ChildNodes.Length);

        var live = body.Children;
        Assert.Equal(5, live.Length);

        foreach (var child in live)
        {
            Assert.Equal("p", child.GetTagName());
            Assert.Empty(child.ChildNodes);
            Assert.Empty(child.Attributes);
            Assert.Equal(NodeType.Element, child.NodeType);
            Assert.Equal("", child.TextContent);
        }

        body.InnerHtml = "<p>First<p>Second<p>Third";
        Assert.Equal(3, body.ChildNodes.Length);
        Assert.Equal(3, live.Length);

        var i = 0;
        var str = new[] { "First", "Second", "Third" };

        foreach (var child in live)
        {
            Assert.Equal("p", child.GetTagName());
            Assert.Single(child.ChildNodes);
            Assert.Empty(child.Attributes);
            Assert.Equal(NodeType.Element, child.NodeType);
            Assert.Equal(str[i++], child.TextContent);
        }
    }

    [Fact]
    public void HtmlLiveCollectionCompleteDOMRebuildWithText()
    {
        var document = Html("<p><p><p><p><p>");

        var body = document.Body;
        Assert.NotNull(body);
        Assert.Equal(5, body.ChildNodes.Length);

        var live = body.Children;
        Assert.Equal(5, live.Length);

        foreach (var child in live)
        {
            Assert.Equal("p", child.GetTagName());
            Assert.Empty(child.ChildNodes);
            Assert.Empty(child.Attributes);
            Assert.Equal(NodeType.Element, child.NodeType);
            Assert.Equal("", child.TextContent);
        }

        body.InnerHtml = "This is pure text!";
        Assert.Single(body.ChildNodes);
        Assert.Empty(live);

        body.InnerHtml = "<b>Proof that we still have live view</b>";
        Assert.Single(body.ChildNodes);
        Assert.Single(live);
    }

    [Fact]
    public void HtmlLiveCollectionWithAttr()
    {
        var document = Html("<a name=first>some name</a><a name=second>more</a><div><a name=third>last</a><a id=change>not really an anchor</a></div>");

        var body = document.Body;
        Assert.NotNull(body);
        Assert.Equal(3, body.ChildNodes.Length);

        var live = document.Anchors;
        Assert.Equal(3, live.Length);

        foreach (var child in live)
        {
            Assert.Equal("a", child.GetTagName());
            Assert.Single(child.Attributes);
            Assert.Equal(NodeType.Element, child.NodeType);
            Assert.NotNull(child.GetAttribute("name"));
        }

        var a = document.QuerySelector("#change");
        Assert.NotNull(a);

        a.SetAttribute("name", "changed");
        Assert.Equal(4, live.Length);
    }

    [Fact]
    public void HtmlLiveCollectionMultiple()
    {
        var document = Html("<embed></embed><div><object></object><applet></applet>");

        var body = document.Body;
        Assert.NotNull(body);
        Assert.Equal(2, body.ChildNodes.Length);

        var live = document.Plugins;
        Assert.Single(live);

        var div = document.QuerySelector(TagNames.Div);
        Assert.NotNull(div);

        var embed = document.CreateElement(TagNames.Embed);
        div.AppendChild(embed);

        Assert.Equal(2, live.Length);
    }

    [Fact]
    public void HtmlLiveCollectionMultipleWithAttr()
    {
        var document = Html("<a href='http://127.0.0.1'></a><div class='container'><area href='#'>my area</area>");

        var body = document.Body;
        Assert.NotNull(body);
        Assert.Equal(2, body.ChildNodes.Length);

        var live = document.Links;
        Assert.Equal(2, live.Length);

        var div = document.QuerySelector("body > div.container");
        Assert.NotNull(div);

        var a = document.CreateElement(TagNames.A);
        div.AppendChild(a);

        Assert.Equal(2, live.Length);

        a.SetAttribute("href", "http://localhost");
        Assert.Equal(3, live.Length);

        foreach (var element in live)
        {
            Assert.NotNull(element.GetAttribute("href"));
            Assert.True(element.GetTagName() == "a" || element.GetTagName() == "area");
        }
    }

    [Fact]
    public void HtmlFormLiveCollectionContainsNonChildAssignedElements()
    {
        var document = Html("<form id=main><input><input><input></form><input form=main>");
        var form = document.QuerySelector("form") as IHtmlFormElement;
        var elements = form.Elements;
        Assert.Equal(4, elements.Length);
        Assert.Equal("main", elements[3].GetAttribute("form"));
        Assert.Equal(form, (elements[3] as IHtmlInputElement).Form);
    }
}
