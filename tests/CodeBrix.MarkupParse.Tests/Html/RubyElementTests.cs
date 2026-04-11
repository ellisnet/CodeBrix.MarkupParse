using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/ruby.dat
/// </summary>

public class RubyElementTests
{
    [Fact]
    public void RubyElementImpliedEndForRbWithRb()
    {
        var doc = (@"<html><ruby>a<rb>b<rb></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rb1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb1).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

        var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rb1Text0.TextContent);

        var dochtml0body1ruby0rb2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rb2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb2).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRbWithRt()
    {
        var doc = (@"<html><ruby>a<rb>b<rt></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rb1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb1).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

        var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rb1Text0.TextContent);

        var dochtml0body1ruby0rt2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rt2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rt2).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rt2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRbWithRtc()
    {
        var doc = (@"<html><ruby>a<rb>b<rtc></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rb1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb1).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

        var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rb1Text0.TextContent);

        var dochtml0body1ruby0rtc2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rtc2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc2).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRbWithRp()
    {
        var doc = (@"<html><ruby>a<rb>b<rp></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rb1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb1).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

        var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rb1Text0.TextContent);

        var dochtml0body1ruby0rp2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rp2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rp2).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rp2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp2.NodeType);
    }

    [Fact]
    public void RubyElementNoImpliedEndForRbWithSpan()
    {
        var doc = (@"<html><ruby>a<rb>b<span></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rb1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Equal(2, dochtml0body1ruby0rb1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0rb1).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb1.NodeType);

        var dochtml0body1ruby0rb1Text0 = dochtml0body1ruby0rb1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rb1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rb1Text0.TextContent);

        var dochtml0body1ruby0rb1span1 = dochtml0body1ruby0rb1.ChildNodes[1];
        Assert.Empty(dochtml0body1ruby0rb1span1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb1span1).Attributes);
        Assert.Equal("span", dochtml0body1ruby0rb1span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb1span1.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRtWithRb()
    {
        var doc = (@"<html><ruby>a<rt>b<rb></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rt1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rt1).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rt1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

        var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rt1Text0.TextContent);

        var dochtml0body1ruby0rb2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rb2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb2).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRtWithRt()
    {
        var doc = (@"<html><ruby>a<rt>b<rt></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rt1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rt1).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rt1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

        var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rt1Text0.TextContent);

        var dochtml0body1ruby0rt2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rt2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rt2).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rt2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRtWithRtc()
    {
        var doc = (@"<html><ruby>a<rt>b<rtc></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rt1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rt1).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rt1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

        var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rt1Text0.TextContent);

        var dochtml0body1ruby0rtc2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rtc2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc2).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRtWithRp()
    {
        var doc = (@"<html><ruby>a<rt>b<rp></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rt1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rt1).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rt1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

        var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rt1Text0.TextContent);

        var dochtml0body1ruby0rp2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rp2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rp2).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rp2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp2.NodeType);
    }

    [Fact]
    public void RubyElementNoImpliedEndForRtWithSpan()
    {
        var doc = (@"<html><ruby>a<rt>b<span></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rt1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Equal(2, dochtml0body1ruby0rt1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0rt1).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rt1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt1.NodeType);

        var dochtml0body1ruby0rt1Text0 = dochtml0body1ruby0rt1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rt1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rt1Text0.TextContent);

        var dochtml0body1ruby0rt1span1 = dochtml0body1ruby0rt1.ChildNodes[1];
        Assert.Empty(dochtml0body1ruby0rt1span1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rt1span1).Attributes);
        Assert.Equal("span", dochtml0body1ruby0rt1span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt1span1.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRtcWithRb()
    {
        var doc = (@"<html><ruby>a<rtc>b<rb></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rtc1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

        var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rtc1Text0.TextContent);

        var dochtml0body1ruby0rb2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rb2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb2).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb2.NodeType);
    }

    [Fact]
    public void RubyElementNoImpliedEndForRtcWithRt()
    {
        var doc = (@"<html><ruby>a<rtc>b<rt>c<rt>d</ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Equal(3, dochtml0body1ruby0rtc1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

        var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rtc1Text0.TextContent);

        var dochtml0body1ruby0rtc1rt1 = dochtml0body1ruby0rtc1.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rtc1rt1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1rt1).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rtc1rt1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1rt1.NodeType);

        var dochtml0body1ruby0rtc1rt1Text0 = dochtml0body1ruby0rtc1rt1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc1rt1Text0.NodeType);
        Assert.Equal("c", dochtml0body1ruby0rtc1rt1Text0.TextContent);

        var dochtml0body1ruby0rtc1rt2 = dochtml0body1ruby0rtc1.ChildNodes[2];
        Assert.Single(dochtml0body1ruby0rtc1rt2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1rt2).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rtc1rt2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1rt2.NodeType);

        var dochtml0body1ruby0rtc1rt2Text0 = dochtml0body1ruby0rtc1rt2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc1rt2Text0.NodeType);
        Assert.Equal("d", dochtml0body1ruby0rtc1rt2Text0.TextContent);
    }

    [Fact]
    public void RubyElementImpliedEndForRtcWithRtc()
    {
        var doc = (@"<html><ruby>a<rtc>b<rtc></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rtc1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

        var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rtc1Text0.TextContent);

        var dochtml0body1ruby0rtc2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rtc2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc2).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRtcWithRp()
    {
        var doc = (@"<html><ruby>a<rtc>b<rp></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Equal(2, dochtml0body1ruby0rtc1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

        var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rtc1Text0.TextContent);

        var dochtml0body1ruby0rtc1rp1 = dochtml0body1ruby0rtc1.ChildNodes[1];
        Assert.Empty(dochtml0body1ruby0rtc1rp1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1rp1).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rtc1rp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1rp1.NodeType);
    }

    [Fact]
    public void RubyElementNoImpliedEndForRtcWithSpan()
    {
        var doc = (@"<html><ruby>a<rtc>b<span></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rtc1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Equal(2, dochtml0body1ruby0rtc1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1.NodeType);

        var dochtml0body1ruby0rtc1Text0 = dochtml0body1ruby0rtc1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rtc1Text0.TextContent);

        var dochtml0body1ruby0rtc1span1 = dochtml0body1ruby0rtc1.ChildNodes[1];
        Assert.Empty(dochtml0body1ruby0rtc1span1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc1span1).Attributes);
        Assert.Equal("span", dochtml0body1ruby0rtc1span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc1span1.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRpWithRb()
    {
        var doc = (@"<html><ruby>a<rp>b<rb></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rp1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rp1).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

        var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rp1Text0.TextContent);

        var dochtml0body1ruby0rb2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rb2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rb2).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rb2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rb2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRpWithRt()
    {
        var doc = (@"<html><ruby>a<rp>b<rt></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rp1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rp1).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

        var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rp1Text0.TextContent);

        var dochtml0body1ruby0rt2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rt2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rt2).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rt2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rt2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRpWithRtc()
    {
        var doc = (@"<html><ruby>a<rp>b<rtc></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rp1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rp1).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

        var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rp1Text0.TextContent);

        var dochtml0body1ruby0rtc2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rtc2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc2).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc2.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndForRpWithRp()
    {
        var doc = (@"<html><ruby>a<rp>b<rp></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rp1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rp1).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

        var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rp1Text0.TextContent);

        var dochtml0body1ruby0rp2 = dochtml0body1ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rp2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rp2).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rp2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp2.NodeType);
    }

    [Fact]
    public void RubyElementNoImpliedEndForRpWithSpan()
    {
        var doc = (@"<html><ruby>a<rp>b<span></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0Text0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0Text0.TextContent);

        var dochtml0body1ruby0rp1 = dochtml0body1ruby0.ChildNodes[1];
        Assert.Equal(2, dochtml0body1ruby0rp1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0rp1).Attributes);
        Assert.Equal("rp", dochtml0body1ruby0rp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp1.NodeType);

        var dochtml0body1ruby0rp1Text0 = dochtml0body1ruby0rp1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rp1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rp1Text0.TextContent);

        var dochtml0body1ruby0rp1span1 = dochtml0body1ruby0rp1.ChildNodes[1];
        Assert.Empty(dochtml0body1ruby0rp1span1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rp1span1).Attributes);
        Assert.Equal("span", dochtml0body1ruby0rp1span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rp1span1.NodeType);
    }

    [Fact]
    public void RubyElementImpliedEndWithRuby()
    {
        var doc = (@"<html><ruby><rtc><ruby>a<rb>b<rt></ruby></ruby></html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1ruby0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0rtc0 = dochtml0body1ruby0.ChildNodes[0];
        Assert.Single(dochtml0body1ruby0rtc0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc0).Attributes);
        Assert.Equal("rtc", dochtml0body1ruby0rtc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc0.NodeType);

        var dochtml0body1ruby0rtc0ruby0 = dochtml0body1ruby0rtc0.ChildNodes[0];
        Assert.Equal(3, dochtml0body1ruby0rtc0ruby0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1ruby0rtc0ruby0).Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0rtc0ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc0ruby0.NodeType);

        var dochtml0body1ruby0rtc0ruby0Text0 = dochtml0body1ruby0rtc0ruby0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc0ruby0Text0.NodeType);
        Assert.Equal("a", dochtml0body1ruby0rtc0ruby0Text0.TextContent);

        var dochtml0body1ruby0rtc0ruby0rb1 = dochtml0body1ruby0rtc0ruby0.ChildNodes[1];
        Assert.Single(dochtml0body1ruby0rtc0ruby0rb1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc0ruby0rb1).Attributes);
        Assert.Equal("rb", dochtml0body1ruby0rtc0ruby0rb1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc0ruby0rb1.NodeType);

        var dochtml0body1ruby0rtc0ruby0rb1Text0 = dochtml0body1ruby0rtc0ruby0rb1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0rtc0ruby0rb1Text0.NodeType);
        Assert.Equal("b", dochtml0body1ruby0rtc0ruby0rb1Text0.TextContent);

        var dochtml0body1ruby0rtc0ruby0rt2 = dochtml0body1ruby0rtc0ruby0.ChildNodes[2];
        Assert.Empty(dochtml0body1ruby0rtc0ruby0rt2.ChildNodes);
        Assert.Empty(((Element)dochtml0body1ruby0rtc0ruby0rt2).Attributes);
        Assert.Equal("rt", dochtml0body1ruby0rtc0ruby0rt2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0rtc0ruby0rt2.NodeType);
    }
}
