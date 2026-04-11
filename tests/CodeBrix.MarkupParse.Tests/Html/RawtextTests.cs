using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests5.dat
/// </summary>

public class RawtextTests
{
    [Fact]
    public void IllegalCommentStartInStyleElement()
    {
        var doc = (@"<style> <!-- </style>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0style0).Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal(" <!-- ", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("x", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void StartOfCommentInStyleElement()
    {
        var doc = (@"<style> <!-- </style> --> </style>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Equal(2, dochtml0head0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0style0).Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal(" <!-- ", dochtml0head0style0Text0.TextContent);

        var dochtml0head0Text1 = dochtml0head0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0head0Text1.NodeType);
        Assert.Equal(" ", dochtml0head0Text1.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("--> x", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void IllegalCommentInStyleTag()
    {
        var doc = (@"<style> <!--> </style>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0style0).Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal(" <!--> ", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("x", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void CommentInStyleElement()
    {
        var doc = (@"<style> <!---> </style>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0style0).Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal(" <!---> ", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("x", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void CommentInIframeElement()
    {
        var doc = (@"<iframe> <!---> </iframe>x").ToHtmlDocument();

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

        var dochtml0body1iframe0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1iframe0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1iframe0).Attributes);
        Assert.Equal("iframe", dochtml0body1iframe0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1iframe0.NodeType);

        var dochtml0body1iframe0Text0 = dochtml0body1iframe0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1iframe0Text0.NodeType);
        Assert.Equal(" <!---> ", dochtml0body1iframe0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("x", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void StartOfCommentInIframeElement()
    {
        var doc = (@"<iframe> <!--- </iframe>->x</iframe> --> </iframe>x").ToHtmlDocument();

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

        var dochtml0body1iframe0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1iframe0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1iframe0).Attributes);
        Assert.Equal("iframe", dochtml0body1iframe0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1iframe0.NodeType);

        var dochtml0body1iframe0Text0 = dochtml0body1iframe0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1iframe0Text0.NodeType);
        Assert.Equal(" <!--- ", dochtml0body1iframe0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("->x --> x", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void StartOfCommentInScriptElement()
    {
        var doc = (@"<script> <!-- </script> --> </script>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Equal(2, dochtml0head0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0script0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0script0).Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0head0script0Text0 = dochtml0head0script0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0script0Text0.NodeType);
        Assert.Equal(" <!-- ", dochtml0head0script0Text0.TextContent);

        var dochtml0head0Text1 = dochtml0head0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0head0Text1.NodeType);
        Assert.Equal(" ", dochtml0head0Text1.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("--> x", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void StartOfCommentInTitleElement()
    {
        var doc = (@"<title> <!-- </title> --> </title>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Equal(2, dochtml0head0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0title0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0title0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0title0).Attributes);
        Assert.Equal("title", dochtml0head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0title0.NodeType);

        var dochtml0head0title0Text0 = dochtml0head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0title0Text0.NodeType);
        Assert.Equal(" <!-- ", dochtml0head0title0Text0.TextContent);

        var dochtml0head0Text1 = dochtml0head0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0head0Text1.NodeType);
        Assert.Equal(" ", dochtml0head0Text1.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("--> x", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void StartOfCommentInTextareaElement()
    {
        var doc = (@"<textarea> <!--- </textarea>->x</textarea> --> </textarea>x").ToHtmlDocument();

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

        var dochtml0body1textarea0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1textarea0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1textarea0).Attributes);
        Assert.Equal("textarea", dochtml0body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1textarea0.NodeType);

        var dochtml0body1textarea0Text0 = dochtml0body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1textarea0Text0.NodeType);
        Assert.Equal(" <!--- ", dochtml0body1textarea0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("->x --> x", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void RawtextHalfCommentInStyleElement()
    {
        var doc = (@"<style> <!</-- </style>x").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0style0).Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal(" <!</-- ", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("x", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void XmpInParagraphElement()
    {
        var doc = (@"<p><xmp></xmp>").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1p0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1p0).Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);

        var dochtml0body1xmp1 = dochtml0body1.ChildNodes[1];
        Assert.Empty(dochtml0body1xmp1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1xmp1).Attributes);
        Assert.Equal("xmp", dochtml0body1xmp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1xmp1.NodeType);
    }

    [Fact]
    public void RawtextInXmpTag()
    {
        var doc = (@"<xmp> <!-- > --> </xmp>").ToHtmlDocument();

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

        var dochtml0body1xmp0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1xmp0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1xmp0).Attributes);
        Assert.Equal("xmp", dochtml0body1xmp0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1xmp0.NodeType);

        var dochtml0body1xmp0Text0 = dochtml0body1xmp0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1xmp0Text0.NodeType);
        Assert.Equal(" <!-- > --> ", dochtml0body1xmp0Text0.TextContent);
    }

    [Fact]
    public void EntityInTitleTag()
    {
        var doc = (@"<title>&amp;</title>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0title0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0title0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0title0).Attributes);
        Assert.Equal("title", dochtml0head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0title0.NodeType);

        var dochtml0head0title0Text0 = dochtml0head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0title0Text0.NodeType);
        Assert.Equal("&", dochtml0head0title0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void CommentAndEntityInTitleText()
    {
        var doc = (@"<title><!--&amp;--></title>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0title0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0title0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0title0).Attributes);
        Assert.Equal("title", dochtml0head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0title0.NodeType);

        var dochtml0head0title0Text0 = dochtml0head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0title0Text0.NodeType);
        Assert.Equal("<!--&-->", dochtml0head0title0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TitleTriggersRawtextMode()
    {
        var doc = (@"<title><!--</title>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0title0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0title0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0title0).Attributes);
        Assert.Equal("title", dochtml0head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0title0.NodeType);

        var dochtml0head0title0Text0 = dochtml0head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0title0Text0.NodeType);
        Assert.Equal("<!--", dochtml0head0title0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void NoScriptTriggersRawtextMode()
    {
        var config = Configuration.Default.WithScripting();
        var doc = (@"<noscript><!--</noscript>--></noscript>").ToHtmlDocument(config);

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0noscript0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0noscript0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0noscript0).Attributes);
        Assert.Equal("noscript", dochtml0head0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0noscript0.NodeType);

        var dochtml0head0noscript0Text0 = dochtml0head0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0noscript0Text0.NodeType);
        Assert.Equal("<!--", dochtml0head0noscript0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("-->", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void NoScriptElementWithComment()
    {
        var doc = (@"<noscript><!--</noscript>--></noscript>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0noscript0 = dochtml0head0.ChildNodes[0];
        Assert.Single(dochtml0head0noscript0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0noscript0).Attributes);
        Assert.Equal("noscript", dochtml0head0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0noscript0.NodeType);

        var dochtml0head0noscript0Comment0 = dochtml0head0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Comment, dochtml0head0noscript0Comment0.NodeType);
        Assert.Equal(@"</noscript>", dochtml0head0noscript0Comment0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }
}
