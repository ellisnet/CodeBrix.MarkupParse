using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/main-element.dat
/// </summary>

public class MainElementTests
{
    [Fact]
    public void MainElementClosesOpenParagraph()
    {
        var doc = (@"<!doctype html><p>foo<main>bar<p>baz").ToHtmlDocument();

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
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1p0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1p0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1p0).Attributes);
        Assert.Equal("p", dochtml1body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0.NodeType);

        var dochtml1body1p0Text0 = dochtml1body1p0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1p0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1p0Text0.TextContent);

        var dochtml1body1main1 = dochtml1body1.ChildNodes[1];
        Assert.Equal(2, dochtml1body1main1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1body1main1).Attributes);
        Assert.Equal("main", dochtml1body1main1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1main1.NodeType);

        var dochtml1body1main1Text0 = dochtml1body1main1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1main1Text0.NodeType);
        Assert.Equal("bar", dochtml1body1main1Text0.TextContent);

        var dochtml1body1main1p1 = dochtml1body1main1.ChildNodes[1];
        Assert.Single(dochtml1body1main1p1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1main1p1).Attributes);
        Assert.Equal("p", dochtml1body1main1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1main1p1.NodeType);

        var dochtml1body1main1p1Text0 = dochtml1body1main1p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1main1p1Text0.NodeType);
        Assert.Equal("baz", dochtml1body1main1p1Text0.TextContent);
    }

    [Fact]
    public void MainClosesNestedParagraph()
    {
        var doc = (@"<!doctype html><main><p>foo</main>bar").ToHtmlDocument();

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
        Assert.Equal(2, dochtml1body1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1main0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1main0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1main0).Attributes);
        Assert.Equal("main", dochtml1body1main0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1main0.NodeType);

        var dochtml1body1main0p0 = dochtml1body1main0.ChildNodes[0];
        Assert.Single(dochtml1body1main0p0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1main0p0).Attributes);
        Assert.Equal("p", dochtml1body1main0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1main0p0.NodeType);

        var dochtml1body1main0p0Text0 = dochtml1body1main0p0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1main0p0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1main0p0Text0.TextContent);

        var dochtml1body1Text1 = dochtml1body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1Text1.NodeType);
        Assert.Equal("bar", dochtml1body1Text1.TextContent);
    }

    [Fact]
    public void MainElementInForeignSvgElement()
    {
        var doc = (@"<!DOCTYPE html>xxx<svg><x><g><a><main><b>").ToHtmlDocument();

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
        Assert.Equal(3, dochtml1body1.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("xxx", dochtml1body1Text0.TextContent);

        var dochtml1body1svg1 = dochtml1body1.ChildNodes[1];
        Assert.Single(dochtml1body1svg1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1svg1).Attributes);
        Assert.Equal("svg", dochtml1body1svg1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg1.NodeType);

        var dochtml1body1svg1x0 = dochtml1body1svg1.ChildNodes[0];
        Assert.Single(dochtml1body1svg1x0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1svg1x0).Attributes);
        Assert.Equal("x", dochtml1body1svg1x0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg1x0.NodeType);

        var dochtml1body1svg1x0g0 = dochtml1body1svg1x0.ChildNodes[0];
        Assert.Single(dochtml1body1svg1x0g0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1svg1x0g0).Attributes);
        Assert.Equal("g", dochtml1body1svg1x0g0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg1x0g0.NodeType);

        var dochtml1body1svg1x0g0a0 = dochtml1body1svg1x0g0.ChildNodes[0];
        Assert.Single(dochtml1body1svg1x0g0a0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1svg1x0g0a0).Attributes);
        Assert.Equal("a", dochtml1body1svg1x0g0a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg1x0g0a0.NodeType);

        var dochtml1body1svg1x0g0a0main0 = dochtml1body1svg1x0g0a0.ChildNodes[0];
        Assert.Empty(dochtml1body1svg1x0g0a0main0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1svg1x0g0a0main0).Attributes);
        Assert.Equal("main", dochtml1body1svg1x0g0a0main0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg1x0g0a0main0.NodeType);

        var dochtml1body1b2 = dochtml1body1.ChildNodes[2];
        Assert.Empty(dochtml1body1b2.ChildNodes);
        Assert.Empty(((Element)dochtml1body1b2).Attributes);
        Assert.Equal("b", dochtml1body1b2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b2.NodeType);

    }

}
