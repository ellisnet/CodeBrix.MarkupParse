using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests21.dat
/// </summary>

public class CDataTests
{
    [Fact]
    public void CDataInSvgElement()
    {
        var doc = (@"<svg><![CDATA[foo]]>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("foo", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataInMathElement()
    {
        var doc = (@"<math><![CDATA[foo]]>").ToHtmlDocument();

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

        var dochtml0body1math0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1math0).Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0Text0 = dochtml0body1math0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1math0Text0.NodeType);
        Assert.Equal("foo", dochtml0body1math0Text0.TextContent);
    }

    [Fact]
    public void CDataInDivElement()
    {
        var doc = (@"<div><![CDATA[foo]]>").ToHtmlDocument();

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

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1div0).Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0Comment0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Comment, dochtml0body1div0Comment0.NodeType);
        Assert.Equal(@"[CDATA[foo]]", dochtml0body1div0Comment0.TextContent);
    }

    [Fact]
    public void CDataUnclosedInSvgElement()
    {
        var doc = (@"<svg><![CDATA[foo").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("foo", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataUnclosedWithoutTextInSvgElement()
    {
        var doc = (@"<svg><![CDATA[").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);
    }

    [Fact]
    public void CDataWithoutTextInSvgElement()
    {
        var doc = (@"<svg><![CDATA[]]>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);
    }

    [Fact]
    public void CDataClosedWrongInSvgElement()
    {
        var doc = (@"<svg><![CDATA[]] >]]>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("]] >", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataMissingClosingBracketInSvgElement()
    {
        var doc = (@"<svg><![CDATA[]]").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("]]", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataMissingClosingBracketsInSvgElement()
    {
        var doc = (@"<svg><![CDATA[]").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("]", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataMissingClosingSquareBracketInSvgElement()
    {
        var doc = (@"<svg><![CDATA[]>a").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("]>a", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithAdditionalClosingSquareBracketInSvgElementWithStandardDoctype()
    {
        var doc = (@"<!DOCTYPE html><svg><![CDATA[foo]]]>").ToHtmlDocument();

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

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1svg0).Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0Text0 = dochtml1body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0Text0.NodeType);
        Assert.Equal("foo]", dochtml1body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithManyClosingSquareBracketsInSvgElementWithStandardDoctype()
    {
        var doc = (@"<!DOCTYPE html><svg><![CDATA[foo]]]]>").ToHtmlDocument();

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

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1svg0).Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0Text0 = dochtml1body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0Text0.NodeType);
        Assert.Equal("foo]]", dochtml1body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithManyMoreClosingSquareBracketsInSvgElementWithStandardDoctype()
    {
        var doc = (@"<!DOCTYPE html><svg><![CDATA[foo]]]]]>").ToHtmlDocument();

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

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1svg0).Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0Text0 = dochtml1body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0Text0.NodeType);
        Assert.Equal("foo]]]", dochtml1body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataInDivLocatedInForeignObjectWhichIsPlacedInSvgElement()
    {
        var doc = (@"<svg><foreignObject><div><![CDATA[foo]]>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0foreignObject0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Single(dochtml0body1svg0foreignObject0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0foreignObject0).Attributes);
        Assert.Equal("foreignObject", dochtml0body1svg0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0foreignObject0.NodeType);

        var dochtml0body1svg0foreignObject0div0 = dochtml0body1svg0foreignObject0.ChildNodes[0];
        Assert.Single(dochtml0body1svg0foreignObject0div0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0foreignObject0div0).Attributes);
        Assert.Equal("div", dochtml0body1svg0foreignObject0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0foreignObject0div0.NodeType);

        var dochtml0body1svg0foreignObject0div0Comment0 = dochtml0body1svg0foreignObject0div0.ChildNodes[0];
        Assert.Equal(NodeType.Comment, dochtml0body1svg0foreignObject0div0Comment0.NodeType);
        Assert.Equal(@"[CDATA[foo]]", dochtml0body1svg0foreignObject0div0Comment0.TextContent);
    }

    [Fact]
    public void CDataWithSvgTagInSvgElement()
    {
        var doc = (@"<svg><![CDATA[<svg>]]>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("<svg>", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithClosingSvgTagInSvgElement()
    {
        var doc = (@"<svg><![CDATA[</svg>a]]>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("</svg>a", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithSvgTagUnclosedInSvgElement()
    {
        var doc = (@"<svg><![CDATA[<svg>a").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("<svg>a", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithClosingSvgTagUnclosedInSvgElement()
    {
        var doc = (@"<svg><![CDATA[</svg>a").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("</svg>a", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithSvgTagInSvgElementFollowedByPath()
    {
        var doc = (@"<svg><![CDATA[<svg>]]><path>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1svg0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("<svg>", dochtml0body1svg0Text0.TextContent);

        var dochtml0body1svg0path1 = dochtml0body1svg0.ChildNodes[1];
        Assert.Empty(dochtml0body1svg0path1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0path1).Attributes);
        Assert.Equal("path", dochtml0body1svg0path1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0path1.NodeType);
    }

    [Fact]
    public void CDataWithSvgTagInSvgElementFollowedByClosingPath()
    {
        var doc = (@"<svg><![CDATA[<svg>]]></path>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("<svg>", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithSvgTagInSvgElementFollowedByComment()
    {
        var doc = (@"<svg><![CDATA[<svg>]]><!--path-->").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(2, dochtml0body1svg0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("<svg>", dochtml0body1svg0Text0.TextContent);

        var dochtml0body1svg0Comment1 = dochtml0body1svg0.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1svg0Comment1.NodeType);
        Assert.Equal(@"path", dochtml0body1svg0Comment1.TextContent);
    }

    [Fact]
    public void CDataWithSvgTagInSvgElementFollowedByText()
    {
        var doc = (@"<svg><![CDATA[<svg>]]>path").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("<svg>path", dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void CDataWithCommentInSvgElement()
    {
        var doc = (@"<svg><![CDATA[<!--svg-->]]>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1svg0).Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("<!--svg-->", dochtml0body1svg0Text0.TextContent);
    }
}
