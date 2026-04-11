using CodeBrix.MarkupParse.Dom;
using Xunit;
using System;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/comments01.dat
/// </summary>

public class HtmlCommentTests
{
    [Fact]
    public void ValidCommentInText()
    {
        var doc = (@"FOO<!-- BAR -->BAZ").ToHtmlDocument();

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
        Assert.Equal(3, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" BAR ", dochtml0body1Comment1.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAZ", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ToleratedComment()
    {
        var doc = (@"FOO<!-- BAR --!>BAZ").ToHtmlDocument();

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
        Assert.Equal(3, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" BAR ", dochtml0body1Comment1.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAZ", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void InvalidComment()
    {
        var doc = (@"FOO<!-- BAR --   >BAZ").ToHtmlDocument();

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
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" BAR --   >BAZ", dochtml0body1Comment1.TextContent);
    }

    [Fact]
    public void ValidCommentWithTagInside()
    {
        var doc = (@"FOO<!-- BAR -- <QUX> -- MUX -->BAZ").ToHtmlDocument();

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
        Assert.Equal(3, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" BAR -- <QUX> -- MUX ", dochtml0body1Comment1.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAZ", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void ToleratedCommentWithTagInside()
    {
        var doc = (@"FOO<!-- BAR -- <QUX> -- MUX --!>BAZ").ToHtmlDocument();

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
        Assert.Equal(3, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" BAR -- <QUX> -- MUX ", dochtml0body1Comment1.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAZ", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void InvalidCommentWithTagInside()
    {
        var doc = (@"FOO<!-- BAR -- <QUX> -- MUX -- >BAZ").ToHtmlDocument();

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
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" BAR -- <QUX> -- MUX -- >BAZ", dochtml0body1Comment1.TextContent);
    }

    [Fact]
    public void ToleratedInvalidEmptyComment4Dashes()
    {
        var doc = (@"FOO<!---->BAZ").ToHtmlDocument();

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
        Assert.Equal(3, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@"", dochtml0body1Comment1.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAZ", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ToleratedInvalidEmptyComment3Dashes()
    {
        var doc = (@"FOO<!--->BAZ").ToHtmlDocument();

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
        Assert.Equal(3, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@"", dochtml0body1Comment1.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAZ", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void ToleratedInvalidEmptyComment2Dashes()
    {
        var doc = (@"FOO<!-->BAZ").ToHtmlDocument();

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
        Assert.Equal(3, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@"", dochtml0body1Comment1.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAZ", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void XmlPreambleAsBogusCommentFollowedByText()
    {
        var doc = (@"<?xml version=""1.0"">Hi").ToHtmlDocument();

        var docComment0 = doc.ChildNodes[0];
        Assert.Equal(NodeType.Comment, docComment0.NodeType);
        Assert.Equal(@"?xml version=""1.0""", docComment0.TextContent);

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

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("Hi", dochtml1body1Text0.TextContent);
    }

    [Fact]
    public void XmlPreambleAsBogusCommentStandalone()
    {
        var doc = (@"<?xml version=""1.0"">").ToHtmlDocument();

        var docComment0 = doc.ChildNodes[0];
        Assert.Equal(NodeType.Comment, docComment0.NodeType);
        Assert.Equal(@"?xml version=""1.0""", docComment0.TextContent);

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
    public void XmlPreambleFragmentWithEOF()
    {
        var doc = (@"<?xml version").ToHtmlDocument();

        var docComment0 = doc.ChildNodes[0];
        Assert.Equal(NodeType.Comment, docComment0.NodeType);
        Assert.Equal(@"?xml version", docComment0.TextContent);

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
    public void ToleratedInvalidEmptyComment5Dashes()
    {
        var doc = (@"FOO<!----->BAZ").ToHtmlDocument();

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
        Assert.Equal(3, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@"-", dochtml0body1Comment1.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAZ", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void ValidCommentInRoot()
    {
        var doc = (@"<html><!-- comment --><title>Comment before head</title>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0Comment0 = dochtml0.ChildNodes[0];
        Assert.Equal(NodeType.Comment, dochtml0Comment0.NodeType);
        Assert.Equal(@" comment ", dochtml0Comment0.TextContent);

        var dochtml0head1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0head1.ChildNodes);
        Assert.Empty(dochtml0head1.Attributes);
        Assert.Equal("head", dochtml0head1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head1.NodeType);

        var dochtml0head1title0 = dochtml0head1.ChildNodes[0] as Element;
        Assert.Single(dochtml0head1title0.ChildNodes);
        Assert.Empty(dochtml0head1title0.Attributes);
        Assert.Equal("title", dochtml0head1title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head1title0.NodeType);

        var dochtml0head1title0Text0 = dochtml0head1title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head1title0Text0.NodeType);
        Assert.Equal("Comment before head", dochtml0head1title0Text0.TextContent);

        var dochtml0body2 = dochtml0.ChildNodes[2] as Element;
        Assert.Empty(dochtml0body2.ChildNodes);
        Assert.Empty(dochtml0body2.Attributes);
        Assert.Equal("body", dochtml0body2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body2.NodeType);

    }

    [Fact]
    public void MassiveCommentInNBCPage()
    {
        try
        {
            var doc = (Assets.nbc).ToHtmlDocument();
            Assert.NotNull(doc);
            Assert.Equal(1152, doc.QuerySelectorAll("*").Length);
        }
        catch (StackOverflowException)
        {
            Assert.Fail("The parsing resulted in a stackoverflow.");
        }
    }

    [Fact]
    public void CommentInHtmlCausesException()
    {
        var source = "<!DOCTYPE html><body><!---------------------GA--------------------------- --></body></html>";
        var doc = (source).ToHtmlDocument();
        Assert.NotNull(doc);
    }

    [Fact]
    public void CommentAtTheEndOfXHtmlDocumentShouldNotCauseException()
    {
        var source = @"<html xmlns=""http://www.w3.org/1999/xhtml"">
<head></head>
<body></body>
</html>
<!-- Comment -->";
        var document = source.ToHtmlDocument();
        Assert.NotNull(document);
        Assert.NotNull(document.ToHtml());
    }
}
