using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Text;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

public class PlaintextUnsafeTests
{
    [Fact]
    public void IllegalCodepointForNumericEntity()
    {
        var doc = (@"FOO&#x000D;ZOO").ToHtmlDocument();

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

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("FOO\rZOO", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void NullCharacterAfterHtml()
    {
        var doc = ("<html>" + Symbols.Null.ToString() + "<frameset></frameset>").ToHtmlDocument();

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
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(dochtml0frameset1.Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void NullCharacterWithSpacesAfterHtml()
    {
        var doc = ("<html> " + Symbols.Null.ToString() + " <frameset></frameset>").ToHtmlDocument();

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
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(dochtml0frameset1.Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void NullCharacterWithCharactersAfterHtml()
    {
        var doc = ("<html>a" + Symbols.Null.ToString() + "a<frameset></frameset>").ToHtmlDocument();

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

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("aa", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void DoubleNullCharactersAfterHtml()
    {
        var doc = (@"<html>" + Symbols.Null.ToString() + Symbols.Null.ToString() + "<frameset></frameset>").ToHtmlDocument();

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
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(dochtml0frameset1.Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void NullCharacterWithLinebreakAfterHtml()
    {
        var doc = ("<html>" + Symbols.Null.ToString() + @"
 <frameset></frameset>").ToHtmlDocument();

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
        Assert.Empty(dochtml0frameset1.ChildNodes);
        Assert.Empty(dochtml0frameset1.Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);
    }

    [Fact]
    public void PlaintextWithFillerText()
    {
        var doc = (@"<plaintext>□filler□text□".Replace('□', Symbols.Null)).ToHtmlDocument();

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

        var dochtml0body1plaintext0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1plaintext0.ChildNodes);
        Assert.Empty(dochtml0body1plaintext0.Attributes);
        Assert.Equal("plaintext", dochtml0body1plaintext0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1plaintext0.NodeType);

        var dochtml0body1plaintext0Text0 = dochtml0body1plaintext0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1plaintext0Text0.NodeType);
        Assert.Equal("�filler�text�".Replace('�', Symbols.Replacement), dochtml0body1plaintext0Text0.TextContent);

    }

    [Fact]
    public void NullCharacterInCDataWithFillerInSvg()
    {
        var doc = ("<svg><![CDATA[" + Symbols.Null.ToString() + 
            "filler" + Symbols.Null.ToString() + "text" + Symbols.Null.ToString() + "]]>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(dochtml0body1svg0.Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0Text0 = dochtml0body1svg0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0Text0.NodeType);
        Assert.Equal("�filler�text�".Replace('�', Symbols.Replacement), dochtml0body1svg0Text0.TextContent);
    }

    [Fact]
    public void NullCharacterInComment()
    {
        var doc = (@"<body><!" + Symbols.Null.ToString() + ">").ToHtmlDocument();

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

        var dochtml0body1child = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1child.ChildNodes);
        Assert.Equal(Symbols.Replacement.ToString(), dochtml0body1child.TextContent);
        Assert.Equal(NodeType.Comment, dochtml0body1child.NodeType);
    }

    [Fact]
    public void NullAndOtherCharactersInComment()
    {
        var doc = (@"<body><!" + Symbols.Null.ToString() + "filler" + Symbols.Null.ToString() + "text>").ToHtmlDocument();

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

        var dochtml0body1Comment = dochtml0body1.ChildNodes[0];
        Assert.Empty(dochtml0body1Comment.ChildNodes);
        Assert.Equal("�filler�text".Replace('�', Symbols.Replacement), dochtml0body1Comment.TextContent);
        Assert.Equal(NodeType.Comment, dochtml0body1Comment.NodeType);
    }

    [Fact]
    public void NullCharactersInForeignObjectInSvg()
    {
        var doc = (@"<body><svg><foreignObject>" + Symbols.Null.ToString() + "filler" + Symbols.Null.ToString() + "text").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1svg0.ChildNodes);
        Assert.Empty(dochtml0body1svg0.Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1svg0foreignObject0 = dochtml0body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1svg0foreignObject0.ChildNodes);
        Assert.Empty(dochtml0body1svg0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml0body1svg0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0foreignObject0.NodeType);

        var dochtml0body1svg0foreignObject0Text0 = dochtml0body1svg0foreignObject0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1svg0foreignObject0Text0.NodeType);
        Assert.Equal("fillertext", dochtml0body1svg0foreignObject0Text0.TextContent);
    }

    [Fact]
    public void PreTagStartingWithTwoEmptyLines()
    {
        var doc = (@"<!DOCTYPE html><pre>

A</pre>").ToHtmlDocument();

        var doctype = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(doctype);
        Assert.Equal(NodeType.DocumentType, doctype.NodeType);
        Assert.Equal(@"html", doctype.Name);

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1pre0.ChildNodes);
        Assert.Empty(dochtml1body1pre0.Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("\nA", dochtml1body1pre0Text0.TextContent);
    }

    [Fact]
    public void PreTagStartingWithOneEmptyLine()
    {
        var doc = (@"<!DOCTYPE html><pre>
A</pre>").ToHtmlDocument();

        var doctype = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(doctype);
        Assert.Equal(NodeType.DocumentType, doctype.NodeType);
        Assert.Equal(@"html", doctype.Name);

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1pre0.ChildNodes);
        Assert.Empty(dochtml1body1pre0.Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("A", dochtml1body1pre0Text0.TextContent);
    }

    [Fact]
    public void NullCharacterInMathTextInMathTag()
    {
        var doc = (@"<!DOCTYPE html><table><tr><td><math><mtext>" + Symbols.Null.ToString() + "a").ToHtmlDocument();

        var doctype = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(doctype);
        Assert.Equal(NodeType.DocumentType, doctype.NodeType);
        Assert.Equal(@"html", doctype.Name);

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
        Assert.Single(dochtml1body1table0tbody0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0.NodeType);

        var dochtml1body1table0tbody0tr0 = dochtml1body1table0tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml1body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0.NodeType);

        var dochtml1body1table0tbody0tr0td0 = dochtml1body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml1body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0math0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0.Attributes);
        Assert.Equal("math", dochtml1body1table0tbody0tr0td0math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mtext0 = dochtml1body1table0tbody0tr0td0math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0math0mtext0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mtext0.Attributes);
        Assert.Equal("mtext", dochtml1body1table0tbody0tr0td0math0mtext0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mtext0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mtext0Text0 = dochtml1body1table0tbody0tr0td0math0mtext0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0math0mtext0Text0.NodeType);
        Assert.Equal("a", dochtml1body1table0tbody0tr0td0math0mtext0Text0.TextContent);
    }

    [Fact]
    public void NullCharacterAfterLetterInMathIdentifier()
    {
        var doc = (@"<!DOCTYPE html><math><mi>a" + Symbols.Null.ToString() + "b").ToHtmlDocument();

        var doctype = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(doctype);
        Assert.Equal(NodeType.DocumentType, doctype.NodeType);
        Assert.Equal(@"html", doctype.Name);

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mi0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mi0.ChildNodes);
        Assert.Empty(dochtml1body1math0mi0.Attributes);
        Assert.Equal("mi", dochtml1body1math0mi0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mi0.NodeType);

        var dochtml1body1math0mi0Text0 = dochtml1body1math0mi0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mi0Text0.NodeType);
        Assert.Equal("ab", dochtml1body1math0mi0Text0.TextContent);
    }

    [Fact]
    public void NullCharacterAfterLetterInMathNumeric()
    {
        var doc = (@"<!DOCTYPE html><math><mn>a" + Symbols.Null.ToString() + "b").ToHtmlDocument();

        var doctype = doc.ChildNodes[0] as DocumentType;
        Assert.NotNull(doctype);
        Assert.Equal(NodeType.DocumentType, doctype.NodeType);
        Assert.Equal(@"html", doctype.Name);

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mn0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mn0.ChildNodes);
        Assert.Empty(dochtml1body1math0mn0.Attributes);
        Assert.Equal("mn", dochtml1body1math0mn0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mn0.NodeType);

        var dochtml1body1math0mn0Text0 = dochtml1body1math0mn0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mn0Text0.NodeType);
        Assert.Equal("ab", dochtml1body1math0mn0Text0.TextContent);
    }

    [Fact]
    public void TitleClosedWrongRestOkay()
    {
        var doc = (@"<!doctype html><title>foo/title><link></head><body>X").ToHtmlDocument();

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
        Assert.Equal("foo/title><link></head><body>X", dochtml1head0title0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void NoFramesWithCommentInsideThatContainsAnotherNoFramesPair()
    {
        var doc = (@"<!doctype html><noframes><!--<noframes></noframes>--></noframes>").ToHtmlDocument();

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

        var dochtml1head0noframes0 = dochtml1head0.ChildNodes[0] as Element;
        Assert.Single(dochtml1head0noframes0.ChildNodes);
        Assert.Empty(dochtml1head0noframes0.Attributes);
        Assert.Equal("noframes", dochtml1head0noframes0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0noframes0.NodeType);

        var dochtml1head0noframes0Text0 = dochtml1head0noframes0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1head0noframes0Text0.NodeType);
        Assert.Equal("<!--<noframes>", dochtml1head0noframes0Text0.TextContent);

        var dochtml1body1 = dochtml1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1.ChildNodes);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1Text0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1Text0.NodeType);
        Assert.Equal("-->", dochtml1body1Text0.TextContent);
    }

    [Fact]
    public void TextAreaWithCommentInsideThatContainsAnotherTextAreaPair()
    {
        var doc = (@"<!doctype html><textarea><!--<textarea></textarea>--></textarea>").ToHtmlDocument();

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

        var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1textarea0.ChildNodes);
        Assert.Empty(dochtml1body1textarea0.Attributes);
        Assert.Equal("textarea", dochtml1body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1textarea0.NodeType);

        var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
        Assert.Equal("<!--<textarea>", dochtml1body1textarea0Text0.TextContent);

        var dochtml1body1Text1 = dochtml1body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1Text1.NodeType);
        Assert.Equal("-->", dochtml1body1Text1.TextContent);
    }

