using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests6.dat,
/// tree-construction/tests7.dat,
/// tree-construction/tests8.dat
/// </summary>

public class FosterParentingTests
{
    [Fact]
    public void FosterDivInDivMisclosedSpan()
    {
        var doc = (@"<div>
<div></div>
</span>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0body1div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("\n", dochtml0body1div0Text0.TextContent);

        var dochtml0body1div0div1 = dochtml0body1div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0div1.ChildNodes);
        Assert.Empty(dochtml0body1div0div1.Attributes);
        Assert.Equal("div", dochtml0body1div0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0div1.NodeType);

        var dochtml0body1div0Text2 = dochtml0body1div0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text2.NodeType);
        Assert.Equal("\nx", dochtml0body1div0Text2.TextContent);
    }

    [Fact]
    public void FosterTextAndDivInDivMisclosedSpan()
    {
        var doc = (@"<div>x<div></div>
</span>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0body1div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("x", dochtml0body1div0Text0.TextContent);

        var dochtml0body1div0div1 = dochtml0body1div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0div1.ChildNodes);
        Assert.Empty(dochtml0body1div0div1.Attributes);
        Assert.Equal("div", dochtml0body1div0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0div1.NodeType);

        var dochtml0body1div0Text2 = dochtml0body1div0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text2.NodeType);
        Assert.Equal("\nx", dochtml0body1div0Text2.TextContent);
    }

    [Fact]
    public void FosterTextAndDivInDivMisclosedSpanWithText()
    {
        var doc = (@"<div>x<div></div>x</span>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0body1div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("x", dochtml0body1div0Text0.TextContent);

        var dochtml0body1div0div1 = dochtml0body1div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0div1.ChildNodes);
        Assert.Empty(dochtml0body1div0div1.Attributes);
        Assert.Equal("div", dochtml0body1div0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0div1.NodeType);

        var dochtml0body1div0Text2 = dochtml0body1div0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text2.NodeType);
        Assert.Equal("xx", dochtml0body1div0Text2.TextContent);
    }

    [Fact]
    public void FosterTextAndDivInDivWithTextMisclosedSpan()
    {
        var doc = (@"<div>x<div></div>y</span>z").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0body1div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("x", dochtml0body1div0Text0.TextContent);

        var dochtml0body1div0div1 = dochtml0body1div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0div1.ChildNodes);
        Assert.Empty(dochtml0body1div0div1.Attributes);
        Assert.Equal("div", dochtml0body1div0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0div1.NodeType);

        var dochtml0body1div0Text2 = dochtml0body1div0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text2.NodeType);
        Assert.Equal("yz", dochtml0body1div0Text2.TextContent);
    }

    [Fact]
    public void FosterDivAndTextInDivAndTable()
    {
        var doc = (@"<table><div>x<div></div>x</span>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0body1div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("x", dochtml0body1div0Text0.TextContent);

        var dochtml0body1div0div1 = dochtml0body1div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0div1.ChildNodes);
        Assert.Empty(dochtml0body1div0div1.Attributes);
        Assert.Equal("div", dochtml0body1div0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0div1.NodeType);

        var dochtml0body1div0Text2 = dochtml0body1div0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text2.NodeType);
        Assert.Equal("xx", dochtml0body1div0Text2.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);
    }

    [Fact]
    public void FosterTextInTable()
    {
        var doc = (@"x<table>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("xx", dochtml0body1Text0.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);
    }

    [Fact]
    public void FosterTableInTable()
    {
        var doc = (@"x<table><table>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(4, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("x", dochtml0body1Text0.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("x", dochtml0body1Text2.TextContent);

        var dochtml0body1table3 = dochtml0body1.ChildNodes[3] as Element;
        Assert.Empty(dochtml0body1table3.ChildNodes);
        Assert.Empty(dochtml0body1table3.Attributes);
        Assert.Equal("table", dochtml0body1table3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table3.NodeType);
    }

    [Fact]
    public void FosterDivsInBoldFormatting()
    {
        var doc = (@"<b>a<div></div><div></b>y").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1b0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1b0.ChildNodes.Length);
        Assert.Empty(dochtml0body1b0.Attributes);
        Assert.Equal("b", dochtml0body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b0.NodeType);

        var dochtml0body1b0Text0 = dochtml0body1b0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1b0Text0.NodeType);
        Assert.Equal("a", dochtml0body1b0Text0.TextContent);

        var dochtml0body1b0div1 = dochtml0body1b0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1b0div1.ChildNodes);
        Assert.Empty(dochtml0body1b0div1.Attributes);
        Assert.Equal("div", dochtml0body1b0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b0div1.NodeType);

        var dochtml0body1div1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1div1.ChildNodes.Length);
        Assert.Empty(dochtml0body1div1.Attributes);
        Assert.Equal("div", dochtml0body1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1.NodeType);

        var dochtml0body1div1b0 = dochtml0body1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div1b0.ChildNodes);
        Assert.Empty(dochtml0body1div1b0.Attributes);
        Assert.Equal("b", dochtml0body1div1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1b0.NodeType);

        var dochtml0body1div1Text1 = dochtml0body1div1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1div1Text1.NodeType);
        Assert.Equal("y", dochtml0body1div1Text1.TextContent);
    }

    [Fact]
    public void FosterParagraphAndDivInAnchor()
    {
        var doc = (@"<a><div><p></a>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1a0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1a0.ChildNodes);
        Assert.Empty(dochtml0body1a0.Attributes);
        Assert.Equal("a", dochtml0body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0.NodeType);

        var dochtml0body1div1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1div1.ChildNodes.Length);
        Assert.Empty(dochtml0body1div1.Attributes);
        Assert.Equal("div", dochtml0body1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1.NodeType);

        var dochtml0body1div1a0 = dochtml0body1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1a0.NodeType);

        var dochtml0body1div1p1 = dochtml0body1div1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1div1p1.ChildNodes);
        Assert.Empty(dochtml0body1div1p1.Attributes);
        Assert.Equal("p", dochtml0body1div1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1p1.NodeType);

        var dochtml0body1div1p1a0 = dochtml0body1div1p1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div1p1a0.ChildNodes);
        Assert.Empty(dochtml0body1div1p1a0.Attributes);
        Assert.Equal("a", dochtml0body1div1p1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1p1a0.NodeType);
    }

    [Fact]
    public void FosterTitleInBody()
    {
        var doc = (@"<!doctype html><body><title>X</title>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1title0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1title0.ChildNodes);
        Assert.Empty(dochtml1body1title0.Attributes);
        Assert.Equal("title", dochtml1body1title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1title0.NodeType);

        var dochtml1body1title0Text0 = dochtml1body1title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1title0Text0.NodeType);
        Assert.Equal("X", dochtml1body1title0Text0.TextContent);
    }

    [Fact]
    public void FosterTitleInTable()
    {
        var doc = (@"<!doctype html><table><title>X</title></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1title0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1title0.ChildNodes);
        Assert.Empty(dochtml1body1title0.Attributes);
        Assert.Equal("title", dochtml1body1title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1title0.NodeType);

        var dochtml1body1title0Text0 = dochtml1body1title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1title0Text0.NodeType);
        Assert.Equal("X", dochtml1body1title0Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);
    }

    [Fact]
    public void FosterTitleOutsideHead()
    {
        var doc = (@"<!doctype html><head></head><title>X</title>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0title0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0title0.ChildNodes);
        Assert.Empty(dochtml1head0title0.Attributes);
        Assert.Equal("title", dochtml1head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0title0.NodeType);

        var dochtml1head0title0Text0 = dochtml1head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0title0Text0.NodeType);
        Assert.Equal("X", dochtml1head0title0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void FosterMisclosedHeadAndTitle()
    {
        var doc = (@"<!doctype html></head><title>X</title>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0title0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0title0.ChildNodes);
        Assert.Empty(dochtml1head0title0.Attributes);
        Assert.Equal("title", dochtml1head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0title0.NodeType);

        var dochtml1head0title0Text0 = dochtml1head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0title0Text0.NodeType);
        Assert.Equal("X", dochtml1head0title0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void FosterMetaInTable()
    {
        var doc = (@"<!doctype html><table><meta></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1meta0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1meta0.ChildNodes);
        Assert.Empty(dochtml1body1meta0.Attributes);
        Assert.Equal("meta", dochtml1body1meta0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1meta0.NodeType);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);
    }

    [Fact]
    public void FosterMetaInTableInTableCell()
    {
        var doc = (@"<!doctype html><table>X<tr><td><table> <meta></table></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("X", dochtml1body1Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);

        var dochtml1body1table1tbody0 = dochtml1body1table1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table1tbody0.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0.NodeType);

        var dochtml1body1table1tbody0tr0 = dochtml1body1table1tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table1tbody0tr0.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml1body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0tr0.NodeType);

        var dochtml1body1table1tbody0tr0td0 = dochtml1body1table1tbody0tr0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table1tbody0tr0td0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table1tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml1body1table1tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0tr0td0.NodeType);

        var dochtml1body1table1tbody0tr0td0meta0 = dochtml1body1table1tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table1tbody0tr0td0meta0.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0tr0td0meta0.Attributes);
        Assert.Equal("meta", dochtml1body1table1tbody0tr0td0meta0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0tr0td0meta0.NodeType);

        var dochtml1body1table1tbody0tr0td0table1 = dochtml1body1table1tbody0tr0td0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table1tbody0tr0td0table1.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0tr0td0table1.Attributes);
        Assert.Equal("table", dochtml1body1table1tbody0tr0td0table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0tr0td0table1.NodeType);

        var dochtml1body1table1tbody0tr0td0table1Text0 = dochtml1body1table1tbody0tr0td0table1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table1tbody0tr0td0table1Text0.NodeType);
        Assert.Equal(" ", dochtml1body1table1tbody0tr0td0table1Text0.TextContent);
    }

    [Fact]
    public void FosterSpaceBeforeHead()
    {
        var doc = (@"<!doctype html><html> <head>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void FosterSpaceBeforeHtml()
    {
        var doc = (@"<!doctype html> <head>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void FosterStyleInTableWithSpaces()
    {
        var doc = (@"<!doctype html><table><style> <tr>x </style> </table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0style0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0style0.ChildNodes);
        Assert.Empty(dochtml1body1table0style0.Attributes);
        Assert.Equal("style", dochtml1body1table0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0style0.NodeType);

        var dochtml1body1table0style0Text0 = dochtml1body1table0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0style0Text0.NodeType);
        Assert.Equal(" <tr>x ", dochtml1body1table0style0Text0.TextContent);

        var dochtml1body1table0Text1 = dochtml1body1table0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1table0Text1.NodeType);
        Assert.Equal(" ", dochtml1body1table0Text1.TextContent);
    }

    [Fact]
    public void FosterScriptInTbodyInTable()
    {
        var doc = (@"<!doctype html><table><TBODY><script> <tr>x </script> </table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0tbody0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0tbody0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0.NodeType);

        var dochtml1body1table0tbody0script0 = dochtml1body1table0tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0script0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0script0.Attributes);
        Assert.Equal("script", dochtml1body1table0tbody0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0script0.NodeType);

        var dochtml1body1table0tbody0script0Text0 = dochtml1body1table0tbody0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0script0Text0.NodeType);
        Assert.Equal(" <tr>x ", dochtml1body1table0tbody0script0Text0.TextContent);

        var dochtml1body1table0tbody0Text1 = dochtml1body1table0tbody0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0Text1.NodeType);
        Assert.Equal(" ", dochtml1body1table0tbody0Text1.TextContent);
    }

    [Fact]
    public void FosterAppletInParagraph()
    {
        var doc = (@"<!doctype html><p><applet><p>X</p></applet>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1p0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0.ChildNodes);
        Assert.Empty(dochtml1body1p0.Attributes);
        Assert.Equal("p", dochtml1body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0.NodeType);

        var dochtml1body1p0applet0 = dochtml1body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0applet0.ChildNodes);
        Assert.Empty(dochtml1body1p0applet0.Attributes);
        Assert.Equal("applet", dochtml1body1p0applet0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0applet0.NodeType);

        var dochtml1body1p0applet0p0 = dochtml1body1p0applet0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1p0applet0p0.ChildNodes);
        Assert.Empty(dochtml1body1p0applet0p0.Attributes);
        Assert.Equal("p", dochtml1body1p0applet0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0applet0p0.NodeType);

        var dochtml1body1p0applet0p0Text0 = dochtml1body1p0applet0p0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p0applet0p0Text0.NodeType);
        Assert.Equal("X", dochtml1body1p0applet0p0Text0.TextContent);
    }

    [Fact]
    public void FosterListingBeforeHtml()
    {
        var doc = (@"<!doctype html><listing>
X</listing>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1listing0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1listing0.ChildNodes);
        Assert.Empty(dochtml1body1listing0.Attributes);
        Assert.Equal("listing", dochtml1body1listing0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1listing0.NodeType);

        var dochtml1body1listing0Text0 = dochtml1body1listing0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1listing0Text0.NodeType);
        Assert.Equal("X", dochtml1body1listing0Text0.TextContent);
    }

    [Fact]
    public void FosterSelectWithMisnestedInput()
    {
        var doc = (@"<!doctype html><select><input>X").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(3, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1select0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1select0.ChildNodes);
        Assert.Empty(dochtml1body1select0.Attributes);
        Assert.Equal("select", dochtml1body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1select0.NodeType);

        var dochtml1body1input1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1input1.ChildNodes);
        Assert.Empty(dochtml1body1input1.Attributes);
        Assert.Equal("input", dochtml1body1input1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1input1.NodeType);

        var dochtml1body1Text2 = dochtml1body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml1body1Text2.NodeType);
        Assert.Equal("X", dochtml1body1Text2.TextContent);
    }

    [Fact]
    public void FosterSelectInSelect()
    {
        var doc = (@"<!doctype html><select><select>X").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1select0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1select0.ChildNodes);
        Assert.Empty(dochtml1body1select0.Attributes);
        Assert.Equal("select", dochtml1body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1select0.NodeType);

        var dochtml1body1Text1 = dochtml1body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1Text1.NodeType);
        Assert.Equal("X", dochtml1body1Text1.TextContent);
    }

    [Fact]
    public void FosterInputInTable()
    {
        var doc = (@"<!doctype html><table><input type=hidDEN></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0input0 = dochtml1body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table0input0.ChildNodes);
        Assert.Single(dochtml1body1table0input0.Attributes);
        Assert.Equal("input", dochtml1body1table0input0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0input0.NodeType);
        Assert.Equal("hidDEN", dochtml1body1table0input0.GetAttribute("type"));
    }

    [Fact]
    public void FosterInputAndTextInTable()
    {
        var doc = (@"<!doctype html><table>X<input type=hidDEN></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("X", dochtml1body1Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);

        var dochtml1body1table1input0 = dochtml1body1table1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table1input0.ChildNodes);
        Assert.Single(dochtml1body1table1input0.Attributes);
        Assert.Equal("input", dochtml1body1table1input0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1input0.NodeType);
        Assert.Equal("hidDEN", dochtml1body1table1input0.GetAttribute("type"));
    }

    [Fact]
    public void FosterSpacesAndInputInTable()
    {
        var doc = (@"<!doctype html><table>  <input type=hidDEN></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0Text0 = dochtml1body1table0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0Text0.NodeType);
        Assert.Equal("  ", dochtml1body1table0Text0.TextContent);

        var dochtml1body1table0input1 = dochtml1body1table0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table0input1.ChildNodes);
        Assert.Single(dochtml1body1table0input1.Attributes);
        Assert.Equal("input", dochtml1body1table0input1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0input1.NodeType);
        Assert.Equal("hidDEN", dochtml1body1table0input1.GetAttribute("type"));
    }

    [Fact]
    public void FosterInputAndSpacesWithAttributeInTable()
    {
        var doc = (@"<!doctype html><table>  <input type='hidDEN'></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0Text0 = dochtml1body1table0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0Text0.NodeType);
        Assert.Equal("  ", dochtml1body1table0Text0.TextContent);

        var dochtml1body1table0input1 = dochtml1body1table0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1table0input1.ChildNodes);
        Assert.Single(dochtml1body1table0input1.Attributes);
        Assert.Equal("input", dochtml1body1table0input1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0input1.NodeType);
        Assert.Equal("hidDEN", dochtml1body1table0input1.GetAttribute("type"));
    }

    [Fact]
    public void FosterTwoInputsInTable()
    {
        var doc = (@"<!doctype html><table><input type="" hidden""><input type=hidDEN></table>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1input0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1input0.ChildNodes);
        Assert.Single(dochtml1body1input0.Attributes);
        Assert.Equal("input", dochtml1body1input0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1input0.NodeType);
        Assert.Equal(" hidden", dochtml1body1input0.GetAttribute("type"));

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);

        var dochtml1body1table1input0 = dochtml1body1table1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table1input0.ChildNodes);
        Assert.Single(dochtml1body1table1input0.Attributes);
        Assert.Equal("input", dochtml1body1table1input0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1input0.NodeType);
        Assert.Equal("hidDEN", dochtml1body1table1input0.GetAttribute("type"));
    }

    [Fact]
    public void FosterSelectInTable()
    {
        var doc = (@"<!doctype html><table><select>X<tr>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1select0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1select0.ChildNodes);
        Assert.Empty(dochtml1body1select0.Attributes);
        Assert.Equal("select", dochtml1body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1select0.NodeType);

        var dochtml1body1select0Text0 = dochtml1body1select0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1select0Text0.NodeType);
        Assert.Equal("X", dochtml1body1select0Text0.TextContent);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table1.ChildNodes);
        Assert.Empty(dochtml1body1table1.Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);

        var dochtml1body1table1tbody0 = dochtml1body1table1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table1tbody0.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0.NodeType);

        var dochtml1body1table1tbody0tr0 = dochtml1body1table1tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table1tbody0tr0.ChildNodes);
        Assert.Empty(dochtml1body1table1tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml1body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1tbody0tr0.NodeType);
    }

    [Fact]
    public void FosterTextInSelect()
    {
        var doc = (@"<!doctype html><select>X</select>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1select0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1select0.ChildNodes);
        Assert.Empty(dochtml1body1select0.Attributes);
        Assert.Equal("select", dochtml1body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1select0.NodeType);

        var dochtml1body1select0Text0 = dochtml1body1select0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1select0Text0.NodeType);
        Assert.Equal("X", dochtml1body1select0Text0.TextContent);
    }

    [Fact]
    public void MixingUpperAndLowercaseInDoctype()
    {
        var doc = (@"<!DOCTYPE hTmL><html></html>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void PureUppercaseDoctype()
    {
        var doc = (@"<!DOCTYPE HTML><html></html>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(dochtml1.Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(dochtml1head0.Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void ParagraphClosedWrongInDiv()
    {
        var doc = (@"<div><p>a</x> b").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0p0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0p0.ChildNodes);
        Assert.Empty(dochtml0body1div0p0.Attributes);
        Assert.Equal("p", dochtml0body1div0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0p0.NodeType);

        var dochtml0body1div0p0Text0 = dochtml0body1div0p0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0p0Text0.NodeType);
        Assert.Equal("a b", dochtml0body1div0p0Text0.TextContent);
    }

    [Fact]
    public void FosterImplicitCellClosed()
    {
        var doc = (@"<table><tr><td><code></code> </table>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(dochtml0body1table0.Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0tbody0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0.Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0.NodeType);

        var dochtml0body1table0tbody0tr0 = dochtml0body1table0tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0.NodeType);

        var dochtml0body1table0tbody0tr0td0 = dochtml0body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1table0tbody0tr0td0.ChildNodes.Length);
        Assert.Empty(dochtml0body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);

        var dochtml0body1table0tbody0tr0td0code0 = dochtml0body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0td0code0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0code0.Attributes);
        Assert.Equal("code", dochtml0body1table0tbody0tr0td0code0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0code0.NodeType);

        var dochtml0body1table0tbody0tr0td0Text1 = dochtml0body1table0tbody0tr0td0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1table0tbody0tr0td0Text1.NodeType);
        Assert.Equal(" ", dochtml0body1table0tbody0tr0td0Text1.TextContent);
    }

    [Fact]
    public void FosterTextInTableAfterRow()
    {
        var doc = (@"<table><b><tr><td>aaa</td></tr>bbb</table>ccc").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(4, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1b0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b0.ChildNodes);
        Assert.Empty(dochtml0body1b0.Attributes);
        Assert.Equal("b", dochtml0body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b0.NodeType);

        var dochtml0body1b1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1b1.ChildNodes);
        Assert.Empty(dochtml0body1b1.Attributes);
        Assert.Equal("b", dochtml0body1b1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1.NodeType);

        var dochtml0body1b1Text0 = dochtml0body1b1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1b1Text0.NodeType);
        Assert.Equal("bbb", dochtml0body1b1Text0.TextContent);

        var dochtml0body1table2 = dochtml0body1.ChildNodes[2] as Element;
        Assert.Single(dochtml0body1table2.ChildNodes);
        Assert.Empty(dochtml0body1table2.Attributes);
        Assert.Equal("table", dochtml0body1table2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table2.NodeType);

        var dochtml0body1table2tbody0 = dochtml0body1table2.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table2tbody0.ChildNodes);
        Assert.Empty(dochtml0body1table2tbody0.Attributes);
        Assert.Equal("tbody", dochtml0body1table2tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table2tbody0.NodeType);

        var dochtml0body1table2tbody0tr0 = dochtml0body1table2tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table2tbody0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table2tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table2tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table2tbody0tr0.NodeType);

        var dochtml0body1table2tbody0tr0td0 = dochtml0body1table2tbody0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table2tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table2tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table2tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table2tbody0tr0td0.NodeType);

        var dochtml0body1table2tbody0tr0td0Text0 = dochtml0body1table2tbody0tr0td0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1table2tbody0tr0td0Text0.NodeType);
        Assert.Equal("aaa", dochtml0body1table2tbody0tr0td0Text0.TextContent);

        var dochtml0body1b3 = dochtml0body1.ChildNodes[3] as Element;
        Assert.Single(dochtml0body1b3.ChildNodes);
        Assert.Empty(dochtml0body1b3.Attributes);
        Assert.Equal("b", dochtml0body1b3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b3.NodeType);

        var dochtml0body1b3Text0 = dochtml0body1b3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1b3Text0.NodeType);
        Assert.Equal("ccc", dochtml0body1b3Text0.TextContent);
    }

    [Fact]
    public void FosterSpacesAndTextAfterRow()
    {
        var doc = (@"A<table><tr> B</tr> B</table>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("A B B", dochtml0body1Text0.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1tbody0 = dochtml0body1table1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table1tbody0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml0body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0.NodeType);

        var dochtml0body1table1tbody0tr0 = dochtml0body1table1tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table1tbody0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0.NodeType);
    }

    [Fact]
    public void FosterSpacesTextAndFormattingAfterRow()
    {
        var doc = (@"A<table><tr> B</tr> </em>C</table>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("A BC", dochtml0body1Text0.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1tbody0 = dochtml0body1table1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1table1tbody0.ChildNodes.Length);
        Assert.Empty(dochtml0body1table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml0body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0.NodeType);

        var dochtml0body1table1tbody0tr0 = dochtml0body1table1tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table1tbody0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0.NodeType);

        var dochtml0body1table1tbody0Text1 = dochtml0body1table1tbody0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1table1tbody0Text1.NodeType);
        Assert.Equal(" ", dochtml0body1table1tbody0Text1.TextContent);
    }

    [Fact]
    public void FosterKeygenInSelect()
    {
        var doc = (@"<select><keygen>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0.ChildNodes);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1keygen1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1keygen1.ChildNodes);
        Assert.Empty(dochtml0body1keygen1.Attributes);
        Assert.Equal("keygen", dochtml0body1keygen1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1keygen1.NodeType);
    }

    [Fact]
    public void StandardDoctypeProvidedAndSpaceShouldBePlacedInBodyWithSecondHeadIgnored()
    {
        var doc = (@"<!doctype html></head> <head>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(3, dochtml1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0];
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0).Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1Text1 = dochtml1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1Text1.NodeType);
        Assert.Equal(" ", dochtml1Text1.TextContent);

        var dochtml1body2 = dochtml1.ChildNodes[2];
        Assert.Empty(dochtml1body2.ChildNodes);
        Assert.Empty(((Element)dochtml1body2).Attributes);
        Assert.Equal("body", dochtml1body2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body2.NodeType);
    }

    [Fact]
    public void StandardDoctypeProvidedAndFormShouldNotCloseInDiv()
    {
        var doc = (@"<!doctype html><form><div></form><div>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0];
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0).Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1];
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1form0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1form0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1form0).Attributes);
        Assert.Equal("form", dochtml1body1form0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1form0.NodeType);

        var dochtml1body1form0div0 = dochtml1body1form0.ChildNodes[0];
        Assert.Single(dochtml1body1form0div0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1form0div0).Attributes);
        Assert.Equal("div", dochtml1body1form0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1form0div0.NodeType);

        var dochtml1body1form0div0div0 = dochtml1body1form0div0.ChildNodes[0];
        Assert.Empty(dochtml1body1form0div0div0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1form0div0div0).Attributes);
        Assert.Equal("div", dochtml1body1form0div0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1form0div0div0.NodeType);
    }

    [Fact]
    public void StandardDoctypeProvidedAndEntityInTitleUsed()
    {
        var doc = (@"<!doctype html><title>&amp;</title>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0];
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0).Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0title0 = dochtml1head0.ChildNodes[0];
        Assert.Single(dochtml1head0title0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0title0).Attributes);
        Assert.Equal("title", dochtml1head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0title0.NodeType);

        var dochtml1head0title0Text0 = dochtml1head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0title0Text0.NodeType);
        Assert.Equal("&", dochtml1head0title0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1];
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void StandardDoctypeProvidedAndStrangeTitleEntered()
    {
        var doc = (@"<!doctype html><title><!--&amp;--></title>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0];
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0).Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0title0 = dochtml1head0.ChildNodes[0];
        Assert.Single(dochtml1head0title0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0title0).Attributes);
        Assert.Equal("title", dochtml1head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0title0.NodeType);

        var dochtml1head0title0Text0 = dochtml1head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0title0Text0.NodeType);
        Assert.Equal("<!--&-->", dochtml1head0title0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1];
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void BareDocTypeProvidedWithNoOtherContent()
    {
        var doc = (@"<!doctype>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"", docType0.Name);
        Assert.Equal(@"", docType0.SystemIdentifier);
        Assert.Equal(@"", docType0.PublicIdentifier);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0];
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0).Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1];
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void UnfinishedCommentShouldBePlacedOnTop()
    {
        var doc = (@"<!---x").ToHtmlDocument();

        var docComment0 = doc.ChildNodes[0];
        Assert.Equal(NodeType.Comment, docComment0.NodeType);
        Assert.Equal(@"-x", docComment0.TextContent);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0];
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0).Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1];
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void FragmentAnotherBodyAndDivOpenedInContextOfADiv()
    {
        var doc = (@"<body>
<div>").ToHtmlFragment("div");

        var docText0 = doc[0];
        Assert.Equal(NodeType.Text, docText0.NodeType);
        Assert.Equal("\n", docText0.TextContent);

        var docdiv1 = doc[1];
        Assert.Empty(docdiv1.ChildNodes);
        Assert.Empty(((Element)docdiv1).Attributes);
        Assert.Equal("div", docdiv1.GetTagName());
        Assert.Equal(NodeType.Element, docdiv1.NodeType);
    }

    [Fact]
    public void FramesetOpenedAndClosedDirectlyFollowedByText()
    {
        var doc = (@"<frameset></frameset>
foo").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);

        var dochtml0Text2 = dochtml0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0Text2.NodeType);
        Assert.Equal("\n", dochtml0Text2.TextContent);
    }

    [Fact]
    public void FramesetOpenedAndClosedDirectlyFollowedByNoframes()
    {
        var doc = (@"<frameset></frameset>
<noframes>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(4, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);

        var dochtml0Text2 = dochtml0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0Text2.NodeType);
        Assert.Equal("\n", dochtml0Text2.TextContent);

        var dochtml0noframes3 = dochtml0.ChildNodes[3];
        Assert.Empty(dochtml0noframes3.ChildNodes);
        Assert.Empty(((Element)dochtml0noframes3).Attributes);
        Assert.Equal("noframes", dochtml0noframes3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0noframes3.NodeType);
    }

    [Fact]
    public void FramesetOpenedAndClosedDirectlyFollowedByOpenedDiv()
    {
        var doc = (@"<frameset></frameset>
<div>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);

        var dochtml0Text2 = dochtml0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0Text2.NodeType);
        Assert.Equal("\n", dochtml0Text2.TextContent);
    }

    [Fact]
    public void FramesetOpenedAndClosedDirectlyFollowedByClosedHtml()
    {
        var doc = (@"<frameset></frameset>
</html>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);

        var dochtml0Text2 = dochtml0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0Text2.NodeType);
        Assert.Equal("\n", dochtml0Text2.TextContent);
    }

    [Fact]
    public void FramesetOpenedAndClosedDirectlyFollowedByClosedDiv()
    {
        var doc = (@"<frameset></frameset>
</div>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);

        var dochtml0Text2 = dochtml0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0Text2.NodeType);
        Assert.Equal("\n", dochtml0Text2.TextContent);
    }

    [Fact]
    public void FormOpenedInExistingForm()
    {
        var doc = (@"<form><form>").ToHtmlDocument();

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

        var dochtml0body1form0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1form0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1form0).Attributes);
        Assert.Equal("form", dochtml0body1form0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0.NodeType);
    }

    [Fact]
    public void ButtonOpenedInExistingButton()
    {
        var doc = (@"<button><button>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1button0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1button0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1button0).Attributes);
        Assert.Equal("button", dochtml0body1button0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1button0.NodeType);

        var dochtml0body1button1 = dochtml0body1.ChildNodes[1];
        Assert.Empty(dochtml0body1button1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1button1).Attributes);
        Assert.Equal("button", dochtml0body1button1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1button1.NodeType);
    }

    [Fact]
    public void NormalCellClosedAsHeaderCellInRowInTable()
    {
        var doc = (@"<table><tr><td></th>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0tbody0 = dochtml0body1table0.ChildNodes[0];
        Assert.Single(dochtml0body1table0tbody0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0).Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0.NodeType);

        var dochtml0body1table0tbody0tr0 = dochtml0body1table0tbody0.ChildNodes[0];
        Assert.Single(dochtml0body1table0tbody0tr0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0tr0).Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0.NodeType);

        var dochtml0body1table0tbody0tr0td0 = dochtml0body1table0tbody0tr0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0tr0td0).Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);
    }

    [Fact]
    public void CellInCaptionSpawnedInTable()
    {
        var doc = (@"<table><caption><td>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1table0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0caption0 = dochtml0body1table0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0caption0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0).Attributes);
        Assert.Equal("caption", dochtml0body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0.NodeType);

        var dochtml0body1table0tbody1 = dochtml0body1table0.ChildNodes[1];
        Assert.Single(dochtml0body1table0tbody1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody1).Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody1.NodeType);

        var dochtml0body1table0tbody1tr0 = dochtml0body1table0tbody1.ChildNodes[0];
        Assert.Single(dochtml0body1table0tbody1tr0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody1tr0).Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody1tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody1tr0.NodeType);

        var dochtml0body1table0tbody1tr0td0 = dochtml0body1table0tbody1tr0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0tbody1tr0td0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody1tr0td0).Attributes);
        Assert.Equal("td", dochtml0body1table0tbody1tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody1tr0td0.NodeType);
    }

    [Fact]
    public void DivOpenedInCaptionSpawnedInTable()
    {
        var doc = (@"<table><caption><div>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0caption0 = dochtml0body1table0.ChildNodes[0];
        Assert.Single(dochtml0body1table0caption0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0).Attributes);
        Assert.Equal("caption", dochtml0body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0.NodeType);

        var dochtml0body1table0caption0div0 = dochtml0body1table0caption0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0caption0div0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0div0).Attributes);
        Assert.Equal("div", dochtml0body1table0caption0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0div0.NodeType);
    }

    [Fact]
    public void FragmentWithClosedCaptionAndOpenDivInContextOfACaption()
    {
        var doc = (@"</caption><div>").ToHtmlFragment("caption");

        var docdiv0 = doc[0];
        Assert.Empty(docdiv0.ChildNodes);
        Assert.Empty(((Element)docdiv0).Attributes);
        Assert.Equal("div", docdiv0.GetTagName());
        Assert.Equal(NodeType.Element, docdiv0.NodeType);
    }

    [Fact]
    public void DivInCaptionSpawnedInTable()
    {
        var doc = (@"<table><caption><div></caption>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0caption0 = dochtml0body1table0.ChildNodes[0];
        Assert.Single(dochtml0body1table0caption0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0).Attributes);
        Assert.Equal("caption", dochtml0body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0.NodeType);

        var dochtml0body1table0caption0div0 = dochtml0body1table0caption0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0caption0div0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0div0).Attributes);
        Assert.Equal("div", dochtml0body1table0caption0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0div0.NodeType);
    }

    [Fact]
    public void CloseTableAfterCaptionHasBeenCreatedInsideTable()
    {
        var doc = (@"<table><caption></table>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0caption0 = dochtml0body1table0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0caption0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0).Attributes);
        Assert.Equal("caption", dochtml0body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0.NodeType);
    }

    [Fact]
    public void FragmentCloseTableAndOpenDivInContextOfACaption()
    {
        var doc = (@"</table><div>").ToHtmlFragment("caption");

        var docdiv0 = doc[0];
        Assert.Empty(docdiv0.ChildNodes);
        Assert.Empty(((Element)docdiv0).Attributes);
        Assert.Equal("div", docdiv0.GetTagName());
        Assert.Equal(NodeType.Element, docdiv0.NodeType);
    }

    [Fact]
    public void UnexpectedClosingOfTheBodyInACaptionWithinATableElement()
    {
        var doc = (@"<table><caption></body></col></colgroup></html></tbody></td></tfoot></th></thead></tr>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0caption0 = dochtml0body1table0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0caption0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0).Attributes);
        Assert.Equal("caption", dochtml0body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0.NodeType);
    }

    [Fact]
    public void DivInCaptionDirectlyPlacedInTable()
    {
        var doc = (@"<table><caption><div></div>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0caption0 = dochtml0body1table0.ChildNodes[0];
        Assert.Single(dochtml0body1table0caption0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0).Attributes);
        Assert.Equal("caption", dochtml0body1table0caption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0.NodeType);

        var dochtml0body1table0caption0div0 = dochtml0body1table0caption0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0caption0div0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0caption0div0).Attributes);
        Assert.Equal("div", dochtml0body1table0caption0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption0div0.NodeType);
    }

    [Fact]
    public void ClosingBodyInTable()
    {
        var doc = (@"<table><tr><td></body></caption></col></colgroup></html>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0tbody0 = dochtml0body1table0.ChildNodes[0];
        Assert.Single(dochtml0body1table0tbody0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0).Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0.NodeType);

        var dochtml0body1table0tbody0tr0 = dochtml0body1table0tbody0.ChildNodes[0];
        Assert.Single(dochtml0body1table0tbody0tr0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0tr0).Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0.NodeType);

        var dochtml0body1table0tbody0tr0td0 = dochtml0body1table0tbody0tr0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0tr0td0).Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);
    }

    [Fact]
    public void FragmentWithMultipleClosingTableElementsInContextOfACell()
    {
        var doc = (@"</table></tbody></tfoot></thead></tr><div>").ToHtmlFragment("td");

        var docdiv0 = doc[0];
        Assert.Empty(docdiv0.ChildNodes);
        Assert.Empty(((Element)docdiv0).Attributes);
        Assert.Equal("div", docdiv0.GetTagName());
        Assert.Equal(NodeType.Element, docdiv0.NodeType);
    }

    [Fact]
    public void TextInColGroupSpawnedInTable()
    {
        var doc = (@"<table><colgroup>foo").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("foo", dochtml0body1Text0.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1];
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1).Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1colgroup0 = dochtml0body1table1.ChildNodes[0];
        Assert.Empty(dochtml0body1table1colgroup0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1colgroup0).Attributes);
        Assert.Equal("colgroup", dochtml0body1table1colgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1colgroup0.NodeType);
    }

    [Fact]
    public void FragmentTextAndColInContextOfAColgroup()
    {
        var doc = (@"foo<col>").ToHtmlFragment("colgroup");

        var doccol0 = doc[0];
        Assert.Empty(doccol0.ChildNodes);
        Assert.Empty(((Element)doccol0).Attributes);
        Assert.Equal("col", doccol0.GetTagName());
        Assert.Equal(NodeType.Element, doccol0.NodeType);
    }

    [Fact]
    public void CloseColInColGroupSpawnedInTable()
    {
        var doc = (@"<table><colgroup></col>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0colgroup0 = dochtml0body1table0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0colgroup0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0colgroup0).Attributes);
        Assert.Equal("colgroup", dochtml0body1table0colgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0colgroup0.NodeType);
    }

    [Fact]
    public void OpenDivInFrameset()
    {
        var doc = (@"<frameset><div>").ToHtmlDocument();

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

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void FragmentCloseFramesetAndOpenFrameInContextOfAFrameset()
    {
        var doc = (@"</frameset><frame>").ToHtmlFragment("frameset");

        var docframe0 = doc[0];
        Assert.Empty(docframe0.ChildNodes);
        Assert.Empty(((Element)docframe0).Attributes);
        Assert.Equal("frame", docframe0.GetTagName());
        Assert.Equal(NodeType.Element, docframe0.NodeType);
    }

    [Fact]
    public void CloseDivInAFrameset()
    {
        var doc = (@"<frameset></div>").ToHtmlDocument();

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

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void FragmentCloseBodyAndOpenDivInContextOfABody()
    {
        var doc = (@"</body><div>").ToHtmlFragment("body");

        var docdiv0 = doc[0];
        Assert.Empty(docdiv0.ChildNodes);
        Assert.Empty(((Element)docdiv0).Attributes);
        Assert.Equal("div", docdiv0.GetTagName());
        Assert.Equal(NodeType.Element, docdiv0.NodeType);
    }

    [Fact]
    public void OpenDivInARowSpawnedInATable()
    {
        var doc = (@"<table><tr><div>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1div0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1div0).Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1];
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1).Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1tbody0 = dochtml0body1table1.ChildNodes[0];
        Assert.Single(dochtml0body1table1tbody0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1tbody0).Attributes);
        Assert.Equal("tbody", dochtml0body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0.NodeType);

        var dochtml0body1table1tbody0tr0 = dochtml0body1table1tbody0.ChildNodes[0];
        Assert.Empty(dochtml0body1table1tbody0tr0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1tbody0tr0).Attributes);
        Assert.Equal("tr", dochtml0body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0.NodeType);
    }

    [Fact]
    public void FragmentCloseRowAndOpenCellInContextOfARow()
    {
        var doc = (@"</tr><td>").ToHtmlFragment("tr");

        var doctd0 = doc[0];
        Assert.Empty(doctd0.ChildNodes);
        Assert.Empty(((Element)doctd0).Attributes);
        Assert.Equal("td", doctd0.GetTagName());
        Assert.Equal(NodeType.Element, doctd0.NodeType);
    }

    [Fact]
    public void FragmentCloseBodyFootAndHeadAndOpenCellInContextOfARow()
    {
        var doc = (@"</tbody></tfoot></thead><td>").ToHtmlFragment("tr");

        var doctd0 = doc[0];
        Assert.Empty(doctd0.ChildNodes);
        Assert.Empty(((Element)doctd0).Attributes);
        Assert.Equal("td", doctd0.GetTagName());
        Assert.Equal(NodeType.Element, doctd0.NodeType);
    }

    [Fact]
    public void FosterIncludedDivInARowSpawnedInATableFollowedByACell()
    {
        var doc = (@"<table><tr><div><td>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1div0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1div0).Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1];
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1).Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1tbody0 = dochtml0body1table1.ChildNodes[0];
        Assert.Single(dochtml0body1table1tbody0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1tbody0).Attributes);
        Assert.Equal("tbody", dochtml0body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0.NodeType);

        var dochtml0body1table1tbody0tr0 = dochtml0body1table1tbody0.ChildNodes[0];
        Assert.Single(dochtml0body1table1tbody0tr0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1tbody0tr0).Attributes);
        Assert.Equal("tr", dochtml0body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0.NodeType);

        var dochtml0body1table1tbody0tr0td0 = dochtml0body1table1tbody0tr0.ChildNodes[0];
        Assert.Empty(dochtml0body1table1tbody0tr0td0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1tbody0tr0td0).Attributes);
        Assert.Equal("td", dochtml0body1table1tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0td0.NodeType);
    }

    [Fact]
    public void FragmentCaptionAndOtherTableElementsInContextOfATBody()
    {
        var doc = (@"<caption><col><colgroup><tbody><tfoot><thead><tr>").ToHtmlFragment("tbody");

        var doctr0 = doc[0];
        Assert.Empty(doctr0.ChildNodes);
        Assert.Empty(((Element)doctr0).Attributes);
        Assert.Equal("tr", doctr0.GetTagName());
        Assert.Equal(NodeType.Element, doctr0.NodeType);
    }

    [Fact]
    public void OpenTBodyAndCloseTHeadInATable()
    {
        var doc = (@"<table><tbody></thead>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0tbody0 = dochtml0body1table0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0tbody0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0).Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0.NodeType);
    }

    [Fact]
    public void FragmentCloseTableAndOpenRowInContextOfATBody()
    {
        var doc = (@"</table><tr>").ToHtmlFragment("tbody");

        var doctr0 = doc[0];
        Assert.Empty(doctr0.ChildNodes);
        Assert.Empty(((Element)doctr0).Attributes);
        Assert.Equal("tr", doctr0.GetTagName());
        Assert.Equal(NodeType.Element, doctr0.NodeType);
    }

    [Fact]
    public void VariousTableElementsWithMisclosedBody()
    {
        var doc = (@"<table><tbody></body></caption></col></colgroup></html></td></th></tr>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0tbody0 = dochtml0body1table0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0tbody0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0).Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0.NodeType);
    }

    [Fact]
    public void OpenTBodyAndCloseADivSpawnedInATable()
    {
        var doc = (@"<table><tbody></div>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0tbody0 = dochtml0body1table0.ChildNodes[0];
        Assert.Empty(dochtml0body1table0tbody0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0tbody0).Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0.NodeType);
    }

    [Fact]
    public void OpenTableInATable()
    {
        var doc = (@"<table><table>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1];
        Assert.Empty(dochtml0body1table1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table1).Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);
    }

    [Fact]
    public void OpenVariousTableElementsWhenMiscloseTheHtmlElement()
    {
        var doc = (@"<table></body></caption></col></colgroup></html></tbody></td></tfoot></th></thead></tr>").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1table0).Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);
    }

    [Fact]
    public void FragmentCloseTableAndOpenRowInContextOfATable()
    {
        var doc = (@"</table><tr>").ToHtmlFragment("table");

        var doctbody0 = doc[0];
        Assert.Single(doctbody0.ChildNodes);
        Assert.Empty(((Element)doctbody0).Attributes);
        Assert.Equal("tbody", doctbody0.GetTagName());
        Assert.Equal(NodeType.Element, doctbody0.NodeType);

        var doctbody0tr0 = doctbody0.ChildNodes[0];
        Assert.Empty(doctbody0tr0.ChildNodes);
        Assert.Empty(((Element)doctbody0tr0).Attributes);
        Assert.Equal("tr", doctbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, doctbody0tr0.NodeType);
    }

    [Fact]
    public void FragmentOpenAndCloseBodyCloseHtmlInContextOfAHtml()
    {
        var doc = (@"<body></body></html>").ToHtmlFragment("html");

        var dochead0 = doc[0];
        Assert.Empty(dochead0.ChildNodes);
        Assert.Empty(((Element)dochead0).Attributes);
        Assert.Equal("head", dochead0.GetTagName());
        Assert.Equal(NodeType.Element, dochead0.NodeType);

        var docbody1 = doc[1];
        Assert.Empty(docbody1.ChildNodes);
        Assert.Empty(((Element)docbody1).Attributes);
        Assert.Equal("body", docbody1.GetTagName());
        Assert.Equal(NodeType.Element, docbody1.NodeType);
    }

    [Fact]
    public void SimpleDocumentWithOnlyASingleFrameset()
    {
        var doc = (@"<html><frameset></frameset></html> ").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);

        var dochtml0Text2 = dochtml0.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0Text2.NodeType);
        Assert.Equal(" ", dochtml0Text2.TextContent);
    }

    [Fact]
    public void LegacyDoctypeInConjunctionWithACorrectlyClosedHtmlElement()
    {
        var doc = (@"<!DOCTYPE html PUBLIC ""-//W3C//DTD HTML 4.01//EN""><html></html>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal("html", docType0.Name);
        Assert.Equal("-//W3C//DTD HTML 4.01//EN", docType0.PublicIdentifier);
        Assert.Equal("", docType0.SystemIdentifier);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        var dochtml1head0 = dochtml1.ChildNodes[0];
        Assert.Empty(dochtml1head0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0).Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1];
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void FramesetElementEnclosedInAParamElement()
    {
        var doc = (@"<param><frameset></frameset>").ToHtmlDocument();

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

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void FramesetElementEnclosedInASourceElement()
    {
        var doc = (@"<source><frameset></frameset>").ToHtmlDocument();

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

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void FramesetElementEnclosedInATrackElement()
    {
        var doc = (@"<track><frameset></frameset>").ToHtmlDocument();

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

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void FramesetElementFollowingAMisclosedHtmlTag()
    {
        var doc = (@"</html><frameset></frameset>").ToHtmlDocument();

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

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void FramesetElementFollowingAMisclosedBodyElement()
    {
        var doc = (@"</body><frameset></frameset>").ToHtmlDocument();

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

        var dochtml0frameset1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(((Element)dochtml0frameset1).Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }
}
