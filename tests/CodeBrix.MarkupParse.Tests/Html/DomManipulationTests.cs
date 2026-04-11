using CodeBrix.MarkupParse.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests (automatically modified and adjusted originally) taken from
/// http://w3c-test.org/html/dom/documents/dom-tree-accessors/document.body-getter.html
/// </summary>

public class DomManipulationTests
{
    private static IDocument CreateDocument()
    {
        var doc = string.Empty.ToHtmlDocument();
        doc.RemoveChild(doc.DocumentElement);
        return doc;
    }

    [Fact]
    public void ChildlessDocument()
    {
        var doc = CreateDocument();
        Assert.Null(doc.Body);
    }

    [Fact]
    public void ChildlessHtmlElement()
    {
        var doc = CreateDocument();
        doc.AppendChild(doc.CreateElement("html"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void BodyFollowedByFramesetInsideTheHtmlElement()
    {
        var doc = CreateDocument();
        var html = doc.AppendChild(doc.CreateElement("html"));
        var b = html.AppendChild(doc.CreateElement("body"));
        html.AppendChild(doc.CreateElement("frameset"));
        Assert.Equal(b, doc.Body);
    }

    [Fact]
    public void FramesetFollowedByBodyInsideTheHtmlElement()
    {
        var doc = CreateDocument();
        var html = doc.AppendChild(doc.CreateElement("html"));
        var f = html.AppendChild(doc.CreateElement("frameset"));
        html.AppendChild(doc.CreateElement("body"));
        Assert.Equal(f, doc.Body);
    }

    [Fact]
    public void BodyFollowedByFramesetInsideAnonHtmlElement()
    {
        var doc = CreateDocument();
        var html = doc.AppendChild(doc.CreateElement("http://example.org/test", "html"));
        html.AppendChild(doc.CreateElement("body"));
        html.AppendChild(doc.CreateElement("frameset"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void FramesetFollowedByBodyInsideAnonHtmlElement()
    {
        var doc = CreateDocument();
        var html = doc.AppendChild(doc.CreateElement("http://example.org/test", "html"));
        html.AppendChild(doc.CreateElement("frameset"));
        html.AppendChild(doc.CreateElement("body"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void NonHtmlBodyFollowedByBodyInsideTheHtmlElement()
    {
        var doc = CreateDocument();
        var html = doc.AppendChild(doc.CreateElement("html"));
        html.AppendChild(doc.CreateElement("http://example.org/test", "body"));
        var b = html.AppendChild(doc.CreateElement("body"));
        Assert.Equal(b, doc.Body);
    }

    [Fact]
    public void NonHtmlFramesetFollowedByBodyInsideTheHtmlElement()
    {
        var doc = CreateDocument();
        var html = doc.AppendChild(doc.CreateElement("html"));
        html.AppendChild(doc.CreateElement("http://example.org/test", "frameset"));
        var b = html.AppendChild(doc.CreateElement("body"));
        Assert.Equal(b, doc.Body);
    }

    [Fact]
    public void BodyInsideAnxElementFollowedByBody()
    {
        var doc = CreateDocument();
        var html = doc.AppendChild(doc.CreateElement("html"));
        var x = html.AppendChild(doc.CreateElement("x"));
        x.AppendChild(doc.CreateElement("body"));
        var body = html.AppendChild(doc.CreateElement("body"));
        Assert.Equal(body, doc.Body);
    }

    [Fact]
    public void FramesetInsideAnXElementFollowedByFrameset()
    {
        var doc = CreateDocument();
        var html = doc.AppendChild(doc.CreateElement("html"));
        var x = html.AppendChild(doc.CreateElement("x"));
        x.AppendChild(doc.CreateElement("frameset"));
        var frameset = html.AppendChild(doc.CreateElement("frameset"));
        Assert.Equal(frameset, doc.Body);
    }

    [Fact]
    public void BodyAsTheRootNode()
    {
        var doc = CreateDocument();
        doc.AppendChild(doc.CreateElement("body"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void FramesetAsTheRootNode()
    {
        var doc = CreateDocument();
        doc.AppendChild(doc.CreateElement("frameset"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void BodyAsTheRootNodeWithAFramesetChild()
    {
        var doc = CreateDocument();
        var body = doc.AppendChild(doc.CreateElement("body"));
        body.AppendChild(doc.CreateElement("frameset"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void FramesetAsTheRootNodeWithABodyChild()
    {
        var doc = CreateDocument();
        var frameset = doc.AppendChild(doc.CreateElement("frameset"));
        frameset.AppendChild(doc.CreateElement("body"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void NonHtmlBodyAsTheRootNode()
    {
        var doc = CreateDocument();
        doc.AppendChild(doc.CreateElement("http://example.org/test", "body"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void NonHtmlFramesetAsTheRootNode()
    {
        var doc = CreateDocument();
        doc.AppendChild(doc.CreateElement("http://example.org/test", "frameset"));
        Assert.Null(doc.Body);
    }

    [Fact]
    public void DocumentTitleExactMatch()
    {
        var doc = "<title>document.title with head blown away</title>".ToHtmlDocument();
        Assert.Equal("document.title with head blown away", doc.Title);
    }

    [Fact]
    public void DocumentRemoveHeadAndReadOutTitle()
    {
        var doc = "<title>document.title with head blown away</title>".ToHtmlDocument();
        var head = doc.GetElementsByTagName("head")[0];
        Assert.NotNull(head);
        head.Parent.RemoveChild(head);
        Assert.Empty(doc.GetElementsByTagName("head"));
        doc.Title = "FAIL";
        Assert.Equal("", doc.Title);
    }
    
    [Fact]
    public void DocumentFreshTitleAppendedAfterHeadRemoved()
    {
        var doc = "<title>document.title with head blown away</title>".ToHtmlDocument();
        var head = doc.GetElementsByTagName("head")[0];
        Assert.NotNull(head);
        head.Parent.RemoveChild(head);
        var title2 = doc.CreateElement("title");
        title2.AppendChild(doc.CreateTextNode("PASS"));
        doc.Body.AppendChild(title2);
        Assert.Equal("PASS", doc.Title);
    }
    
    [Fact]
    public void DocumentInsertTitleBeforePreviouslyInsertedTitle()
    {
        var doc = "<title>document.title with head blown away</title>".ToHtmlDocument();
        var head = doc.GetElementsByTagName("head")[0];
        Assert.NotNull(head);
        head.Parent.RemoveChild(head);
        var title2 = doc.CreateElement("title");
        title2.AppendChild(doc.CreateTextNode("PASS"));
        doc.Body.AppendChild(title2);
        Assert.Equal("PASS", doc.Title);
        var title3 = doc.CreateElement("title");
        title3.AppendChild(doc.CreateTextNode("PASS2"));
        doc.DocumentElement.InsertBefore(title3, doc.Body);
        Assert.Equal("PASS2", doc.Title);
    }

    [Fact]
    public void RemoveAttributeWithSpecialCharacterWorks()
    {
        var document = "<TAG MÍ=\"\" />".ToHtmlDocument();
        var element = document.Body.FirstElementChild;

        Assert.Single(element.Attributes);
        element.RemoveAttribute(element.Attributes[0].Name);
        Assert.Empty(element.Attributes);
    }
}