    [Fact]
    public void TextAreaWithQuiteCloseTextAreaClosingInside()
    {
        var doc = (@"<!doctype html><textarea>&lt;/textarea></textarea>").ToHtmlDocument();

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

        var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1textarea0.ChildNodes);
        Assert.Empty(dochtml1body1textarea0.Attributes);
        Assert.Equal("textarea", dochtml1body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1textarea0.NodeType);

        var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
        Assert.Equal("</textarea>", dochtml1body1textarea0Text0.TextContent);
    }

    [Fact]
    public void TextAreaWithEntityInside()
    {
        var doc = (@"<!doctype html><textarea>&lt;</textarea>").ToHtmlDocument();

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

        var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1textarea0.ChildNodes);
        Assert.Empty(dochtml1body1textarea0.Attributes);
        Assert.Equal("textarea", dochtml1body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1textarea0.NodeType);

        var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
        Assert.Equal("<", dochtml1body1textarea0Text0.TextContent);
    }

    [Fact]
    public void TextAreaWithTextThatContainsEntityInside()
    {
        var doc = (@"<!doctype html><textarea>a&lt;b</textarea>").ToHtmlDocument();

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

        var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1textarea0.ChildNodes);
        Assert.Empty(dochtml1body1textarea0.Attributes);
        Assert.Equal("textarea", dochtml1body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1textarea0.NodeType);

        var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
        Assert.Equal("a<b", dochtml1body1textarea0Text0.TextContent);
    }
}
