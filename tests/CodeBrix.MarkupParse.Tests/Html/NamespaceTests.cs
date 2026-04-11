using CodeBrix.MarkupParse.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests14.dat
/// </summary>

public class NamespaceTests
{
    private static readonly string HtmlWithNestedSvgElement = @"<!DOCTYPE html>
<div><span><svg xmlns=""http://www.w3.org/2000/svg""><svg><circle /></svg></svg></span></div>";

    [Fact]
    public void UnknownElementWithUnknownNamespaceInBody()
    {
        var doc = (@"<!DOCTYPE html><html><body><xyz:abc></xyz:abc>").ToHtmlDocument();

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

        var dochtml1body1xyzabc0 = dochtml1body1.ChildNodes[0];
        Assert.Empty(dochtml1body1xyzabc0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1xyzabc0).Attributes);
        Assert.Equal("xyz:abc", dochtml1body1xyzabc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1xyzabc0.NodeType);
    }

    [Fact]
    public void UnknownElementWithUnknownNamespaceInBodyBeforeSpan()
    {
        var doc = (@"<!DOCTYPE html><html><body><xyz:abc></xyz:abc><span></span>").ToHtmlDocument();

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

        var dochtml1body1xyzabc0 = dochtml1body1.ChildNodes[0];
        Assert.Empty(dochtml1body1xyzabc0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1xyzabc0).Attributes);
        Assert.Equal("xyz:abc", dochtml1body1xyzabc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1xyzabc0.NodeType);

        var dochtml1body1span1 = dochtml1body1.ChildNodes[1];
        Assert.Empty(dochtml1body1span1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1span1).Attributes);
        Assert.Equal("span", dochtml1body1span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1span1.NodeType);
    }

    [Fact]
    public void UnknownElementWithUnknownNamespaceInHtmlWithUnknownAttribute()
    {
        var doc = (@"<!DOCTYPE html><html><html abc:def=gh><xyz:abc></xyz:abc>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Single(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        Assert.NotNull(((Element)dochtml1).GetAttribute("abc:def"));
        Assert.Equal("gh", ((Element)dochtml1).GetAttribute("abc:def"));

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

        var dochtml1body1xyzabc0 = dochtml1body1.ChildNodes[0];
        Assert.Empty(dochtml1body1xyzabc0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1xyzabc0).Attributes);
        Assert.Equal("xyz:abc", dochtml1body1xyzabc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1xyzabc0.NodeType);
    }

    [Fact]
    public void DuplicatedHtmlTagWithMultipleXmlLangAttributes()
    {
        var doc = (@"<!DOCTYPE html><html xml:lang=bar><html xml:lang=foo>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Single(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        Assert.NotNull(((Element)dochtml1).GetAttribute("xml:lang"));
        Assert.Equal("bar", ((Element)dochtml1).GetAttribute("xml:lang"));

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
    public void NumericAttributeWithNumericValue()
    {
        var doc = (@"<!DOCTYPE html><html 123=456>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Single(((Element)dochtml1).Attributes);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        Assert.NotNull(((Element)dochtml1).GetAttribute("123"));
        Assert.Equal("456", ((Element)dochtml1).GetAttribute("123"));

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
    public void DuplicatedHtmlTagWithDifferentNumericAttributes()
    {
        var doc = (@"<!DOCTYPE html><html 123=456><html 789=012>").ToHtmlDocument();

        var docType0 = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(docType0);
        Assert.Equal(NodeType.DocumentType, docType0.NodeType);
        Assert.Equal(@"html", docType0.Name);

        var dochtml1 = doc.ChildNodes[1];
        Assert.Equal(2, dochtml1.ChildNodes.Length);
        Assert.Equal(2, ((Element)dochtml1).Attributes.Length);
        Assert.Equal("html", dochtml1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1.NodeType);

        Assert.NotNull(((Element)dochtml1).GetAttribute("123"));
        Assert.Equal("456", ((Element)dochtml1).GetAttribute("123"));

        Assert.NotNull(((Element)dochtml1).GetAttribute("789"));
        Assert.Equal("012", ((Element)dochtml1).GetAttribute("789"));

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
    public void BodyTagWithNumericAttribute()
    {
        var doc = (@"<!DOCTYPE html><html><body 789=012>").ToHtmlDocument();

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
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Single(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        Assert.NotNull(((Element)dochtml1body1).GetAttribute("789"));
        Assert.Equal("012", ((Element)dochtml1body1).GetAttribute("789"));
    }

    [Fact]
    public void HtmlElementsAreUppercaseSvgElementsLowercase()
    {
        var doc = (HtmlWithNestedSvgElement).ToHtmlDocument();
        var body = doc.Body;
        var div = body.FirstElementChild;
        var span = div.FirstElementChild;
        var svg = span.FirstElementChild;
        Assert.Equal("BODY", body.TagName);
        Assert.Equal("DIV", div.TagName);
        Assert.Equal("SPAN", span.TagName);
        Assert.Equal("svg", svg.TagName);
    }

    [Fact]
    public void NestedSvgElementHasSameNameAsNormalSvgElement()
    {
        var doc = (HtmlWithNestedSvgElement).ToHtmlDocument();
        var svg = doc.Body.FirstElementChild.FirstElementChild.FirstElementChild;
        var nestedSvg = svg.FirstElementChild;
        var circle = nestedSvg.FirstElementChild;
        Assert.Equal("svg", nestedSvg.TagName);
        Assert.Equal("circle", circle.TagName);
    }
}
