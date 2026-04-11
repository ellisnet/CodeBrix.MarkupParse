using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Urls; //Was previously: namespace AngleSharp.Core.Tests.Urls

/// <summary>
/// Tests automatically generated from:
/// https://w3c-test.org/url/a-element.html
/// </summary>

public class UrlValidationTests
{
    private static IDocument Html(string code)
    {
        return code.ToHtmlDocument();
    }

    [Fact]
    public void DocumentUrlWithSpacesAndLineBreak()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example	.
org");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithEverythingSupplied()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://user:pass@foo:21/bar;par?b#c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("21", anchor.Port);
        Assert.Equal("/bar;par", anchor.PathName);
        Assert.Equal("?b", anchor.Search);
        Assert.Equal("#c", anchor.Hash);
        Assert.Equal("http://user:pass@foo:21/bar;par?b#c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithInvalidSchemeResolvingToFileName()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:foo.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/foo.com", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/foo.com", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithInvalidHostResolvingToFileName()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"	   :foo.com
");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:foo.com", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:foo.com", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithBareHostNameResolvingToFileName()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @" foo.com  ");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/foo.com", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/foo.com", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithProtocolAndHostName()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"a:	 foo.com");
        Assert.Equal("a:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal(" foo.com", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("a: foo.com", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithValidSchemeConvertedWithPercentEncoding()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://f:21/ b ? d # e ");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("f", anchor.HostName);
        Assert.Equal("21", anchor.Port);
        Assert.Equal("/%20b%20", anchor.PathName);
        Assert.Equal("?%20d%20", anchor.Search);
        Assert.Equal("# e", anchor.Hash);
        Assert.Equal("http://f:21/%20b%20?%20d%20# e", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithColonButMissingPort()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://f:/c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("f", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://f/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithPortZeroAndPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://f:0/c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("f", anchor.HostName);
        Assert.Equal("0", anchor.Port);
        Assert.Equal("/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://f:0/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithPortZerosAndPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://f:00000000000000/c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("f", anchor.HostName);
        Assert.Equal("0", anchor.Port);
        Assert.Equal("/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://f:0/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithStandardPortAndPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://f:00000000000000000000080/c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("f", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://f/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithColonButNoPortAndLineBreak()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://f:
/c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("f", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://f/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithStrangePortAndPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://f:999999/c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("f", anchor.HostName);
        Assert.Equal("999999", anchor.Port);
        Assert.Equal("/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://f:999999/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithNoRelativeUrlTakesAbsolutePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithSpacesTakesAbsolutePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"  	");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithInvalidSchemeTakesFileName()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @":foo.com/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:foo.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:foo.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithIncompleteRelativePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @":foo.com\");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:foo.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:foo.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithRelativeColonInterpretedAsPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @":");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithColonLetterInterpretedAsRelativePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @":a");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:a", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:a", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithColonSlashInterpretedAsRelativePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @":/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithColonBackslashInterpretedAsRelativePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @":\");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithColonNumberSignInterpretedAsFileAndHash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @":#");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:#", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithNumberSignInterpretedAsHash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"#");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/bar#", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithNumberSignSlashInterpretedAsHash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"#/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("#/", anchor.Hash);
        Assert.Equal("http://example.org/foo/bar#/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithNumberSignBackslashInterpretedAsHash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"#\");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal(@"#\", anchor.Hash);
        Assert.Equal(@"http://example.org/foo/bar#\", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest30()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"#;?");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("#;?", anchor.Hash);
        Assert.Equal("http://example.org/foo/bar#;?", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest31()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"?");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/bar?", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest32()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest33()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @":23");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:23", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:23", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest34()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/:23");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/:23", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/:23", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest35()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"::");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/::", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/::", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest36()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"::23");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/::23", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/::23", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest37()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"foo://");
        Assert.Equal("foo:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("//", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("foo://", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest38()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://a:b@c:29/d");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("c", anchor.HostName);
        Assert.Equal("29", anchor.Port);
        Assert.Equal("/d", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://a:b@c:29/d", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest39()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http::@c:29");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/:@c:29", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/:@c:29", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest40()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://&a:foo(b]c@d:2/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("d", anchor.HostName);
        Assert.Equal("2", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://&a:foo(b]c@d:2/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest41()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://::@c@d:2");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("d", anchor.HostName);
        Assert.Equal("2", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://:%3A%40c@d:2/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest42()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://foo.com:b@d/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("d", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://foo.com:b@d/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest43()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://foo.com/\@");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("//@", anchor.PathName);
            Assert.Equal("", anchor.Search);
            Assert.Equal("", anchor.Hash);
            Assert.Equal("http://foo.com//@", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest44()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:\\foo.com\");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://foo.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest45()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:\\a\b:c\d@foo.com\");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("a", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/b:c/d@foo.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://a/b:c/d@foo.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest46()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"foo:/");
        Assert.Equal("foo:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("foo:/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest47()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"foo:/bar.com/");
        Assert.Equal("foo:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/bar.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("foo:/bar.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest48()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"foo://///////");
        Assert.Equal("foo:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/////////", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("foo://///////", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest49()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"foo://///////bar.com/");
        Assert.Equal("foo:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/////////bar.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("foo://///////bar.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest50()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"foo:////://///");
        Assert.Equal("foo:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("////://///", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("foo:////://///", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlFileProtocolNotGivenShouldBeUnknownProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"c:/foo");
        Assert.Equal("c:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("c:/foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlProtocolRelativePathShouldBeHttp()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"//foo/bar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://foo/bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoubleQueryWithHashShouldBePreserved()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://foo/path;a??e#f#g");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/path;a", anchor.PathName);
        Assert.Equal("??e", anchor.Search);
        Assert.Equal("#f#g", anchor.Hash);
        Assert.Equal("http://foo/path;a??e#f#g", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoubleQueryShouldBePreserved()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://foo/abcd?efgh?ijkl");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/abcd", anchor.PathName);
        Assert.Equal("?efgh?ijkl", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://foo/abcd?efgh?ijkl", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlValidFullAddressWithSimpleHostname()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://foo/abcd#foo?bar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/abcd", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("#foo?bar", anchor.Hash);
        Assert.Equal("http://foo/abcd#foo?bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlRangesCountedAsRelativePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"[61:24:74]:98");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/[61:24:74]:98", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/[61:24:74]:98", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlHttpWithNoSlahesShouldGetDoubleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:[61:27]/:foo");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/[61:27]/:foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/[61:27]/:foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlHttpWithValidAddressShouldKeepIt()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://[2001::1]");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("[2001::1]", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://[2001::1]/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlHttpWithStandardPortShouldOmitPort()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://[2001::1]:80");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("[2001::1]", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://[2001::1]/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlHttpWithSingleSlashShouldGetSecondSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:/example.com/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlFtpWithSingleSlashShouldGetSecondSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftp:/example.com/");
        Assert.Equal("ftp:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftp://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlHttpsWithSingleSlashShouldGetSecondSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"https:/example.com/");
        Assert.Equal("https:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("https://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlCustomSchemeWithSingleSlashShouldBePreserved()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"madeupscheme:/example.com/");
        Assert.Equal("madeupscheme:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("madeupscheme:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlFileWithSingleSlashShouldBeThreeSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file:/example.com/");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlUnknownFtpsShouldBePreservedAtSingleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftps:/example.com/");
        Assert.Equal("ftps:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftps:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlGopherWithSingleSlashShouldBeTwoSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"gopher:/example.com/");
        Assert.Equal("gopher:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("gopher://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWebSocketWithSingleSlashShouldBeTwoSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ws:/example.com/");
        Assert.Equal("ws:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ws://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlSecureWebSocketWithSingleSlashShouldBeTwoSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"wss:/example.com/");
        Assert.Equal("wss:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("wss://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDataShouldPreserveSingleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"data:/example.com/");
        Assert.Equal("data:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("data:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlJavaScriptShouldPreserveSingleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"javascript:/example.com/");
        Assert.Equal("javascript:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("javascript:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlMailtoShouldPreserveSingleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"mailto:/example.com/");
        Assert.Equal("mailto:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("mailto:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlHttpWithNoSlashesShouldCountAsRelativePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:example.com/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/foo/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlFtpWithNoSlashesShouldBeAbsoluteWithTwoSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftp:example.com/");
        Assert.Equal("ftp:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftp://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlHttpsWithNoSlashesShouldBeAbsoluteWithTwoSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"https:example.com/");
        Assert.Equal("https:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("https://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlCustomProtocolWithNoSlashesShouldBePreserved()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"madeupscheme:example.com/");
        Assert.Equal("madeupscheme:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("madeupscheme:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlFtpsWithNoSlashesShouldBePreserved()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftps:example.com/");
        Assert.Equal("ftps:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftps:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlGopherProtocolShouldInsertDoubleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"gopher:example.com/");
        Assert.Equal("gopher:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("gopher://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWebSocketProtocolShouldInsertDoubleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ws:example.com/");
        Assert.Equal("ws:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ws://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlSecureWebSocketProtocolShouldInsertDoubleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"wss:example.com/");
        Assert.Equal("wss:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("wss://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDataProtocolShouldNotInsertSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"data:example.com/");
        Assert.Equal("data:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("data:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlJavaScriptProtocolShouldNotInsertSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"javascript:example.com/");
        Assert.Equal("javascript:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("javascript:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlMailToProtocolShouldNotInsertSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"mailto:example.com/");
        Assert.Equal("mailto:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("mailto:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlRootedPathShouldBeAbsolute()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/a/b/c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/a/b/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/a/b/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlSpaceInPathShouldBeEscaped()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/a/ /c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/a/%20/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/a/%20/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlEscapeSequenceInPathShouldBeEscapedAgain()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/a%2fc");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/a%2fc", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/a%2fc", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlPureEscapedNameShouldBeEscapedAgain()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/a/%2f/c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/a/%2f/c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.org/a/%2f/c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlSoloHashShouldBeTreatedAsRelativePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"#β");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("#β", anchor.Hash);
        Assert.Equal("http://example.org/foo/bar#β", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest92()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://example.org/foo/bar";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"data:text/html,test#test");
        Assert.Equal("data:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("text/html,test", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("#test", anchor.Hash);
        Assert.Equal("data:text/html,test#test", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest93()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file:c:\foo\bar.html");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/c:/foo/bar.html", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///c:/foo/bar.html", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest94()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"  File:c|////foo\bar.html");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/c:////foo/bar.html", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///c:////foo/bar.html", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest95()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"C|/foo/bar");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/C:/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///C:/foo/bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest96()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/C|\foo\bar");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/C:/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///C:/foo/bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest97()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"//C|/foo/bar");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/C:/foo/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///C:/foo/bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest98()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"//server/file");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("server", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/file", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file://server/file", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest99()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"\\server\file");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("server", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/file", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file://server/file", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest100()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/\server/file");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("server", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/file", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file://server/file", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest101()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file:///foo/bar.txt");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar.txt", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///foo/bar.txt", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest102()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file:///home/me");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/home/me", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///home/me", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest103()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"//");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest104()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"///");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest105()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"///test");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/test", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///test", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest106()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file://test");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("test", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file://test/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest107()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file://localhost");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("localhost", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file://localhost/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest108()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file://localhost/");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("localhost", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file://localhost/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest109()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file://localhost/test");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("localhost", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/test", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file://localhost/test", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldKeepProvidedFilePathWithThreeSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"test");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/tmp/mock/test", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///tmp/mock/test", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldKeepProvidedFilePathWithTwoSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"file:///tmp/mock/path";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file:test");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/tmp/mock/test", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///tmp/mock/test", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldNormalizeCurrentDots()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/././foo");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldNormalizeCurrentDot()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/./.foo");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/.foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/.foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldRemainInSameDirectoryNoExtraSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/.");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldRemainInSameDirectoryWithExtraSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/./");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldGoToParentDirectory()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/bar/..");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldGoToUpperDirectory()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/bar/../");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldPreserveTwoDotsIfLeading()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/..bar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/..bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/..bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldGoToAdjacentDirectory()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/bar/../ton");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/ton", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/ton", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldGoToTopDirectory()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/bar/../ton/../../a");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/a", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/a", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldStopGoingFurtherUpwards()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/../../..");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldStopGoingFurtherAndThenGoDown()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/../../../ton");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/ton", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/ton", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldResolveAndIgnoreCurrentDot()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/%2e");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldKeepInvalidSequence()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/%2e%2");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/%2e%2", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/%2e%2", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldActIfSomeDotsHaveBeenSeen()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/%2e./%2e%2e/.%2e/%2e.bar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%2e.bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/%2e.bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldUseTheDotsButKeepExtraSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com////../..");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("//", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com//", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldGoUpwardsWithRespectToEmptyName()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/bar//../..");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldLeaveEmptyDirectory()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo/bar//..");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/bar/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo/bar/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldJustRemainTheSame()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithLeadingPercentEncoding()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/%20foo");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%20foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/%20foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithSinglePercentEnding()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo%");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo%", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo%", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithIncompletePercentEncodingInPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo%2");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo%2", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo%2", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithInvalidPercentEncodingInPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo%2zbar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo%2zbar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo%2zbar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithNonAsciiCharsInPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo%2Â©zbar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo%2%C3%82%C2%A9zbar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo%2%C3%82%C2%A9zbar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithMixedPathStartingWithLetters()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo%41%7a");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo%41%7a", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo%41%7a", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithTabInPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo	%91");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo%C2%91%91", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo%C2%91%91", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithMixedPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo%00%51");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo%00%51", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foo%00%51", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithPercentEncodedPathInBrackets()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/(%28:%3A%29)");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/(%28:%3A%29)", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/(%28:%3A%29)", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithPercentEncodedPath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/%3A%3a%3C%3c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%3A%3a%3C%3c", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/%3A%3a%3C%3c", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithUnprintedSpace()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/foo	bar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foobar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/foobar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithMixtureOfSlashesAndBackslashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com\\foo\\bar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("//foo//bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com//foo//bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithCharactersThatRequirePercentEncoding()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/%7Ffp3%3Eju%3Dduvgw%3Dd");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%7Ffp3%3Eju%3Dduvgw%3Dd", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/%7Ffp3%3Eju%3Dduvgw%3Dd", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithAtCharacterAndPercentEncoding()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/@asdf%40");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/@asdf%40", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/@asdf%40", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithAsianCharactersThatNeedToBePercentEncoded()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/你好你好");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%E4%BD%A0%E5%A5%BD%E4%BD%A0%E5%A5%BD", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/%E4%BD%A0%E5%A5%BD%E4%BD%A0%E5%A5%BD", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithSpecialCdotCharacter()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/‥/foo");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%E2%80%A5/foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/%E2%80%A5/foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithVerySpecialSlashCharacterAsSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/﻿/foo");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%EF%BB%BF/foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/%EF%BB%BF/foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithSpecialCharactersAsSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://example.com/‮/foo/‭/bar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%E2%80%AE/foo/%E2%80%AD/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/%E2%80%AE/foo/%E2%80%AD/bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlWithPathSearchAndHash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://www.google.com/foo?bar=baz#");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.google.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo", anchor.PathName);
        Assert.Equal("?bar=baz", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.google.com/foo?bar=baz#", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlithSpecialCharactersInHash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://www.google.com/foo?bar=baz# »");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.google.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo", anchor.PathName);
        Assert.Equal("?bar=baz", anchor.Search);
        Assert.Equal("# »", anchor.Hash);
        Assert.Equal("http://www.google.com/foo?bar=baz# »", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlFromDataWithSpecialCharacters()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"data:test# »");
        Assert.Equal("data:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("test", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("# »", anchor.Hash);
        Assert.Equal("data:test# »", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlFromStandardGoogle()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://www.google.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.google.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.google.com/", anchor.Href);
        Assert.NotNull(document);
    }

    //TODO [Fact]
    internal void DocumentUrlWithHostAsIpInHex()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://192.0x00A80001");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("192.168.0.1", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://192.168.0.1/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlStrangeIntranetUrlWithPercentEncoding()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://www/foo%2Ehtml");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo%2Ehtml", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www/foo%2Ehtml", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlStrangeIntranetWithInvalidPercentEncoding()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://www/foo/%2E/html");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo/html", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www/foo/html", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlUserNameAndPasswordWithPercent()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://%25DOMAIN:foobar@foodomain.com/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foodomain.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://%25DOMAIN:foobar@foodomain.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlReplaceBackslashWithOrdinarySlashInGoogle()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:\\www.google.com\foo");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.google.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/foo", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.google.com/foo", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlReplaceHttpStandardPortWithBlank()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://foo:80/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceNonStandardHttpPortInUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://foo:81/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("81", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://foo:81/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplacePortInUnknownScheme()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"httpa://foo:80/");
        Assert.Equal("httpa:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("//foo:80/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("httpa://foo:80/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlReplaceStandardHttpsPortWithBlank()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"https://foo:443/");
        Assert.Equal("https:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("https://foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceHttpStandardPortInHttps()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"https://foo:80/");
        Assert.Equal("https:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("80", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("https://foo:80/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlReplaceStandardFtpPortWithBlank()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftp://foo:21/");
        Assert.Equal("ftp:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftp://foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceStandardHttpPortInFtp()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftp://foo:80/");
        Assert.Equal("ftp:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("80", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftp://foo:80/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlReplaceStandardGopherPortWithBlank()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"gopher://foo:70/");
        Assert.Equal("gopher:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("gopher://foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceStandardHttpsPortInGohperScheme()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"gopher://foo:443/");
        Assert.Equal("gopher:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("443", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("gopher://foo:443/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlReplaceStandardHttpPortInWebsocket()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ws://foo:80/");
        Assert.Equal("ws:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ws://foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceNonStandardHttpPortInWebSocket()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ws://foo:81/");
        Assert.Equal("ws:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("81", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ws://foo:81/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceStandardHttpsPortInWebSocket()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ws://foo:443/");
        Assert.Equal("ws:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("443", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ws://foo:443/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceNonStandardPortInWebSocket()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ws://foo:815/");
        Assert.Equal("ws:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("815", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ws://foo:815/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceStandardHttpPortInSecureWebSocket()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"wss://foo:80/");
        Assert.Equal("wss:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("80", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("wss://foo:80/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceNonStandardPortinSecureWebSocket()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"wss://foo:81/");
        Assert.Equal("wss:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("81", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("wss://foo:81/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlReplaceStandardHttpsPortInSecureWebSocketWithBlank()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"wss://foo:443/");
        Assert.Equal("wss:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("wss://foo/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotReplaceNonStandardPortInSecureWebSocket()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"wss://foo:815/");
        Assert.Equal("wss:", anchor.Protocol);
        Assert.Equal("foo", anchor.HostName);
        Assert.Equal("815", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("wss://foo:815/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashAfterProtocolForHttp()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:/example.com/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashAfterProtocolForFtp()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftp:/example.com/");
        Assert.Equal("ftp:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftp://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashAfterProtocolForHttps()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"https:/example.com/");
        Assert.Equal("https:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("https://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddPotentiallyMissingSlashAfterUnknownScheme()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"madeupscheme:/example.com/");
        Assert.Equal("madeupscheme:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("madeupscheme:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashAfterProtocolForFile()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"file:/example.com/");
        Assert.Equal("file:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("file:///example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddPotentiallyMissingSlashAfterProtocolForFtps()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftps:/example.com/");
        Assert.Equal("ftps:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftps:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashAfterProtocolForGopher()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"gopher:/example.com/");
        Assert.Equal("gopher:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("gopher://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashAfterProtocolForWebSockets()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ws:/example.com/");
        Assert.Equal("ws:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ws://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashAfterProtocolForSecureWebsockets()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"wss:/example.com/");
        Assert.Equal("wss:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("wss://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddSlashAfterProtocolForData()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"data:/example.com/");
        Assert.Equal("data:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("data:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddSlashAfterProtocolForJavaScript()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"javascript:/example.com/");
        Assert.Equal("javascript:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("javascript:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddSlashAfterProtocolForMailTo()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"mailto:/example.com/");
        Assert.Equal("mailto:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("mailto:/example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashesAfterHttpProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:example.com/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashesAfterFtpProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftp:example.com/");
        Assert.Equal("ftp:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftp://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashesAfterHttpsProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"https:example.com/");
        Assert.Equal("https:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("https://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddPotentiallyMissingSlashesAfterUnknownScheme()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"madeupscheme:example.com/");
        Assert.Equal("madeupscheme:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("madeupscheme:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddPotentiallyMissingSlashesAfterFtps()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ftps:example.com/");
        Assert.Equal("ftps:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ftps:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashesAfterGopherProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"gopher:example.com/");
        Assert.Equal("gopher:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("gopher://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashesAfterWsProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"ws:example.com/");
        Assert.Equal("ws:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("ws://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlAddMissingSlashesAfterWssProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"wss:example.com/");
        Assert.Equal("wss:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("wss://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddSlashesAfterDataProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"data:example.com/");
        Assert.Equal("data:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("data:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddSlashesAfterJavaScriptProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"javascript:example.com/");
        Assert.Equal("javascript:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("javascript:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlDoNotAddSlashesAfterMailToProtocol()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"mailto:example.com/");
        Assert.Equal("mailto:", anchor.Protocol);
        Assert.Equal("", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("example.com/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("mailto:example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldDropEverythingBeforeTheAtSignAndIgnoreMissingSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldDropEverythingBeforeTheAtSignAndIgnoreMissingSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:/@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldDropPartBeforeTheAtSign()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldAddMissingSlashesToPasswordUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:a:b@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://a:b@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldAddMissingSlashToPasswordUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:/a:b@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://a:b@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldHandleUserAndPasswordInUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://a:b@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://a:b@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldDropIllegalPartUntilAtLetter()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://@pple.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("pple.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://pple.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldHandlePasswordProtectedUrlWithoutSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http::b@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://:b@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldHandlePasswordProtectedUrlWithSingleSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:/:b@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://:b@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldHandlePasswordProtectedUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://:b@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://:b@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldIntegrateTheMissingSlashes()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:a:@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://a:@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldIntegrateTheSecondSlash()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http:/a:@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://a:@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldChangeToTheUsernameAndPasswordUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://a:@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://a:@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldSplitAtTheAtLetter()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://www.@pple.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("pple.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.@pple.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldChangeTheWholeUrlWithUsernameAndPassword()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://:@www.example.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://:@www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldSetTheAbsolutePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldUseTheAbsolutePath()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"/test.txt");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/test.txt", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/test.txt", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldLeaveTheCurrentPathUnmodified()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @".");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldGoOneDirectoryUp()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"..");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldUseCurrentDirectory()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"test.txt");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/test.txt", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/test.txt", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldStayInCurrentDirectory()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"./test.txt");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/test.txt", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/test.txt", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldBeAbleToGoOneDirectorUp()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"../test.txt");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/test.txt", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/test.txt", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldBeAbleToGoOneDirectorUpAndDown()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"../aaa/test.txt");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/aaa/test.txt", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/aaa/test.txt", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldBeAbleToGoTwoDirectoriesUp()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"../../test.txt");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/test.txt", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/test.txt", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldTransformJapaneseLetter()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"中/test.txt");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/%E4%B8%AD/test.txt", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example.com/%E4%B8%AD/test.txt", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldHandleValidAbsoluteUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://www.example2.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example2.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example2.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldHandleSchemeRelativeUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://www.example.com/test";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"//www.example2.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.example2.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.example2.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldLowerCase()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://ExAmPlE.CoM");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldDropForbiddenHiddenSpace()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://GOO​⁠﻿goo.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("googoo.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://googoo.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldDropLeadingAndTrailingC0ControlOrSpace()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", "\u0000\u001b\u0004\u0012 http://example.com/\u001f \u000d ");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://example.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldDropTabLFCR()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://host:9000";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", "h\tt\nt\rp://h\to\ns\rt:9\t0\n0\r0/p\ta\nt\rh?q\tu\ne\rry#f\tr\na\rg");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("host", anchor.HostName);
        Assert.Equal("9000", anchor.Port);
        Assert.Equal("/path", anchor.PathName);
        Assert.Equal("?query", anchor.Search);
        Assert.Equal("#frag", anchor.Hash);
        Assert.Equal("http://host:9000/path?query#frag", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldDoUtf8PercentDecoding()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", "https://%e2%98%83");
        Assert.Equal("https:", anchor.Protocol);
        Assert.Equal("xn--n3h", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("https://xn--n3h/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldTransformBigDot()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://www.foo。bar.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("www.foo.bar.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://www.foo.bar.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldTransformAlternativeGAndOLetters()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://Ｇｏ.com");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("go.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://go.com/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlTest253()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://你好你好");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("xn--6qqa088eba", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://xn--6qqa088eba/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldCorrectlyTransformPercentEncodedHostname()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://%30%78%63%30%2e%30%32%35%30.01");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("0xc0.0250.01", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://0xc0.0250.01/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldTransformPercentUrl()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://%30%78%63%30%2e%30%32%35%30.01%2e");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("0xc0.0250.01.", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://0xc0.0250.01./", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldConvertSpecialNumbers()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://０Ｘｃ０．０２５０．０１");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("0xc0.0250.01", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://0xc0.0250.01/", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldHandleUnicodeInPassword()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"http://other.com/";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", @"http://foo:💩@example.com/bar");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.com", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/bar", anchor.PathName);
        Assert.Equal("", anchor.Search);
        Assert.Equal("", anchor.Hash);
        Assert.Equal("http://foo:%F0%9F%92%A9@example.com/bar", anchor.Href);
        Assert.NotNull(document);
    }

    [Fact]
    public void DocumentUrlShouldHandleNullCodePointInFragment()
    {
        var document = Html("<base id=base>");
        var element = document.GetElementById("base") as HtmlBaseElement;
        Assert.NotNull(element);
        element.Href = @"about:blank";
        var anchor = document.CreateElement<IHtmlAnchorElement>();
        anchor.SetAttribute("href", "http://example.org/test?a#b\u0000c");
        Assert.Equal("http:", anchor.Protocol);
        Assert.Equal("example.org", anchor.HostName);
        Assert.Equal("", anchor.Port);
        Assert.Equal("/test", anchor.PathName);
        Assert.Equal("?a", anchor.Search);
        Assert.Equal("#bc", anchor.Hash);
        Assert.Equal("http://example.org/test?a#bc", anchor.Href);
        Assert.NotNull(document);
    }
}
