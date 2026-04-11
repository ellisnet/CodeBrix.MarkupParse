using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// encoding/template.dat
/// </summary>

public class HtmlTemplateTests
{
    [Fact]
    public void TemplateNodeInBodyWithTextContent()
    {
        var doc = (@"<body><template>Hello</template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0ContentText0 = dochtml0body1template0Content.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1template0ContentText0.NodeType);
        Assert.Equal("Hello", dochtml0body1template0ContentText0.TextContent);
    }

    [Fact]
    public void TemplateNodeStandaloneWithTextContent()
    {
        var doc = (@"<template>Hello</template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0ContentText0 = dochtml0head0template0Content.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0template0ContentText0.NodeType);
        Assert.Equal("Hello", dochtml0head0template0ContentText0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeEmptyFollowedByEmptyDiv()
    {
        var doc = (@"<template></template><div></div>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Empty(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);
    }

    [Fact]
    public void TemplateInHtmlWithTextContent()
    {
        var doc = (@"<html><template>Hello</template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0ContentText0 = dochtml0head0template0Content.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0template0ContentText0.NodeType);
        Assert.Equal("Hello", dochtml0head0template0ContentText0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateInHeadWithDivElement()
    {
        var doc = (@"<head><template><div></div></template></head>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentdiv0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0head0template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentdiv0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeInDivWithDivAndSpanMisclosed()
    {
        var doc = (@"<div><template><div><span></template><b>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0template0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0template0.ChildNodes);
        Assert.Empty(dochtml0body1div0template0.Attributes);
        Assert.Equal("template", dochtml0body1div0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0template0.NodeType);

        var dochtml0body1div0template0Content = ((HtmlTemplateElement)dochtml0body1div0template0).Content;
        Assert.Single(dochtml0body1div0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1div0template0Content.NodeType);

        var dochtml0body1div0template0Contentdiv0 = dochtml0body1div0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0body1div0template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0body1div0template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0template0Contentdiv0.NodeType);

        var dochtml0body1div0template0Contentdiv0span0 = dochtml0body1div0template0Contentdiv0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0template0Contentdiv0span0.ChildNodes);
        Assert.Empty(dochtml0body1div0template0Contentdiv0span0.Attributes);
        Assert.Equal("span", dochtml0body1div0template0Contentdiv0span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0template0Contentdiv0span0.NodeType);

        var dochtml0body1div0b1 = dochtml0body1div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0b1.ChildNodes);
        Assert.Empty(dochtml0body1div0b1.Attributes);
        Assert.Equal("b", dochtml0body1div0b1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0b1.NodeType);
    }

    [Fact]
    public void TemplateNodeInDivMisclosed()
    {
        var doc = (@"<div><template></div>Hello").ToHtmlDocument();

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

        var dochtml0body1div0template0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0template0.ChildNodes);
        Assert.Empty(dochtml0body1div0template0.Attributes);
        Assert.Equal("template", dochtml0body1div0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0template0.NodeType);

        var dochtml0body1div0template0Content = ((HtmlTemplateElement)dochtml0body1div0template0).Content;
        Assert.Single(dochtml0body1div0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1div0template0Content.NodeType);

        var dochtml0body1div0template0ContentText0 = dochtml0body1div0template0Content.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0template0ContentText0.NodeType);
        Assert.Equal("Hello", dochtml0body1div0template0ContentText0.TextContent);
    }

    [Fact]
    public void TemplateNodeClosedInDivElement()
    {
        var doc = (@"<div></template></div>").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);
    }

    [Fact]
    public void TemplateNodeInTableElement()
    {
        var doc = (@"<table><template></template></table>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Empty(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInTableElementMisclosed()
    {
        var doc = (@"<table><template></template></div>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Empty(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInDivUnderTableElement()
    {
        var doc = (@"<table><div><template></template></div>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0template0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0template0.ChildNodes);
        Assert.Empty(dochtml0body1div0template0.Attributes);
        Assert.Equal("template", dochtml0body1div0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0template0.NodeType);

        var dochtml0body1div0template0Content = ((HtmlTemplateElement)dochtml0body1div0template0).Content;
        Assert.Empty(dochtml0body1div0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1div0template0Content.NodeType);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);
    }

    [Fact]
    public void TemplateNodeFollowedByDivInTable()
    {
        var doc = (@"<table><template></template><div></div>").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1template0 = dochtml0body1table1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table1template0.ChildNodes);
        Assert.Empty(dochtml0body1table1template0.Attributes);
        Assert.Equal("template", dochtml0body1table1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1template0.NodeType);

        var dochtml0body1table1template0Content = ((HtmlTemplateElement)dochtml0body1table1template0).Content;
        Assert.Empty(dochtml0body1table1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table1template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInTableAfterSpaces()
    {
        var doc = (@"<table>   <template></template></table>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1table0.ChildNodes.Length);
        Assert.Empty(dochtml0body1table0.Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1table0Text0 = dochtml0body1table0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1table0Text0.NodeType);
        Assert.Equal("   ", dochtml0body1table0Text0.TextContent);

        var dochtml0body1table0template1 = dochtml0body1table0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table0template1.ChildNodes);
        Assert.Empty(dochtml0body1table0template1.Attributes);
        Assert.Equal("template", dochtml0body1table0template1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template1.NodeType);

        var dochtml0body1table0template1Content = ((HtmlTemplateElement)dochtml0body1table0template1).Content;
        Assert.Empty(dochtml0body1table0template1Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template1Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInTbody()
    {
        var doc = (@"<table><tbody><template></template></tbody>").ToHtmlDocument();

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

        var dochtml0body1table0tbody0template0 = dochtml0body1table0tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0tbody0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0template0.NodeType);

        var dochtml0body1table0tbody0template0Content = ((HtmlTemplateElement)dochtml0body1table0tbody0template0).Content;
        Assert.Empty(dochtml0body1table0tbody0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0tbody0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInTbodyMisclosed()
    {
        var doc = (@"<table><tbody><template></tbody></template>").ToHtmlDocument();

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

        var dochtml0body1table0tbody0template0 = dochtml0body1table0tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0tbody0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0template0.NodeType);

        var dochtml0body1table0tbody0template0Content = ((HtmlTemplateElement)dochtml0body1table0tbody0template0).Content;
        Assert.Empty(dochtml0body1table0tbody0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0tbody0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInTbodyInTable()
    {
        var doc = (@"<table><tbody><template></template></tbody></table>").ToHtmlDocument();

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

        var dochtml0body1table0tbody0template0 = dochtml0body1table0tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0tbody0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0template0.NodeType);

        var dochtml0body1table0tbody0template0Content = ((HtmlTemplateElement)dochtml0body1table0tbody0template0).Content;
        Assert.Empty(dochtml0body1table0tbody0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0tbody0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInThead()
    {
        var doc = (@"<table><thead><template></template></thead>").ToHtmlDocument();

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

        var dochtml0body1table0thead0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0thead0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0.Attributes);
        Assert.Equal("thead", dochtml0body1table0thead0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0.NodeType);

        var dochtml0body1table0thead0template0 = dochtml0body1table0thead0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0thead0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0thead0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0template0.NodeType);

        var dochtml0body1table0thead0template0Content = ((HtmlTemplateElement)dochtml0body1table0thead0template0).Content;
        Assert.Empty(dochtml0body1table0thead0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0thead0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInTfoot()
    {
        var doc = (@"<table><tfoot><template></template></tfoot>").ToHtmlDocument();

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

        var dochtml0body1table0tfoot0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tfoot0.ChildNodes);
        Assert.Empty(dochtml0body1table0tfoot0.Attributes);
        Assert.Equal("tfoot", dochtml0body1table0tfoot0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tfoot0.NodeType);

        var dochtml0body1table0tfoot0template0 = dochtml0body1table0tfoot0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tfoot0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0tfoot0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0tfoot0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tfoot0template0.NodeType);

        var dochtml0body1table0tfoot0template0Content = ((HtmlTemplateElement)dochtml0body1table0tfoot0template0).Content;
        Assert.Empty(dochtml0body1table0tfoot0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0tfoot0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInSelect()
    {
        var doc = (@"<select><template></template></select>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1select0.ChildNodes);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1select0template0 = dochtml0body1select0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0template0.ChildNodes);
        Assert.Empty(dochtml0body1select0template0.Attributes);
        Assert.Equal("template", dochtml0body1select0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0template0.NodeType);

        var dochtml0body1select0template0Content = ((HtmlTemplateElement)dochtml0body1select0template0).Content;
        Assert.Empty(dochtml0body1select0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1select0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOptionInSelect()
    {
        var doc = (@"<select><template><option></option></template></select>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1select0.ChildNodes);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1select0template0 = dochtml0body1select0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0template0.ChildNodes);
        Assert.Empty(dochtml0body1select0template0.Attributes);
        Assert.Equal("template", dochtml0body1select0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0template0.NodeType);

        var dochtml0body1select0template0Content = ((HtmlTemplateElement)dochtml0body1select0template0).Content;
        Assert.Single(dochtml0body1select0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1select0template0Content.NodeType);

        var dochtml0body1select0template0Contentoption0 = dochtml0body1select0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0template0Contentoption0.ChildNodes);
        Assert.Empty(dochtml0body1select0template0Contentoption0.Attributes);
        Assert.Equal("option", dochtml0body1select0template0Contentoption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0template0Contentoption0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOptionsAndMisclosedSelect()
    {
        var doc = (@"<template><option></option></select><option></option></template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Equal(2, dochtml0head0template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentoption0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentoption0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentoption0.Attributes);
        Assert.Equal("option", dochtml0head0template0Contentoption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentoption0.NodeType);

        var dochtml0head0template0Contentoption1 = dochtml0head0template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0head0template0Contentoption1.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentoption1.Attributes);
        Assert.Equal("option", dochtml0head0template0Contentoption1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentoption1.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeInSelectFollowedByOption()
    {
        var doc = (@"<select><template></template><option></select>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1select0.ChildNodes.Length);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1select0template0 = dochtml0body1select0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0template0.ChildNodes);
        Assert.Empty(dochtml0body1select0template0.Attributes);
        Assert.Equal("template", dochtml0body1select0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0template0.NodeType);

        var dochtml0body1select0template0Content = ((HtmlTemplateElement)dochtml0body1select0template0).Content;
        Assert.Empty(dochtml0body1select0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1select0template0Content.NodeType);

        var dochtml0body1select0option1 = dochtml0body1select0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1select0option1.ChildNodes);
        Assert.Empty(dochtml0body1select0option1.Attributes);
        Assert.Equal("option", dochtml0body1select0option1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0option1.NodeType);
    }

    [Fact]
    public void TemplateNodeInOptionOfSelect()
    {
        var doc = (@"<select><option><template></template></select>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1select0.ChildNodes);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1select0option0 = dochtml0body1select0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1select0option0.ChildNodes);
        Assert.Empty(dochtml0body1select0option0.Attributes);
        Assert.Equal("option", dochtml0body1select0option0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0option0.NodeType);

        var dochtml0body1select0option0template0 = dochtml0body1select0option0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0option0template0.ChildNodes);
        Assert.Empty(dochtml0body1select0option0template0.Attributes);
        Assert.Equal("template", dochtml0body1select0option0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0option0template0.NodeType);

        var dochtml0body1select0option0template0Content = ((HtmlTemplateElement)dochtml0body1select0option0template0).Content;
        Assert.Empty(dochtml0body1select0option0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1select0option0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInImplicitlyClosed()
    {
        var doc = (@"<select><template>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1select0.ChildNodes);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1select0template0 = dochtml0body1select0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0template0.ChildNodes);
        Assert.Empty(dochtml0body1select0template0.Attributes);
        Assert.Equal("template", dochtml0body1select0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0template0.NodeType);

        var dochtml0body1select0template0Content = ((HtmlTemplateElement)dochtml0body1select0template0).Content;
        Assert.Empty(dochtml0body1select0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1select0template0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInInSelectAfterClosedOption()
    {
        var doc = (@"<select><option></option><template>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1select0.ChildNodes.Length);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1select0option0 = dochtml0body1select0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0option0.ChildNodes);
        Assert.Empty(dochtml0body1select0option0.Attributes);
        Assert.Equal("option", dochtml0body1select0option0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0option0.NodeType);

        var dochtml0body1select0template1 = dochtml0body1select0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1select0template1.ChildNodes);
        Assert.Empty(dochtml0body1select0template1.Attributes);
        Assert.Equal("template", dochtml0body1select0template1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0template1.NodeType);

        var dochtml0body1select0template1Content = ((HtmlTemplateElement)dochtml0body1select0template1).Content;
        Assert.Empty(dochtml0body1select0template1Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1select0template1Content.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenOptionInSelectAfterClosedOption()
    {
        var doc = (@"<select><option></option><template><option>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1select0.ChildNodes.Length);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1select0option0 = dochtml0body1select0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0option0.ChildNodes);
        Assert.Empty(dochtml0body1select0option0.Attributes);
        Assert.Equal("option", dochtml0body1select0option0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0option0.NodeType);

        var dochtml0body1select0template1 = dochtml0body1select0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1select0template1.ChildNodes);
        Assert.Empty(dochtml0body1select0template1.Attributes);
        Assert.Equal("template", dochtml0body1select0template1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0template1.NodeType);

        var dochtml0body1select0template1Content = ((HtmlTemplateElement)dochtml0body1select0template1).Content;
        Assert.Single(dochtml0body1select0template1Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1select0template1Content.NodeType);

        var dochtml0body1select0template1Contentoption0 = dochtml0body1select0template1Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0template1Contentoption0.ChildNodes);
        Assert.Empty(dochtml0body1select0template1Contentoption0.Attributes);
        Assert.Equal("option", dochtml0body1select0template1Contentoption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0template1Contentoption0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenTdInThead()
    {
        var doc = (@"<table><thead><template><td></template></table>").ToHtmlDocument();

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

        var dochtml0body1table0thead0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0thead0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0.Attributes);
        Assert.Equal("thead", dochtml0body1table0thead0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0.NodeType);

        var dochtml0body1table0thead0template0 = dochtml0body1table0thead0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0thead0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0thead0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0template0.NodeType);

        var dochtml0body1table0thead0template0Content = ((HtmlTemplateElement)dochtml0body1table0thead0template0).Content;
        Assert.Single(dochtml0body1table0thead0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0thead0template0Content.NodeType);

        var dochtml0body1table0thead0template0Contenttd0 = dochtml0body1table0thead0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0thead0template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1table0thead0template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0template0Contenttd0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenTheadInTable()
    {
        var doc = (@"<table><template><thead></template></table>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Single(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);

        var dochtml0body1table0template0Contentthead0 = dochtml0body1table0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contentthead0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contentthead0.Attributes);
        Assert.Equal("thead", dochtml0body1table0template0Contentthead0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contentthead0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenTdAndMisclosedTrInTable()
    {
        var doc = (@"<body><table><template><td></tr><div></template></table>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Single(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);

        var dochtml0body1table0template0Contenttd0 = dochtml0body1table0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1table0template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttd0.NodeType);

        var dochtml0body1table0template0Contenttd0div0 = dochtml0body1table0template0Contenttd0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contenttd0div0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttd0div0.Attributes);
        Assert.Equal("div", dochtml0body1table0template0Contenttd0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttd0div0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenTheadInTableWithMisclosedThead()
    {
        var doc = (@"<table><template><thead></template></thead></table>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Single(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);

        var dochtml0body1table0template0Contentthead0 = dochtml0body1table0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contentthead0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contentthead0.Attributes);
        Assert.Equal("thead", dochtml0body1table0template0Contentthead0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contentthead0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenTrInTheadInTable()
    {
        var doc = (@"<table><thead><template><tr></template></table>").ToHtmlDocument();

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

        var dochtml0body1table0thead0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0thead0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0.Attributes);
        Assert.Equal("thead", dochtml0body1table0thead0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0.NodeType);

        var dochtml0body1table0thead0template0 = dochtml0body1table0thead0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0thead0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0thead0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0template0.NodeType);

        var dochtml0body1table0thead0template0Content = ((HtmlTemplateElement)dochtml0body1table0thead0template0).Content;
        Assert.Single(dochtml0body1table0thead0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0thead0template0Content.NodeType);

        var dochtml0body1table0thead0template0Contenttr0 = dochtml0body1table0thead0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0thead0template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0thead0template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0template0Contenttr0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenTrInTable()
    {
        var doc = (@"<table><template><tr></template></table>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Single(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);

        var dochtml0body1table0template0Contenttr0 = dochtml0body1table0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttr0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenTdInTrInTable()
    {
        var doc = (@"<table><tr><template><td>").ToHtmlDocument();

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

        var dochtml0body1table0tbody0tr0template0 = dochtml0body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0tbody0tr0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0template0.NodeType);

        var dochtml0body1table0tbody0tr0template0Content = ((HtmlTemplateElement)dochtml0body1table0tbody0tr0template0).Content;
        Assert.Single(dochtml0body1table0tbody0tr0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0tbody0tr0template0Content.NodeType);

        var dochtml0body1table0tbody0tr0template0Contenttd0 = dochtml0body1table0tbody0tr0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0template0Contenttd0.NodeType);
    }

    [Fact]
    public void TemplateNodesNestedWithClosedElementsInTable()
    {
        var doc = (@"<table><template><tr><template><td></template></tr></template></table>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Single(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);

        var dochtml0body1table0template0Contenttr0 = dochtml0body1table0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttr0.NodeType);

        var dochtml0body1table0template0Contenttr0template0 = dochtml0body1table0template0Contenttr0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contenttr0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttr0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0Contenttr0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttr0template0.NodeType);

        var dochtml0body1table0template0Contenttr0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0Contenttr0template0).Content;
        Assert.Single(dochtml0body1table0template0Contenttr0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Contenttr0template0Content.NodeType);

        var dochtml0body1table0template0Contenttr0template0Contenttd0 = dochtml0body1table0template0Contenttr0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contenttr0template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttr0template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1table0template0Contenttr0template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttr0template0Contenttd0.NodeType);
    }

    [Fact]
    public void TemplateNodesNestedWithOpenElementsInTable()
    {
        var doc = (@"<table><template><tr><template><td></td></template></tr></template></table>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Single(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);

        var dochtml0body1table0template0Contenttr0 = dochtml0body1table0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttr0.NodeType);

        var dochtml0body1table0template0Contenttr0template0 = dochtml0body1table0template0Contenttr0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contenttr0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttr0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0Contenttr0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttr0template0.NodeType);

        var dochtml0body1table0template0Contenttr0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0Contenttr0template0).Content;
        Assert.Single(dochtml0body1table0template0Contenttr0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Contenttr0template0Content.NodeType);

        var dochtml0body1table0template0Contenttr0template0Contenttd0 = dochtml0body1table0template0Contenttr0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contenttr0template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttr0template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1table0template0Contenttr0template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttr0template0Contenttd0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithOpenTdInTable()
    {
        var doc = (@"<table><template><td></template>").ToHtmlDocument();

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

        var dochtml0body1table0template0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0.NodeType);

        var dochtml0body1table0template0Content = ((HtmlTemplateElement)dochtml0body1table0template0).Content;
        Assert.Single(dochtml0body1table0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0template0Content.NodeType);

        var dochtml0body1table0template0Contenttd0 = dochtml0body1table0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1table0template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1table0template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0template0Contenttd0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithTdInBody()
    {
        var doc = (@"<body><template><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttd0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd0.NodeType);
    }

    [Fact]
    public void TemplateNodesMisnestedContent()
    {
        var doc = (@"<body><template><template><tr></tr></template><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttemplate0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0body1template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate0.NodeType);

        var dochtml0body1template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0body1template0Contenttemplate0).Content;
        Assert.Single(dochtml0body1template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Contenttemplate0Content.NodeType);

        var dochtml0body1template0Contenttemplate0Contenttr0 = dochtml0body1template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttemplate0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate0Contenttr0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeWithColInColgroupInTable()
    {
        var doc = (@"<table><colgroup><template><col>").ToHtmlDocument();

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

        var dochtml0body1table0colgroup0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0colgroup0.ChildNodes);
        Assert.Empty(dochtml0body1table0colgroup0.Attributes);
        Assert.Equal("colgroup", dochtml0body1table0colgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0colgroup0.NodeType);

        var dochtml0body1table0colgroup0template0 = dochtml0body1table0colgroup0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0colgroup0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0colgroup0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0colgroup0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0colgroup0template0.NodeType);

        var dochtml0body1table0colgroup0template0Content = ((HtmlTemplateElement)dochtml0body1table0colgroup0template0).Content;
        Assert.Single(dochtml0body1table0colgroup0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0colgroup0template0Content.NodeType);

        var dochtml0body1table0colgroup0template0Contentcol0 = dochtml0body1table0colgroup0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0colgroup0template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0body1table0colgroup0template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0body1table0colgroup0template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0colgroup0template0Contentcol0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithFrameInFrameset()
    {
        var doc = (@"<frameset><template><frame></frame></template></frameset>").ToHtmlDocument();

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

        var dochtml0frameset1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0frameset1.ChildNodes);
        Assert.Empty(dochtml0frameset1.Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void TemplateWithFrameAndMisclosedFrameset()
    {
        var doc = (@"<template><frame></frame></frameset><frame></frame></template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Empty(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);
    }

    [Fact]
    public void TemplateWithDivFramesetAndSpan()
    {
        var doc = (@"<template><div><frameset><span></span></div><span></span></template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Equal(2, dochtml0head0template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentdiv0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0head0template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentdiv0.NodeType);

        var dochtml0head0template0Contentdiv0span0 = dochtml0head0template0Contentdiv0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentdiv0span0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentdiv0span0.Attributes);
        Assert.Equal("span", dochtml0head0template0Contentdiv0span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentdiv0span0.NodeType);

        var dochtml0head0template0Contentspan1 = dochtml0head0template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0head0template0Contentspan1.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentspan1.Attributes);
        Assert.Equal("span", dochtml0head0template0Contentspan1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentspan1.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithDivFramesetSpan()
    {
        var doc = (@"<body><template><div><frameset><span></span></div><span></span></template></body>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentdiv0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0body1template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentdiv0.NodeType);

        var dochtml0body1template0Contentdiv0span0 = dochtml0body1template0Contentdiv0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentdiv0span0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentdiv0span0.Attributes);
        Assert.Equal("span", dochtml0body1template0Contentdiv0span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentdiv0span0.NodeType);

        var dochtml0body1template0Contentspan1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contentspan1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentspan1.Attributes);
        Assert.Equal("span", dochtml0body1template0Contentspan1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentspan1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithScriptAndTd()
    {
        var doc = (@"<body><template><script>var i = 1;</script><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentscript0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1template0Contentscript0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentscript0.Attributes);
        Assert.Equal("script", dochtml0body1template0Contentscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentscript0.NodeType);

        var dochtml0body1template0Contentscript0Text0 = dochtml0body1template0Contentscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1template0Contentscript0Text0.NodeType);
        Assert.Equal("var i = 1;", dochtml0body1template0Contentscript0Text0.TextContent);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTrDiv()
    {
        var doc = (@"<body><template><tr><div></div></tr></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttr0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr0.NodeType);

        var dochtml0body1template0Contentdiv1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contentdiv1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentdiv1.Attributes);
        Assert.Equal("div", dochtml0body1template0Contentdiv1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentdiv1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTrTd()
    {
        var doc = (@"<body><template><tr></tr><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttr0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr0.NodeType);

        var dochtml0body1template0Contenttr1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1template0Contenttr1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr1.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr1.NodeType);

        var dochtml0body1template0Contenttr1td0 = dochtml0body1template0Contenttr1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttr1td0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr1td0.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttr1td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr1td0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTdMisclosedTrAndTd()
    {
        var doc = (@"<body><template><td></td></tr><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttd0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTdTbodyTd()
    {
        var doc = (@"<body><template><td></td><tbody><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttd0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTdCaptionTd()
    {
        var doc = (@"<body><template><td></td><caption></caption><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttd0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTdColgroupTd()
    {
        var doc = (@"<body><template><td></td><colgroup></caption><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttd0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTdMisclosedTableAndTd()
    {
        var doc = (@"<body><template><td></td></table><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttd0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTrTbodyTr()
    {
        var doc = (@"<body><template><tr></tr><tbody><tr></tr></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttr0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr0.NodeType);

        var dochtml0body1template0Contenttr1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttr1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr1.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTrCaptionTr()
    {
        var doc = (@"<body><template><tr></tr><caption><tr></tr></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttr0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr0.NodeType);

        var dochtml0body1template0Contenttr1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttr1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr1.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTrMisclosedTableTr()
    {
        var doc = (@"<body><template><tr></tr></table><tr></tr></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttr0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr0.NodeType);

        var dochtml0body1template0Contenttr1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttr1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr1.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTheadCaptionTbody()
    {
        var doc = (@"<body><template><thead></thead><caption></caption><tbody></tbody></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(3, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentthead0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentthead0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentthead0.Attributes);
        Assert.Equal("thead", dochtml0body1template0Contentthead0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentthead0.NodeType);

        var dochtml0body1template0Contentcaption1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contentcaption1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentcaption1.Attributes);
        Assert.Equal("caption", dochtml0body1template0Contentcaption1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentcaption1.NodeType);

        var dochtml0body1template0Contenttbody2 = dochtml0body1template0Content.ChildNodes[2] as Element;
        Assert.Empty(dochtml0body1template0Contenttbody2.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttbody2.Attributes);
        Assert.Equal("tbody", dochtml0body1template0Contenttbody2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttbody2.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTheadMisclosedTableTbody()
    {
        var doc = (@"<body><template><thead></thead></table><tbody></tbody></template></body>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentthead0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentthead0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentthead0.Attributes);
        Assert.Equal("thead", dochtml0body1template0Contentthead0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentthead0.NodeType);

        var dochtml0body1template0Contenttbody1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttbody1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttbody1.Attributes);
        Assert.Equal("tbody", dochtml0body1template0Contenttbody1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttbody1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithDivTr()
    {
        var doc = (@"<body><template><div><tr></tr></div></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentdiv0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0body1template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentdiv0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithEmAndText()
    {
        var doc = (@"<body><template><em>Hello</em></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentem0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1template0Contentem0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentem0.Attributes);
        Assert.Equal("em", dochtml0body1template0Contentem0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentem0.NodeType);

        var dochtml0body1template0Contentem0Text0 = dochtml0body1template0Contentem0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1template0Contentem0Text0.NodeType);
        Assert.Equal("Hello", dochtml0body1template0Contentem0Text0.TextContent);
    }

    [Fact]
    public void TemplateNodeInBodyWithComment()
    {
        var doc = (@"<body><template><!--comment--></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0ContentComment0 = dochtml0body1template0Content.ChildNodes[0];
        Assert.Equal(NodeType.Comment, dochtml0body1template0ContentComment0.NodeType);
        Assert.Equal(@"comment", dochtml0body1template0ContentComment0.TextContent);
    }

    [Fact]
    public void TemplateNodeInBodyWithStyleTd()
    {
        var doc = (@"<body><template><style></style><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentstyle0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentstyle0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentstyle0.Attributes);
        Assert.Equal("style", dochtml0body1template0Contentstyle0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentstyle0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithMetaTd()
    {
        var doc = (@"<body><template><meta><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentmeta0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentmeta0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentmeta0.Attributes);
        Assert.Equal("meta", dochtml0body1template0Contentmeta0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentmeta0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithLinkTd()
    {
        var doc = (@"<body><template><link><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentlink0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentlink0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentlink0.Attributes);
        Assert.Equal("link", dochtml0body1template0Contentlink0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentlink0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedTemplateWithTr()
    {
        var doc = (@"<body><template><template><tr></tr></template><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttemplate0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0body1template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate0.NodeType);

        var dochtml0body1template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0body1template0Contenttemplate0).Content;
        Assert.Single(dochtml0body1template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Contenttemplate0Content.NodeType);

        var dochtml0body1template0Contenttemplate0Contenttr0 = dochtml0body1template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttemplate0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate0Contenttr0.NodeType);

        var dochtml0body1template0Contenttd1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttd1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttd1.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttd1.NodeType);
    }

    [Fact]
    public void TemplateNodeInColgroupWithCol()
    {
        var doc = (@"<body><table><colgroup><template><col></col></template></colgroup></table></body>").ToHtmlDocument();

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

        var dochtml0body1table0colgroup0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0colgroup0.ChildNodes);
        Assert.Empty(dochtml0body1table0colgroup0.Attributes);
        Assert.Equal("colgroup", dochtml0body1table0colgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0colgroup0.NodeType);

        var dochtml0body1table0colgroup0template0 = dochtml0body1table0colgroup0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0colgroup0template0.ChildNodes);
        Assert.Empty(dochtml0body1table0colgroup0template0.Attributes);
        Assert.Equal("template", dochtml0body1table0colgroup0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0colgroup0template0.NodeType);

        var dochtml0body1table0colgroup0template0Content = ((HtmlTemplateElement)dochtml0body1table0colgroup0template0).Content;
        Assert.Single(dochtml0body1table0colgroup0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1table0colgroup0template0Content.NodeType);

        var dochtml0body1table0colgroup0template0Contentcol0 = dochtml0body1table0colgroup0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0colgroup0template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0body1table0colgroup0template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0body1table0colgroup0template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0colgroup0template0Contentcol0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithAttrAndDivAndOtherBody()
    {
        var doc = (@"<body a=b><template><div></div><body c=d><div></div></body></template></body>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
        Assert.NotNull(dochtml0body1.Attributes.GetNamedItem("a"));
        Assert.Equal("a", dochtml0body1.Attributes.GetNamedItem("a").Name);
        Assert.Equal("b", dochtml0body1.Attributes.GetNamedItem("a").Value);

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentdiv0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0body1template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentdiv0.NodeType);

        var dochtml0body1template0Contentdiv1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contentdiv1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentdiv1.Attributes);
        Assert.Equal("div", dochtml0body1template0Contentdiv1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentdiv1.NodeType);
    }

    [Fact]
    public void TemplateNodeInHtmlWithAttrWithDivAndOtherHtml()
    {
        var doc = (@"<html a=b><template><div><html b=c><span></template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Single(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);
        Assert.NotNull(dochtml0.Attributes.GetNamedItem("a"));
        Assert.Equal("a", dochtml0.Attributes.GetNamedItem("a").Name);
        Assert.Equal("b", dochtml0.Attributes.GetNamedItem("a").Value);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentdiv0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0head0template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentdiv0.NodeType);

        var dochtml0head0template0Contentdiv0span0 = dochtml0head0template0Contentdiv0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentdiv0span0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentdiv0span0.Attributes);
        Assert.Equal("span", dochtml0head0template0Contentdiv0span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentdiv0span0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeInHtmlWithAttrWithColAndOtherHtml()
    {
        var doc = (@"<html a=b><template><col></col><html b=c><col></col></template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Single(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);
        Assert.NotNull(dochtml0.Attributes.GetNamedItem("a"));
        Assert.Equal("a", dochtml0.Attributes.GetNamedItem("a").Name);
        Assert.Equal("b", dochtml0.Attributes.GetNamedItem("a").Value);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Equal(2, dochtml0head0template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentcol0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0head0template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentcol0.NodeType);

        var dochtml0head0template0Contentcol1 = dochtml0head0template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0head0template0Contentcol1.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentcol1.Attributes);
        Assert.Equal("col", dochtml0head0template0Contentcol1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentcol1.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeInHtmlWithAttrWithFrameAndOtherHtml()
    {
        var doc = (@"<html a=b><template><frame></frame><html b=c><frame></frame></template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Single(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);
        Assert.NotNull(dochtml0.Attributes.GetNamedItem("a"));
        Assert.Equal("a", dochtml0.Attributes.GetNamedItem("a").Name);
        Assert.Equal("b", dochtml0.Attributes.GetNamedItem("a").Value);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Empty(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTrAndNestedTemplate()
    {
        var doc = (@"<body><template><tr></tr><template></template><td></td></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(3, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttr0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr0.NodeType);

        var dochtml0body1template0Contenttemplate1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate1.Attributes);
        Assert.Equal("template", dochtml0body1template0Contenttemplate1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate1.NodeType);

        var dochtml0body1template0Contenttemplate1Content = ((HtmlTemplateElement)dochtml0body1template0Contenttemplate1).Content;
        Assert.Empty(dochtml0body1template0Contenttemplate1Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Contenttemplate1Content.NodeType);

        var dochtml0body1template0Contenttr2 = dochtml0body1template0Content.ChildNodes[2] as Element;
        Assert.Single(dochtml0body1template0Contenttr2.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr2.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttr2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr2.NodeType);

        var dochtml0body1template0Contenttr2td0 = dochtml0body1template0Contenttr2.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttr2td0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttr2td0.Attributes);
        Assert.Equal("td", dochtml0body1template0Contenttr2td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttr2td0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithTheadTrTfootNestedTemplateWithTr()
    {
        var doc = (@"<body><template><thead></thead><template><tr></tr></template><tr></tr><tfoot></tfoot></template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(4, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentthead0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentthead0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentthead0.Attributes);
        Assert.Equal("thead", dochtml0body1template0Contentthead0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentthead0.NodeType);

        var dochtml0body1template0Contenttemplate1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate1.Attributes);
        Assert.Equal("template", dochtml0body1template0Contenttemplate1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate1.NodeType);

        var dochtml0body1template0Contenttemplate1Content = ((HtmlTemplateElement)dochtml0body1template0Contenttemplate1).Content;
        Assert.Single(dochtml0body1template0Contenttemplate1Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Contenttemplate1Content.NodeType);

        var dochtml0body1template0Contenttemplate1Contenttr0 = dochtml0body1template0Contenttemplate1Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate1Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate1Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttemplate1Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate1Contenttr0.NodeType);

        var dochtml0body1template0Contenttbody2 = dochtml0body1template0Content.ChildNodes[2] as Element;
        Assert.Single(dochtml0body1template0Contenttbody2.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttbody2.Attributes);
        Assert.Equal("tbody", dochtml0body1template0Contenttbody2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttbody2.NodeType);

        var dochtml0body1template0Contenttbody2tr0 = dochtml0body1template0Contenttbody2.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttbody2tr0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttbody2tr0.Attributes);
        Assert.Equal("tr", dochtml0body1template0Contenttbody2tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttbody2tr0.NodeType);

        var dochtml0body1template0Contenttfoot3 = dochtml0body1template0Content.ChildNodes[3] as Element;
        Assert.Empty(dochtml0body1template0Contenttfoot3.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttfoot3.Attributes);
        Assert.Equal("tfoot", dochtml0body1template0Contenttfoot3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttfoot3.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithNestedTemplateBTemplateAndText()
    {
        var doc = (@"<body><template><template><b><template></template></template>text</template>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenttemplate0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0body1template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate0.NodeType);

        var dochtml0body1template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0body1template0Contenttemplate0).Content;
        Assert.Single(dochtml0body1template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Contenttemplate0Content.NodeType);

        var dochtml0body1template0Contenttemplate0Contentb0 = dochtml0body1template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1template0Contenttemplate0Contentb0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate0Contentb0.Attributes);
        Assert.Equal("b", dochtml0body1template0Contenttemplate0Contentb0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate0Contentb0.NodeType);

        var dochtml0body1template0Contenttemplate0Contentb0template0 = dochtml0body1template0Contenttemplate0Contentb0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate0Contentb0template0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate0Contentb0template0.Attributes);
        Assert.Equal("template", dochtml0body1template0Contenttemplate0Contentb0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate0Contentb0template0.NodeType);

        var dochtml0body1template0Contenttemplate0Contentb0template0Content = ((HtmlTemplateElement)dochtml0body1template0Contenttemplate0Contentb0template0).Content;
        Assert.Empty(dochtml0body1template0Contenttemplate0Contentb0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Contenttemplate0Contentb0template0Content.NodeType);

        var dochtml0body1template0ContentText1 = dochtml0body1template0Content.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1template0ContentText1.NodeType);
        Assert.Equal("text", dochtml0body1template0ContentText1.TextContent);
    }

    [Fact]
    public void TemplateNodeWithColColgroupInBody()
    {
        var doc = (@"<body><template><col><colgroup>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentcol0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0body1template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentcol0.NodeType);
    }

    [Fact]
    public void TemplateNodeWithColMisclosedColgroupInBody()
    {
        var doc = (@"<body><template><col></colgroup>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentcol0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0body1template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentcol0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithColAndColgroup()
    {
        var doc = (@"<body><template><col><colgroup></template></body>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentcol0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0body1template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentcol0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithColDiv()
    {
        var doc = (@"<body><template><col><div>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentcol0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0body1template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentcol0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithColMisclosedDiv()
    {
        var doc = (@"<body><template><col></div>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentcol0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0body1template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentcol0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithColAndText()
    {
        var doc = (@"<body><template><col>Hello").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Single(dochtml0body1template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentcol0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0body1template0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentcol0.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithItalicAndMenuAndText()
    {
        var doc = (@"<body><template><i><menu>Foo</i>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contenti0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0Contenti0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenti0.Attributes);
        Assert.Equal("i", dochtml0body1template0Contenti0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenti0.NodeType);

        var dochtml0body1template0Contentmenu1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1template0Contentmenu1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentmenu1.Attributes);
        Assert.Equal("menu", dochtml0body1template0Contentmenu1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentmenu1.NodeType);

        var dochtml0body1template0Contentmenu1i0 = dochtml0body1template0Contentmenu1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1template0Contentmenu1i0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentmenu1i0.Attributes);
        Assert.Equal("i", dochtml0body1template0Contentmenu1i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentmenu1i0.NodeType);

        var dochtml0body1template0Contentmenu1i0Text0 = dochtml0body1template0Contentmenu1i0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1template0Contentmenu1i0Text0.NodeType);
        Assert.Equal("Foo", dochtml0body1template0Contentmenu1i0Text0.TextContent);
    }

    [Fact]
    public void TemplateNodeWithMisclosedDivDivTextAndNestedTemplateInBody()
    {
        var doc = (@"<body><template></div><div>Foo</div><template></template><tr></tr>").ToHtmlDocument();

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

        var dochtml0body1template0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1template0.ChildNodes);
        Assert.Empty(dochtml0body1template0.Attributes);
        Assert.Equal("template", dochtml0body1template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0.NodeType);

        var dochtml0body1template0Content = ((HtmlTemplateElement)dochtml0body1template0).Content;
        Assert.Equal(2, dochtml0body1template0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Content.NodeType);

        var dochtml0body1template0Contentdiv0 = dochtml0body1template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0body1template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0body1template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contentdiv0.NodeType);

        var dochtml0body1template0Contentdiv0Text0 = dochtml0body1template0Contentdiv0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1template0Contentdiv0Text0.NodeType);
        Assert.Equal("Foo", dochtml0body1template0Contentdiv0Text0.TextContent);

        var dochtml0body1template0Contenttemplate1 = dochtml0body1template0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1template0Contenttemplate1.ChildNodes);
        Assert.Empty(dochtml0body1template0Contenttemplate1.Attributes);
        Assert.Equal("template", dochtml0body1template0Contenttemplate1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1template0Contenttemplate1.NodeType);

        var dochtml0body1template0Contenttemplate1Content = ((HtmlTemplateElement)dochtml0body1template0Contenttemplate1).Content;
        Assert.Empty(dochtml0body1template0Contenttemplate1Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1template0Contenttemplate1Content.NodeType);
    }

    [Fact]
    public void TemplateNodeInBodyWithMisclosedDivTrTdAndText()
    {
        var doc = (@"<body><div><template></div><tr><td>Foo</td></tr></template>").ToHtmlDocument();

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

        var dochtml0body1div0template0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0template0.ChildNodes);
        Assert.Empty(dochtml0body1div0template0.Attributes);
        Assert.Equal("template", dochtml0body1div0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0template0.NodeType);

        var dochtml0body1div0template0Content = ((HtmlTemplateElement)dochtml0body1div0template0).Content;
        Assert.Single(dochtml0body1div0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0body1div0template0Content.NodeType);

        var dochtml0body1div0template0Contenttr0 = dochtml0body1div0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0template0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0body1div0template0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0body1div0template0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0template0Contenttr0.NodeType);

        var dochtml0body1div0template0Contenttr0td0 = dochtml0body1div0template0Contenttr0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0template0Contenttr0td0.ChildNodes);
        Assert.Empty(dochtml0body1div0template0Contenttr0td0.Attributes);
        Assert.Equal("td", dochtml0body1div0template0Contenttr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0template0Contenttr0td0.NodeType);

        var dochtml0body1div0template0Contenttr0td0Text0 = dochtml0body1div0template0Contenttr0td0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0template0Contenttr0td0Text0.NodeType);
        Assert.Equal("Foo", dochtml0body1div0template0Contenttr0td0Text0.TextContent);
    }

    [Fact]
    public void TemplateNodeMisclosedFigcaptionAndSubAndTable()
    {
        var doc = (@"<template></figcaption><sub><table></table>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentsub0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0template0Contentsub0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentsub0.Attributes);
        Assert.Equal("sub", dochtml0head0template0Contentsub0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentsub0.NodeType);

        var dochtml0head0template0Contentsub0table0 = dochtml0head0template0Contentsub0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentsub0table0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentsub0table0.Attributes);
        Assert.Equal("table", dochtml0head0template0Contentsub0table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentsub0table0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeEmptyNested()
    {
        var doc = (@"<template><template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Empty(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeWithDivStandalone()
    {
        var doc = (@"<template><div>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentdiv0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0head0template0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentdiv0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithDiv()
    {
        var doc = (@"<template><template><div>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contentdiv0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentdiv0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentdiv0.Attributes);
        Assert.Equal("div", dochtml0head0template0Contenttemplate0Contentdiv0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contentdiv0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithTable()
    {
        var doc = (@"<template><template><table>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contenttable0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttable0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttable0.Attributes);
        Assert.Equal("table", dochtml0head0template0Contenttemplate0Contenttable0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contenttable0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithTbody()
    {
        var doc = (@"<template><template><tbody>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contenttbody0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttbody0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttbody0.Attributes);
        Assert.Equal("tbody", dochtml0head0template0Contenttemplate0Contenttbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contenttbody0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithTr()
    {
        var doc = (@"<template><template><tr>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contenttr0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttr0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttr0.Attributes);
        Assert.Equal("tr", dochtml0head0template0Contenttemplate0Contenttr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contenttr0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithTd()
    {
        var doc = (@"<template><template><td>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contenttd0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0head0template0Contenttemplate0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contenttd0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithCaption()
    {
        var doc = (@"<template><template><caption>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contentcaption0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentcaption0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentcaption0.Attributes);
        Assert.Equal("caption", dochtml0head0template0Contenttemplate0Contentcaption0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contentcaption0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithColgroup()
    {
        var doc = (@"<template><template><colgroup>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contentcolgroup0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentcolgroup0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentcolgroup0.Attributes);
        Assert.Equal("colgroup", dochtml0head0template0Contenttemplate0Contentcolgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contentcolgroup0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithCol()
    {
        var doc = (@"<template><template><col>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contentcol0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentcol0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentcol0.Attributes);
        Assert.Equal("col", dochtml0head0template0Contenttemplate0Contentcol0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contentcol0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithSelectInTbody()
    {
        var doc = (@"<template><template><tbody><select>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Equal(2, dochtml0head0template0Contenttemplate0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contenttbody0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttbody0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttbody0.Attributes);
        Assert.Equal("tbody", dochtml0head0template0Contenttemplate0Contenttbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contenttbody0.NodeType);

        var dochtml0head0template0Contenttemplate0Contentselect1 = dochtml0head0template0Contenttemplate0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentselect1.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentselect1.Attributes);
        Assert.Equal("select", dochtml0head0template0Contenttemplate0Contentselect1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contentselect1.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithTextInTable()
    {
        var doc = (@"<template><template><table>Foo").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Equal(2, dochtml0head0template0Contenttemplate0Content.ChildNodes.Length);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0ContentText0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0template0Contenttemplate0ContentText0.NodeType);
        Assert.Equal("Foo", dochtml0head0template0Contenttemplate0ContentText0.TextContent);

        var dochtml0head0template0Contenttemplate0Contenttable1 = dochtml0head0template0Contenttemplate0Content.ChildNodes[1] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttable1.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contenttable1.Attributes);
        Assert.Equal("table", dochtml0head0template0Contenttemplate0Contenttable1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contenttable1.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithFrame()
    {
        var doc = (@"<template><template><frame>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Empty(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithScriptUnclosed()
    {
        var doc = (@"<template><template><script>var i").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contentscript0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0template0Contenttemplate0Contentscript0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentscript0.Attributes);
        Assert.Equal("script", dochtml0head0template0Contenttemplate0Contentscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contentscript0.NodeType);

        var dochtml0head0template0Contenttemplate0Contentscript0Text0 = dochtml0head0template0Contenttemplate0Contentscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0template0Contenttemplate0Contentscript0Text0.NodeType);
        Assert.Equal("var i", dochtml0head0template0Contenttemplate0Contentscript0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeNestedWithStyleUnclosed()
    {
        var doc = (@"<template><template><style>var i").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttemplate0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttemplate0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contenttemplate0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0.NodeType);

        var dochtml0head0template0Contenttemplate0Content = ((HtmlTemplateElement)dochtml0head0template0Contenttemplate0).Content;
        Assert.Single(dochtml0head0template0Contenttemplate0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Contenttemplate0Content.NodeType);

        var dochtml0head0template0Contenttemplate0Contentstyle0 = dochtml0head0template0Contenttemplate0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0template0Contenttemplate0Contentstyle0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttemplate0Contentstyle0.Attributes);
        Assert.Equal("style", dochtml0head0template0Contenttemplate0Contentstyle0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttemplate0Contentstyle0.NodeType);

        var dochtml0head0template0Contenttemplate0Contentstyle0Text0 = dochtml0head0template0Contenttemplate0Contentstyle0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0template0Contenttemplate0Contentstyle0Text0.NodeType);
        Assert.Equal("var i", dochtml0head0template0Contenttemplate0Contentstyle0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TemplateNodeWithTableBeforeBodySpanText()
    {
        var doc = (@"<template><table></template><body><span>Foo").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttable0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttable0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttable0.Attributes);
        Assert.Equal("table", dochtml0head0template0Contenttable0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttable0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1span0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1span0.ChildNodes);
        Assert.Empty(dochtml0body1span0.Attributes);
        Assert.Equal("span", dochtml0body1span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1span0.NodeType);

        var dochtml0body1span0Text0 = dochtml0body1span0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1span0Text0.NodeType);
        Assert.Equal("Foo", dochtml0body1span0Text0.TextContent);
    }

    [Fact]
    public void TemplateNodeWithTdBeforeBodySpanText()
    {
        var doc = (@"<template><td></template><body><span>Foo").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contenttd0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contenttd0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contenttd0.Attributes);
        Assert.Equal("td", dochtml0head0template0Contenttd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contenttd0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1span0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1span0.ChildNodes);
        Assert.Empty(dochtml0body1span0.Attributes);
        Assert.Equal("span", dochtml0body1span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1span0.NodeType);

        var dochtml0body1span0Text0 = dochtml0body1span0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1span0Text0.NodeType);
        Assert.Equal("Foo", dochtml0body1span0Text0.TextContent);
    }

    [Fact]
    public void TemplateNodeWithObjectBeforeBodySpanText()
    {
        var doc = (@"<template><object></template><body><span>Foo").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentobject0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentobject0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentobject0.Attributes);
        Assert.Equal("object", dochtml0head0template0Contentobject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentobject0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1span0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1span0.ChildNodes);
        Assert.Empty(dochtml0body1span0.Attributes);
        Assert.Equal("span", dochtml0body1span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1span0.NodeType);

        var dochtml0body1span0Text0 = dochtml0body1span0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1span0Text0.NodeType);
        Assert.Equal("Foo", dochtml0body1span0Text0.TextContent);
    }

    [Fact]
    public void TemplateNodeWithSvgAndNestedTemplate()
    {
        var doc = (@"<template><svg><template>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0template0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0.NodeType);

        var dochtml0head0template0Content = ((HtmlTemplateElement)dochtml0head0template0).Content;
        Assert.Single(dochtml0head0template0Content.ChildNodes);
        Assert.Equal(NodeType.DocumentFragment, dochtml0head0template0Content.NodeType);

        var dochtml0head0template0Contentsvg0 = dochtml0head0template0Content.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0template0Contentsvg0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentsvg0.Attributes);
        Assert.Equal("svg", dochtml0head0template0Contentsvg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentsvg0.NodeType);

        var dochtml0head0template0Contentsvg0template0 = dochtml0head0template0Contentsvg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0template0Contentsvg0template0.ChildNodes);
        Assert.Empty(dochtml0head0template0Contentsvg0template0.Attributes);
        Assert.Equal("template", dochtml0head0template0Contentsvg0template0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0template0Contentsvg0template0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
}
