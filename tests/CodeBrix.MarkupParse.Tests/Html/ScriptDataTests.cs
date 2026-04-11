using CodeBrix.MarkupParse.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/scriptdata01.dat
/// </summary>

public class ScriptDataTests
{
    [Fact]
    public void ScriptWithQuotedHelloText()
    {
        var doc = (@"FOO<script>'Hello'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'Hello'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithNoContent()
    {
        var doc = (@"FOO<script></script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithNoContentAndSpaceInClosingTag()
    {
        var doc = (@"FOO<script></script >BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void ScriptWithNoContentAndSelfClosingClosingTag()
    {
        var doc = (@"FOO<script></script/>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void ScriptWithNoContentAndSpacedSelfClosingClosingTag()
    {
        var doc = (@"FOO<script></script/ >BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void ScriptWithAttributeAndWrongClosingTag()
    {
        var doc = (@"FOO<script type=""text/plain""></scriptx>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("</scriptx>BAR", dochtml0body1script1Text0.TextContent);
    }

    [Fact]
    public void ScriptWithAttributeInClosingTag()
    {
        var doc = (@"FOO<script></script foo="" > "" dd>BAR").ToHtmlDocument();
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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void ScriptWithQuotedLtInText()
    {
        var doc = (@"FOO<script>'<'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithQuotedLtEmInText()
    {
        var doc = (@"FOO<script>'<!'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithQuotedLtEmDashInText()
    {
        var doc = (@"FOO<script>'<!-'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithQuotedCommentStartInText()
    {
        var doc = (@"FOO<script>'<!--'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!--'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithQuotedCommentStartAndDashInText()
    {
        var doc = (@"FOO<script>'<!---'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!---'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithQuotedEmptyCommentInText()
    {
        var doc = (@"FOO<script>'<!-->'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-->'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithQuotedEmptyShortCommentInText()
    {
        var doc = (@"FOO<script>'<!-->'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-->'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithQuotedPotatoCommentInText()
    {
        var doc = (@"FOO<script>'<!-- potato'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- potato'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithQuotedScriptEndInComment()
    {
        var doc = (@"FOO<script>'<!-- <sCrIpt'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithAttributesAndQuotedScriptEnd()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt>'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt>'</script>BAR", dochtml0body1script1Text0.TextContent);
    }

    [Fact]
    public void ScriptWithAttributesAndQuotedScriptStart()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt> -'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt> -'</script>BAR", dochtml0body1script1Text0.TextContent);
    }

    [Fact]
    public void ScriptWithAttributesAndQuotedScriptStartMoreDashes()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt> --'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt> --'</script>BAR", dochtml0body1script1Text0.TextContent);
    }

    [Fact]
    public void ScriptWithValidCommentAndStartInQuotes()
    {
        var doc = (@"FOO<script>'<!-- <sCrIpt> -->'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Empty(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt> -->'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);
    }

    [Fact]
    public void ScriptWithAttributeAndToleratedStartInCommentAndQuotes()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt> --!>'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt> --!>'</script>BAR", dochtml0body1script1Text0.TextContent);
    }

    [Fact]
    public void ScriptWithAttributeAndInvalidCommentAndQuotes()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt> -- >'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt> -- >'</script>BAR", dochtml0body1script1Text0.TextContent);
    }

    [Fact]
    public void ScriptWithAttributeAndInvalidStartOfCommentAndQuotes()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt '</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt '</script>BAR", dochtml0body1script1Text0.TextContent);
    }

    [Fact]
    public void ScriptWithAttributeAndInvalidStartOfCommentAndQuotesTrailingSolidus()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt/'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt/'</script>BAR", dochtml0body1script1Text0.TextContent);
    }

    [Fact]
    public void ScriptWithAttributeAndInvalidStartOfCommentAndQuotesTrailingBackslash()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt\'</script>BAR").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal(@"'<!-- <sCrIpt\'", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("BAR", dochtml0body1Text2.TextContent);

    }

    [Fact]
    public void ScriptWithAttributeAndInvalidStartOfCommentAndQuotesConsistentlyClosed()
    {
        var doc = (@"FOO<script type=""text/plain"">'<!-- <sCrIpt/'</script>BAR</script>QUX").ToHtmlDocument();

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

        var dochtml0body1script1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1script1.ChildNodes);
        Assert.Single(dochtml0body1script1.Attributes);
        Assert.Equal("script", dochtml0body1script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script1.NodeType);
        Assert.Equal("text/plain", dochtml0body1script1.GetAttribute("type"));

        var dochtml0body1script1Text0 = dochtml0body1script1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script1Text0.NodeType);
        Assert.Equal("'<!-- <sCrIpt/'</script>BAR", dochtml0body1script1Text0.TextContent);

        var dochtml0body1Text2 = dochtml0body1.ChildNodes[2];
        Assert.Equal(NodeType.Text, dochtml0body1Text2.NodeType);
        Assert.Equal("QUX", dochtml0body1Text2.TextContent);
    }
}
