using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// These tests are taken from http://www.quirksmode.org/dom/tests/.
/// More information: http://www.quirksmode.org/dom/w3c_core.html
/// </summary>

public class QuirksmodeTests
{
    private IDocument document;

    public QuirksmodeTests()
    {
        document = Assets.quirksmode.ToHtmlDocument();
    }

    [Fact]
    public void CreateElementInUppercase()
    {
        var x = document.CreateElement("P");
        Assert.NotNull(x);
        Assert.True(x is HtmlParagraphElement);
        Assert.Equal(document, x.Owner);
    }

    [Fact]
    public void CreateTextNode()
    {
        var text = " textNode";
        var test = document.CreateTextNode(text);
        var testEl = document.GetElementById("test");

        for (var i = testEl.ChildNodes.Length - 1; i >= 0; i--)
        {
            testEl.RemoveChild(testEl.ChildNodes[i]);
        }

        Assert.Empty(testEl.Children);
        testEl.AppendChild(test as TextNode);
        Assert.Equal(text, testEl.InnerHtml);
        Assert.Equal(document, test.Owner);
    }

    [Fact]
    public void GetElementById()
    {
        var x = document.GetElementById("test");
        Assert.Equal("p", x.LocalName);
        Assert.Equal(document, x.Owner);
    }

    [Fact]
    public void GetElementByIdWithAName()
    {
        var x = document.GetElementById("test3");
        Assert.Null(x);
    }

    [Fact]
    public void GetElementsByClassNameSingle()
    {
        var cn = document.GetElementsByClassName("testClass");
        Assert.Equal(2, cn.Length);
        Assert.Equal("p", cn[0].LocalName);
    }

    [Fact]
    public void GetElementsByClassNameMultiple()
    {
        var cn = document.GetElementsByClassName("testClass nonsense");
        Assert.Single(cn);
        Assert.Equal("p", cn[0].LocalName);
    }

    [Fact]
    public void GetElementsByTagNameUsual()
    {
        var result = document.GetElementsByTagName("P");
        Assert.Equal(4, result.Length);
    }

    [Fact]
    public void GetElementsByTagNameAll()
    {
        var result = document.GetElementsByTagName("*");
        Assert.Equal(23, result.Length);
    }

    [Fact]
    public void GetElementsByTagNameCustom()
    {
        var result = document.GetElementsByTagName("ppk");
        Assert.Single(result);
    }

    [Fact]
    public void QuerySelectorAllClass()
    {
        var qsa = document.QuerySelectorAll(".testClass");
        Assert.Equal(2, qsa.Length);
    }

    [Fact]
    public void QuerySelectorAllCompound()
    {
        var qsa = document.QuerySelectorAll(".testClass + p");
        Assert.Equal(2, qsa.Length);
    }
}
