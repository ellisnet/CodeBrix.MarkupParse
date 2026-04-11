using CodeBrix.MarkupParse.Dom;
using Xunit;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Css; //Was previously: namespace AngleSharp.Core.Tests.Css

public class QueryExtensionsTests
{
    private static IDocument GetTestDocument()
    {
        var content = "<!doctype html><ul><li>First entry<li>Second entry<li>Third entry<li>4<li>Fifth<li>Last</ul>";
        return content.ToHtmlDocument();
    }

    [Fact]
    public void QueryOnEmptyNodeListShouldYieldEmptyResult()
    {
        var document = GetTestDocument();
        var result = document.Head.QuerySelectorAll("a");
        Assert.Empty(result);
    }

    [Fact]
    public void InvalidQueryOnEmptyNodeListShouldThrowException()
    {
        var document = GetTestDocument();
        Assert.ThrowsAny<DomException>(() => document.Head.QuerySelectorAll("<invalid>"));
    }

    [Fact]
    public void QueryOnNonEmptyNodeListShouldYieldEmptyResult()
    {
        var document = GetTestDocument();
        var result = document.Body.QuerySelectorAll("a");
        Assert.Empty(result);
    }

    [Fact]
    public void InvalidQueryOnNonEmptyNodeListShouldThrowException()
    {
        var document = GetTestDocument();
        Assert.ThrowsAny<DomException>(() => document.Body.QuerySelectorAll("<invalid>"));
    }

    [Fact]
    public void QueryEqValidIndexShouldYieldEntry()
    {
        var document = GetTestDocument();
        var item = document.QuerySelectorAll("li").Eq(3);
        Assert.NotNull(item);
        Assert.Equal("4", item.TextContent);
    }

    [Fact]
    public void InvalidQueryPseudoClassSelectorShouldYieldException()
    {
        var document = GetTestDocument();
        Assert.ThrowsAny<DomException>(() => document.QuerySelectorAll(":foo > p"));
    }

    [Fact]
    public void InvalidQueryPseudoClassFunctionSelectorShouldYieldException()
    {
        var document = GetTestDocument();
        Assert.ThrowsAny<DomException>(() => document.QuerySelectorAll(":bar(baz) > p"));
    }

    [Fact]
    public void InvalidQueryPseudoElementSelectorShouldYieldException()
    {
        var document = GetTestDocument();
        Assert.ThrowsAny<DomException>(() => document.QuerySelectorAll("::test > p"));
    }

    [Fact]
    public void QueryEqInvalidIndexShouldYieldNull()
    {
        var document = GetTestDocument();
        var item = document.QuerySelectorAll("li").Eq(6);
        Assert.Null(item);
    }

    [Fact]
    public void QueryLtShouldLimitEntries()
    {
        var document = GetTestDocument();
        var items = document.QuerySelectorAll("li").Lt(3);
        Assert.Equal(3, items.Count());
        Assert.Equal("First entry", items.Skip(0).First().TextContent);
        Assert.Equal("Second entry", items.Skip(1).First().TextContent);
        Assert.Equal("Third entry", items.Skip(2).First().TextContent);
    }

    [Fact]
    public void QueryLtZeroShouldYieldNoEntries()
    {
        var document = GetTestDocument();
        var items = document.QuerySelectorAll("li").Lt(0);
        Assert.Empty(items);
    }

    [Fact]
    public void QueryGtShouldLimitEntries()
    {
        var document = GetTestDocument();
        var items = document.QuerySelectorAll("li").Gt(3);
        Assert.Equal(2, items.Count());
        Assert.Equal("Fifth", items.Skip(0).First().TextContent);
        Assert.Equal("Last", items.Skip(1).First().TextContent);
    }

    [Fact]
    public void QueryGtZeroShouldYieldNoEntries()
    {
        var document = GetTestDocument();
        var items = document.QuerySelectorAll("li").Gt(6);
        Assert.Empty(items);
    }

    [Fact]
    public void QueryEvenShouldYieldOnlyEvenEntries()
    {
        var document = GetTestDocument();
        var items = document.QuerySelectorAll("li").Even();
        Assert.Equal(3, items.Count());
        Assert.Equal("First entry", items.Skip(0).First().TextContent);
        Assert.Equal("Third entry", items.Skip(1).First().TextContent);
        Assert.Equal("Fifth", items.Skip(2).First().TextContent);
    }

    [Fact]
    public void QueryOddShouldYieldOnlyOddEntries()
    {
        var document = GetTestDocument();
        var items = document.QuerySelectorAll("li").Odd();
        Assert.Equal(3, items.Count());
        Assert.Equal("Second entry", items.Skip(0).First().TextContent);
        Assert.Equal("4", items.Skip(1).First().TextContent);
        Assert.Equal("Last", items.Skip(2).First().TextContent);
    }
}
