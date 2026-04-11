using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Css; //Was previously: namespace AngleSharp.Core.Tests.Css

public class SlickspeedTests
{
    private static IDocument CreateTestDocument()
    {
        var config = Configuration.Default.WithCulture("en-US").WithScripting();
        return Assets.w3c_selectors.ToHtmlDocument(config);
    }

    [Fact]
    public void SlickspeedFindBodyElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("body");
        Assert.Single(result);
    }

    [Fact]
    public void SlickspeedFindDivElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div");
        Assert.Equal(51, result.Length);
    }

    [Fact]
    public void SlickspeedFindBodyDivElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("body div");
        Assert.Equal(51, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivPElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div p");
        Assert.Equal(140, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivPChildElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div > p");
        Assert.Equal(134, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivPSiblingElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div + p");
        Assert.Equal(22, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivPFollowingElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div ~ p");
        Assert.Equal(183, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivClassExaClassMpleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class^=exa][class$=mple]");
        Assert.Equal(43, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivPAElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div p a");
        Assert.Equal(12, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivOrPOrAElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div, p, a");
        Assert.Equal(671, result.Length);
    }

    [Fact]
    public void SlickspeedFindNoteElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll(".note");
        Assert.Equal(14, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivExampleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div.example");
        Assert.Equal(43, result.Length);
    }

    [Fact]
    public void SlickspeedFindUlTocline2Element()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("ul .tocline2");
        Assert.Equal(12, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivExampleDivNoteElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div.example, div.note");
        Assert.Equal(44, result.Length);
    }

    [Fact]
    public void SlickspeedFindTitleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("#title");
        Assert.Single(result);
    }

    [Fact]
    public void SlickspeedFindH1TitleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("h1#title");
        Assert.Single(result);
    }

    [Fact]
    public void SlickspeedFindDivTitleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div #title");
        Assert.Single(result);
    }

    [Fact]
    public void SlickspeedFindUlTocLiTocline2Element()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("ul.toc li.tocline2");
        Assert.Equal(12, result.Length);
    }

    [Fact]
    public void SlickspeedFindUlTocLiTocline2ChildElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("ul.toc > li.tocline2");
        Assert.Equal(12, result.Length);
    }

    [Fact]
    public void SlickspeedFindH1TitleDivPElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("h1#title + div > p");
        Assert.Empty(result);
    }

    [Fact]
    public void SlickspeedFindH1IdContainsSelectorsElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("h1[id]:contains(Selectors)");
        Assert.Single(result);
    }

    [Fact]
    public void SlickspeedFindAHrefLangClassElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("a[href][lang][class]");
        Assert.Single(result);
    }

    [Fact]
    public void SlickspeedFindDivClassElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class]");
        Assert.Equal(51, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivClassExampleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class=example]");
        Assert.Equal(43, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivClassExaElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class^=exa]");
        Assert.Equal(43, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivClassMpleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class$=mple]");
        Assert.Equal(43, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivClassEElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class*=e]");
        Assert.Equal(50, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivClassDialogElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class|=dialog]");
        Assert.Empty(result);
    }

    [Fact]
    public void SlickspeedFindDivClassMade_UpElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class!=made_up]");
        Assert.Equal(51, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivClassContainsExampleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div[class~=example]");
        Assert.Equal(43, result.Length);
    }

    [Fact]
    public void SlickspeedFindDivNotExampleElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("div:not(.example)");
        Assert.Equal(8, result.Length);
    }

    [Fact]
    public void SlickspeedFindPContainsSelectorsElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:contains(selectors)");
        Assert.Equal(54, result.Length);
    }

    [Fact]
    public void SlickspeedFindPNthChildEvenElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:nth-child(even)");
        Assert.Equal(158, result.Length);
    }

    [Fact]
    public void SlickspeedFindPNthChild2NElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:nth-child(2n)");
        Assert.Equal(158, result.Length);
    }

    [Fact]
    public void SlickspeedFindPNthChildOddElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:nth-child(odd)");
        Assert.Equal(166, result.Length);
    }

    [Fact]
    public void SlickspeedFindPNthChild2N1Element()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:nth-child(2n+1)");
        Assert.Equal(166, result.Length);
    }

    [Fact]
    public void SlickspeedFindPNthChildNElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:nth-child(n)");
        Assert.Equal(324, result.Length);
    }

    [Fact]
    public void SlickspeedFindPOnlyChildElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:only-child");
        Assert.Equal(3, result.Length);
    }

    [Fact]
    public void SlickspeedFindPLastChildElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:last-child");
        Assert.Equal(19, result.Length);
    }

    [Fact]
    public void SlickspeedFindPFirstChildElement()
    {
        var document = CreateTestDocument();
        var result = document.QuerySelectorAll("p:first-child");
        Assert.Equal(54, result.Length);
    }
}
