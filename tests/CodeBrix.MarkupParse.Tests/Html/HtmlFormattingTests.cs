using CodeBrix.MarkupParse.Dom;
using Xunit;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tests22.dat,
/// tree-construction/tests23.dat
/// </summary>

public class HtmlFormattingTests
{
    [Fact]
    public void FormattingEightFontTagsWithParagraph()
    {
        var doc = (@"<p><font size=4><font color=red><font size=4><font size=4><font size=4><font size=4><font size=4><font color=red><p>X").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0.ChildNodes);
        Assert.Empty(dochtml0body1p0.Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);

        var dochtml0body1p0font0 = dochtml0body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0.NodeType);
        Assert.NotNull(dochtml0body1p0font0.GetAttribute("size"));
        Assert.Equal("4", dochtml0body1p0font0.GetAttribute("size"));

        var dochtml0body1p0font0font0 = dochtml0body1p0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0.NodeType);
        Assert.NotNull(dochtml0body1p0font0font0.GetAttribute("color"));
        Assert.Equal("red", dochtml0body1p0font0font0.GetAttribute("color"));

        var dochtml0body1p0font0font0font0 = dochtml0body1p0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0.NodeType);

        var attr1 = dochtml0body1p0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr1);
        Assert.Equal("size", attr1.Name);
        Assert.Equal("4", attr1.Value);

        var dochtml0body1p0font0font0font0font0 = dochtml0body1p0font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0.NodeType);

        var attr2 = dochtml0body1p0font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr2);
        Assert.Equal("size", attr2.Name);
        Assert.Equal("4", attr2.Value);

        var dochtml0body1p0font0font0font0font0font0 = dochtml0body1p0font0font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0font0.NodeType);

        var attr3 = dochtml0body1p0font0font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr3);
        Assert.Equal("size", attr3.Name);
        Assert.Equal("4", attr3.Value);

        var dochtml0body1p0font0font0font0font0font0font0 = dochtml0body1p0font0font0font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0font0font0.NodeType);

        var attr4 = dochtml0body1p0font0font0font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr4);
        Assert.Equal("size", attr4.Name);
        Assert.Equal("4", attr4.Value);

        var dochtml0body1p0font0font0font0font0font0font0font0 = dochtml0body1p0font0font0font0font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0font0font0font0.NodeType);

        var attr5 = dochtml0body1p0font0font0font0font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr5);
        Assert.Equal("size", attr5.Name);
        Assert.Equal("4", attr5.Value);

        var dochtml0body1p0font0font0font0font0font0font0font0font0 = dochtml0body1p0font0font0font0font0font0font0font0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1p0font0font0font0font0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0font0font0font0font0.NodeType);

        var attr6 = dochtml0body1p0font0font0font0font0font0font0font0font0.Attributes.GetNamedItem("color");
        Assert.NotNull(attr6);
        Assert.Equal("color", attr6.Name);
        Assert.Equal("red", attr6.Value);

        var dochtml0body1p1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p1.ChildNodes);
        Assert.Empty(dochtml0body1p1.Attributes);
        Assert.Equal("p", dochtml0body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1.NodeType);

        var dochtml0body1p1font0 = dochtml0body1p1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0.NodeType);

        var attr7 = dochtml0body1p1font0.Attributes.GetNamedItem("color");
        Assert.NotNull(attr7);
        Assert.Equal("color", attr7.Name);
        Assert.Equal("red", attr7.Value);

        var dochtml0body1p1font0font0 = dochtml0body1p1font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0.NodeType);

        var attr8 = dochtml0body1p1font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr8);
        Assert.Equal("size", attr8.Name);
        Assert.Equal("4", attr8.Value);

        var dochtml0body1p1font0font0font0 = dochtml0body1p1font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0font0.NodeType);

        var attr9 = dochtml0body1p1font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr9);
        Assert.Equal("size", attr9.Name);
        Assert.Equal("4", attr9.Value);

        var dochtml0body1p1font0font0font0font0 = dochtml0body1p1font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0font0font0.NodeType);

        var attr10 = dochtml0body1p1font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr10);
        Assert.Equal("size", attr10.Name);
        Assert.Equal("4", attr10.Value);

        var dochtml0body1p1font0font0font0font0font0 = dochtml0body1p1font0font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0font0font0font0.NodeType);

        var attr11 = dochtml0body1p1font0font0font0font0font0.Attributes.GetNamedItem("color");
        Assert.NotNull(attr11);
        Assert.Equal("color", attr11.Name);
        Assert.Equal("red", attr11.Value);

        var dochtml0body1p1font0font0font0font0font0Text0 = dochtml0body1p1font0font0font0font0font0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p1font0font0font0font0font0Text0.NodeType);
        Assert.Equal("X", dochtml0body1p1font0font0font0font0font0Text0.TextContent);
    }

    [Fact]
    public void FormattingThreeFontTagsWithParagraph()
    {
        var doc = (@"<p><font size=4><font size=4><font size=4><font size=4><p>X").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0.ChildNodes);
        Assert.Empty(dochtml0body1p0.Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);

        var dochtml0body1p0font0 = dochtml0body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0.NodeType);

        var attr1 = dochtml0body1p0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr1);
        Assert.Equal("size", attr1.Name);
        Assert.Equal("4", attr1.Value);

        var dochtml0body1p0font0font0 = dochtml0body1p0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0.NodeType);

        var attr2 = dochtml0body1p0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr2);
        Assert.Equal("size", attr2.Name);
        Assert.Equal("4", attr2.Value);

        var dochtml0body1p0font0font0font0 = dochtml0body1p0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0.NodeType);

        var attr3 = dochtml0body1p0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr3);
        Assert.Equal("size", attr3.Name);
        Assert.Equal("4", attr3.Value);

        var dochtml0body1p0font0font0font0font0 = dochtml0body1p0font0font0font0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1p0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0.NodeType);

        var attr4 = dochtml0body1p0font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr4);
        Assert.Equal("size", attr4.Name);
        Assert.Equal("4", attr4.Value);

        var dochtml0body1p1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p1.ChildNodes);
        Assert.Empty(dochtml0body1p1.Attributes);
        Assert.Equal("p", dochtml0body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1.NodeType);

        var dochtml0body1p1font0 = dochtml0body1p1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0.NodeType);

        var attr5 = dochtml0body1p1font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr5);
        Assert.Equal("size", attr5.Name);
        Assert.Equal("4", attr5.Value);

        var dochtml0body1p1font0font0 = dochtml0body1p1font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0.NodeType);

        var attr6 = dochtml0body1p1font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr6);
        Assert.Equal("size", attr6.Name);
        Assert.Equal("4", attr6.Value);
        var dochtml0body1p1font0font0font0 = dochtml0body1p1font0font0.ChildNodes[0] as Element;

        Assert.Single(dochtml0body1p1font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0font0.NodeType);

        var attr7 = dochtml0body1p1font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr7);
        Assert.Equal("size", attr7.Name);
        Assert.Equal("4", attr7.Value);

        var dochtml0body1p1font0font0font0Text0 = dochtml0body1p1font0font0font0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p1font0font0font0Text0.NodeType);
        Assert.Equal("X", dochtml0body1p1font0font0font0Text0.TextContent);
    }

    [Fact]
    public void FormattingFiveFontTagsWithParagraph()
    {
        var doc = (@"<p><font size=4><font size=4><font size=4><font size=""5""><font size=4><p>X").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0.ChildNodes);
        Assert.Empty(dochtml0body1p0.Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);

        var dochtml0body1p0font0 = dochtml0body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0.NodeType);
        Assert.NotNull(dochtml0body1p0font0.Attributes.GetNamedItem("size"));
        Assert.Equal("size", dochtml0body1p0font0.Attributes.GetNamedItem("size").Name);
        Assert.Equal("4", dochtml0body1p0font0.Attributes.GetNamedItem("size").Value);

        var dochtml0body1p0font0font0 = dochtml0body1p0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0.NodeType);
        Assert.NotNull(dochtml0body1p0font0font0.Attributes.GetNamedItem("size"));
        Assert.Equal("size", dochtml0body1p0font0font0.Attributes.GetNamedItem("size").Name);
        Assert.Equal("4", dochtml0body1p0font0font0.Attributes.GetNamedItem("size").Value);

        var dochtml0body1p0font0font0font0 = dochtml0body1p0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0.NodeType);
        Assert.NotNull(dochtml0body1p0font0font0font0.Attributes.GetNamedItem("size"));
        Assert.Equal("size", dochtml0body1p0font0font0font0.Attributes.GetNamedItem("size").Name);
        Assert.Equal("4", dochtml0body1p0font0font0font0.Attributes.GetNamedItem("size").Value);

        var dochtml0body1p0font0font0font0font0 = dochtml0body1p0font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0.NodeType);
        Assert.NotNull(dochtml0body1p0font0font0font0font0.Attributes.GetNamedItem("size"));
        Assert.Equal("size", dochtml0body1p0font0font0font0font0.Attributes.GetNamedItem("size").Name);
        Assert.Equal("5", dochtml0body1p0font0font0font0font0.Attributes.GetNamedItem("size").Value);

        var dochtml0body1p0font0font0font0font0font0 = dochtml0body1p0font0font0font0font0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1p0font0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0font0.NodeType);
        Assert.NotNull(dochtml0body1p0font0font0font0font0font0.Attributes.GetNamedItem("size"));
        Assert.Equal("size", dochtml0body1p0font0font0font0font0font0.Attributes.GetNamedItem("size").Name);
        Assert.Equal("4", dochtml0body1p0font0font0font0font0font0.Attributes.GetNamedItem("size").Value);

        var dochtml0body1p1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p1.ChildNodes);
        Assert.Empty(dochtml0body1p1.Attributes);
        Assert.Equal("p", dochtml0body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1.NodeType);

        var dochtml0body1p1font0 = dochtml0body1p1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0.NodeType);
        Assert.NotNull(dochtml0body1p1font0.Attributes.GetNamedItem("size"));
        Assert.Equal("size", dochtml0body1p1font0.Attributes.GetNamedItem("size").Name);
        Assert.Equal("4", dochtml0body1p1font0.Attributes.GetNamedItem("size").Value);

        var dochtml0body1p1font0font0 = dochtml0body1p1font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0.NodeType);
        Assert.NotNull(dochtml0body1p1font0font0.Attributes.GetNamedItem("size"));
        Assert.Equal("size", dochtml0body1p1font0font0.Attributes.GetNamedItem("size").Name);
        Assert.Equal("4", dochtml0body1p1font0font0.Attributes.GetNamedItem("size").Value);

        var dochtml0body1p1font0font0font0 = dochtml0body1p1font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0font0.NodeType);
        Assert.NotNull(dochtml0body1p1font0font0font0.Attributes.GetNamedItem("size"));
        Assert.Equal("size", dochtml0body1p1font0font0font0.Attributes.GetNamedItem("size").Name);
        Assert.Equal("5", dochtml0body1p1font0font0font0.Attributes.GetNamedItem("size").Value);

        var dochtml0body1p1font0font0font0font0 = dochtml0body1p1font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0font0font0.NodeType);

        var attr9 = dochtml0body1p1font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr9);
        Assert.Equal("size", attr9.Name);
        Assert.Equal("4", attr9.Value);

        var dochtml0body1p1font0font0font0font0Text0 = dochtml0body1p1font0font0font0font0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p1font0font0font0font0Text0.NodeType);
        Assert.Equal("X", dochtml0body1p1font0font0font0font0Text0.TextContent);
    }

    [Fact]
    public void FormattingFourFontTagsWithParagraph()
    {
        var doc = (@"<p><font size=4 id=a><font size=4 id=b><font size=4><font size=4><p>X").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0.ChildNodes);
        Assert.Empty(dochtml0body1p0.Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);

        var dochtml0body1p0font0 = dochtml0body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0.ChildNodes);
        Assert.Equal(2, dochtml0body1p0font0.Attributes.Count());
        Assert.Equal("font", dochtml0body1p0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0.NodeType);

        var attr1 = dochtml0body1p0font0.Attributes.GetNamedItem("id");
        Assert.NotNull(attr1);
        Assert.Equal("id", attr1.Name);
        Assert.Equal("a", attr1.Value);

        var attr2 = dochtml0body1p0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr2);
        Assert.Equal("size", attr2.Name);
        Assert.Equal("4", attr2.Value);

        var dochtml0body1p0font0font0 = dochtml0body1p0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0.ChildNodes);
        Assert.Equal(2, dochtml0body1p0font0font0.Attributes.Count());
        Assert.Equal("font", dochtml0body1p0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0.NodeType);

        var attr3 = dochtml0body1p0font0font0.Attributes.GetNamedItem("id");
        Assert.NotNull(attr3);
        Assert.Equal("id", attr3.Name);
        Assert.Equal("b", attr3.Value);

        var attr4 = dochtml0body1p0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr4);
        Assert.Equal("size", attr4.Name);
        Assert.Equal("4", attr4.Value);

        var dochtml0body1p0font0font0font0 = dochtml0body1p0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0.NodeType);

        var attr5 = dochtml0body1p0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr5);
        Assert.Equal("size", attr5.Name);
        Assert.Equal("4", attr5.Value);

        var dochtml0body1p0font0font0font0font0 = dochtml0body1p0font0font0font0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1p0font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p0font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p0font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0font0font0font0font0.NodeType);

        var attr6 = dochtml0body1p0font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr6);
        Assert.Equal("size", attr6.Name);
        Assert.Equal("4", attr6.Value);

        var dochtml0body1p1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p1.ChildNodes);
        Assert.Empty(dochtml0body1p1.Attributes);
        Assert.Equal("p", dochtml0body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1.NodeType);

        var dochtml0body1p1font0 = dochtml0body1p1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0.ChildNodes);
        Assert.Equal(2, dochtml0body1p1font0.Attributes.Count());
        Assert.Equal("font", dochtml0body1p1font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0.NodeType);

        var attr7 = dochtml0body1p1font0.Attributes.GetNamedItem("id");
        Assert.NotNull(attr7);
        Assert.Equal("id", attr7.Name);
        Assert.Equal("a", attr7.Value);

        var attr8 = dochtml0body1p1font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr8);
        Assert.Equal("size", attr8.Name);
        Assert.Equal("4", attr8.Value);

        var dochtml0body1p1font0font0 = dochtml0body1p1font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0.ChildNodes);
        Assert.Equal(2, dochtml0body1p1font0font0.Attributes.Count());
        Assert.Equal("font", dochtml0body1p1font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0.NodeType);

        var attr9 = dochtml0body1p1font0font0.Attributes.GetNamedItem("id");
        Assert.NotNull(attr9);
        Assert.Equal("id", attr9.Name);
        Assert.Equal("b", attr9.Value);

        var attr10 = dochtml0body1p1font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr10);
        Assert.Equal("size", attr10.Name);
        Assert.Equal("4", attr10.Value);

        var dochtml0body1p1font0font0font0 = dochtml0body1p1font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0font0.NodeType);

        var attr11 = dochtml0body1p1font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr11);
        Assert.Equal("size", attr11.Name);
        Assert.Equal("4", attr11.Value);

        var dochtml0body1p1font0font0font0font0 = dochtml0body1p1font0font0font0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1font0font0font0font0.ChildNodes);
        Assert.Single(dochtml0body1p1font0font0font0font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0font0font0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0font0font0font0.NodeType);

        var attr12 = dochtml0body1p1font0font0font0font0.Attributes.GetNamedItem("size");
        Assert.NotNull(attr12);
        Assert.Equal("size", attr12.Name);
        Assert.Equal("4", attr12.Value);

        var dochtml0body1p1font0font0font0font0Text0 = dochtml0body1p1font0font0font0font0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p1font0font0font0font0Text0.NodeType);
        Assert.Equal("X", dochtml0body1p1font0font0font0font0Text0.TextContent);
    }

    [Fact]
    public void FormattingMultipleBoldTagsWithObject()
    {
        var doc = (@"<p><b id=a><b id=a><b id=a><b><object><b id=a><b id=a>X</object><p>Y").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0.ChildNodes);
        Assert.Empty(dochtml0body1p0.Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);

        var dochtml0body1p0b0 = dochtml0body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0b0.ChildNodes);
        Assert.Single(dochtml0body1p0b0.Attributes);
        Assert.Equal("b", dochtml0body1p0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0b0.NodeType);
        Assert.NotNull(dochtml0body1p0b0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1p0b0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("a", dochtml0body1p0b0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p0b0b0 = dochtml0body1p0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0b0b0.ChildNodes);
        Assert.Single(dochtml0body1p0b0b0.Attributes);
        Assert.Equal("b", dochtml0body1p0b0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0b0b0.NodeType);
        Assert.NotNull(dochtml0body1p0b0b0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1p0b0b0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("a", dochtml0body1p0b0b0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p0b0b0b0 = dochtml0body1p0b0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0b0b0b0.ChildNodes);
        Assert.Single(dochtml0body1p0b0b0b0.Attributes);
        Assert.Equal("b", dochtml0body1p0b0b0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0b0b0b0.NodeType);
        Assert.NotNull(dochtml0body1p0b0b0b0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1p0b0b0b0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("a", dochtml0body1p0b0b0b0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p0b0b0b0b0 = dochtml0body1p0b0b0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0b0b0b0b0.ChildNodes);
        Assert.Empty(dochtml0body1p0b0b0b0b0.Attributes);
        Assert.Equal("b", dochtml0body1p0b0b0b0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0b0b0b0b0.NodeType);

        var dochtml0body1p0b0b0b0b0object0 = dochtml0body1p0b0b0b0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0b0b0b0b0object0.ChildNodes);
        Assert.Empty(dochtml0body1p0b0b0b0b0object0.Attributes);
        Assert.Equal("object", dochtml0body1p0b0b0b0b0object0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0b0b0b0b0object0.NodeType);

        var dochtml0body1p0b0b0b0b0object0b0 = dochtml0body1p0b0b0b0b0object0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0b0b0b0b0object0b0.ChildNodes);
        Assert.Single(dochtml0body1p0b0b0b0b0object0b0.Attributes);
        Assert.Equal("b", dochtml0body1p0b0b0b0b0object0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0b0b0b0b0object0b0.NodeType);
        Assert.NotNull(dochtml0body1p0b0b0b0b0object0b0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1p0b0b0b0b0object0b0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("a", dochtml0body1p0b0b0b0b0object0b0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p0b0b0b0b0object0b0b0 = dochtml0body1p0b0b0b0b0object0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0b0b0b0b0object0b0b0.ChildNodes);
        Assert.Single(dochtml0body1p0b0b0b0b0object0b0b0.Attributes);
        Assert.Equal("b", dochtml0body1p0b0b0b0b0object0b0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0b0b0b0b0object0b0b0.NodeType);
        Assert.NotNull(dochtml0body1p0b0b0b0b0object0b0b0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1p0b0b0b0b0object0b0b0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("a", dochtml0body1p0b0b0b0b0object0b0b0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p0b0b0b0b0object0b0b0Text0 = dochtml0body1p0b0b0b0b0object0b0b0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p0b0b0b0b0object0b0b0Text0.NodeType);
        Assert.Equal("X", dochtml0body1p0b0b0b0b0object0b0b0Text0.TextContent);

        var dochtml0body1p1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p1.ChildNodes);
        Assert.Empty(dochtml0body1p1.Attributes);
        Assert.Equal("p", dochtml0body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1.NodeType);

        var dochtml0body1p1b0 = dochtml0body1p1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1b0.ChildNodes);
        Assert.Single(dochtml0body1p1b0.Attributes);
        Assert.Equal("b", dochtml0body1p1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1b0.NodeType);
        Assert.NotNull(dochtml0body1p1b0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1p1b0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("a", dochtml0body1p1b0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p1b0b0 = dochtml0body1p1b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1b0b0.ChildNodes);
        Assert.Single(dochtml0body1p1b0b0.Attributes);
        Assert.Equal("b", dochtml0body1p1b0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1b0b0.NodeType);
        Assert.NotNull(dochtml0body1p1b0b0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1p1b0b0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("a", dochtml0body1p1b0b0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p1b0b0b0 = dochtml0body1p1b0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1b0b0b0.ChildNodes);
        Assert.Single(dochtml0body1p1b0b0b0.Attributes);
        Assert.Equal("b", dochtml0body1p1b0b0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1b0b0b0.NodeType);
        Assert.NotNull(dochtml0body1p1b0b0b0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1p1b0b0b0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("a", dochtml0body1p1b0b0b0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p1b0b0b0b0 = dochtml0body1p1b0b0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p1b0b0b0b0.ChildNodes);
        Assert.Empty(dochtml0body1p1b0b0b0b0.Attributes);
        Assert.Equal("b", dochtml0body1p1b0b0b0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1b0b0b0b0.NodeType);

        var dochtml0body1p1b0b0b0b0Text0 = dochtml0body1p1b0b0b0b0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p1b0b0b0b0Text0.NodeType);
        Assert.Equal("Y", dochtml0body1p1b0b0b0b0Text0.TextContent);
    }

    [Fact]
    public void FormattingMultipleTagsWithXInDivSurroundedByAnchor()
    {
        var doc = (@"<a><b><big><em><strong><div>X</a>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1a0.ChildNodes);
        Assert.Empty(dochtml0body1a0.Attributes);
        Assert.Equal("a", dochtml0body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0.NodeType);

        var dochtml0body1a0b0 = dochtml0body1a0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1a0b0.ChildNodes);
        Assert.Empty(dochtml0body1a0b0.Attributes);
        Assert.Equal("b", dochtml0body1a0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0b0.NodeType);

        var dochtml0body1a0b0big0 = dochtml0body1a0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1a0b0big0.ChildNodes);
        Assert.Empty(dochtml0body1a0b0big0.Attributes);
        Assert.Equal("big", dochtml0body1a0b0big0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0b0big0.NodeType);

        var dochtml0body1a0b0big0em0 = dochtml0body1a0b0big0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1a0b0big0em0.ChildNodes);
        Assert.Empty(dochtml0body1a0b0big0em0.Attributes);
        Assert.Equal("em", dochtml0body1a0b0big0em0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0b0big0em0.NodeType);

        var dochtml0body1a0b0big0em0strong0 = dochtml0body1a0b0big0em0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1a0b0big0em0strong0.ChildNodes);
        Assert.Empty(dochtml0body1a0b0big0em0strong0.Attributes);
        Assert.Equal("strong", dochtml0body1a0b0big0em0strong0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0b0big0em0strong0.NodeType);

        var dochtml0body1big1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1big1.ChildNodes);
        Assert.Empty(dochtml0body1big1.Attributes);
        Assert.Equal("big", dochtml0body1big1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1big1.NodeType);

        var dochtml0body1big1em0 = dochtml0body1big1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1big1em0.ChildNodes);
        Assert.Empty(dochtml0body1big1em0.Attributes);
        Assert.Equal("em", dochtml0body1big1em0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1big1em0.NodeType);

        var dochtml0body1big1em0strong0 = dochtml0body1big1em0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1big1em0strong0.ChildNodes);
        Assert.Empty(dochtml0body1big1em0strong0.Attributes);
        Assert.Equal("strong", dochtml0body1big1em0strong0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1big1em0strong0.NodeType);

        var dochtml0body1big1em0strong0div0 = dochtml0body1big1em0strong0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1big1em0strong0div0.ChildNodes);
        Assert.Empty(dochtml0body1big1em0strong0div0.Attributes);
        Assert.Equal("div", dochtml0body1big1em0strong0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1big1em0strong0div0.NodeType);

        var dochtml0body1big1em0strong0div0a0 = dochtml0body1big1em0strong0div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1big1em0strong0div0a0.ChildNodes);
        Assert.Empty(dochtml0body1big1em0strong0div0a0.Attributes);
        Assert.Equal("a", dochtml0body1big1em0strong0div0a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1big1em0strong0div0a0.NodeType);

        var dochtml0body1big1em0strong0div0a0Text0 = dochtml0body1big1em0strong0div0a0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1big1em0strong0div0a0Text0.NodeType);
        Assert.Equal("X", dochtml0body1big1em0strong0div0a0Text0.TextContent);
    }

    [Fact]
    public void FormattingEightDivsInBoldAndAnchor()
    {
        var doc = (@"<a><b><div id=1><div id=2><div id=3><div id=4><div id=5><div id=6><div id=7><div id=8>A</a>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1a0.ChildNodes);
        Assert.Empty(dochtml0body1a0.Attributes);
        Assert.Equal("a", dochtml0body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0.NodeType);

        var dochtml0body1a0b0 = dochtml0body1a0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1a0b0.ChildNodes);
        Assert.Empty(dochtml0body1a0b0.Attributes);
        Assert.Equal("b", dochtml0body1a0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0b0.NodeType);

        var dochtml0body1b1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1b1.ChildNodes);
        Assert.Empty(dochtml0body1b1.Attributes);
        Assert.Equal("b", dochtml0body1b1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1.NodeType);

        var dochtml0body1b1div0 = dochtml0body1b1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1b1div0.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0.Attributes);
        Assert.Equal("div", dochtml0body1b1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0.NodeType);

        Assert.NotNull(dochtml0body1b1div0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("1", dochtml0body1b1div0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0a0 = dochtml0body1b1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0a0.NodeType);

        var dochtml0body1b1div0div1 = dochtml0body1b1div0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("2", dochtml0body1b1div0div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1a0 = dochtml0body1b1div0div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1a0.NodeType);

        var dochtml0body1b1div0div1div1 = dochtml0body1b1div0div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("3", dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1a0 = dochtml0body1b1div0div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1 = dochtml0body1b1div0div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("4", dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1a0 = dochtml0body1b1div0div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1 = dochtml0body1b1div0div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("5", dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("6", dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("7", dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1.ChildNodes);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("8", dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0Text0 = dochtml0body1b1div0div1div1div1div1div1div1div1a0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1b1div0div1div1div1div1div1div1div1a0Text0.NodeType);
        Assert.Equal("A", dochtml0body1b1div0div1div1div1div1div1div1div1a0Text0.TextContent);
    }

    [Fact]
    public void FormattingNineDivsInBoldAndAnchor()
    {
        var doc = (@"<a><b><div id=1><div id=2><div id=3><div id=4><div id=5><div id=6><div id=7><div id=8><div id=9>A</a>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1a0.ChildNodes);
        Assert.Empty(dochtml0body1a0.Attributes);
        Assert.Equal("a", dochtml0body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0.NodeType);

        var dochtml0body1a0b0 = dochtml0body1a0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1a0b0.ChildNodes);
        Assert.Empty(dochtml0body1a0b0.Attributes);
        Assert.Equal("b", dochtml0body1a0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0b0.NodeType);

        var dochtml0body1b1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1b1.ChildNodes);
        Assert.Empty(dochtml0body1b1.Attributes);
        Assert.Equal("b", dochtml0body1b1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1.NodeType);

        var dochtml0body1b1div0 = dochtml0body1b1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1b1div0.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0.Attributes);
        Assert.Equal("div", dochtml0body1b1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0.NodeType);
        Assert.NotNull(dochtml0body1b1div0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("1", dochtml0body1b1div0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0a0 = dochtml0body1b1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0a0.NodeType);

        var dochtml0body1b1div0div1 = dochtml0body1b1div0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("2", dochtml0body1b1div0div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1a0 = dochtml0body1b1div0div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1a0.NodeType);

        var dochtml0body1b1div0div1div1 = dochtml0body1b1div0div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("3", dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1a0 = dochtml0body1b1div0div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1 = dochtml0body1b1div0div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("4", dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1a0 = dochtml0body1b1div0div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1 = dochtml0body1b1div0div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("5", dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("6", dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("7", dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1.ChildNodes);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("8", dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0div0 = dochtml0body1b1div0div1div1div1div1div1div1div1a0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.ChildNodes);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("9", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0div0Text0 = dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1b1div0div1div1div1div1div1div1div1a0div0Text0.NodeType);
        Assert.Equal("A", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0Text0.TextContent);
    }

    [Fact]
    public void FormattingTenDivsInBoldAndAnchor()
    {
        var doc = (@"<a><b><div id=1><div id=2><div id=3><div id=4><div id=5><div id=6><div id=7><div id=8><div id=9><div id=10>A</a>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1a0.ChildNodes);
        Assert.Empty(dochtml0body1a0.Attributes);
        Assert.Equal("a", dochtml0body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0.NodeType);

        var dochtml0body1a0b0 = dochtml0body1a0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1a0b0.ChildNodes);
        Assert.Empty(dochtml0body1a0b0.Attributes);
        Assert.Equal("b", dochtml0body1a0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0b0.NodeType);

        var dochtml0body1b1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1b1.ChildNodes);
        Assert.Empty(dochtml0body1b1.Attributes);
        Assert.Equal("b", dochtml0body1b1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1.NodeType);

        var dochtml0body1b1div0 = dochtml0body1b1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1b1div0.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0.Attributes);
        Assert.Equal("div", dochtml0body1b1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0.NodeType);

        Assert.NotNull(dochtml0body1b1div0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("1", dochtml0body1b1div0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0a0 = dochtml0body1b1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0a0.NodeType);

        var dochtml0body1b1div0div1 = dochtml0body1b1div0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("2", dochtml0body1b1div0div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1a0 = dochtml0body1b1div0div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1a0.NodeType);

        var dochtml0body1b1div0div1div1 = dochtml0body1b1div0div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("3", dochtml0body1b1div0div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1a0 = dochtml0body1b1div0div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1 = dochtml0body1b1div0div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("4", dochtml0body1b1div0div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1a0 = dochtml0body1b1div0div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1 = dochtml0body1b1div0div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("5", dochtml0body1b1div0div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("6", dochtml0body1b1div0div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes.Length);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("7", dochtml0body1b1div0div1div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1div1 = dochtml0body1b1div0div1div1div1div1div1div1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1.ChildNodes);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id").Name);
        Assert.Equal("8", dochtml0body1b1div0div1div1div1div1div1div1div1.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0 = dochtml0body1b1div0div1div1div1div1div1div1div1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0.ChildNodes);
        Assert.Empty(dochtml0body1b1div0div1div1div1div1div1div1div1a0.Attributes);
        Assert.Equal("a", dochtml0body1b1div0div1div1div1div1div1div1div1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1a0.NodeType);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0div0 = dochtml0body1b1div0div1div1div1div1div1div1div1a0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.ChildNodes);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("9", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0 = dochtml0body1b1div0div1div1div1div1div1div1div1a0div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0.ChildNodes);
        Assert.Single(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0.Attributes);
        Assert.Equal("div", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0.NodeType);
        Assert.NotNull(dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0.Attributes.GetNamedItem("id"));
        Assert.Equal("id", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0.Attributes.GetNamedItem("id").Name);
        Assert.Equal("10", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0Text0 = dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0Text0.NodeType);
        Assert.Equal("A", dochtml0body1b1div0div1div1div1div1div1div1div1a0div0div0Text0.TextContent);
    }

    [Fact]
    public void FormattingCiteBoldCiteItalicCiteItalicCiteItalicDivWithText()
    {
        var doc = (@"<cite><b><cite><i><cite><i><cite><i><div>X</b>TEST").ToHtmlDocument();

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

        var dochtml0body1cite0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1cite0.ChildNodes.Length);
        Assert.Empty(dochtml0body1cite0.Attributes);
        Assert.Equal("cite", dochtml0body1cite0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0.NodeType);

        var dochtml0body1cite0b0 = dochtml0body1cite0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1cite0b0.ChildNodes);
        Assert.Empty(dochtml0body1cite0b0.Attributes);
        Assert.Equal("b", dochtml0body1cite0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0b0.NodeType);

        var dochtml0body1cite0b0cite0 = dochtml0body1cite0b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1cite0b0cite0.ChildNodes);
        Assert.Empty(dochtml0body1cite0b0cite0.Attributes);
        Assert.Equal("cite", dochtml0body1cite0b0cite0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0b0cite0.NodeType);

        var dochtml0body1cite0b0cite0i0 = dochtml0body1cite0b0cite0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1cite0b0cite0i0.ChildNodes);
        Assert.Empty(dochtml0body1cite0b0cite0i0.Attributes);
        Assert.Equal("i", dochtml0body1cite0b0cite0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0b0cite0i0.NodeType);

        var dochtml0body1cite0b0cite0i0cite0 = dochtml0body1cite0b0cite0i0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1cite0b0cite0i0cite0.ChildNodes);
        Assert.Empty(dochtml0body1cite0b0cite0i0cite0.Attributes);
        Assert.Equal("cite", dochtml0body1cite0b0cite0i0cite0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0b0cite0i0cite0.NodeType);

        var dochtml0body1cite0b0cite0i0cite0i0 = dochtml0body1cite0b0cite0i0cite0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1cite0b0cite0i0cite0i0.ChildNodes);
        Assert.Empty(dochtml0body1cite0b0cite0i0cite0i0.Attributes);
        Assert.Equal("i", dochtml0body1cite0b0cite0i0cite0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0b0cite0i0cite0i0.NodeType);

        var dochtml0body1cite0b0cite0i0cite0i0cite0 = dochtml0body1cite0b0cite0i0cite0i0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1cite0b0cite0i0cite0i0cite0.ChildNodes);
        Assert.Empty(dochtml0body1cite0b0cite0i0cite0i0cite0.Attributes);
        Assert.Equal("cite", dochtml0body1cite0b0cite0i0cite0i0cite0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0b0cite0i0cite0i0cite0.NodeType);

        var dochtml0body1cite0b0cite0i0cite0i0cite0i0 = dochtml0body1cite0b0cite0i0cite0i0cite0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1cite0b0cite0i0cite0i0cite0i0.ChildNodes);
        Assert.Empty(dochtml0body1cite0b0cite0i0cite0i0cite0i0.Attributes);
        Assert.Equal("i", dochtml0body1cite0b0cite0i0cite0i0cite0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0b0cite0i0cite0i0cite0i0.NodeType);

        var dochtml0body1cite0i1 = dochtml0body1cite0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1cite0i1.ChildNodes);
        Assert.Empty(dochtml0body1cite0i1.Attributes);
        Assert.Equal("i", dochtml0body1cite0i1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0i1.NodeType);

        var dochtml0body1cite0i1i0 = dochtml0body1cite0i1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1cite0i1i0.ChildNodes);
        Assert.Empty(dochtml0body1cite0i1i0.Attributes);
        Assert.Equal("i", dochtml0body1cite0i1i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0i1i0.NodeType);

        var dochtml0body1cite0i1i0div0 = dochtml0body1cite0i1i0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1cite0i1i0div0.ChildNodes.Length);
        Assert.Empty(dochtml0body1cite0i1i0div0.Attributes);
        Assert.Equal("div", dochtml0body1cite0i1i0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0i1i0div0.NodeType);

        var dochtml0body1cite0i1i0div0b0 = dochtml0body1cite0i1i0div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1cite0i1i0div0b0.ChildNodes);
        Assert.Empty(dochtml0body1cite0i1i0div0b0.Attributes);
        Assert.Equal("b", dochtml0body1cite0i1i0div0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1cite0i1i0div0b0.NodeType);

        var dochtml0body1cite0i1i0div0b0Text0 = dochtml0body1cite0i1i0div0b0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1cite0i1i0div0b0Text0.NodeType);
        Assert.Equal("X", dochtml0body1cite0i1i0div0b0Text0.TextContent);

        var dochtml0body1cite0i1i0div0Text1 = dochtml0body1cite0i1i0div0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1cite0i1i0div0Text1.NodeType);
        Assert.Equal("TEST", dochtml0body1cite0i1i0div0Text1.TextContent);
    }

    [Fact]
    public void TagClosedWrongWithNestedEqualFormattingElements_Issue1052()
    {
        var errors = 0;
        var document = @"<!doctype html>

<head></head>

<body>
    <div class=""jive-rendered-content"">
        <p style="" margin: 0;"">
            <strong style=""color: rgba(0, 0, 0, 1); font-size: 14pt; font-family: Calibri;"">
              <strong style=""color: rgba(0, 0, 0, 1); font-size: 14pt; font-family: Calibri;"">
                    <strong style=""color: rgba(0, 0, 0, 1); font-size: 14pt; font-family: Calibri;"">
                        <strong style=""color: rgba(0, 0, 0, 1); font-size: 14pt;"">
                            <strong style=""color: rgba(0, 0, 0, 1); font-size: 14pt; font-family: Calibri;"">
                                <strong style=""color: rgba(255, 0, 0, 1); font-size: 14pt; font-family: Calibri;"">
                                    <strong style=""color: rgba(0, 0, 0, 1); font-size: 14pt; font-family: Calibri;"">
                                        <strong style=""color: rgba(0, 0, 0, 1); font-size: 14pt; font-family: Calibri;"">
                                            <strong
                                                style=""color: rgba(0, 0, 0, 1); font-size: 14pt; font-family: Calibri;"">
                                                ONLY ONE AC TKT IN A PNR </strong>
                                        </strong>
                                    </strong>
                                </strong>
                            </strong>
                        </strong>
                    </strong>
                </strong>
            </strong>
        </p>
    </div>
</body>

</html>".ToHtmlDocument(onError: (_, _) =>
        {
            errors++;
        });
        Assert.Equal(0, errors);
    }
}
