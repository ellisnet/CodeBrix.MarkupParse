using CodeBrix.MarkupParse.Css;
using CodeBrix.MarkupParse.Css.Dom;
using CodeBrix.MarkupParse.Css.Parser;
using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Css; //Was previously: namespace AngleSharp.Core.Tests.Css

public class SelectorPriorityTests
{
    [Fact]
    public void IdentifyMultiSelector_Issue1161()
    {
        var source = @"<h3 id='target'>Test</h3>";
        var doc = source.ToHtmlDocument();
        var selector = doc.Context.GetService<ICssSelectorParser>().ParseSelector("h3, #notarget");

        Assert.Equal(new Priority(0, 1, 0, 0), selector.Specificity);

        var ms = selector as IMultiSelector;

        var subSelector = ms.GetMatchingSelector(doc.QuerySelector("h3, #notarget"));

        Assert.Equal(new Priority(0, 0, 0, 1), subSelector.Specificity);
    }

    [Fact]
    public void MultiSelectorReturnsNullIfNothingMatches_Issue1161()
    {
        var source = @"<h3 id='target'>Test</h3>";
        var doc = source.ToHtmlDocument();
        var selector = doc.Context.GetService<ICssSelectorParser>().ParseSelector("h3, #notarget");

        Assert.Equal(new Priority(0, 1, 0, 0), selector.Specificity);

        var ms = selector as IMultiSelector;

        var subSelector = ms.GetMatchingSelector(doc.QuerySelector("body"));

        Assert.Null(subSelector);
    }

    [Fact]
    public void MultiSelectorReturnsHighestPrioIfMultiMatches_Issue1161()
    {
        var source = @"<h3 id='target'>Test</h3>";
        var doc = source.ToHtmlDocument();
        var selector = doc.Context.GetService<ICssSelectorParser>().ParseSelector("h3, #target");

        Assert.Equal(new Priority(0, 1, 0, 0), selector.Specificity);

        var ms = selector as IMultiSelector;

        var subSelector = ms.GetMatchingSelector(doc.QuerySelector("h3"));

        Assert.Equal(new Priority(0, 1, 0, 0), subSelector.Specificity);
    }

    [Fact]
    public void IsSelectorMatchesInside()
    {
        var selectorText = $@":is(article, section, aside) h1";
        var source = @"<section><div><h1>Foo</h1></div></section><p><h1>Other</h1></p>";
        var doc = source.ToHtmlDocument();

        var result = doc.QuerySelectorAll(selectorText);
        Assert.Single(result);

        Assert.Equal("div", result[0].ParentElement.LocalName);
    }

    [Fact]
    public void NotSelectorWhenNotMatchesInside()
    {
        var selectorText = $@":not(article, section, aside) h1";
        var source = @"<section><div><h1>Foo</h1></div></section><p><h1>Other</h1></p>";
        var doc = source.ToHtmlDocument();

        var result = doc.QuerySelectorAll(selectorText);
        Assert.Equal(2, result.Length);
    }

    [Fact]
    public void HasSelectorWithFollowUpWorks()
    {
        var selectorText = $@"h1:has(+ p)";
        var source = @"<h1>Foo</h1><p>Text</p><h1>Other</h1>";
        var doc = source.ToHtmlDocument();

        var result = doc.QuerySelectorAll(selectorText);
        Assert.Single(result);

        Assert.Equal("Foo", result[0].TextContent);
    }

    [Fact]
    public void WhereHasZeroSpecificity()
    {
        var source = @"<h3 id='target'>Test</h3>";
        var doc = source.ToHtmlDocument();
        var selector = doc.Context.GetService<ICssSelectorParser>().ParseSelector(":where(h1)");

        Assert.Equal(new Priority(0, 0, 0, 0), selector.Specificity);
    }

    [Fact]
    public void NestedSelectorRepresentsScopingRoot()
    {
        var source = @"<h3 id='target'>Test</h3>";
        var doc = source.ToHtmlDocument();
        var selector = doc.Context.GetService<ICssSelectorParser>().ParseSelector("&");

        Assert.Equal(new Priority(0, 0, 1, 0), selector.Specificity);
    }

    [Fact]
    public void IsSelectorIsForgiving()
    {
        var source = @"<div class=valid-class>Foo</div>";
        var selectorText = ":is(.valid-class, :invalid-pseudo-class)";
        var doc = source.ToHtmlDocument();

        var result = doc.QuerySelectorAll(selectorText);
        Assert.Single(result);

        Assert.Equal("Foo", result[0].TextContent);
    }

    [Fact]
    public void StandardSelectorIsNotForgiving()
    {
        var source = @"<div class=valid-class>Foo</div>";
        var selectorText = ".valid-class, :invalid-pseudo-class";
        var doc = source.ToHtmlDocument();

        Assert.Throws<DomException>(() =>
        {
            doc.QuerySelectorAll(selectorText);
        });
    }
}
