using CodeBrix.MarkupParse.Css;
using CodeBrix.MarkupParse.Css.Dom;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Parser;
using CodeBrix.MarkupParse.Io;
using CodeBrix.MarkupParse.Text;
using Xunit;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CodeBrix.MarkupParse.Tests.Css; //Was previously: namespace AngleSharp.Core.Tests.Css

public class StylesheetExtensions
{
    [InlineData(10)]
    [InlineData(100)]
    [InlineData(1000)]
    [InlineData(10000)]
    [Theory]
    public void TestStyleSheetsDoesNotThrowStackOverflowException(int count)
    {
        var thread = new Thread(() =>
        {
            var beginTags = string.Join("", Enumerable.Repeat("<div>", count));
            var endTags = string.Join("", Enumerable.Repeat("</div>", count));
            var html = $"<html><head><style></style></head><body>{beginTags}<span><style></style></span>{endTags}</body></html>";

            var stylingService = new MockStylingService();
            var context = BrowsingContext.New(Configuration.Default.WithOnly<IStylingService>(stylingService));
            var document = context.GetService<IHtmlParser>()!.ParseDocument(html);

            var sheets = document.StyleSheets;
            Assert.Equal(2, sheets.Length);
            Assert.Equal("HEAD", sheets[0]!.OwnerNode.ParentElement?.TagName);
            Assert.Equal("SPAN", sheets[1]!.OwnerNode.ParentElement?.TagName);

        }, (64 + 1) * 1024);

        thread.Start();
        thread.Join();
    }

    [Fact]
    public async Task AppendingStylesheetLinkShouldLoadResource()
    {
        var request = default(Request);

        var stylingService = new MockStylingService();
        var cfg = Configuration.Default
                                    .WithOnly<IStylingService>(stylingService)
                                    .WithMockRequester(req => request = req);
        var html = @"<!doctype html><head><link rel=stylesheet href=/mock-stylesheet-1.css /></head><body></body>";
        var document = await BrowsingContext.New(cfg).OpenAsync(m => m.Content(html), TestContext.Current.CancellationToken);

        // test with link element in the initial HTML
        Assert.NotNull(request);
        Assert.Equal("/mock-stylesheet-1.css", request.Address.PathName);

        request = default(Request);

        // test with dynamically added link element
        var link = document.CreateElement("link");
        link.SetAttribute(AttributeNames.Rel, "stylesheet");
        link.SetAttribute(AttributeNames.Href, "/mock-stylesheet-2.css");

        document.Body.AppendChild(link);

        Assert.NotNull(request);
        Assert.Equal("/mock-stylesheet-2.css", request.Address.PathName);
    }

    [Fact]
    public async Task HtmlInlineStyleSheetShouldLoad()
    {
        var stylingService = new MockStylingService();
        var cfg = Configuration.Default.WithOnly<IStylingService>(stylingService);
        var html = @"<!doctype html><head><style>p { color: blue; }</style></head><body></body>";
        var document = await BrowsingContext.New(cfg).OpenAsync(m => m.Content(html), TestContext.Current.CancellationToken);

        Assert.Single(document.Head.ChildNodes);

        var htmlHeadStyle = document.Head.ChildNodes[0];
        Assert.Equal("style", htmlHeadStyle.GetTagName());
        Assert.Equal(NodeType.Element, htmlHeadStyle.NodeType);

        var style = htmlHeadStyle as ILinkStyle;
        Assert.NotNull(style);
        Assert.Equal("p { color: blue; }", style.Sheet.OwnerNode.TextContent);
    }

    [Fact]
    public async Task SvgInlineStyleSheetShouldLoad()
    {
        var stylingService = new MockStylingService();
        var cfg = Configuration.Default.WithOnly<IStylingService>(stylingService);
        var svg = @"<svg><style>circle { fill: gold; }</style></svg>";
        var document = await BrowsingContext.New(cfg).OpenAsync(m => m.Content(svg), TestContext.Current.CancellationToken);

        Assert.Single(document.Body.ChildNodes);

        var svgBodySvg = document.Body.ChildNodes[0];
        Assert.Single(svgBodySvg.ChildNodes);
        Assert.Equal("svg", svgBodySvg.GetTagName());
        Assert.Equal(NodeType.Element, svgBodySvg.NodeType);

        var svgBodySvgStyle = svgBodySvg.ChildNodes[0];
        Assert.Equal("style", svgBodySvgStyle.GetTagName());
        Assert.Equal(NodeType.Element, svgBodySvgStyle.NodeType);

        var style = svgBodySvgStyle as ILinkStyle;
        Assert.NotNull(style);
        Assert.Equal("circle { fill: gold; }", style.Sheet.OwnerNode.TextContent);
    }
}

internal class MockStylingService : IStylingService
{
    public bool SupportsType(string mimeType) => "text/css" == mimeType;

    public Task<IStyleSheet> ParseStylesheetAsync(IResponse response, StyleOptions options, CancellationToken cancel)
    {
        return Task.FromResult<IStyleSheet>(new MockStyleSheet(options));
    }
}

internal class MockStyleSheet : IStyleSheet
{
    private readonly StyleOptions _options;
    private readonly IMediaList _mediaList;

    public MockStyleSheet(StyleOptions options)
    {
        _options = options;
        _mediaList = new MockMediaList();
    }

    public void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
    }

    public string Type { get; } = "text/css";

    public string Href { get; } = null;

    public IElement OwnerNode => _options.Element;

    public string Title { get; } = "";

    public IMediaList Media { get => _mediaList; }

    public bool IsDisabled { get => _options.IsDisabled; set { } }

    public IBrowsingContext Context => _options.Document.Context;

    public TextSource Source { get; } = null;

    public void SetOwner(IElement element)
    {
    }

    public string LocateNamespace(string prefix) => null;
}

internal class MockMediaList : IMediaList
{
    public string this[int index] => "";

    public string MediaText { get; set; } = "";

    public int Length => 0;

    public void Add(string medium)
    {
    }

    public IEnumerator<ICssMedium> GetEnumerator()
    {
        return default;
    }

    public void Remove(string medium)
    {
    }

    public void ToCss(TextWriter writer, IStyleFormatter formatter)
    {
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return default;
    }
}
