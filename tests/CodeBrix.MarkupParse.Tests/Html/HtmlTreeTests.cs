using CodeBrix.MarkupParse.Tests.Mocks;
using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Parser;
using Xunit;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/isindex.dat,
/// tree-construction/tests3.dat,
/// tree-construction/tests16.dat,
/// tree-construction/inbody01.dat,
/// tree-construction/webkit01.dat,
/// tree-construction/webkit02.dat
/// </summary>

public class HtmlTreeTests
{
    [Fact]
    public void TreeHasOneBangComment()
    {
        var doc = ("<!-- BANG IT --!>").ToHtmlDocument();
        Assert.Equal(2, doc.ChildNodes.Length);
    }

    [Fact]
    public void Html5DocumentType()
    {
        var dom = ("<!doctype html >").ToHtmlDocument();

        Assert.Equal("html", dom.Doctype.Name);
        Assert.Equal("", dom.Doctype.PublicIdentifier);
        Assert.Equal("", dom.Doctype.SystemIdentifier);

        Assert.Equal("<!DOCTYPE html>", dom.Doctype.ToHtml());
    }

    [Fact]
    public void HtmlDocumentTypeWithPublicIdentifier()
    {
        var xhtmlType = "<!DOCTYPE html PUBLIC \"-//w3c//dtd xhtml 1.0\">";

        var dom = (xhtmlType).ToHtmlDocument();

        Assert.Equal("html", dom.Doctype.Name);
        Assert.Equal("-//w3c//dtd xhtml 1.0", dom.Doctype.PublicIdentifier);
        Assert.Equal("", dom.Doctype.SystemIdentifier);
        Assert.Equal(xhtmlType, dom.Doctype.ToHtml());
    }

    [Fact]
    public void TreeNonConformingTable()
    {
        var expected = @"<html><head></head><body><a href=""a"">a<a href=""b"">b</a><table></table></a><a href=""b"">x</a></body></html>";
        var source = @"<a href=""a"">a<table><a href=""b"">b</table>x";
        //8.2.5.4.7 The "in body" insertion mode - "In the non-conforming ..."
        var doc = (source).ToHtmlDocument();

        Assert.Equal(expected, doc.DocumentElement.OuterHtml);
    }

    [Fact]
    public void TreeIFrameWithAnotherIFramePairInsideComment()
    {
        var doc = (@"<!doctype html><iframe><!--<iframe></iframe>--></iframe>").ToHtmlDocument();

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

        var dochtml1body1iframe0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1iframe0.ChildNodes);
        Assert.Empty(dochtml1body1iframe0.Attributes);
        Assert.Equal("iframe", dochtml1body1iframe0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1iframe0.NodeType);

        var dochtml1body1iframe0Text0 = dochtml1body1iframe0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1iframe0Text0.NodeType);
        Assert.Equal("<!--<iframe>", dochtml1body1iframe0Text0.TextContent);

        var dochtml1body1Text1 = dochtml1body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1Text1.NodeType);
        Assert.Equal("-->", dochtml1body1Text1.TextContent);
    }

    [Fact]
    public void TreeIFrameWithTextAndStrangeComment()
    {
        var doc = (@"<!doctype html><iframe>...<!--X->...<!--/X->...</iframe>").ToHtmlDocument();

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

        var dochtml1body1iframe0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1iframe0.ChildNodes);
        Assert.Empty(dochtml1body1iframe0.Attributes);
        Assert.Equal("iframe", dochtml1body1iframe0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1iframe0.NodeType);

        var dochtml1body1iframe0Text0 = dochtml1body1iframe0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1iframe0Text0.NodeType);
        Assert.Equal("...<!--X->...<!--/X->...", dochtml1body1iframe0Text0.TextContent);
    }

    [Fact]
    public void TreeXmpWithAnotherXmpPairInsideComment()
    {
        var doc = (@"<!doctype html><xmp><!--<xmp></xmp>--></xmp>").ToHtmlDocument();

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

        var dochtml1body1xmp0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1xmp0.ChildNodes);
        Assert.Empty(dochtml1body1xmp0.Attributes);
        Assert.Equal("xmp", dochtml1body1xmp0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1xmp0.NodeType);

        var dochtml1body1xmp0Text0 = dochtml1body1xmp0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1xmp0Text0.NodeType);
        Assert.Equal("<!--<xmp>", dochtml1body1xmp0Text0.TextContent);

        var dochtml1body1Text1 = dochtml1body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1Text1.NodeType);
        Assert.Equal("-->", dochtml1body1Text1.TextContent);
    }

    [Fact]
    public void TreeNoEmbedWithAnotherNoEmbedPairInsideComment()
    {
        var doc = (@"<!doctype html><noembed><!--<noembed></noembed>--></noembed>").ToHtmlDocument();

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

        var dochtml1body1noembed0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1noembed0.ChildNodes);
        Assert.Empty(dochtml1body1noembed0.Attributes);
        Assert.Equal("noembed", dochtml1body1noembed0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1noembed0.NodeType);

        var dochtml1body1noembed0Text0 = dochtml1body1noembed0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1noembed0Text0.NodeType);
        Assert.Equal("<!--<noembed>", dochtml1body1noembed0Text0.TextContent);

        var dochtml1body1Text1 = dochtml1body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1Text1.NodeType);
        Assert.Equal("-->", dochtml1body1Text1.TextContent);
    }

    [Fact]
    public void TreeOneTextNodeTableBeforeABCD()
    {
        var expected = "<html><head></head><body>ABCD<table><tbody><tr></tr></tbody></table></body></html>";
        var source = @"A<table>B<tr>C</tr>D</table>";
        //One Text node before the table, containing "ABCD"
        var doc = (source).ToHtmlDocument();

        Assert.Equal(expected, doc.DocumentElement.OuterHtml);
    }

    [Fact]
    public void TreeOneTextNodeTableBeforeAspaceBspaceC()
    {
        var expected = "<html><head></head><body>A B C<table><tbody><tr></tr></tbody></table></body></html>";
        var source = @"A<table><tr> B</tr> C</table>";
        //One Text node before the table, containing "A B C" (A-space-B-space-C).
        var doc = (source).ToHtmlDocument();

        Assert.Equal(expected, doc.DocumentElement.OuterHtml);
    }

    [Fact]
    public void TreeOneTextNodeTableBeforeAspaceBC()
    {
        var expected = "<html><head></head><body>A BC<table><tbody><tr></tr> </tbody></table></body></html>";
        var source = @"A<table><tr> B</tr> </em>C</table>";
        //One Text node before the table, containing "A BC" (A-space-B-C), and one Text node inside the table (as a child of a tbody) with a single space character.
        var doc = (source).ToHtmlDocument();

        Assert.Equal(expected, doc.DocumentElement.OuterHtml);
    }

    [Fact]
    public void TreeUnexpectedTableMarkup()
    {
        var expected = "<html><head></head><body><b></b><b>bbb</b><table><tbody><tr><td>aaa</td></tr></tbody></table><b>ccc</b></body></html>";
        var source = @"<table><b><tr><td>aaa</td></tr>bbb</table>ccc";
        //8.2.8.3 Unexpected markup in tables
        var doc = (source).ToHtmlDocument();

        Assert.Equal(expected, doc.DocumentElement.OuterHtml);
    }

    [Fact]
    public void TreeMisnestedTagsHeisenbergNoFurthest()
    {
        var expected = "<html><head></head><body><p>1<b>2<i>3</i></b><i>4</i>5</p></body></html>";
        var source = @"<p>1<b>2<i>3</b>4</i>5</p>";
        //8.2.8.1 Misnested tags: <b><i></b></i>
        var doc = (source).ToHtmlDocument();

        Assert.Equal(expected, doc.DocumentElement.OuterHtml);
    }

    [Fact]
    public void TreeMisnestedTagsHeisenbergWithFurthest()
    {
        var expected = "<html><head></head><body><b>1</b><p><b>2</b>3</p></body></html>";
        var source = @"<b>1<p>2</b>3</p>";
        //8.2.8.2 Misnested tags: <b><p></b></p>
        var doc = (source).ToHtmlDocument();

        Assert.Equal(expected, doc.DocumentElement.OuterHtml);
    }

    [Fact]
    public void TreeUnclosedFormattingElements()
    {
        var expected = "<html><head></head><body><p><b class=\"x\"><b class=\"x\"><b><b class=\"x\"><b class=\"x\"><b>X</b></b></b></b></b></b></p><p><b class=\"x\"><b><b class=\"x\"><b class=\"x\"><b>X</b></b></b></b></b></p><p><b class=\"x\"><b><b class=\"x\"><b class=\"x\"><b><b><b class=\"x\"><b>X</b></b></b></b></b></b></b></b></p><p>X</p></body></html>";
        var source = @"<!DOCTYPE html>
<p><b class=x><b class=x><b><b class=x><b class=x><b>X<p>X<p><b><b class=x><b>X<p></b></b></b></b></b></b>X";
        //8.2.8.6 Unclosed formatting elements
        var doc = (source).ToHtmlDocument();

        Assert.Equal(expected, doc.DocumentElement.OuterHtml);
    }

    [Fact]
    public void HeisenbergAlgorithmStrong()
    {
        var doc = (@"<p>1<s id=""A"">2<b id=""B"">3</p>4</s>5</b>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Equal(3, body.ChildNodes.Length);

        var p = body.ChildNodes[0] as Element;
        Assert.Equal(NodeType.Element, p.NodeType);
        Assert.Equal(2, p.ChildNodes.Length);

        var pt = p.ChildNodes[0];
        Assert.Equal(NodeType.Text, pt.NodeType);
        Assert.Equal("1", pt.TextContent);

        var ps = p.ChildNodes[1] as Element;
        Assert.Equal("A", ps.GetAttribute("id"));
        Assert.Equal(NodeType.Element, ps.NodeType);
        Assert.Equal(2, ps.ChildNodes.Length);

        var pst = ps.ChildNodes[0];
        Assert.Equal(NodeType.Text, pst.NodeType);
        Assert.Equal("2", pst.TextContent);

        var psb = ps.ChildNodes[1] as Element;
        Assert.Equal(NodeType.Element, psb.NodeType);
        Assert.Single(psb.ChildNodes);
        Assert.Equal("B", psb.GetAttribute("id"));

        var psbt = psb.ChildNodes[0];
        Assert.Equal(NodeType.Text, psbt.NodeType);
        Assert.Equal("3", psbt.TextContent);

        var s = body.ChildNodes[1] as Element;
        Assert.Equal("A", s.Attributes.GetNamedItem("id").Value);
        Assert.Equal(NodeType.Element, s.NodeType);
        Assert.Single(s.ChildNodes);

        var sb = s.ChildNodes[0] as Element;
        Assert.Equal(NodeType.Element, sb.NodeType);
        Assert.Single(sb.ChildNodes);
        Assert.Equal("B", sb.GetAttribute("id"));

        var sbt = sb.ChildNodes[0];
        Assert.Equal(NodeType.Text, sbt.NodeType);
        Assert.Equal("4", sbt.TextContent);

        var b = body.ChildNodes[2] as Element; ;
        Assert.Equal(NodeType.Element, b.NodeType);
        Assert.Single(b.ChildNodes);
        Assert.Equal("B", b.GetAttribute("id"));

        var bt = b.ChildNodes[0];
        Assert.Equal(NodeType.Text, bt.NodeType);
        Assert.Equal("5", bt.TextContent);
    }

    [Fact]
    public void OpenButtonWrongClosingTag()
    {
        var doc = (@"<button>1</foo>").ToHtmlDocument();

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

        var dochtml0body1button0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1button0.ChildNodes);
        Assert.Empty(dochtml0body1button0.Attributes);
        Assert.Equal("button", dochtml0body1button0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1button0.NodeType);

        var dochtml0body1button0Text0 = dochtml0body1button0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1button0Text0.NodeType);
        Assert.Equal("1", dochtml0body1button0Text0.TextContent);
    }

    [Fact]
    public void UnknownTagWithParagraphChild()
    {
        var doc = (@"<foo>1<p>2</foo>").ToHtmlDocument();

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

        var dochtml0body1foo0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1foo0.ChildNodes.Length);
        Assert.Empty(dochtml0body1foo0.Attributes);
        Assert.Equal("foo", dochtml0body1foo0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0.NodeType);

        var dochtml0body1foo0Text0 = dochtml0body1foo0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1foo0Text0.NodeType);
        Assert.Equal("1", dochtml0body1foo0Text0.TextContent);

        var dochtml0body1foo0p1 = dochtml0body1foo0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1foo0p1.ChildNodes);
        Assert.Empty(dochtml0body1foo0p1.Attributes);
        Assert.Equal("p", dochtml0body1foo0p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0p1.NodeType);

        var dochtml0body1foo0p1Text0 = dochtml0body1foo0p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1foo0p1Text0.NodeType);
        Assert.Equal("2", dochtml0body1foo0p1Text0.TextContent);
    }

    [Fact]
    public void OpenDefinitionWrongClosingTag()
    {
        var doc = (@"<dd>1</foo>").ToHtmlDocument();

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

        var dochtml0body1dd0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1dd0.ChildNodes);
        Assert.Empty(dochtml0body1dd0.Attributes);
        Assert.Equal("dd", dochtml0body1dd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1dd0.NodeType);

        var dochtml0body1dd0Text0 = dochtml0body1dd0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1dd0Text0.NodeType);
        Assert.Equal("1", dochtml0body1dd0Text0.TextContent);
    }

    [Fact]
    public void UnknownTagWithDefinitionChild()
    {
        var doc = (@"<foo>1<dd>2</foo>").ToHtmlDocument();

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

        var dochtml0body1foo0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1foo0.ChildNodes.Length);
        Assert.Empty(dochtml0body1foo0.Attributes);
        Assert.Equal("foo", dochtml0body1foo0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0.NodeType);

        var dochtml0body1foo0Text0 = dochtml0body1foo0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1foo0Text0.NodeType);
        Assert.Equal("1", dochtml0body1foo0Text0.TextContent);

        var dochtml0body1foo0dd1 = dochtml0body1foo0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1foo0dd1.ChildNodes);
        Assert.Empty(dochtml0body1foo0dd1.Attributes);
        Assert.Equal("dd", dochtml0body1foo0dd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0dd1.NodeType);

        var dochtml0body1foo0dd1Text0 = dochtml0body1foo0dd1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1foo0dd1Text0.NodeType);
        Assert.Equal("2", dochtml0body1foo0dd1Text0.TextContent);
    }

    [Fact]
    public void IsIndexStandalone()
    {
        var doc = (@"<isindex>").ToHtmlDocument();

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

        var dochtml0body1form0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0body1form0.ChildNodes.Length);
        Assert.Empty(dochtml0body1form0.Attributes);
        Assert.Equal("form", dochtml0body1form0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0.NodeType);

        var dochtml0body1form0hr0 = dochtml0body1form0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1form0hr0.ChildNodes);
        Assert.Empty(dochtml0body1form0hr0.Attributes);
        Assert.Equal("hr", dochtml0body1form0hr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0hr0.NodeType);

        var dochtml0body1form0label1 = dochtml0body1form0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1form0label1.ChildNodes.Length);
        Assert.Empty(dochtml0body1form0label1.Attributes);
        Assert.Equal("label", dochtml0body1form0label1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0label1.NodeType);

        var dochtml0body1form0label1Text0 = dochtml0body1form0label1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1form0label1Text0.NodeType);
        Assert.Equal("This is a searchable index. Enter search keywords: ", dochtml0body1form0label1Text0.TextContent);

        var dochtml0body1form0label1input1 = dochtml0body1form0label1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1form0label1input1.ChildNodes);
        Assert.Single(dochtml0body1form0label1input1.Attributes);
        Assert.Equal("input", dochtml0body1form0label1input1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0label1input1.NodeType);
        Assert.Equal("isindex", dochtml0body1form0label1input1.Attributes.GetNamedItem("name").Value);

        var dochtml0body1form0hr2 = dochtml0body1form0.ChildNodes[2] as Element; ;
        Assert.Empty(dochtml0body1form0hr2.ChildNodes);
        Assert.Empty(dochtml0body1form0hr2.Attributes);
        Assert.Equal("hr", dochtml0body1form0hr2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0hr2.NodeType);
    }

    [Fact]
    public void IsIndexWithAttributes()
    {
        var doc = (@"<isindex name=""A"" action=""B"" prompt=""C"" foo=""D"">").ToHtmlDocument();

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

        var dochtml0body1form0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0body1form0.ChildNodes.Length);
        Assert.Single(dochtml0body1form0.Attributes);
        Assert.Equal("form", dochtml0body1form0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0.NodeType);
        Assert.Equal("B", dochtml0body1form0.Attributes.GetNamedItem("action").Value);

        var dochtml0body1form0hr0 = dochtml0body1form0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1form0hr0.ChildNodes);
        Assert.Empty(dochtml0body1form0hr0.Attributes);
        Assert.Equal("hr", dochtml0body1form0hr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0hr0.NodeType);

        var dochtml0body1form0label1 = dochtml0body1form0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1form0label1.ChildNodes.Length);
        Assert.Empty(dochtml0body1form0label1.Attributes);
        Assert.Equal("label", dochtml0body1form0label1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0label1.NodeType);

        var dochtml0body1form0label1Text0 = dochtml0body1form0label1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1form0label1Text0.NodeType);
        Assert.Equal("C", dochtml0body1form0label1Text0.TextContent);

        var dochtml0body1form0label1input1 = dochtml0body1form0label1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1form0label1input1.ChildNodes);
        Assert.Equal(2, dochtml0body1form0label1input1.Attributes.Length);
        Assert.Equal("input", dochtml0body1form0label1input1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0label1input1.NodeType);
        Assert.Equal("D", dochtml0body1form0label1input1.Attributes.GetNamedItem("foo").Value);
        Assert.Equal("isindex", dochtml0body1form0label1input1.Attributes.GetNamedItem("name").Value);

        var dochtml0body1form0hr2 = dochtml0body1form0.ChildNodes[2] as Element; ;
        Assert.Empty(dochtml0body1form0hr2.ChildNodes);
        Assert.Empty(dochtml0body1form0hr2.Attributes);
        Assert.Equal("hr", dochtml0body1form0hr2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0hr2.NodeType);
    }

    [Fact]
    public void IsIndexWithinForm()
    {
        var doc = (@"<form><isindex>").ToHtmlDocument();

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

        var dochtml0body1form0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1form0.ChildNodes);
        Assert.Empty(dochtml0body1form0.Attributes);
        Assert.Equal("form", dochtml0body1form0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1form0.NodeType);
    }

    [Fact]
    public void TreeSingleTextNode()
    {
        var doc = (@"Test").ToHtmlDocument();

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
        Assert.Equal("Test", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeSingleDivElement()
    {
        var doc = (@"<div></div>").ToHtmlDocument();

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
    public void TreeSingleDivWithTextNode()
    {
        var doc = (@"<div>Test</div>").ToHtmlDocument();

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

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("Test", dochtml0body1div0Text0.TextContent);
    }

    [Fact]
    public void TreeTagStartedUnexpectedEof()
    {
        var doc = (@"<di").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TreeDivsWithContentAndScript()
    {
        var doc = (@"<div>Hello</div>
<script>
console.log(""PASS"");
</script>
<div>Bye</div>").ToHtmlDocument();

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
        Assert.Equal(5, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("Hello", dochtml0body1div0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("\n", dochtml0body1Text1.TextContent);

        var dochtml0body1script2 = dochtml0body1.ChildNodes[2] as Element;
        Assert.Single(dochtml0body1script2.ChildNodes);
        Assert.Empty(dochtml0body1script2.Attributes);
        Assert.Equal("script", dochtml0body1script2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script2.NodeType);

        var dochtml0body1script2Text0 = dochtml0body1script2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script2Text0.NodeType);
        Assert.Equal("\nconsole.log(\"PASS\");\n", dochtml0body1script2Text0.TextContent);

        var dochtml0body1div3 = dochtml0body1.ChildNodes[4];
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div3Text0 = dochtml0body1div3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div3Text0.NodeType);
        Assert.Equal("Bye", dochtml0body1div3Text0.TextContent);
    }

    [Fact]
    public void TreeDivWithAttributeAndTextNode()
    {
        var doc = (@"<div foo=""bar"">Hello</div>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);
        Assert.Equal("bar", dochtml0body1div0.Attributes.GetNamedItem("foo").Value);

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("Hello", dochtml0body1div0Text0.TextContent);
    }

    [Fact]
    public void TreeScriptElementWithTagInside()
    {
        var doc = (@"<div>Hello</div>
<script>
console.log(""FOO<span>BAR</span>BAZ"");
</script>
<div>Bye</div>").ToHtmlDocument();

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
        Assert.Equal(5, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1div0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div0Text0 = dochtml0body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div0Text0.NodeType);
        Assert.Equal("Hello", dochtml0body1div0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("\n", dochtml0body1Text1.TextContent);

        var dochtml0body1script2 = dochtml0body1.ChildNodes[2] as Element; ;
        Assert.Single(dochtml0body1script2.ChildNodes);
        Assert.Empty(dochtml0body1script2.Attributes);
        Assert.Equal("script", dochtml0body1script2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1script2.NodeType);

        var dochtml0body1script2Text0 = dochtml0body1script2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1script2Text0.NodeType);
        Assert.Equal("\nconsole.log(\"FOO<span>BAR</span>BAZ\");\n", dochtml0body1script2Text0.TextContent);

        var dochtml0body1div3 = dochtml0body1.ChildNodes[4];
        Assert.Single(dochtml0body1div0.ChildNodes);
        Assert.Empty(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);

        var dochtml0body1div3Text0 = dochtml0body1div3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div3Text0.NodeType);
        Assert.Equal("Bye", dochtml0body1div3Text0.TextContent);
    }

    [Fact]
    public void TreeUnknownElementsInContent()
    {
        var doc = (@"<foo bar=""baz""></foo><potato quack=""duck""></potato>").ToHtmlDocument();

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

        var dochtml0body1foo0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1foo0.ChildNodes);
        Assert.Single(dochtml0body1foo0.Attributes);
        Assert.Equal("foo", dochtml0body1foo0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0.NodeType);
        Assert.Equal("baz", dochtml0body1foo0.Attributes.GetNamedItem("bar").Value);

        var dochtml0body1potato1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1potato1.ChildNodes);
        Assert.Single(dochtml0body1potato1.Attributes);
        Assert.Equal("potato", dochtml0body1potato1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1potato1.NodeType);
        Assert.Equal("duck", dochtml0body1potato1.Attributes.GetNamedItem("quack").Value);
    }

    [Fact]
    public void TreeUnknownElementsSurrounding()
    {
        var doc = (@"<foo bar=""baz""><potato quack=""duck""></potato></foo>").ToHtmlDocument();

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

        var dochtml0body1foo0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1foo0.ChildNodes);
        Assert.Single(dochtml0body1foo0.Attributes);
        Assert.Equal("foo", dochtml0body1foo0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0.NodeType);
        Assert.Equal("baz", dochtml0body1foo0.Attributes.GetNamedItem("bar").Value);

        var dochtml0body1foo0potato0 = dochtml0body1foo0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1foo0potato0.ChildNodes);
        Assert.Single(dochtml0body1foo0potato0.Attributes);
        Assert.Equal("potato", dochtml0body1foo0potato0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0potato0.NodeType);
        Assert.Equal("duck", dochtml0body1foo0potato0.Attributes.GetNamedItem("quack").Value);
    }

    [Fact]
    public void TreeUnknownElementsWithAttributesInClosing()
    {
        var doc = (@"<foo></foo bar=""baz""><potato></potato quack=""duck"">").ToHtmlDocument();

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

        var dochtml0body1foo0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1foo0.ChildNodes);
        Assert.Empty(dochtml0body1foo0.Attributes);
        Assert.Equal("foo", dochtml0body1foo0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0.NodeType);

        var dochtml0body1potato1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1potato1.ChildNodes);
        Assert.Empty(dochtml0body1potato1.Attributes);
        Assert.Equal("potato", dochtml0body1potato1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1potato1.NodeType);
    }

    [Fact]
    public void TreeInvalidClosingTag()
    {
        var doc = (@"</ tttt>").ToHtmlDocument();

        var docComment0 = doc.ChildNodes[0];
        Assert.Equal(NodeType.Comment, docComment0.NodeType);
        Assert.Equal(@" tttt", docComment0.TextContent);

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
    public void TreeDivWithAttributeAndImages()
    {
        var doc = (@"<div FOO ><img><img></div>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1div0.Attributes);
        Assert.Equal("div", dochtml0body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0.NodeType);
        Assert.Equal("", dochtml0body1div0.Attributes.GetNamedItem("foo").Value);

        var dochtml0body1div0img0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0img0.ChildNodes);
        Assert.Empty(dochtml0body1div0img0.Attributes);
        Assert.Equal("img", dochtml0body1div0img0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0img0.NodeType);

        var dochtml0body1div0img1 = dochtml0body1div0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div0img1.ChildNodes);
        Assert.Empty(dochtml0body1div0img1.Attributes);
        Assert.Equal("img", dochtml0body1div0img1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0img1.NodeType);
    }

    [Fact]
    public void TreeParagraphsWithTypo()
    {
        var doc = (@"<p>Test</p<p>Test2</p>").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0.ChildNodes);
        Assert.Empty(dochtml0body1p0.Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);

        var dochtml0body1p0Text0 = dochtml0body1p0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p0Text0.NodeType);
        Assert.Equal("TestTest2", dochtml0body1p0Text0.TextContent);
    }

    [Fact]
    public void TreeInvalidStartTag()
    {
        var doc = (@"<rdar://problem/6869687>").ToHtmlDocument();

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

        var dochtml0body1rdar0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1rdar0.ChildNodes);
        Assert.Equal(2, dochtml0body1rdar0.Attributes.Length);
        Assert.Equal("rdar:", dochtml0body1rdar0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1rdar0.NodeType);
        Assert.Equal("", dochtml0body1rdar0.GetAttribute("6869687"));
        Assert.Equal("", dochtml0body1rdar0.GetAttribute("problem"));

    }

    [Fact]
    public void TreeAnchorTagWrongClosing()
    {
        var doc = (@"<A>test< /A>").ToHtmlDocument();

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

        var dochtml0body1a0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1a0.ChildNodes);
        Assert.Empty(dochtml0body1a0.Attributes);
        Assert.Equal("a", dochtml0body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0.NodeType);

        var dochtml0body1a0Text0 = dochtml0body1a0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1a0Text0.NodeType);
        Assert.Equal("test< /A>", dochtml0body1a0Text0.TextContent);
    }

    [Fact]
    public void TreeSingleEntity()
    {
        var doc = (@"&lt;").ToHtmlDocument();

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
        Assert.Equal("<", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeDoubleBodiesWithAttributes()
    {
        var doc = (@"<body foo='bar'><body foo='baz' yo='mama'>").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Equal(2, dochtml0body1.Attributes.Length);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
        Assert.Equal("bar", dochtml0body1.Attributes.GetNamedItem("foo").Value);
        Assert.Equal("mama", dochtml0body1.Attributes.GetNamedItem("yo").Value);
    }

    [Fact]
    public void TreeClosingBrWithAttribute()
    {
        var doc = (@"<body></br foo=""bar""></body>").ToHtmlDocument();

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

        var dochtml0body1br0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1br0.ChildNodes);
        Assert.Empty(dochtml0body1br0.Attributes);
        Assert.Equal("br", dochtml0body1br0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1br0.NodeType);
    }

    [Fact]
    public void TreeBodyTypoWithBrAttributes()
    {
        var doc = (@"<bdy><br foo=""bar""></body>").ToHtmlDocument();

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

        var dochtml0body1bdy0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1bdy0.ChildNodes);
        Assert.Empty(dochtml0body1bdy0.Attributes);
        Assert.Equal("bdy", dochtml0body1bdy0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1bdy0.NodeType);

        var dochtml0body1bdy0br0 = dochtml0body1bdy0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1bdy0br0.ChildNodes);
        Assert.Single(dochtml0body1bdy0br0.Attributes);
        Assert.Equal("br", dochtml0body1bdy0br0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1bdy0br0.NodeType);
        Assert.Equal("bar", dochtml0body1bdy0br0.Attributes.GetNamedItem("foo").Value);
    }

    [Fact]
    public void TreeBrClosingWithAttributesOutsideBodyTag()
    {
        var doc = (@"<body></body></br foo=""bar"">").ToHtmlDocument();

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

        var dochtml0body1br0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1br0.ChildNodes);
        Assert.Empty(dochtml0body1br0.Attributes);
        Assert.Equal("br", dochtml0body1br0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1br0.NodeType);
    }

    [Fact]
    public void TreeBodyTpyoWithBrOutside()
    {
        var doc = (@"<bdy></body><br foo=""bar"">").ToHtmlDocument();

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

        var dochtml0body1bdy0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1bdy0.ChildNodes);
        Assert.Empty(dochtml0body1bdy0.Attributes);
        Assert.Equal("bdy", dochtml0body1bdy0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1bdy0.NodeType);

        var dochtml0body1bdy0br0 = dochtml0body1bdy0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1bdy0br0.ChildNodes);
        Assert.Single(dochtml0body1bdy0br0.Attributes);
        Assert.Equal("br", dochtml0body1bdy0br0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1bdy0br0.NodeType);
        Assert.Equal("bar", dochtml0body1bdy0br0.Attributes.GetNamedItem("foo").Value);
    }

    [Fact]
    public void TreeCommentAfterDocumentRoot()
    {
        var doc = (@"<html><body></body></html><!-- Hi there -->").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var docComment1 = doc.ChildNodes[1];
        Assert.Equal(NodeType.Comment, docComment1.NodeType);
        Assert.Equal(@" Hi there ", docComment1.TextContent);
    }

    [Fact]
    public void TreeTextAndCommentAfterDocumentRoot()
    {
        var doc = (@"<html><body></body></html>x<!-- Hi there -->").ToHtmlDocument();

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
        Assert.Equal("x", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" Hi there ", dochtml0body1Comment1.TextContent);
    }

    [Fact]
    public void TreeTextAndCommentAfterDocumentRootTwice()
    {
        var doc = (@"<html><body></body></html>x<!-- Hi there --></html><!-- Again -->").ToHtmlDocument();

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
        Assert.Equal("x", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" Hi there ", dochtml0body1Comment1.TextContent);

        var docComment1 = doc.ChildNodes[1];
        Assert.Equal(NodeType.Comment, docComment1.NodeType);
        Assert.Equal(@" Again ", docComment1.TextContent);
    }

    [Fact]
    public void TreeTextAndCommentAfterDocumentRootWithRedundantClosingTags()
    {
        var doc = (@"<html><body></body></html>x<!-- Hi there --></body></html><!-- Again -->").ToHtmlDocument();

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
        Assert.Equal("x", dochtml0body1Text0.TextContent);

        var dochtml0body1Comment1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0body1Comment1.NodeType);
        Assert.Equal(@" Hi there ", dochtml0body1Comment1.TextContent);

        var docComment1 = doc.ChildNodes[1];
        Assert.Equal(NodeType.Comment, docComment1.NodeType);
        Assert.Equal(@" Again ", docComment1.TextContent);
    }

    [Fact]
    public void TreeRubyWithDivs()
    {
        var doc = (@"<html><body><ruby><div><rp>xx</rp></div></ruby></body></html>").ToHtmlDocument();

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

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1ruby0.ChildNodes);
        Assert.Empty(dochtml0body1ruby0.Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0div0 = dochtml0body1ruby0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1ruby0div0.ChildNodes);
        Assert.Empty(dochtml0body1ruby0div0.Attributes);
        Assert.Equal("div", dochtml0body1ruby0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0div0.NodeType);

        var dochtml0body1ruby0div0rp0 = dochtml0body1ruby0div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1ruby0div0rp0.ChildNodes);
        Assert.Empty(dochtml0body1ruby0div0rp0.Attributes);
        Assert.Equal("rp", dochtml0body1ruby0div0rp0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0div0rp0.NodeType);

        var dochtml0body1ruby0div0rp0Text0 = dochtml0body1ruby0div0rp0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0div0rp0Text0.NodeType);
        Assert.Equal("xx", dochtml0body1ruby0div0rp0Text0.TextContent);
    }

    [Fact]
    public void TreeRubyAndRtElements()
    {
        var doc = (@"<html><body><ruby><div><rt>xx</rt></div></ruby></body></html>").ToHtmlDocument();

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

        var dochtml0body1ruby0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1ruby0.ChildNodes);
        Assert.Empty(dochtml0body1ruby0.Attributes);
        Assert.Equal("ruby", dochtml0body1ruby0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0.NodeType);

        var dochtml0body1ruby0div0 = dochtml0body1ruby0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1ruby0div0.ChildNodes);
        Assert.Empty(dochtml0body1ruby0div0.Attributes);
        Assert.Equal("div", dochtml0body1ruby0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0div0.NodeType);

        var dochtml0body1ruby0div0rt0 = dochtml0body1ruby0div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1ruby0div0rt0.ChildNodes);
        Assert.Empty(dochtml0body1ruby0div0rt0.Attributes);
        Assert.Equal("rt", dochtml0body1ruby0div0rt0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ruby0div0rt0.NodeType);

        var dochtml0body1ruby0div0rt0Text0 = dochtml0body1ruby0div0rt0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ruby0div0rt0Text0.NodeType);
        Assert.Equal("xx", dochtml0body1ruby0div0rt0Text0.TextContent);
    }

    [Fact]
    public void TreeFramesetAndNoframesElements()
    {
        var doc = (@"<html><frameset><!--1--><noframes>A</noframes><!--2--></frameset><!--3--><noframes>B</noframes><!--4--></html><!--5--><noframes>C</noframes><!--6-->").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(6, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0frameset1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(3, dochtml0frameset1.ChildNodes.Length);
        Assert.Empty(dochtml0frameset1.Attributes);
        Assert.Equal("frameset", dochtml0frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1.NodeType);

        var dochtml0frameset1Comment0 = dochtml0frameset1.ChildNodes[0];
        Assert.Equal(NodeType.Comment, dochtml0frameset1Comment0.NodeType);
        Assert.Equal(@"1", dochtml0frameset1Comment0.TextContent);

        var dochtml0frameset1noframes1 = dochtml0frameset1.ChildNodes[1] as Element;
        Assert.Single(dochtml0frameset1noframes1.ChildNodes);
        Assert.Empty(dochtml0frameset1noframes1.Attributes);
        Assert.Equal("noframes", dochtml0frameset1noframes1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0frameset1noframes1.NodeType);

        var dochtml0frameset1noframes1Text0 = dochtml0frameset1noframes1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0frameset1noframes1Text0.NodeType);
        Assert.Equal("A", dochtml0frameset1noframes1Text0.TextContent);

        var dochtml0frameset1Comment2 = dochtml0frameset1.ChildNodes[2];
        Assert.Equal(NodeType.Comment, dochtml0frameset1Comment2.NodeType);
        Assert.Equal(@"2", dochtml0frameset1Comment2.TextContent);

        var dochtml0Comment2 = dochtml0.ChildNodes[2];
        Assert.Equal(NodeType.Comment, dochtml0Comment2.NodeType);
        Assert.Equal(@"3", dochtml0Comment2.TextContent);

        var dochtml0noframes3 = dochtml0.ChildNodes[3] as Element;
        Assert.Single(dochtml0noframes3.ChildNodes);
        Assert.Empty(dochtml0noframes3.Attributes);
        Assert.Equal("noframes", dochtml0noframes3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0noframes3.NodeType);

        var dochtml0noframes3Text0 = dochtml0noframes3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0noframes3Text0.NodeType);
        Assert.Equal("B", dochtml0noframes3Text0.TextContent);

        var dochtml0Comment4 = dochtml0.ChildNodes[4];
        Assert.Equal(NodeType.Comment, dochtml0Comment4.NodeType);
        Assert.Equal(@"4", dochtml0Comment4.TextContent);

        var dochtml0noframes5 = dochtml0.ChildNodes[5] as Element;
        Assert.Single(dochtml0noframes5.ChildNodes);
        Assert.Empty(dochtml0noframes5.Attributes);
        Assert.Equal("noframes", dochtml0noframes5.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0noframes5.NodeType);

        var dochtml0noframes5Text0 = dochtml0noframes5.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0noframes5Text0.NodeType);
        Assert.Equal("C", dochtml0noframes5Text0.TextContent);

        var docComment1 = doc.ChildNodes[1];
        Assert.Equal(NodeType.Comment, docComment1.NodeType);
        Assert.Equal(@"5", docComment1.TextContent);

        var docComment2 = doc.ChildNodes[2];
        Assert.Equal(NodeType.Comment, docComment2.NodeType);
        Assert.Equal(@"6", docComment2.TextContent);
    }

    [Fact]
    public void TreeSelectOptions()
    {
        var doc = (@"<select><option>A<select><option>B<select><option>C<select><option>D<select><option>E<select><option>F<select><option>G<select>").ToHtmlDocument();

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
        Assert.Equal(4, dochtml0body1.ChildNodes.Length);
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

        var dochtml0body1select0option0Text0 = dochtml0body1select0option0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1select0option0Text0.NodeType);
        Assert.Equal("A", dochtml0body1select0option0Text0.TextContent);

        var dochtml0body1option1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1option1.ChildNodes.Length);
        Assert.Empty(dochtml0body1option1.Attributes);
        Assert.Equal("option", dochtml0body1option1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option1.NodeType);

        var dochtml0body1option1Text0 = dochtml0body1option1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1option1Text0.NodeType);
        Assert.Equal("B", dochtml0body1option1Text0.TextContent);

        var dochtml0body1option1select1 = dochtml0body1option1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1option1select1.ChildNodes);
        Assert.Empty(dochtml0body1option1select1.Attributes);
        Assert.Equal("select", dochtml0body1option1select1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option1select1.NodeType);

        var dochtml0body1option1select1option0 = dochtml0body1option1select1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1option1select1option0.ChildNodes);
        Assert.Empty(dochtml0body1option1select1option0.Attributes);
        Assert.Equal("option", dochtml0body1option1select1option0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option1select1option0.NodeType);

        var dochtml0body1option1select1option0Text0 = dochtml0body1option1select1option0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1option1select1option0Text0.NodeType);
        Assert.Equal("C", dochtml0body1option1select1option0Text0.TextContent);

        var dochtml0body1option2 = dochtml0body1.ChildNodes[2] as Element; ;
        Assert.Equal(2, dochtml0body1option2.ChildNodes.Length);
        Assert.Empty(dochtml0body1option2.Attributes);
        Assert.Equal("option", dochtml0body1option2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option2.NodeType);

        var dochtml0body1option2Text0 = dochtml0body1option2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1option2Text0.NodeType);
        Assert.Equal("D", dochtml0body1option2Text0.TextContent);

        var dochtml0body1option2select1 = dochtml0body1option2.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1option2select1.ChildNodes);
        Assert.Empty(dochtml0body1option2select1.Attributes);
        Assert.Equal("select", dochtml0body1option2select1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option2select1.NodeType);

        var dochtml0body1option2select1option0 = dochtml0body1option2select1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1option2select1option0.ChildNodes);
        Assert.Empty(dochtml0body1option2select1option0.Attributes);
        Assert.Equal("option", dochtml0body1option2select1option0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option2select1option0.NodeType);

        var dochtml0body1option2select1option0Text0 = dochtml0body1option2select1option0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1option2select1option0Text0.NodeType);
        Assert.Equal("E", dochtml0body1option2select1option0Text0.TextContent);

        var dochtml0body1option3 = dochtml0body1.ChildNodes[3] as Element;
        Assert.Equal(2, dochtml0body1option3.ChildNodes.Length);
        Assert.Empty(dochtml0body1option3.Attributes);
        Assert.Equal("option", dochtml0body1option3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option3.NodeType);

        var dochtml0body1option3Text0 = dochtml0body1option3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1option3Text0.NodeType);
        Assert.Equal("F", dochtml0body1option3Text0.TextContent);

        var dochtml0body1option3select1 = dochtml0body1option3.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1option3select1.ChildNodes);
        Assert.Empty(dochtml0body1option3select1.Attributes);
        Assert.Equal("select", dochtml0body1option3select1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option3select1.NodeType);

        var dochtml0body1option3select1option0 = dochtml0body1option3select1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1option3select1option0.ChildNodes);
        Assert.Empty(dochtml0body1option3select1option0.Attributes);
        Assert.Equal("option", dochtml0body1option3select1option0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1option3select1option0.NodeType);

        var dochtml0body1option3select1option0Text0 = dochtml0body1option3select1option0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1option3select1option0Text0.NodeType);
        Assert.Equal("G", dochtml0body1option3select1option0Text0.TextContent);
    }

    [Fact]
    public void TreeDefinitionList()
    {
        var doc = (@"<dd><dd><dt><dt><dd><li><li>").ToHtmlDocument();

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
        Assert.Equal(5, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
        var dochtml0body1dd0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1dd0.ChildNodes);
        Assert.Empty(dochtml0body1dd0.Attributes);
        Assert.Equal("dd", dochtml0body1dd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1dd0.NodeType);

        var dochtml0body1dd1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1dd1.ChildNodes);
        Assert.Empty(dochtml0body1dd1.Attributes);
        Assert.Equal("dd", dochtml0body1dd1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1dd1.NodeType);

        var dochtml0body1dt2 = dochtml0body1.ChildNodes[2] as Element; ;
        Assert.Empty(dochtml0body1dt2.ChildNodes);
        Assert.Empty(dochtml0body1dt2.Attributes);
        Assert.Equal("dt", dochtml0body1dt2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1dt2.NodeType);

        var dochtml0body1dt3 = dochtml0body1.ChildNodes[3] as Element;
        Assert.Empty(dochtml0body1dt3.ChildNodes);
        Assert.Empty(dochtml0body1dt3.Attributes);
        Assert.Equal("dt", dochtml0body1dt3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1dt3.NodeType);

        var dochtml0body1dd4 = dochtml0body1.ChildNodes[4] as Element;
        Assert.Equal(2, dochtml0body1dd4.ChildNodes.Length);
        Assert.Empty(dochtml0body1dd4.Attributes);
        Assert.Equal("dd", dochtml0body1dd4.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1dd4.NodeType);

        var dochtml0body1dd4li0 = dochtml0body1dd4.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1dd4li0.ChildNodes);
        Assert.Empty(dochtml0body1dd4li0.Attributes);
        Assert.Equal("li", dochtml0body1dd4li0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1dd4li0.NodeType);

        var dochtml0body1dd4li1 = dochtml0body1dd4.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1dd4li1.ChildNodes);
        Assert.Empty(dochtml0body1dd4li1.Attributes);
        Assert.Equal("li", dochtml0body1dd4li1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1dd4li1.NodeType);
    }

    [Fact]
    public void TreeDivsAndFormatting()
    {
        var doc = (@"<div><b></div><div><nobr>a<nobr>").ToHtmlDocument();

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

        var dochtml0body1div0b0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0b0.ChildNodes);
        Assert.Empty(dochtml0body1div0b0.Attributes);
        Assert.Equal("b", dochtml0body1div0b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0b0.NodeType);

        var dochtml0body1div1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1div1.ChildNodes);
        Assert.Empty(dochtml0body1div1.Attributes);
        Assert.Equal("div", dochtml0body1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1.NodeType);

        var dochtml0body1div1b0 = dochtml0body1div1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1div1b0.ChildNodes.Length);
        Assert.Empty(dochtml0body1div1b0.Attributes);
        Assert.Equal("b", dochtml0body1div1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1b0.NodeType);

        var dochtml0body1div1b0nobr0 = dochtml0body1div1b0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div1b0nobr0.ChildNodes);
        Assert.Empty(dochtml0body1div1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml0body1div1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1b0nobr0.NodeType);

        var dochtml0body1div1b0nobr0Text0 = dochtml0body1div1b0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1div1b0nobr0Text0.NodeType);
        Assert.Equal("a", dochtml0body1div1b0nobr0Text0.TextContent);

        var dochtml0body1div1b0nobr1 = dochtml0body1div1b0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1div1b0nobr1.ChildNodes);
        Assert.Empty(dochtml0body1div1b0nobr1.Attributes);
        Assert.Equal("nobr", dochtml0body1div1b0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div1b0nobr1.NodeType);
    }

    [Fact]
    public void TreeStandardStructureWithoutRoot()
    {
        var doc = (@"<head></head>
<body></body>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0Text1 = dochtml0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0Text1.NodeType);
        Assert.Equal("\n", dochtml0Text1.TextContent);

        var dochtml0body2 = dochtml0.ChildNodes[2] as Element;
        Assert.Empty(dochtml0body2.ChildNodes);
        Assert.Empty(dochtml0body2.Attributes);
        Assert.Equal("body", dochtml0body2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body2.NodeType);
    }

    [Fact]
    public void TreeStyleTagOutsideHead()
    {
        var doc = (@"<head></head> <style></style>ddd").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0.ChildNodes);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0Text1 = dochtml0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0Text1.NodeType);
        Assert.Equal(" ", dochtml0Text1.TextContent);

        var dochtml0body2 = dochtml0.ChildNodes[2] as Element;
        Assert.Single(dochtml0body2.ChildNodes);
        Assert.Empty(dochtml0body2.Attributes);
        Assert.Equal("body", dochtml0body2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body2.NodeType);

        var dochtml0body2Text0 = dochtml0body2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body2Text0.NodeType);
        Assert.Equal("ddd", dochtml0body2Text0.TextContent);
    }

    [Fact]
    public void TreeTableElementMisnestedWithUnknownElement()
    {
        var doc = (@"<kbd><table></kbd><col><select><tr>").ToHtmlDocument();

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

        var dochtml0body1kbd0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1kbd0.ChildNodes.Length);
        Assert.Empty(dochtml0body1kbd0.Attributes);
        Assert.Equal("kbd", dochtml0body1kbd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0.NodeType);

        var dochtml0body1kbd0select0 = dochtml0body1kbd0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1kbd0select0.ChildNodes);
        Assert.Empty(dochtml0body1kbd0select0.Attributes);
        Assert.Equal("select", dochtml0body1kbd0select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0select0.NodeType);

        var dochtml0body1kbd0table1 = dochtml0body1kbd0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1kbd0table1.ChildNodes.Length);
        Assert.Empty(dochtml0body1kbd0table1.Attributes);
        Assert.Equal("table", dochtml0body1kbd0table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1.NodeType);

        var dochtml0body1kbd0table1colgroup0 = dochtml0body1kbd0table1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1kbd0table1colgroup0.ChildNodes);
        Assert.Empty(dochtml0body1kbd0table1colgroup0.Attributes);
        Assert.Equal("colgroup", dochtml0body1kbd0table1colgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1colgroup0.NodeType);

        var dochtml0body1kbd0table1colgroup0col0 = dochtml0body1kbd0table1colgroup0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1kbd0table1colgroup0col0.ChildNodes);
        Assert.Empty(dochtml0body1kbd0table1colgroup0col0.Attributes);
        Assert.Equal("col", dochtml0body1kbd0table1colgroup0col0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1colgroup0col0.NodeType);

        var dochtml0body1kbd0table1tbody1 = dochtml0body1kbd0table1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1kbd0table1tbody1.ChildNodes);
        Assert.Empty(dochtml0body1kbd0table1tbody1.Attributes);
        Assert.Equal("tbody", dochtml0body1kbd0table1tbody1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1tbody1.NodeType);

        var dochtml0body1kbd0table1tbody1tr0 = dochtml0body1kbd0table1tbody1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1kbd0table1tbody1tr0.ChildNodes);
        Assert.Empty(dochtml0body1kbd0table1tbody1tr0.Attributes);
        Assert.Equal("tr", dochtml0body1kbd0table1tbody1tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1tbody1tr0.NodeType);
    }

    [Fact]
    public void TreeTableAndSelectElementMistnestedInUnknownElement()
    {
        var doc = (@"<kbd><table></kbd><col><select><tr></table><div>").ToHtmlDocument();

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

        var dochtml0body1kbd0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0body1kbd0.ChildNodes.Length);
        Assert.Empty(dochtml0body1kbd0.Attributes);
        Assert.Equal("kbd", dochtml0body1kbd0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0.NodeType);

        var dochtml0body1kbd0select0 = dochtml0body1kbd0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1kbd0select0.ChildNodes);
        Assert.Empty(dochtml0body1kbd0select0.Attributes);
        Assert.Equal("select", dochtml0body1kbd0select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0select0.NodeType);

        var dochtml0body1kbd0table1 = dochtml0body1kbd0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1kbd0table1.ChildNodes.Length);
        Assert.Empty(dochtml0body1kbd0table1.Attributes);
        Assert.Equal("table", dochtml0body1kbd0table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1.NodeType);

        var dochtml0body1kbd0table1colgroup0 = dochtml0body1kbd0table1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1kbd0table1colgroup0.ChildNodes);
        Assert.Empty(dochtml0body1kbd0table1colgroup0.Attributes);
        Assert.Equal("colgroup", dochtml0body1kbd0table1colgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1colgroup0.NodeType);

        var dochtml0body1kbd0table1colgroup0col0 = dochtml0body1kbd0table1colgroup0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1kbd0table1colgroup0col0.ChildNodes);
        Assert.Empty(dochtml0body1kbd0table1colgroup0col0.Attributes);
        Assert.Equal("col", dochtml0body1kbd0table1colgroup0col0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1colgroup0col0.NodeType);

        var dochtml0body1kbd0table1tbody1 = dochtml0body1kbd0table1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1kbd0table1tbody1.ChildNodes);
        Assert.Empty(dochtml0body1kbd0table1tbody1.Attributes);
        Assert.Equal("tbody", dochtml0body1kbd0table1tbody1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1tbody1.NodeType);

        var dochtml0body1kbd0table1tbody1tr0 = dochtml0body1kbd0table1tbody1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1kbd0table1tbody1tr0.ChildNodes);
        Assert.Empty(dochtml0body1kbd0table1tbody1tr0.Attributes);
        Assert.Equal("tr", dochtml0body1kbd0table1tbody1tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0table1tbody1tr0.NodeType);

        var dochtml0body1kbd0div2 = dochtml0body1kbd0.ChildNodes[2] as Element; ;
        Assert.Empty(dochtml0body1kbd0div2.ChildNodes);
        Assert.Empty(dochtml0body1kbd0div2.Attributes);
        Assert.Equal("div", dochtml0body1kbd0div2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1kbd0div2.NodeType);
    }

    [Fact]
    public void TreeVariousTagsInsideAnchorElement()
    {
        var doc = (@"<a><li><style></style><title></title></a>").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1a0.ChildNodes);
        Assert.Empty(dochtml0body1a0.Attributes);
        Assert.Equal("a", dochtml0body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0.NodeType);

        var dochtml0body1li1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1li1.ChildNodes);
        Assert.Empty(dochtml0body1li1.Attributes);
        Assert.Equal("li", dochtml0body1li1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1li1.NodeType);

        var dochtml0body1li1a0 = dochtml0body1li1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1li1a0.ChildNodes.Length);
        Assert.Empty(dochtml0body1li1a0.Attributes);
        Assert.Equal("a", dochtml0body1li1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1li1a0.NodeType);

        var dochtml0body1li1a0style0 = dochtml0body1li1a0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1li1a0style0.ChildNodes);
        Assert.Empty(dochtml0body1li1a0style0.Attributes);
        Assert.Equal("style", dochtml0body1li1a0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1li1a0style0.NodeType);

        var dochtml0body1li1a0title1 = dochtml0body1li1a0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1li1a0title1.ChildNodes);
        Assert.Empty(dochtml0body1li1a0title1.Attributes);
        Assert.Equal("title", dochtml0body1li1a0title1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1li1a0title1.NodeType);
    }

    [Fact]
    public void TreeVariousTagsInsideFontElement()
    {
        var doc = (@"<font></p><p><meta><title></title></font>").ToHtmlDocument();

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

        var dochtml0body1font0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1font0.ChildNodes);
        Assert.Empty(dochtml0body1font0.Attributes);
        Assert.Equal("font", dochtml0body1font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1font0.NodeType);

        var dochtml0body1font0p0 = dochtml0body1font0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1font0p0.ChildNodes);
        Assert.Empty(dochtml0body1font0p0.Attributes);
        Assert.Equal("p", dochtml0body1font0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1font0p0.NodeType);

        var dochtml0body1p1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p1.ChildNodes);
        Assert.Empty(dochtml0body1p1.Attributes);
        Assert.Equal("p", dochtml0body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1.NodeType);

        var dochtml0body1p1font0 = dochtml0body1p1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1p1font0.ChildNodes.Length);
        Assert.Empty(dochtml0body1p1font0.Attributes);
        Assert.Equal("font", dochtml0body1p1font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0.NodeType);

        var dochtml0body1p1font0meta0 = dochtml0body1p1font0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1p1font0meta0.ChildNodes);
        Assert.Empty(dochtml0body1p1font0meta0.Attributes);
        Assert.Equal("meta", dochtml0body1p1font0meta0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0meta0.NodeType);

        var dochtml0body1p1font0title1 = dochtml0body1p1font0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1p1font0title1.ChildNodes);
        Assert.Empty(dochtml0body1p1font0title1.Attributes);
        Assert.Equal("title", dochtml0body1p1font0title1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1font0title1.NodeType);
    }

    [Fact]
    public void TreeCenterTitleElementInAnchorElement()
    {
        var doc = (@"<a><center><title></title><a>").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1a0.ChildNodes);
        Assert.Empty(dochtml0body1a0.Attributes);
        Assert.Equal("a", dochtml0body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1a0.NodeType);

        var dochtml0body1center1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1center1.ChildNodes.Length);
        Assert.Empty(dochtml0body1center1.Attributes);
        Assert.Equal("center", dochtml0body1center1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1center1.NodeType);

        var dochtml0body1center1a0 = dochtml0body1center1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1center1a0.ChildNodes);
        Assert.Empty(dochtml0body1center1a0.Attributes);
        Assert.Equal("a", dochtml0body1center1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1center1a0.NodeType);

        var dochtml0body1center1a0title0 = dochtml0body1center1a0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1center1a0title0.ChildNodes);
        Assert.Empty(dochtml0body1center1a0title0.Attributes);
        Assert.Equal("title", dochtml0body1center1a0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1center1a0title0.NodeType);

        var dochtml0body1center1a1 = dochtml0body1center1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1center1a1.ChildNodes);
        Assert.Empty(dochtml0body1center1a1.Attributes);
        Assert.Equal("a", dochtml0body1center1a1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1center1a1.NodeType);
    }

    [Fact]
    public void TreeSvgElementWithTitleAndDiv()
    {
        var doc = (@"<svg><title><div>").ToHtmlDocument();

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

        var dochtml0body1svg0title0 = dochtml0body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1svg0title0.ChildNodes);
        Assert.Empty(dochtml0body1svg0title0.Attributes);
        Assert.Equal("title", dochtml0body1svg0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0title0.NodeType);

        var dochtml0body1svg0title0div0 = dochtml0body1svg0title0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1svg0title0div0.ChildNodes);
        Assert.Empty(dochtml0body1svg0title0div0.Attributes);
        Assert.Equal("div", dochtml0body1svg0title0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0title0div0.NodeType);
    }

    [Fact]
    public void TreeSvgElementWithTitleAndRectAndDiv()
    {
        var doc = (@"<svg><title><rect><div>").ToHtmlDocument();

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

        var dochtml0body1svg0title0 = dochtml0body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1svg0title0.ChildNodes);
        Assert.Empty(dochtml0body1svg0title0.Attributes);
        Assert.Equal("title", dochtml0body1svg0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0title0.NodeType);

        var dochtml0body1svg0title0rect0 = dochtml0body1svg0title0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1svg0title0rect0.ChildNodes);
        Assert.Empty(dochtml0body1svg0title0rect0.Attributes);
        Assert.Equal("rect", dochtml0body1svg0title0rect0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0title0rect0.NodeType);

        var dochtml0body1svg0title0rect0div0 = dochtml0body1svg0title0rect0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1svg0title0rect0div0.ChildNodes);
        Assert.Empty(dochtml0body1svg0title0rect0div0.Attributes);
        Assert.Equal("div", dochtml0body1svg0title0rect0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0title0rect0div0.NodeType);
    }

    [Fact]
    public void TreeSvgElementWithTitleRepeated()
    {
        var doc = (@"<svg><title><svg><div>").ToHtmlDocument();

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

        var dochtml0body1svg0title0 = dochtml0body1svg0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1svg0title0.ChildNodes.Length);
        Assert.Empty(dochtml0body1svg0title0.Attributes);
        Assert.Equal("title", dochtml0body1svg0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0title0.NodeType);

        var dochtml0body1svg0title0svg0 = dochtml0body1svg0title0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1svg0title0svg0.ChildNodes);
        Assert.Empty(dochtml0body1svg0title0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1svg0title0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0title0svg0.NodeType);

        var dochtml0body1svg0title0div1 = dochtml0body1svg0title0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1svg0title0div1.ChildNodes);
        Assert.Empty(dochtml0body1svg0title0div1.Attributes);
        Assert.Equal("div", dochtml0body1svg0title0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0title0div1.NodeType);
    }

    [Fact]
    public void TreeImageWithFailedContent()
    {
        var doc = (@"<img <="""" FAIL>").ToHtmlDocument();

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

        var dochtml0body1img0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1img0.ChildNodes);
        Assert.Equal(2, dochtml0body1img0.Attributes.Length);
        Assert.Equal("img", dochtml0body1img0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1img0.NodeType);
        Assert.Equal("", dochtml0body1img0.GetAttribute("fail"));
        Assert.Equal("", dochtml0body1img0.GetAttribute("<"));
    }

    [Fact]
    public void TreeUnorderedListWithDivElements()
    {
        var doc = (@"<ul><li><div id='foo'/>A</li><li>B<div>C</div></li></ul>").ToHtmlDocument();

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

        var dochtml0body1ul0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1ul0.ChildNodes.Length);
        Assert.Empty(dochtml0body1ul0.Attributes);
        Assert.Equal("ul", dochtml0body1ul0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ul0.NodeType);

        var dochtml0body1ul0li0 = dochtml0body1ul0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1ul0li0.ChildNodes);
        Assert.Empty(dochtml0body1ul0li0.Attributes);
        Assert.Equal("li", dochtml0body1ul0li0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ul0li0.NodeType);

        var dochtml0body1ul0li0div0 = dochtml0body1ul0li0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1ul0li0div0.ChildNodes);
        Assert.Single(dochtml0body1ul0li0div0.Attributes);
        Assert.Equal("div", dochtml0body1ul0li0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ul0li0div0.NodeType);
        Assert.Equal("foo", dochtml0body1ul0li0div0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1ul0li0div0Text0 = dochtml0body1ul0li0div0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ul0li0div0Text0.NodeType);
        Assert.Equal("A", dochtml0body1ul0li0div0Text0.TextContent);

        var dochtml0body1ul0li1 = dochtml0body1ul0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1ul0li1.ChildNodes.Length);
        Assert.Empty(dochtml0body1ul0li1.Attributes);
        Assert.Equal("li", dochtml0body1ul0li1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ul0li1.NodeType);

        var dochtml0body1ul0li1Text0 = dochtml0body1ul0li1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ul0li1Text0.NodeType);
        Assert.Equal("B", dochtml0body1ul0li1Text0.TextContent);

        var dochtml0body1ul0li1div1 = dochtml0body1ul0li1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1ul0li1div1.ChildNodes);
        Assert.Empty(dochtml0body1ul0li1div1.Attributes);
        Assert.Equal("div", dochtml0body1ul0li1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1ul0li1div1.NodeType);

        var dochtml0body1ul0li1div1Text0 = dochtml0body1ul0li1div1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1ul0li1div1Text0.NodeType);
        Assert.Equal("C", dochtml0body1ul0li1div1Text0.TextContent);
    }

    [Fact]
    public void TreeSvgWithEmAndDescElements()
    {
        var doc = (@"<svg><em><desc></em>").ToHtmlDocument();

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

        var dochtml0body1svg0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1svg0.ChildNodes);
        Assert.Empty(dochtml0body1svg0.Attributes);
        Assert.Equal("svg", dochtml0body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0.NodeType);

        var dochtml0body1em1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1em1.ChildNodes);
        Assert.Empty(dochtml0body1em1.Attributes);
        Assert.Equal("em", dochtml0body1em1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1em1.NodeType);

        var dochtml0body1em1desc0 = dochtml0body1em1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1em1desc0.ChildNodes);
        Assert.Empty(dochtml0body1em1desc0.Attributes);
        Assert.Equal("desc", dochtml0body1em1desc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1em1desc0.NodeType);
    }

    [Fact]
    public void TreeSvgWithTfootAndClosingMiElement()
    {
        var doc = (@"<svg><tfoot></mi><td>").ToHtmlDocument();

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

        var dochtml0body1svg0tfoot0 = dochtml0body1svg0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1svg0tfoot0.ChildNodes);
        Assert.Empty(dochtml0body1svg0tfoot0.Attributes);
        Assert.Equal("tfoot", dochtml0body1svg0tfoot0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0tfoot0.NodeType);

        var dochtml0body1svg0tfoot0td0 = dochtml0body1svg0tfoot0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1svg0tfoot0td0.ChildNodes);
        Assert.Empty(dochtml0body1svg0tfoot0td0.Attributes);
        Assert.Equal("td", dochtml0body1svg0tfoot0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1svg0tfoot0td0.NodeType);
    }

    [Fact]
    public void TreeMathWithMrowsAndOtherElements()
    {
        var doc = (@"<math><mrow><mrow><mn>1</mn></mrow><mi>a</mi></mrow></math>").ToHtmlDocument();

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

        var dochtml0body1math0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0.ChildNodes);
        Assert.Empty(dochtml0body1math0.Attributes);
        Assert.Equal("math", dochtml0body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0.NodeType);

        var dochtml0body1math0mrow0 = dochtml0body1math0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1math0mrow0.ChildNodes.Length);
        Assert.Empty(dochtml0body1math0mrow0.Attributes);
        Assert.Equal("mrow", dochtml0body1math0mrow0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mrow0.NodeType);

        var dochtml0body1math0mrow0mrow0 = dochtml0body1math0mrow0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mrow0mrow0.ChildNodes);
        Assert.Empty(dochtml0body1math0mrow0mrow0.Attributes);
        Assert.Equal("mrow", dochtml0body1math0mrow0mrow0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mrow0mrow0.NodeType);

        var dochtml0body1math0mrow0mrow0mn0 = dochtml0body1math0mrow0mrow0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1math0mrow0mrow0mn0.ChildNodes);
        Assert.Empty(dochtml0body1math0mrow0mrow0mn0.Attributes);
        Assert.Equal("mn", dochtml0body1math0mrow0mrow0mn0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mrow0mrow0mn0.NodeType);

        var dochtml0body1math0mrow0mrow0mn0Text0 = dochtml0body1math0mrow0mrow0mn0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1math0mrow0mrow0mn0Text0.NodeType);
        Assert.Equal("1", dochtml0body1math0mrow0mrow0mn0Text0.TextContent);

        var dochtml0body1math0mrow0mi1 = dochtml0body1math0mrow0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1math0mrow0mi1.ChildNodes);
        Assert.Empty(dochtml0body1math0mrow0mi1.Attributes);
        Assert.Equal("mi", dochtml0body1math0mrow0mi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1math0mrow0mi1.NodeType);

        var dochtml0body1math0mrow0mi1Text0 = dochtml0body1math0mrow0mi1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1math0mrow0mi1Text0.NodeType);
        Assert.Equal("a", dochtml0body1math0mrow0mi1Text0.TextContent);
    }

    [Fact]
    public void TreeDocTypeWithInputHiddenAndFrameset()
    {
        var doc = (@"<!doctype html><input type=""hidden""><frameset>").ToHtmlDocument();

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

        var dochtml1frameset1 = dochtml1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1frameset1.ChildNodes);
        Assert.Empty(dochtml1frameset1.Attributes);
        Assert.Equal("frameset", dochtml1frameset1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1frameset1.NodeType);
    }

    [Fact]
    public void TreeDocTypeWithInputButtonAndFrameset()
    {
        var doc = (@"<!doctype html><input type=""button""><frameset>").ToHtmlDocument();

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

        var dochtml1body1input0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1input0.ChildNodes);
        Assert.Single(dochtml1body1input0.Attributes);
        Assert.Equal("input", dochtml1body1input0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1input0.NodeType);
        Assert.Equal("button", dochtml1body1input0.Attributes.GetNamedItem("type").Value);
    }

    [Fact]
    public void TreeUnknownTagSelfClosing()
    {
        var doc = (@"<foo bar=qux/>").ToHtmlDocument();

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

        var dochtml0body1foo0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1foo0.ChildNodes);
        Assert.Single(dochtml0body1foo0.Attributes);
        Assert.Equal("foo", dochtml0body1foo0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1foo0.NodeType);
        Assert.Equal("qux/", dochtml0body1foo0.Attributes.GetNamedItem("bar").Value);
    }

    [Fact]
    public void TreeParagraphWithTightAttributesAndNoScriptTagScriptingEnabled()
    {
        var source = @"<p id=""status""><noscript><strong>A</strong></noscript><span>B</span></p>";
        var config = Configuration.Default.WithScripting();
        var context = BrowsingContext.New(config);
        var parser = context.GetService<IHtmlParser>();
        var doc = parser.ParseDocument(source);

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1p0.ChildNodes.Length);
        Assert.Single(dochtml0body1p0.Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);
        Assert.Equal("status", dochtml0body1p0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p0noscript0 = dochtml0body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0noscript0.ChildNodes);
        Assert.Empty(dochtml0body1p0noscript0.Attributes);
        Assert.Equal("noscript", dochtml0body1p0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0noscript0.NodeType);

        var dochtml0body1p0noscript0Text0 = dochtml0body1p0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p0noscript0Text0.NodeType);
        Assert.Equal("<strong>A</strong>", dochtml0body1p0noscript0Text0.TextContent);

        var dochtml0body1p0span1 = dochtml0body1p0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p0span1.ChildNodes);
        Assert.Empty(dochtml0body1p0span1.Attributes);
        Assert.Equal("span", dochtml0body1p0span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0span1.NodeType);

        var dochtml0body1p0span1Text0 = dochtml0body1p0span1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p0span1Text0.NodeType);
        Assert.Equal("B", dochtml0body1p0span1Text0.TextContent);
    }

    [Fact]
    public void TreeParagraphWithTightAttributesAndNoScriptTagScriptingDisabled()
    {
        //Scripting is disabled by default
        var doc = (@"<p id=""status""><noscript><strong>A</strong></noscript><span>B</span></p>").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0body1p0.ChildNodes.Length);
        Assert.Single(dochtml0body1p0.Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);
        Assert.Equal("status", dochtml0body1p0.Attributes.GetNamedItem("id").Value);

        var dochtml0body1p0noscript0 = dochtml0body1p0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0noscript0.ChildNodes);
        Assert.Empty(dochtml0body1p0noscript0.Attributes);
        Assert.Equal("noscript", dochtml0body1p0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0noscript0.NodeType);

        var dochtml0body1p0noscript0Strong0 = dochtml0body1p0noscript0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1p0noscript0Strong0.ChildNodes);
        Assert.Empty(dochtml0body1p0noscript0Strong0.Attributes);
        Assert.Equal("strong", dochtml0body1p0noscript0Strong0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0noscript0Strong0.NodeType);

        var dochtml0body1p0noscript0Strong0Text = dochtml0body1p0noscript0Strong0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p0noscript0Strong0Text.NodeType);
        Assert.Equal("A", dochtml0body1p0noscript0Strong0Text.TextContent);

        var dochtml0body1p0span1 = dochtml0body1p0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p0span1.ChildNodes);
        Assert.Empty(dochtml0body1p0span1.Attributes);
        Assert.Equal("span", dochtml0body1p0span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0span1.NodeType);

        var dochtml0body1p0span1Text0 = dochtml0body1p0span1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p0span1Text0.NodeType);
        Assert.Equal("B", dochtml0body1p0span1Text0.TextContent);
    }

    [Fact]
    public void TreeSarcasmTagUsed()
    {
        var doc = (@"<div><sarcasm><div></div></sarcasm></div>").ToHtmlDocument();

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

        var dochtml0body1div0sarcasm0 = dochtml0body1div0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1div0sarcasm0.ChildNodes);
        Assert.Empty(dochtml0body1div0sarcasm0.Attributes);
        Assert.Equal("sarcasm", dochtml0body1div0sarcasm0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0sarcasm0.NodeType);

        var dochtml0body1div0sarcasm0div0 = dochtml0body1div0sarcasm0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1div0sarcasm0div0.ChildNodes);
        Assert.Empty(dochtml0body1div0sarcasm0div0.Attributes);
        Assert.Equal("div", dochtml0body1div0sarcasm0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1div0sarcasm0div0.NodeType);
    }

    [Fact]
    public void TreeImageWithOpeningDoubleQuotesAltAttribute()
    {
        var doc = (@"<html><body><img src="""" border=""0"" alt=""><div>A</div></body></html>").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TreeWithMisnestedClosingTableBodySection()
    {
        var doc = (@"<table><td></tbody>A").ToHtmlDocument();

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
        Assert.Equal("A", dochtml0body1Text0.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1tbody0 = dochtml0body1table1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table1tbody0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml0body1table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0.NodeType);

        var dochtml0body1table1tbody0tr0 = dochtml0body1table1tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table1tbody0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0.NodeType);

        var dochtml0body1table1tbody0tr0td0 = dochtml0body1table1tbody0tr0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table1tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table1tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0td0.NodeType);
    }

    [Fact]
    public void TreeWithMisnestedClosingTableHeadSection()
    {
        var doc = (@"<table><td></thead>A").ToHtmlDocument();

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

        var dochtml0body1table0tbody0tr0td0 = dochtml0body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);

        var dochtml0body1table0tbody0tr0td0Text0 = dochtml0body1table0tbody0tr0td0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1table0tbody0tr0td0Text0.NodeType);
        Assert.Equal("A", dochtml0body1table0tbody0tr0td0Text0.TextContent);
    }

    [Fact]
    public void TreeWithMisnestedClosingTableFootSection()
    {
        var doc = (@"<table><td></tfoot>A").ToHtmlDocument();

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

        var dochtml0body1table0tbody0tr0td0 = dochtml0body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);

        var dochtml0body1table0tbody0tr0td0Text0 = dochtml0body1table0tbody0tr0td0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1table0tbody0tr0td0Text0.NodeType);
        Assert.Equal("A", dochtml0body1table0tbody0tr0td0Text0.TextContent);
    }

    [Fact]
    public void TreeWithTableHeadSectionAndMisnestedClosingTableBodySection()
    {
        var doc = (@"<table><thead><td></tbody>A").ToHtmlDocument();

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

        var dochtml0body1table0thead0tr0 = dochtml0body1table0thead0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0thead0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0thead0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0tr0.NodeType);

        var dochtml0body1table0thead0tr0td0 = dochtml0body1table0thead0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0thead0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table0thead0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0thead0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0thead0tr0td0.NodeType);

        var dochtml0body1table0thead0tr0td0Text0 = dochtml0body1table0thead0tr0td0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1table0thead0tr0td0Text0.NodeType);
        Assert.Equal("A", dochtml0body1table0thead0tr0td0Text0.TextContent);
    }

    [Fact]
    public void TreeNobrTagsInBody()
    {
        var doc = (@"<!DOCTYPE html><body><a href='#1'><nobr>1<nobr></a><br><a href='#2'><nobr>2<nobr></a><br><a href='#3'><nobr>3<nobr></a>").ToHtmlDocument();

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
        Assert.Equal(5, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1a0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1a0.ChildNodes.Length);
        Assert.Single(dochtml1body1a0.Attributes);
        Assert.Equal("a", dochtml1body1a0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a0.NodeType);
        Assert.NotNull(dochtml1body1a0.Attributes.GetNamedItem("href"));
        Assert.Equal("href", dochtml1body1a0.Attributes.GetNamedItem("href").Name);
        Assert.Equal("#1", dochtml1body1a0.Attributes.GetNamedItem("href").Value);

        var dochtml1body1a0nobr0 = dochtml1body1a0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1a0nobr0.ChildNodes);
        Assert.Empty(dochtml1body1a0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1a0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a0nobr0.NodeType);

        var dochtml1body1a0nobr0Text0 = dochtml1body1a0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1a0nobr0Text0.NodeType);
        Assert.Equal("1", dochtml1body1a0nobr0Text0.TextContent);

        var dochtml1body1a0nobr1 = dochtml1body1a0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1a0nobr1.ChildNodes);
        Assert.Empty(dochtml1body1a0nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1a0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a0nobr1.NodeType);

        var dochtml1body1nobr1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1nobr1.ChildNodes.Length);
        Assert.Empty(dochtml1body1nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1.NodeType);

        var dochtml1body1nobr1br0 = dochtml1body1nobr1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1nobr1br0.ChildNodes);
        Assert.Empty(dochtml1body1nobr1br0.Attributes);
        Assert.Equal("br", dochtml1body1nobr1br0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1br0.NodeType);

        var dochtml1body1nobr1a1 = dochtml1body1nobr1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1nobr1a1.ChildNodes);
        Assert.Single(dochtml1body1nobr1a1.Attributes);
        Assert.Equal("a", dochtml1body1nobr1a1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1a1.NodeType);
        Assert.NotNull(dochtml1body1nobr1a1.Attributes.GetNamedItem("href"));
        Assert.Equal("href", dochtml1body1nobr1a1.Attributes.GetNamedItem("href").Name);
        Assert.Equal("#2", dochtml1body1nobr1a1.Attributes.GetNamedItem("href").Value);

        var dochtml1body1a2 = dochtml1body1.ChildNodes[2] as Element; ;
        Assert.Equal(2, dochtml1body1a2.ChildNodes.Length);
        Assert.Single(dochtml1body1a2.Attributes);
        Assert.Equal("a", dochtml1body1a2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a2.NodeType);
        Assert.NotNull(dochtml1body1a2.Attributes.GetNamedItem("href"));
        Assert.Equal("href", dochtml1body1a2.Attributes.GetNamedItem("href").Name);
        Assert.Equal("#2", dochtml1body1a2.Attributes.GetNamedItem("href").Value);

        var dochtml1body1a2nobr0 = dochtml1body1a2.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1a2nobr0.ChildNodes);
        Assert.Empty(dochtml1body1a2nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1a2nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a2nobr0.NodeType);

        var dochtml1body1a2nobr0Text0 = dochtml1body1a2nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1a2nobr0Text0.NodeType);
        Assert.Equal("2", dochtml1body1a2nobr0Text0.TextContent);

        var dochtml1body1a2nobr1 = dochtml1body1a2.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1a2nobr1.ChildNodes);
        Assert.Empty(dochtml1body1a2nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1a2nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a2nobr1.NodeType);

        var dochtml1body1nobr3 = dochtml1body1.ChildNodes[3] as Element;
        Assert.Equal(2, dochtml1body1nobr3.ChildNodes.Length);
        Assert.Empty(dochtml1body1nobr3.Attributes);
        Assert.Equal("nobr", dochtml1body1nobr3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr3.NodeType);

        var dochtml1body1nobr3br0 = dochtml1body1nobr3.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1nobr3br0.ChildNodes);
        Assert.Empty(dochtml1body1nobr3br0.Attributes);
        Assert.Equal("br", dochtml1body1nobr3br0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr3br0.NodeType);

        var dochtml1body1nobr3a1 = dochtml1body1nobr3.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1nobr3a1.ChildNodes);
        Assert.Single(dochtml1body1nobr3a1.Attributes);
        Assert.Equal("a", dochtml1body1nobr3a1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr3a1.NodeType);
        Assert.NotNull(dochtml1body1nobr3a1.Attributes.GetNamedItem("href"));
        Assert.Equal("href", dochtml1body1nobr3a1.Attributes.GetNamedItem("href").Name);
        Assert.Equal("#3", dochtml1body1nobr3a1.Attributes.GetNamedItem("href").Value);

        var dochtml1body1a4 = dochtml1body1.ChildNodes[4] as Element;
        Assert.Equal(2, dochtml1body1a4.ChildNodes.Length);
        Assert.Single(dochtml1body1a4.Attributes);
        Assert.Equal("a", dochtml1body1a4.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a4.NodeType);
        Assert.NotNull(dochtml1body1a4.Attributes.GetNamedItem("href"));
        Assert.Equal("href", dochtml1body1a4.Attributes.GetNamedItem("href").Name);
        Assert.Equal("#3", dochtml1body1a4.Attributes.GetNamedItem("href").Value);

        var dochtml1body1a4nobr0 = dochtml1body1a4.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1a4nobr0.ChildNodes);
        Assert.Empty(dochtml1body1a4nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1a4nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a4nobr0.NodeType);

        var dochtml1body1a4nobr0Text0 = dochtml1body1a4nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1a4nobr0Text0.NodeType);
        Assert.Equal("3", dochtml1body1a4nobr0Text0.TextContent);

        var dochtml1body1a4nobr1 = dochtml1body1a4.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1a4nobr1.ChildNodes);
        Assert.Empty(dochtml1body1a4nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1a4nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1a4nobr1.NodeType);
    }

    [Fact]
    public void TreeNobrAndFormattingTagsInBody()
    {
        var doc = (@"<!DOCTYPE html><body><b><nobr>1<nobr></b><i><nobr>2<nobr></i>3").ToHtmlDocument();

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
        Assert.Equal(4, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1b0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1b0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0.Attributes);
        Assert.Equal("b", dochtml1body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0.NodeType);

        var dochtml1body1b0nobr0 = dochtml1body1b0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0.NodeType);

        var dochtml1body1b0nobr0Text0 = dochtml1body1b0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0Text0.NodeType);
        Assert.Equal("1", dochtml1body1b0nobr0Text0.TextContent);

        var dochtml1body1b0nobr1 = dochtml1body1b0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1b0nobr1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr1.NodeType);

        var dochtml1body1nobr1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1nobr1.ChildNodes);
        Assert.Empty(dochtml1body1nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1.NodeType);

        var dochtml1body1nobr1i0 = dochtml1body1nobr1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1nobr1i0.ChildNodes);
        Assert.Empty(dochtml1body1nobr1i0.Attributes);
        Assert.Equal("i", dochtml1body1nobr1i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1i0.NodeType);

        var dochtml1body1i2 = dochtml1body1.ChildNodes[2] as Element; ;
        Assert.Equal(2, dochtml1body1i2.ChildNodes.Length);
        Assert.Empty(dochtml1body1i2.Attributes);
        Assert.Equal("i", dochtml1body1i2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1i2.NodeType);

        var dochtml1body1i2nobr0 = dochtml1body1i2.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1i2nobr0.ChildNodes);
        Assert.Empty(dochtml1body1i2nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1i2nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1i2nobr0.NodeType);

        var dochtml1body1i2nobr0Text0 = dochtml1body1i2nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1i2nobr0Text0.NodeType);
        Assert.Equal("2", dochtml1body1i2nobr0Text0.TextContent);

        var dochtml1body1i2nobr1 = dochtml1body1i2.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1i2nobr1.ChildNodes);
        Assert.Empty(dochtml1body1i2nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1i2nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1i2nobr1.NodeType);

        var dochtml1body1nobr3 = dochtml1body1.ChildNodes[3] as Element;
        Assert.Single(dochtml1body1nobr3.ChildNodes);
        Assert.Empty(dochtml1body1nobr3.Attributes);
        Assert.Equal("nobr", dochtml1body1nobr3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr3.NodeType);

        var dochtml1body1nobr3Text0 = dochtml1body1nobr3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1nobr3Text0.NodeType);
        Assert.Equal("3", dochtml1body1nobr3Text0.TextContent);
    }

    [Fact]
    public void TreeNobrAndTableTagsInBody()
    {
        var doc = (@"<!DOCTYPE html><body><b><nobr>1<table><nobr></b><i><nobr>2<nobr></i>3").ToHtmlDocument();

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

        var dochtml1body1b0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0.ChildNodes);
        Assert.Empty(dochtml1body1b0.Attributes);
        Assert.Equal("b", dochtml1body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0.NodeType);

        var dochtml1body1b0nobr0 = dochtml1body1b0.ChildNodes[0] as Element;
        Assert.Equal(5, dochtml1body1b0nobr0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0.NodeType);

        var dochtml1body1b0nobr0Text0 = dochtml1body1b0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0Text0.NodeType);
        Assert.Equal("1", dochtml1body1b0nobr0Text0.TextContent);

        var dochtml1body1b0nobr0nobr1 = dochtml1body1b0nobr0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1b0nobr0nobr1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0nobr1.NodeType);

        var dochtml1body1b0nobr0nobr1i0 = dochtml1body1b0nobr0nobr1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1b0nobr0nobr1i0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0nobr1i0.Attributes);
        Assert.Equal("i", dochtml1body1b0nobr0nobr1i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0nobr1i0.NodeType);

        var dochtml1body1b0nobr0i2 = dochtml1body1b0nobr0.ChildNodes[2] as Element;
        Assert.Equal(2, dochtml1body1b0nobr0i2.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0nobr0i2.Attributes);
        Assert.Equal("i", dochtml1body1b0nobr0i2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0i2.NodeType);

        var dochtml1body1b0nobr0i2nobr0 = dochtml1body1b0nobr0i2.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0i2nobr0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0i2nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0i2nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0i2nobr0.NodeType);

        var dochtml1body1b0nobr0i2nobr0Text0 = dochtml1body1b0nobr0i2nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0i2nobr0Text0.NodeType);
        Assert.Equal("2", dochtml1body1b0nobr0i2nobr0Text0.TextContent);

        var dochtml1body1b0nobr0i2nobr1 = dochtml1body1b0nobr0i2.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1b0nobr0i2nobr1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0i2nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0i2nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0i2nobr1.NodeType);

        var dochtml1body1b0nobr0nobr3 = dochtml1body1b0nobr0.ChildNodes[3] as Element;
        Assert.Single(dochtml1body1b0nobr0nobr3.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0nobr3.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0nobr3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0nobr3.NodeType);

        var dochtml1body1b0nobr0nobr3Text0 = dochtml1body1b0nobr0nobr3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0nobr3Text0.NodeType);
        Assert.Equal("3", dochtml1body1b0nobr0nobr3Text0.TextContent);

        var dochtml1body1b0nobr0table4 = dochtml1body1b0nobr0.ChildNodes[4] as Element;
        Assert.Empty(dochtml1body1b0nobr0table4.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table4.Attributes);
        Assert.Equal("table", dochtml1body1b0nobr0table4.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table4.NodeType);
    }

    [Fact]
    public void TreeNoBrAndTableCellTagsInBody()
    {
        var doc = (@"<!DOCTYPE html><body><b><nobr>1<table><tr><td><nobr></b><i><nobr>2<nobr></i>3").ToHtmlDocument();

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

        var dochtml1body1b0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0.ChildNodes);
        Assert.Empty(dochtml1body1b0.Attributes);
        Assert.Equal("b", dochtml1body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0.NodeType);

        var dochtml1body1b0nobr0 = dochtml1body1b0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1b0nobr0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0.NodeType);

        var dochtml1body1b0nobr0Text0 = dochtml1body1b0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0Text0.NodeType);
        Assert.Equal("1", dochtml1body1b0nobr0Text0.TextContent);

        var dochtml1body1b0nobr0table1 = dochtml1body1b0nobr0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1b0nobr0table1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table1.Attributes);
        Assert.Equal("table", dochtml1body1b0nobr0table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1.NodeType);

        var dochtml1body1b0nobr0table1tbody0 = dochtml1body1b0nobr0table1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0table1tbody0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0.Attributes);
        Assert.Equal("tbody", dochtml1body1b0nobr0table1tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0 = dochtml1body1b0nobr0table1tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0table1tbody0tr0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml1body1b0nobr0table1tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0tr0.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0td0 = dochtml1body1b0nobr0table1tbody0tr0.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml1body1b0nobr0table1tbody0tr0td0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml1body1b0nobr0table1tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0tr0td0.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0td0nobr0 = dochtml1body1b0nobr0table1tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0table1tbody0tr0td0nobr0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0table1tbody0tr0td0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0tr0td0nobr0.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0td0nobr0i0 = dochtml1body1b0nobr0table1tbody0tr0td0nobr0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0nobr0i0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0nobr0i0.Attributes);
        Assert.Equal("i", dochtml1body1b0nobr0table1tbody0tr0td0nobr0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0tr0td0nobr0i0.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0td0i1 = dochtml1body1b0nobr0table1tbody0tr0td0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1b0nobr0table1tbody0tr0td0i1.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0i1.Attributes);
        Assert.Equal("i", dochtml1body1b0nobr0table1tbody0tr0td0i1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0tr0td0i1.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0 = dochtml1body1b0nobr0table1tbody0tr0td0i1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0Text0 = dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0Text0.NodeType);
        Assert.Equal("2", dochtml1body1b0nobr0table1tbody0tr0td0i1nobr0Text0.TextContent);

        var dochtml1body1b0nobr0table1tbody0tr0td0i1nobr1 = dochtml1body1b0nobr0table1tbody0tr0td0i1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0i1nobr1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0i1nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0table1tbody0tr0td0i1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0tr0td0i1nobr1.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0td0nobr2 = dochtml1body1b0nobr0table1tbody0tr0td0.ChildNodes[2] as Element; ;
        Assert.Single(dochtml1body1b0nobr0table1tbody0tr0td0nobr2.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0table1tbody0tr0td0nobr2.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0table1tbody0tr0td0nobr2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0table1tbody0tr0td0nobr2.NodeType);

        var dochtml1body1b0nobr0table1tbody0tr0td0nobr2Text0 = dochtml1body1b0nobr0table1tbody0tr0td0nobr2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0table1tbody0tr0td0nobr2Text0.NodeType);
        Assert.Equal("3", dochtml1body1b0nobr0table1tbody0tr0td0nobr2Text0.TextContent);
    }

    [Fact]
    public void TreeNobrAndDivTagsInBody()
    {
        var doc = (@"<!DOCTYPE html><body><b><nobr>1<div><nobr></b><i><nobr>2<nobr></i>3").ToHtmlDocument();

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

        var dochtml1body1b0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0.ChildNodes);
        Assert.Empty(dochtml1body1b0.Attributes);
        Assert.Equal("b", dochtml1body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0.NodeType);

        var dochtml1body1b0nobr0 = dochtml1body1b0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0.NodeType);

        var dochtml1body1b0nobr0Text0 = dochtml1body1b0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0Text0.NodeType);
        Assert.Equal("1", dochtml1body1b0nobr0Text0.TextContent);

        var dochtml1body1div1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Equal(4, dochtml1body1div1.ChildNodes.Length);
        Assert.Empty(dochtml1body1div1.Attributes);
        Assert.Equal("div", dochtml1body1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1.NodeType);

        var dochtml1body1div1b0 = dochtml1body1div1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1div1b0.ChildNodes.Length);
        Assert.Empty(dochtml1body1div1b0.Attributes);
        Assert.Equal("b", dochtml1body1div1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1b0.NodeType);

        var dochtml1body1div1b0nobr0 = dochtml1body1div1b0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1div1b0nobr0.ChildNodes);
        Assert.Empty(dochtml1body1div1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1div1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1b0nobr0.NodeType);

        var dochtml1body1div1b0nobr1 = dochtml1body1div1b0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1div1b0nobr1.ChildNodes);
        Assert.Empty(dochtml1body1div1b0nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1div1b0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1b0nobr1.NodeType);

        var dochtml1body1div1nobr1 = dochtml1body1div1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1div1nobr1.ChildNodes);
        Assert.Empty(dochtml1body1div1nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1div1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1nobr1.NodeType);

        var dochtml1body1div1nobr1i0 = dochtml1body1div1nobr1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1div1nobr1i0.ChildNodes);
        Assert.Empty(dochtml1body1div1nobr1i0.Attributes);
        Assert.Equal("i", dochtml1body1div1nobr1i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1nobr1i0.NodeType);

        var dochtml1body1div1i2 = dochtml1body1div1.ChildNodes[2] as Element; ;
        Assert.Equal(2, dochtml1body1div1i2.ChildNodes.Length);
        Assert.Empty(dochtml1body1div1i2.Attributes);
        Assert.Equal("i", dochtml1body1div1i2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1i2.NodeType);

        var dochtml1body1div1i2nobr0 = dochtml1body1div1i2.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1div1i2nobr0.ChildNodes);
        Assert.Empty(dochtml1body1div1i2nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1div1i2nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1i2nobr0.NodeType);

        var dochtml1body1div1i2nobr0Text0 = dochtml1body1div1i2nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1div1i2nobr0Text0.NodeType);
        Assert.Equal("2", dochtml1body1div1i2nobr0Text0.TextContent);

        var dochtml1body1div1i2nobr1 = dochtml1body1div1i2.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1div1i2nobr1.ChildNodes);
        Assert.Empty(dochtml1body1div1i2nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1div1i2nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1i2nobr1.NodeType);

        var dochtml1body1div1nobr3 = dochtml1body1div1.ChildNodes[3] as Element;
        Assert.Single(dochtml1body1div1nobr3.ChildNodes);
        Assert.Empty(dochtml1body1div1nobr3.Attributes);
        Assert.Equal("nobr", dochtml1body1div1nobr3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1nobr3.NodeType);

        var dochtml1body1div1nobr3Text0 = dochtml1body1div1nobr3.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1div1nobr3Text0.NodeType);
        Assert.Equal("3", dochtml1body1div1nobr3Text0.TextContent);
    }

    [Fact]
    public void TreeNobrAndBoldAndDivTagsInBody()
    {
        var doc = (@"<!DOCTYPE html><body><b><nobr>1<nobr></b><div><i><nobr>2<nobr></i>3").ToHtmlDocument();

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

        var dochtml1body1b0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1b0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0.Attributes);
        Assert.Equal("b", dochtml1body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0.NodeType);

        var dochtml1body1b0nobr0 = dochtml1body1b0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0.NodeType);

        var dochtml1body1b0nobr0Text0 = dochtml1body1b0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0Text0.NodeType);
        Assert.Equal("1", dochtml1body1b0nobr0Text0.TextContent);

        var dochtml1body1b0nobr1 = dochtml1body1b0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1b0nobr1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr1.NodeType);

        var dochtml1body1div1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Equal(3, dochtml1body1div1.ChildNodes.Length);
        Assert.Empty(dochtml1body1div1.Attributes);
        Assert.Equal("div", dochtml1body1div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1.NodeType);

        var dochtml1body1div1nobr0 = dochtml1body1div1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1div1nobr0.ChildNodes);
        Assert.Empty(dochtml1body1div1nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1div1nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1nobr0.NodeType);

        var dochtml1body1div1nobr0i0 = dochtml1body1div1nobr0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1div1nobr0i0.ChildNodes);
        Assert.Empty(dochtml1body1div1nobr0i0.Attributes);
        Assert.Equal("i", dochtml1body1div1nobr0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1nobr0i0.NodeType);

        var dochtml1body1div1i1 = dochtml1body1div1.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml1body1div1i1.ChildNodes.Length);
        Assert.Empty(dochtml1body1div1i1.Attributes);
        Assert.Equal("i", dochtml1body1div1i1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1i1.NodeType);

        var dochtml1body1div1i1nobr0 = dochtml1body1div1i1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1div1i1nobr0.ChildNodes);
        Assert.Empty(dochtml1body1div1i1nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1div1i1nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1i1nobr0.NodeType);

        var dochtml1body1div1i1nobr0Text0 = dochtml1body1div1i1nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1div1i1nobr0Text0.NodeType);
        Assert.Equal("2", dochtml1body1div1i1nobr0Text0.TextContent);

        var dochtml1body1div1i1nobr1 = dochtml1body1div1i1.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1div1i1nobr1.ChildNodes);
        Assert.Empty(dochtml1body1div1i1nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1div1i1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1i1nobr1.NodeType);

        var dochtml1body1div1nobr2 = dochtml1body1div1.ChildNodes[2] as Element; ;
        Assert.Single(dochtml1body1div1nobr2.ChildNodes);
        Assert.Empty(dochtml1body1div1nobr2.Attributes);
        Assert.Equal("nobr", dochtml1body1div1nobr2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div1nobr2.NodeType);

        var dochtml1body1div1nobr2Text0 = dochtml1body1div1nobr2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1div1nobr2Text0.NodeType);
        Assert.Equal("3", dochtml1body1div1nobr2Text0.TextContent);
    }

    [Fact]
    public void TreeNobrAndInsTagInBody()
    {
        var doc = (@"<!DOCTYPE html><body><b><nobr>1<nobr><ins></b><i><nobr>").ToHtmlDocument();

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
        Assert.Equal(3, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1b0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1b0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0.Attributes);
        Assert.Equal("b", dochtml1body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0.NodeType);

        var dochtml1body1b0nobr0 = dochtml1body1b0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1b0nobr0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0.NodeType);

        var dochtml1body1b0nobr0Text0 = dochtml1body1b0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0Text0.NodeType);
        Assert.Equal("1", dochtml1body1b0nobr0Text0.TextContent);

        var dochtml1body1b0nobr1 = dochtml1body1b0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1b0nobr1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr1.NodeType);

        var dochtml1body1b0nobr1ins0 = dochtml1body1b0nobr1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1b0nobr1ins0.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr1ins0.Attributes);
        Assert.Equal("ins", dochtml1body1b0nobr1ins0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr1ins0.NodeType);

        var dochtml1body1nobr1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1nobr1.ChildNodes);
        Assert.Empty(dochtml1body1nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1.NodeType);

        var dochtml1body1nobr1i0 = dochtml1body1nobr1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1nobr1i0.ChildNodes);
        Assert.Empty(dochtml1body1nobr1i0.Attributes);
        Assert.Equal("i", dochtml1body1nobr1i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1i0.NodeType);

        var dochtml1body1i2 = dochtml1body1.ChildNodes[2] as Element; ;
        Assert.Single(dochtml1body1i2.ChildNodes);
        Assert.Empty(dochtml1body1i2.Attributes);
        Assert.Equal("i", dochtml1body1i2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1i2.NodeType);

        var dochtml1body1i2nobr0 = dochtml1body1i2.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1i2nobr0.ChildNodes);
        Assert.Empty(dochtml1body1i2nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1i2nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1i2nobr0.NodeType);
    }

    [Fact]
    public void TreeNobrAndInsTagWithBoldInBody()
    {
        var doc = (@"<!DOCTYPE html><body><b><nobr>1<ins><nobr></b><i>2").ToHtmlDocument();

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

        var dochtml1body1b0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1b0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0.Attributes);
        Assert.Equal("b", dochtml1body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0.NodeType);

        var dochtml1body1b0nobr0 = dochtml1body1b0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1b0nobr0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0.NodeType);

        var dochtml1body1b0nobr0Text0 = dochtml1body1b0nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0nobr0Text0.NodeType);
        Assert.Equal("1", dochtml1body1b0nobr0Text0.TextContent);

        var dochtml1body1b0nobr0ins1 = dochtml1body1b0nobr0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1b0nobr0ins1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr0ins1.Attributes);
        Assert.Equal("ins", dochtml1body1b0nobr0ins1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr0ins1.NodeType);

        var dochtml1body1b0nobr1 = dochtml1body1b0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1b0nobr1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr1.NodeType);

        var dochtml1body1nobr1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1nobr1.ChildNodes);
        Assert.Empty(dochtml1body1nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1.NodeType);

        var dochtml1body1nobr1i0 = dochtml1body1nobr1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1nobr1i0.ChildNodes);
        Assert.Empty(dochtml1body1nobr1i0.Attributes);
        Assert.Equal("i", dochtml1body1nobr1i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1i0.NodeType);

        var dochtml1body1nobr1i0Text0 = dochtml1body1nobr1i0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1nobr1i0Text0.NodeType);
        Assert.Equal("2", dochtml1body1nobr1i0Text0.TextContent);
    }

    [Fact]
    public void TreeNobrAndItalicTagsInBody()
    {
        var doc = (@"<!DOCTYPE html><body><b>1<nobr></b><i><nobr>2</i>").ToHtmlDocument();

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
        Assert.Equal(3, dochtml1body1.ChildNodes.Length);
        Assert.Empty(dochtml1body1.Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);

        var dochtml1body1b0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1b0.ChildNodes.Length);
        Assert.Empty(dochtml1body1b0.Attributes);
        Assert.Equal("b", dochtml1body1b0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0.NodeType);

        var dochtml1body1b0Text0 = dochtml1body1b0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1b0Text0.NodeType);
        Assert.Equal("1", dochtml1body1b0Text0.TextContent);

        var dochtml1body1b0nobr1 = dochtml1body1b0.ChildNodes[1] as Element;
        Assert.Empty(dochtml1body1b0nobr1.ChildNodes);
        Assert.Empty(dochtml1body1b0nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1b0nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1b0nobr1.NodeType);

        var dochtml1body1nobr1 = dochtml1body1.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1nobr1.ChildNodes);
        Assert.Empty(dochtml1body1nobr1.Attributes);
        Assert.Equal("nobr", dochtml1body1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1.NodeType);

        var dochtml1body1nobr1i0 = dochtml1body1nobr1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1nobr1i0.ChildNodes);
        Assert.Empty(dochtml1body1nobr1i0.Attributes);
        Assert.Equal("i", dochtml1body1nobr1i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1i0.NodeType);

        var dochtml1body1i2 = dochtml1body1.ChildNodes[2] as Element; ;
        Assert.Single(dochtml1body1i2.ChildNodes);
        Assert.Empty(dochtml1body1i2.Attributes);
        Assert.Equal("i", dochtml1body1i2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1i2.NodeType);

        var dochtml1body1i2nobr0 = dochtml1body1i2.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1i2nobr0.ChildNodes);
        Assert.Empty(dochtml1body1i2nobr0.Attributes);
        Assert.Equal("nobr", dochtml1body1i2nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1i2nobr0.NodeType);

        var dochtml1body1i2nobr0Text0 = dochtml1body1i2nobr0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1i2nobr0Text0.NodeType);
        Assert.Equal("2", dochtml1body1i2nobr0Text0.TextContent);
    }

    [Fact]
    public void TreeMisopenedCodeTagInParagraph()
    {
        var doc = (@"<p><code x</code></p>
").ToHtmlDocument();

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

        var dochtml0body1p0code0 = dochtml0body1p0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1p0code0.ChildNodes);
        Assert.Equal(2, dochtml0body1p0code0.Attributes.Length);
        Assert.Equal("code", dochtml0body1p0code0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0code0.NodeType);
        Assert.NotNull(dochtml0body1p0code0.Attributes.GetNamedItem("code"));
        Assert.Equal("code", dochtml0body1p0code0.Attributes.GetNamedItem("code").Name);
        Assert.Equal("", dochtml0body1p0code0.Attributes.GetNamedItem("code").Value);
        Assert.NotNull(dochtml0body1p0code0.Attributes.GetNamedItem("x<"));
        Assert.Equal("x<", dochtml0body1p0code0.Attributes.GetNamedItem("x<").Name);
        Assert.Equal("", dochtml0body1p0code0.Attributes.GetNamedItem("x<").Value);

        var dochtml0body1code1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1code1.ChildNodes);
        Assert.Equal(2, dochtml0body1code1.Attributes.Length);
        Assert.Equal("code", dochtml0body1code1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1code1.NodeType);
        Assert.NotNull(dochtml0body1code1.Attributes.GetNamedItem("code"));
        Assert.Equal("code", dochtml0body1code1.Attributes.GetNamedItem("code").Name);
        Assert.Equal("", dochtml0body1code1.Attributes.GetNamedItem("code").Value);
        Assert.NotNull(dochtml0body1code1.Attributes.GetNamedItem("x<"));
        Assert.Equal("x<", dochtml0body1code1.Attributes.GetNamedItem("x<").Name);
        Assert.Equal("", dochtml0body1code1.Attributes.GetNamedItem("x<").Value);

        var dochtml0body1code1Text0 = dochtml0body1code1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1code1Text0.NodeType);
        Assert.Equal("\n", dochtml0body1code1Text0.TextContent);
    }

    [Fact]
    public void TreeItalicInParagraphInForeignObjectInSvg()
    {
        var doc = (@"<!DOCTYPE html><svg><foreignObject><p><i></p>a").ToHtmlDocument();

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

        var dochtml1body1svg0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0.ChildNodes);
        Assert.Empty(dochtml1body1svg0.Attributes);
        Assert.Equal("svg", dochtml1body1svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0.NodeType);

        var dochtml1body1svg0foreignObject0 = dochtml1body1svg0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1svg0foreignObject0.ChildNodes.Length);
        Assert.Empty(dochtml1body1svg0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml1body1svg0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0foreignObject0.NodeType);

        var dochtml1body1svg0foreignObject0p0 = dochtml1body1svg0foreignObject0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1svg0foreignObject0p0.ChildNodes);
        Assert.Empty(dochtml1body1svg0foreignObject0p0.Attributes);
        Assert.Equal("p", dochtml1body1svg0foreignObject0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0foreignObject0p0.NodeType);

        var dochtml1body1svg0foreignObject0p0i0 = dochtml1body1svg0foreignObject0p0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1svg0foreignObject0p0i0.ChildNodes);
        Assert.Empty(dochtml1body1svg0foreignObject0p0i0.Attributes);
        Assert.Equal("i", dochtml1body1svg0foreignObject0p0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0foreignObject0p0i0.NodeType);

        var dochtml1body1svg0foreignObject0i1 = dochtml1body1svg0foreignObject0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1svg0foreignObject0i1.ChildNodes);
        Assert.Empty(dochtml1body1svg0foreignObject0i1.Attributes);
        Assert.Equal("i", dochtml1body1svg0foreignObject0i1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1svg0foreignObject0i1.NodeType);

        var dochtml1body1svg0foreignObject0i1Text0 = dochtml1body1svg0foreignObject0i1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1svg0foreignObject0i1Text0.NodeType);
        Assert.Equal("a", dochtml1body1svg0foreignObject0i1Text0.TextContent);
    }

    [Fact]
    public void TreeTableWithSvgInTableCell()
    {
        var doc = (@"<!DOCTYPE html><table><tr><td><svg><foreignObject><p><i></p>a").ToHtmlDocument();

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

        var dochtml1body1table0tbody0tr0td0svg0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0svg0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0.Attributes);
        Assert.Equal("svg", dochtml1body1table0tbody0tr0td0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0foreignObject0 = dochtml1body1table0tbody0tr0td0svg0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1table0tbody0tr0td0svg0foreignObject0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0foreignObject0.Attributes);
        Assert.Equal("foreignObject", dochtml1body1table0tbody0tr0td0svg0foreignObject0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0foreignObject0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0foreignObject0p0 = dochtml1body1table0tbody0tr0td0svg0foreignObject0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0svg0foreignObject0p0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0foreignObject0p0.Attributes);
        Assert.Equal("p", dochtml1body1table0tbody0tr0td0svg0foreignObject0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0foreignObject0p0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0foreignObject0p0i0 = dochtml1body1table0tbody0tr0td0svg0foreignObject0p0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0foreignObject0p0i0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0foreignObject0p0i0.Attributes);
        Assert.Equal("i", dochtml1body1table0tbody0tr0td0svg0foreignObject0p0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0foreignObject0p0i0.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0foreignObject0i1 = dochtml1body1table0tbody0tr0td0svg0foreignObject0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0svg0foreignObject0i1.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0svg0foreignObject0i1.Attributes);
        Assert.Equal("i", dochtml1body1table0tbody0tr0td0svg0foreignObject0i1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0svg0foreignObject0i1.NodeType);

        var dochtml1body1table0tbody0tr0td0svg0foreignObject0i1Text0 = dochtml1body1table0tbody0tr0td0svg0foreignObject0i1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0svg0foreignObject0i1Text0.NodeType);
        Assert.Equal("a", dochtml1body1table0tbody0tr0td0svg0foreignObject0i1Text0.TextContent);
    }

    [Fact]
    public void TreeItalicInParagraphInMtextInMath()
    {
        var doc = (@"<!DOCTYPE html><math><mtext><p><i></p>a").ToHtmlDocument();

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

        var dochtml1body1math0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0.ChildNodes);
        Assert.Empty(dochtml1body1math0.Attributes);
        Assert.Equal("math", dochtml1body1math0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0.NodeType);

        var dochtml1body1math0mtext0 = dochtml1body1math0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1math0mtext0.ChildNodes.Length);
        Assert.Empty(dochtml1body1math0mtext0.Attributes);
        Assert.Equal("mtext", dochtml1body1math0mtext0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mtext0.NodeType);

        var dochtml1body1math0mtext0p0 = dochtml1body1math0mtext0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1math0mtext0p0.ChildNodes);
        Assert.Empty(dochtml1body1math0mtext0p0.Attributes);
        Assert.Equal("p", dochtml1body1math0mtext0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mtext0p0.NodeType);

        var dochtml1body1math0mtext0p0i0 = dochtml1body1math0mtext0p0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1math0mtext0p0i0.ChildNodes);
        Assert.Empty(dochtml1body1math0mtext0p0i0.Attributes);
        Assert.Equal("i", dochtml1body1math0mtext0p0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mtext0p0i0.NodeType);

        var dochtml1body1math0mtext0i1 = dochtml1body1math0mtext0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1math0mtext0i1.ChildNodes);
        Assert.Empty(dochtml1body1math0mtext0i1.Attributes);
        Assert.Equal("i", dochtml1body1math0mtext0i1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1math0mtext0i1.NodeType);

        var dochtml1body1math0mtext0i1Text0 = dochtml1body1math0mtext0i1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1math0mtext0i1Text0.NodeType);
        Assert.Equal("a", dochtml1body1math0mtext0i1Text0.TextContent);
    }

    [Fact]
    public void TreeTableWithMathInTableCell()
    {
        var doc = (@"<!DOCTYPE html><table><tr><td><math><mtext><p><i></p>a").ToHtmlDocument();

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
        Assert.Equal(2, dochtml1body1table0tbody0tr0td0math0mtext0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mtext0.Attributes);
        Assert.Equal("mtext", dochtml1body1table0tbody0tr0td0math0mtext0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mtext0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mtext0p0 = dochtml1body1table0tbody0tr0td0math0mtext0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0math0mtext0p0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mtext0p0.Attributes);
        Assert.Equal("p", dochtml1body1table0tbody0tr0td0math0mtext0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mtext0p0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mtext0p0i0 = dochtml1body1table0tbody0tr0td0math0mtext0p0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mtext0p0i0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mtext0p0i0.Attributes);
        Assert.Equal("i", dochtml1body1table0tbody0tr0td0math0mtext0p0i0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mtext0p0i0.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mtext0i1 = dochtml1body1table0tbody0tr0td0math0mtext0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0math0mtext0i1.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0math0mtext0i1.Attributes);
        Assert.Equal("i", dochtml1body1table0tbody0tr0td0math0mtext0i1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0math0mtext0i1.NodeType);

        var dochtml1body1table0tbody0tr0td0math0mtext0i1Text0 = dochtml1body1table0tbody0tr0td0math0mtext0i1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0tbody0tr0td0math0mtext0i1Text0.NodeType);
        Assert.Equal("a", dochtml1body1table0tbody0tr0td0math0mtext0i1Text0.TextContent);
    }

    [Fact]
    public void TreeDivWithMisclosedTagInBody()
    {
        var doc = (@"<!DOCTYPE html><body><div><!/div>a").ToHtmlDocument();

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

        var dochtml1body1div0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml1body1div0.ChildNodes.Length);
        Assert.Empty(dochtml1body1div0.Attributes);
        Assert.Equal("div", dochtml1body1div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1div0.NodeType);

        var dochtml1body1div0Comment0 = dochtml1body1div0.ChildNodes[0];
        Assert.Equal(NodeType.Comment, dochtml1body1div0Comment0.NodeType);
        Assert.Equal(@"/div", dochtml1body1div0Comment0.TextContent);

        var dochtml1body1div0Text1 = dochtml1body1div0.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml1body1div0Text1.NodeType);
        Assert.Equal("a", dochtml1body1div0Text1.TextContent);
    }

    [Fact]
    public void TreeStyleWithCommentThatOpensAndClosesAStyleTagInside()
    {
        var doc = (@"<style><!--<style></style>--></style>").ToHtmlDocument();

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

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal("<!--<style>", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("-->", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeStyleWithOpeningCommentAndClosingStyleInside()
    {
        var doc = (@"<style><!--</style>X").ToHtmlDocument();

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

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal("<!--", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("X", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeStyleWithClosingStyleInCommentInside()
    {
        var doc = (@"<style><!--...</style>...--></style>").ToHtmlDocument();

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

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal("<!--...", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("...-->", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeStyleWithTagsInside()
    {
        var doc = (@"<style><!--<br><html xmlns:v=""urn:schemas-microsoft-com:vml""><!--[if !mso]><style></style>X").ToHtmlDocument();

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

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal("<!--<br><html xmlns:v=\"urn:schemas-microsoft-com:vml\"><!--[if !mso]><style>", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("X", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeStyleWithStyleCommentsInside()
    {
        var doc = (@"<style><!--...<style><!--...--!></style>--></style>").ToHtmlDocument();

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

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal("<!--...<style><!--...--!>", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("-->", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeStyleWithClosingStyleCommentsInside()
    {
        var doc = (@"<style><!--...</style><!-- --><style>@import ...</style>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Equal(3, dochtml0head0.ChildNodes.Length);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal("<!--...", dochtml0head0style0Text0.TextContent);

        var dochtml0head0Comment1 = dochtml0head0.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0head0Comment1.NodeType);
        Assert.Equal(@" ", dochtml0head0Comment1.TextContent);

        var dochtml0head0style2 = dochtml0head0.ChildNodes[2] as Element; ;
        Assert.Single(dochtml0head0style2.ChildNodes);
        Assert.Empty(dochtml0head0style2.Attributes);
        Assert.Equal("style", dochtml0head0style2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style2.NodeType);

        var dochtml0head0style2Text0 = dochtml0head0style2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style2Text0.NodeType);
        Assert.Equal("@import ...", dochtml0head0style2Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TreeStyleWithNestedStyleInside()
    {
        var doc = (@"<style>...<style><!--...</style><!-- --></style>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0.ChildNodes.Length);
        Assert.Empty(dochtml0.Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml0head0.ChildNodes.Length);
        Assert.Empty(dochtml0head0.Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal("...<style><!--...", dochtml0head0style0Text0.TextContent);

        var dochtml0head0Comment1 = dochtml0head0.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0head0Comment1.NodeType);
        Assert.Equal(@" ", dochtml0head0Comment1.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TreeStyleWithIEConditionalCommentsInside()
    {
        var doc = (@"<style>...<!--[if IE]><style>...</style>X").ToHtmlDocument();

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

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0style0.ChildNodes);
        Assert.Empty(dochtml0head0style0.Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0style0Text0 = dochtml0head0style0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0style0Text0.NodeType);
        Assert.Equal("...<!--[if IE]><style>...", dochtml0head0style0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("X", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeTitleWithTitleCommentInside()
    {
        var doc = (@"<title><!--<title></title>--></title>").ToHtmlDocument();

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

        var dochtml0head0title0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0title0.ChildNodes);
        Assert.Empty(dochtml0head0title0.Attributes);
        Assert.Equal("title", dochtml0head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0title0.NodeType);

        var dochtml0head0title0Text0 = dochtml0head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0title0Text0.NodeType);
        Assert.Equal("<!--<title>", dochtml0head0title0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("-->", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeTitleWronglyAndCorrectlyClosed()
    {
        var doc = (@"<title>&lt;/title></title>").ToHtmlDocument();

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

        var dochtml0head0title0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0title0.ChildNodes);
        Assert.Empty(dochtml0head0title0.Attributes);
        Assert.Equal("title", dochtml0head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0title0.NodeType);

        var dochtml0head0title0Text0 = dochtml0head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0title0Text0.NodeType);
        Assert.Equal("</title>", dochtml0head0title0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TreeTitleWronglyClosedWithLinkAndClosingHead()
    {
        var doc = (@"<title>foo/title><link></head><body>X").ToHtmlDocument();

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

        var dochtml0head0title0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0title0.ChildNodes);
        Assert.Empty(dochtml0head0title0.Attributes);
        Assert.Equal("title", dochtml0head0title0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0title0.NodeType);

        var dochtml0head0title0Text0 = dochtml0head0title0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0title0Text0.NodeType);
        Assert.Equal("foo/title><link></head><body>X", dochtml0head0title0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TreeNoScriptWithNoScriptCommentInside()
    {
        var source = @"<noscript><!--<noscript></noscript>--></noscript>";
        var config = Configuration.Default.WithScripting();
        var context = BrowsingContext.New(config);
        var parser = context.GetService<IHtmlParser>();
        var doc = parser.ParseDocument(source);

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

        var dochtml0head0noscript0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0noscript0.ChildNodes);
        Assert.Empty(dochtml0head0noscript0.Attributes);
        Assert.Equal("noscript", dochtml0head0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0noscript0.NodeType);

        var dochtml0head0noscript0Text0 = dochtml0head0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0noscript0Text0.NodeType);
        Assert.Equal("<!--<noscript>", dochtml0head0noscript0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("-->", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeNoScriptWithCommentAndClosingNoScriptInside()
    {
        var source = @"<noscript><!--</noscript>X<noscript>--></noscript>";
        var config = Configuration.Default.WithScripting();
        var context = BrowsingContext.New(config);
        var parser = context.GetService<IHtmlParser>();
        var doc = parser.ParseDocument(source);

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

        var dochtml0head0noscript0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0noscript0.ChildNodes);
        Assert.Empty(dochtml0head0noscript0.Attributes);
        Assert.Equal("noscript", dochtml0head0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0noscript0.NodeType);

        var dochtml0head0noscript0Text0 = dochtml0head0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0noscript0Text0.NodeType);
        Assert.Equal("<!--", dochtml0head0noscript0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Equal(2, dochtml0body1.ChildNodes.Length);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("X", dochtml0body1Text0.TextContent);

        var dochtml0body1noscript1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1noscript1.ChildNodes);
        Assert.Empty(dochtml0body1noscript1.Attributes);
        Assert.Equal("noscript", dochtml0body1noscript1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1noscript1.NodeType);

        var dochtml0body1noscript1Text0 = dochtml0body1noscript1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1noscript1Text0.NodeType);
        Assert.Equal("-->", dochtml0body1noscript1Text0.TextContent);
    }

    [Fact]
    public void TreeNoScriptWithIFrameInside()
    {
        var source = @"<noscript><iframe></noscript>X";
        var config = Configuration.Default.WithScripting();
        var context = BrowsingContext.New(config);
        var parser = context.GetService<IHtmlParser>();
        var doc = parser.ParseDocument(source);

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

        var dochtml0head0noscript0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0noscript0.ChildNodes);
        Assert.Empty(dochtml0head0noscript0.Attributes);
        Assert.Equal("noscript", dochtml0head0noscript0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0noscript0.NodeType);

        var dochtml0head0noscript0Text0 = dochtml0head0noscript0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0noscript0Text0.NodeType);
        Assert.Equal("<iframe>", dochtml0head0noscript0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("X", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeNoFramesWithNoFramesComment()
    {
        var doc = (@"<noframes><!--<noframes></noframes>--></noframes>").ToHtmlDocument();

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

        var dochtml0head0noframes0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0noframes0.ChildNodes);
        Assert.Empty(dochtml0head0noframes0.Attributes);
        Assert.Equal("noframes", dochtml0head0noframes0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0noframes0.NodeType);

        var dochtml0head0noframes0Text0 = dochtml0head0noframes0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0noframes0Text0.NodeType);
        Assert.Equal("<!--<noframes>", dochtml0head0noframes0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);

        var dochtml0body1Text0 = dochtml0body1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1Text0.NodeType);
        Assert.Equal("-->", dochtml0body1Text0.TextContent);
    }

    [Fact]
    public void TreeNoframesWithBodyAndScriptWithComment()
    {
        var doc = (@"<noframes><body><script><!--...</script></body></noframes></html>").ToHtmlDocument();

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

        var dochtml0head0noframes0 = dochtml0head0.ChildNodes[0] as Element;
        Assert.Single(dochtml0head0noframes0.ChildNodes);
        Assert.Empty(dochtml0head0noframes0.Attributes);
        Assert.Equal("noframes", dochtml0head0noframes0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0noframes0.NodeType);

        var dochtml0head0noframes0Text0 = dochtml0head0noframes0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0head0noframes0Text0.NodeType);
        Assert.Equal("<body><script><!--...</script></body>", dochtml0head0noframes0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(dochtml0body1.Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void TreeTextareaWithIllegalComment()
    {
        var doc = (@"<textarea><!--<textarea></textarea>--></textarea>").ToHtmlDocument();

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

        var dochtml0body1textarea0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1textarea0.ChildNodes);
        Assert.Empty(dochtml0body1textarea0.Attributes);
        Assert.Equal("textarea", dochtml0body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1textarea0.NodeType);

        var dochtml0body1textarea0Text0 = dochtml0body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1textarea0Text0.NodeType);
        Assert.Equal("<!--<textarea>", dochtml0body1textarea0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("-->", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void TreeTextareaWithLegalComment()
    {
        var doc = (@"<textarea>&lt;/textarea></textarea>").ToHtmlDocument();

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

        var dochtml0body1textarea0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1textarea0.ChildNodes);
        Assert.Empty(dochtml0body1textarea0.Attributes);
        Assert.Equal("textarea", dochtml0body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1textarea0.NodeType);

        var dochtml0body1textarea0Text0 = dochtml0body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1textarea0Text0.NodeType);
        Assert.Equal("</textarea>", dochtml0body1textarea0Text0.TextContent);
    }

    [Fact]
    public void TreeIFrameWithTextAndIFrameComment()
    {
        var doc = (@"<iframe><!--<iframe></iframe>--></iframe>").ToHtmlDocument();

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

        var dochtml0body1iframe0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1iframe0.ChildNodes);
        Assert.Empty(dochtml0body1iframe0.Attributes);
        Assert.Equal("iframe", dochtml0body1iframe0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1iframe0.NodeType);

        var dochtml0body1iframe0Text0 = dochtml0body1iframe0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1iframe0Text0.NodeType);
        Assert.Equal("<!--<iframe>", dochtml0body1iframe0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("-->", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void TreeIFrameWithTextAndXComment()
    {
        var doc = (@"<iframe>...<!--X->...<!--/X->...</iframe>").ToHtmlDocument();

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

        var dochtml0body1iframe0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1iframe0.ChildNodes);
        Assert.Empty(dochtml0body1iframe0.Attributes);
        Assert.Equal("iframe", dochtml0body1iframe0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1iframe0.NodeType);

        var dochtml0body1iframe0Text0 = dochtml0body1iframe0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1iframe0Text0.NodeType);
        Assert.Equal("...<!--X->...<!--/X->...", dochtml0body1iframe0Text0.TextContent);
    }

    [Fact]
    public void treeXmpWithComment()
    {
        var doc = (@"<xmp><!--<xmp></xmp>--></xmp>").ToHtmlDocument();

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

        var dochtml0body1xmp0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1xmp0.ChildNodes);
        Assert.Empty(dochtml0body1xmp0.Attributes);
        Assert.Equal("xmp", dochtml0body1xmp0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1xmp0.NodeType);

        var dochtml0body1xmp0Text0 = dochtml0body1xmp0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1xmp0Text0.NodeType);
        Assert.Equal("<!--<xmp>", dochtml0body1xmp0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("-->", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void TreeNoEmbedWithComments()
    {
        var doc = (@"<noembed><!--<noembed></noembed>--></noembed>").ToHtmlDocument();

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

        var dochtml0body1noembed0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1noembed0.ChildNodes);
        Assert.Empty(dochtml0body1noembed0.Attributes);
        Assert.Equal("noembed", dochtml0body1noembed0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1noembed0.NodeType);

        var dochtml0body1noembed0Text0 = dochtml0body1noembed0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1noembed0Text0.NodeType);
        Assert.Equal("<!--<noembed>", dochtml0body1noembed0Text0.TextContent);

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("-->", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void TreeTableWithNewLine()
    {
        var doc = (@"<!doctype html><table>
").ToHtmlDocument();

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

        var dochtml1body1table0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0.ChildNodes);
        Assert.Empty(dochtml1body1table0.Attributes);
        Assert.Equal("table", dochtml1body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0.NodeType);

        var dochtml1body1table0Text0 = dochtml1body1table0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1table0Text0.NodeType);
        Assert.Equal("\n", dochtml1body1table0Text0.TextContent);
    }

    [Fact]
    public void TreeSpanAndFontInMisnestedTableCell()
    {
        var doc = (@"<!doctype html><table><td><span><font></span><span>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml1body1table0tbody0tr0td0.ChildNodes.Length);
        Assert.Empty(dochtml1body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml1body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0.NodeType);

        var dochtml1body1table0tbody0tr0td0span0 = dochtml1body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0span0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0span0.Attributes);
        Assert.Equal("span", dochtml1body1table0tbody0tr0td0span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0span0.NodeType);

        var dochtml1body1table0tbody0tr0td0span0font0 = dochtml1body1table0tbody0tr0td0span0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table0tbody0tr0td0span0font0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0span0font0.Attributes);
        Assert.Equal("font", dochtml1body1table0tbody0tr0td0span0font0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0span0font0.NodeType);

        var dochtml1body1table0tbody0tr0td0font1 = dochtml1body1table0tbody0tr0td0.ChildNodes[1] as Element;
        Assert.Single(dochtml1body1table0tbody0tr0td0font1.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0font1.Attributes);
        Assert.Equal("font", dochtml1body1table0tbody0tr0td0font1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0font1.NodeType);

        var dochtml1body1table0tbody0tr0td0font1span0 = dochtml1body1table0tbody0tr0td0font1.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1table0tbody0tr0td0font1span0.ChildNodes);
        Assert.Empty(dochtml1body1table0tbody0tr0td0font1span0.Attributes);
        Assert.Equal("span", dochtml1body1table0tbody0tr0td0font1span0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table0tbody0tr0td0font1span0.NodeType);
    }

    [Fact]
    public void TreeTableInFormDoubleMisnested()
    {
        var doc = (@"<!doctype html><form><table></form><form></table></form>").ToHtmlDocument();

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

        var dochtml1body1form0 = dochtml1body1.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1form0.ChildNodes);
        Assert.Empty(dochtml1body1form0.Attributes);
        Assert.Equal("form", dochtml1body1form0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1form0.NodeType);

        var dochtml1body1form0table0 = dochtml1body1form0.ChildNodes[0] as Element;
        Assert.Single(dochtml1body1form0table0.ChildNodes);
        Assert.Empty(dochtml1body1form0table0.Attributes);
        Assert.Equal("table", dochtml1body1form0table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1form0table0.NodeType);

        var dochtml1body1form0table0form0 = dochtml1body1form0table0.ChildNodes[0] as Element;
        Assert.Empty(dochtml1body1form0table0form0.ChildNodes);
        Assert.Empty(dochtml1body1form0table0form0.Attributes);
        Assert.Equal("form", dochtml1body1form0table0form0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1form0table0form0.NodeType);
    }

    [Fact]
    public void PlaceStyleAfterHead()
    {
        var doc = (@"<head></head><style></style>").ToHtmlDocument();

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
        Assert.Empty(dochtml0head0style0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0style0).Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void PlaceScriptAfterHead()
    {
        var doc = (@"<head></head><script></script>").ToHtmlDocument();

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

        var dochtml0head0script0 = dochtml0head0.ChildNodes[0];
        Assert.Empty(dochtml0head0script0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0script0).Attributes);
        Assert.Equal("script", dochtml0head0script0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script0.NodeType);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void PlaceCommentAfterHeadAndStyleAfterHeadAndScriptAfterHead()
    {
        var doc = (@"<head></head><!-- --><style></style><!-- --><script></script>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(4, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Equal(2, dochtml0head0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0head0style0 = dochtml0head0.ChildNodes[0];
        Assert.Empty(dochtml0head0style0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0style0).Attributes);
        Assert.Equal("style", dochtml0head0style0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0style0.NodeType);

        var dochtml0head0script1 = dochtml0head0.ChildNodes[1];
        Assert.Empty(dochtml0head0script1.ChildNodes);
        Assert.Empty(((Element)dochtml0head0script1).Attributes);
        Assert.Equal("script", dochtml0head0script1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0script1.NodeType);

        var dochtml0Comment1 = dochtml0.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0Comment1.NodeType);
        Assert.Equal(@" ", dochtml0Comment1.TextContent);

        var dochtml0Comment2 = dochtml0.ChildNodes[2];
        Assert.Equal(NodeType.Comment, dochtml0Comment2.NodeType);
        Assert.Equal(@" ", dochtml0Comment2.TextContent);

        var dochtml0body3 = dochtml0.ChildNodes[3];
        Assert.Empty(dochtml0body3.ChildNodes);
        Assert.Empty(((Element)dochtml0body3).Attributes);
        Assert.Equal("body", dochtml0body3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body3.NodeType);

    }

    [Fact]
    public void PlaceCommentAndTextAfterHeadAndStyleAndScriptAfterHead()
    {
        var doc = (@"<head></head><!-- -->x<style></style><!-- --><script></script>").ToHtmlDocument();

        var dochtml0 = doc.ChildNodes[0];
        Assert.Equal(3, dochtml0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0).Attributes);
        Assert.Equal("html", dochtml0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0.NodeType);

        var dochtml0head0 = dochtml0.ChildNodes[0];
        Assert.Empty(dochtml0head0.ChildNodes);
        Assert.Empty(((Element)dochtml0head0).Attributes);
        Assert.Equal("head", dochtml0head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0head0.NodeType);

        var dochtml0Comment1 = dochtml0.ChildNodes[1];
        Assert.Equal(NodeType.Comment, dochtml0Comment1.NodeType);
        Assert.Equal(@" ", dochtml0Comment1.TextContent);

        var dochtml0body2 = dochtml0.ChildNodes[2];
        Assert.Equal(4, dochtml0body2.ChildNodes.Length);
        Assert.Empty(((Element)dochtml0body2).Attributes);
        Assert.Equal("body", dochtml0body2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body2.NodeType);

        var dochtml0body2Text0 = dochtml0body2.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body2Text0.NodeType);
        Assert.Equal("x", dochtml0body2Text0.TextContent);

        var dochtml0body2style1 = dochtml0body2.ChildNodes[1];
        Assert.Empty(dochtml0body2style1.ChildNodes);
        Assert.Empty(((Element)dochtml0body2style1).Attributes);
        Assert.Equal("style", dochtml0body2style1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body2style1.NodeType);

        var dochtml0body2Comment2 = dochtml0body2.ChildNodes[2];
        Assert.Equal(NodeType.Comment, dochtml0body2Comment2.NodeType);
        Assert.Equal(@" ", dochtml0body2Comment2.TextContent);

        var dochtml0body2script3 = dochtml0body2.ChildNodes[3];
        Assert.Empty(dochtml0body2script3.ChildNodes);
        Assert.Empty(((Element)dochtml0body2script3).Attributes);
        Assert.Equal("script", dochtml0body2script3.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body2script3.NodeType);
    }

    [Fact]
    public void SkipInitialNewlineInPreElement()
    {
        var doc = (@"<!DOCTYPE html><html><head></head><body><pre>
</pre></body></html>").ToHtmlDocument();

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0];
        Assert.Empty(dochtml1body1pre0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1pre0).Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);
    }

    [Fact]
    public void SkipInitialNewLineInPreElementWithText()
    {
        var doc = (@"<!DOCTYPE html><html><head></head><body><pre>
foo</pre></body></html>").ToHtmlDocument();

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1pre0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1pre0).Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1pre0Text0.TextContent);
    }

    [Fact]
    public void SkipInitialNewLineInPreElementWithTextThatStartsWithANewLine()
    {
        var doc = (@"<!DOCTYPE html><html><head></head><body><pre>

foo</pre></body></html>").ToHtmlDocument();

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1pre0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1pre0).Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("\nfoo", dochtml1body1pre0Text0.TextContent);
    }

    [Fact]
    public void SkipInitialNewLineInPreElementWithTextThatEndsWithANewLine()
    {
        var doc = (@"<!DOCTYPE html><html><head></head><body><pre>
foo
</pre></body></html>").ToHtmlDocument();

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1pre0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1pre0).Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("foo\n", dochtml1body1pre0Text0.TextContent);
    }

    [Fact]
    public void DontSkipAnythingInPreElementWithText()
    {
        var doc = (@"<!DOCTYPE html><html><head></head><body><pre>x</pre><span>
</span></body></html>").ToHtmlDocument();

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1pre0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1pre0).Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("x", dochtml1body1pre0Text0.TextContent);

        var dochtml1body1span1 = dochtml1body1.ChildNodes[1];
        Assert.Single(dochtml1body1span1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1span1).Attributes);
        Assert.Equal("span", dochtml1body1span1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1span1.NodeType);

        var dochtml1body1span1Text0 = dochtml1body1span1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1span1Text0.NodeType);
        Assert.Equal("\n", dochtml1body1span1Text0.TextContent);
    }

    [Fact]
    public void DontSkipAnythingInPreElementWithTextThatContainsALineBreak()
    {
        var doc = (@"<!DOCTYPE html><html><head></head><body><pre>x
y</pre></body></html>").ToHtmlDocument();

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1pre0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1pre0).Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("x\ny", dochtml1body1pre0Text0.TextContent);
    }

    [Fact]
    public void ClosePreElementWhenDivElementIsOpenedInside()
    {
        var doc = (@"<!DOCTYPE html><html><head></head><body><pre>x<div>
y</pre></body></html>").ToHtmlDocument();

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(2, dochtml1body1pre0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1body1pre0).Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("x", dochtml1body1pre0Text0.TextContent);

        var dochtml1body1pre0div1 = dochtml1body1pre0.ChildNodes[1];
        Assert.Single(dochtml1body1pre0div1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1pre0div1).Attributes);
        Assert.Equal("div", dochtml1body1pre0div1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0div1.NodeType);

        var dochtml1body1pre0div1Text0 = dochtml1body1pre0div1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0div1Text0.NodeType);
        Assert.Equal("\ny", dochtml1body1pre0div1Text0.TextContent);
    }

    [Fact]
    public void DoNotSkipFirstLineInPreElementWhenGeneratedViaEntities()
    {
        var doc = (@"<!DOCTYPE html><pre>&#x0a;&#x0a;A</pre>").ToHtmlDocument();

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

        var dochtml1body1pre0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1pre0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1pre0).Attributes);
        Assert.Equal("pre", dochtml1body1pre0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1pre0.NodeType);

        var dochtml1body1pre0Text0 = dochtml1body1pre0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1pre0Text0.NodeType);
        Assert.Equal("\nA", dochtml1body1pre0Text0.TextContent);
    }

    [Fact]
    public void ConvertUpperCaseTagsToLowerCaseTags()
    {
        var doc = (@"<!DOCTYPE html><HTML><META><HEAD></HEAD></HTML>").ToHtmlDocument();

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
        Assert.Single(dochtml1head0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0).Attributes);
        Assert.Equal("head", dochtml1head0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0.NodeType);

        var dochtml1head0meta0 = dochtml1head0.ChildNodes[0];
        Assert.Empty(dochtml1head0meta0.ChildNodes);
        Assert.Empty(((Element)dochtml1head0meta0).Attributes);
        Assert.Equal("meta", dochtml1head0meta0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1head0meta0.NodeType);

        var dochtml1body1 = dochtml1.ChildNodes[1];
        Assert.Empty(dochtml1body1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void ConvertMixedCaseTagsToLowerCaseTags()
    {
        var doc = (@"<!DOCTYPE html><HTML><HEAD><head></HEAD></HTML>").ToHtmlDocument();

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
        Assert.Empty(((Element)dochtml1body1).Attributes);
        Assert.Equal("body", dochtml1body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1.NodeType);
    }

    [Fact]
    public void SwitchToRawtextModeInTextareaElement()
    {
        var doc = (@"<textarea>foo<span>bar</span><i>baz").ToHtmlDocument();

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

        var dochtml0body1textarea0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1textarea0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1textarea0).Attributes);
        Assert.Equal("textarea", dochtml0body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1textarea0.NodeType);

        var dochtml0body1textarea0Text0 = dochtml0body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1textarea0Text0.NodeType);
        Assert.Equal("foo<span>bar</span><i>baz", dochtml0body1textarea0Text0.TextContent);
    }

    [Fact]
    public void SwitchToRawtextModeInTitleElement()
    {
        var doc = (@"<title>foo<span>bar</em><i>baz").ToHtmlDocument();

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
        Assert.Equal("foo<span>bar</em><i>baz", dochtml0head0title0Text0.TextContent);

        var dochtml0body1 = dochtml0.ChildNodes[1];
        Assert.Empty(dochtml0body1.ChildNodes);
        Assert.Empty(((Element)dochtml0body1).Attributes);
        Assert.Equal("body", dochtml0body1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1.NodeType);
    }

    [Fact]
    public void IgnoreInitialLineInTextareaElement()
    {
        var doc = (@"<!DOCTYPE html><textarea>
</textarea>").ToHtmlDocument();

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

        var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0];
        Assert.Empty(dochtml1body1textarea0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1textarea0).Attributes);
        Assert.Equal("textarea", dochtml1body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1textarea0.NodeType);
    }

    [Fact]
    public void IgnoreInitialLineInTextareaElementWithText()
    {
        var doc = (@"<!DOCTYPE html><textarea>
foo</textarea>").ToHtmlDocument();

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

        var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1textarea0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1textarea0).Attributes);
        Assert.Equal("textarea", dochtml1body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1textarea0.NodeType);

        var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
        Assert.Equal("foo", dochtml1body1textarea0Text0.TextContent);
    }

    [Fact]
    public void IgnoreInitialLineInTextareaElementWithNewLineAndText()
    {
        var doc = (@"<!DOCTYPE html><textarea>

foo</textarea>").ToHtmlDocument();

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

        var dochtml1body1textarea0 = dochtml1body1.ChildNodes[0];
        Assert.Single(dochtml1body1textarea0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1textarea0).Attributes);
        Assert.Equal("textarea", dochtml1body1textarea0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1textarea0.NodeType);

        var dochtml1body1textarea0Text0 = dochtml1body1textarea0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml1body1textarea0Text0.NodeType);
        Assert.Equal("\nfoo", dochtml1body1textarea0Text0.TextContent);
    }

    [Fact]
    public void GeneratedImpliedEndTagsForListItemsAndParagraphs()
    {
        var doc = (@"<!DOCTYPE html><html><head></head><body><ul><li><div><p><li></ul></body></html>").ToHtmlDocument();

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

        var dochtml1body1ul0 = dochtml1body1.ChildNodes[0];
        Assert.Equal(2, dochtml1body1ul0.ChildNodes.Length);
        Assert.Empty(((Element)dochtml1body1ul0).Attributes);
        Assert.Equal("ul", dochtml1body1ul0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1ul0.NodeType);

        var dochtml1body1ul0li0 = dochtml1body1ul0.ChildNodes[0];
        Assert.Single(dochtml1body1ul0li0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1ul0li0).Attributes);
        Assert.Equal("li", dochtml1body1ul0li0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1ul0li0.NodeType);

        var dochtml1body1ul0li0div0 = dochtml1body1ul0li0.ChildNodes[0];
        Assert.Single(dochtml1body1ul0li0div0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1ul0li0div0).Attributes);
        Assert.Equal("div", dochtml1body1ul0li0div0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1ul0li0div0.NodeType);

        var dochtml1body1ul0li0div0p0 = dochtml1body1ul0li0div0.ChildNodes[0];
        Assert.Empty(dochtml1body1ul0li0div0p0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1ul0li0div0p0).Attributes);
        Assert.Equal("p", dochtml1body1ul0li0div0p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1ul0li0div0p0.NodeType);

        var dochtml1body1ul0li1 = dochtml1body1ul0.ChildNodes[1];
        Assert.Empty(dochtml1body1ul0li1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1ul0li1).Attributes);
        Assert.Equal("li", dochtml1body1ul0li1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1ul0li1.NodeType);
    }

    [Fact]
    public void UseSelfClosingElementWithoutClosingSlash()
    {
        var doc = (@"<!doctype html><nobr><nobr><nobr>").ToHtmlDocument();

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

        var dochtml1body1nobr0 = dochtml1body1.ChildNodes[0];
        Assert.Empty(dochtml1body1nobr0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1nobr0).Attributes);
        Assert.Equal("nobr", dochtml1body1nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr0.NodeType);

        var dochtml1body1nobr1 = dochtml1body1.ChildNodes[1];
        Assert.Empty(dochtml1body1nobr1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1nobr1).Attributes);
        Assert.Equal("nobr", dochtml1body1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1.NodeType);

        var dochtml1body1nobr2 = dochtml1body1.ChildNodes[2];
        Assert.Empty(dochtml1body1nobr2.ChildNodes);
        Assert.Empty(((Element)dochtml1body1nobr2).Attributes);
        Assert.Equal("nobr", dochtml1body1nobr2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr2.NodeType);
    }

    [Fact]
    public void WronglyUseClosingTagForSelfClosingElement()
    {
        var doc = (@"<!doctype html><nobr><nobr></nobr><nobr>").ToHtmlDocument();

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

        var dochtml1body1nobr0 = dochtml1body1.ChildNodes[0];
        Assert.Empty(dochtml1body1nobr0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1nobr0).Attributes);
        Assert.Equal("nobr", dochtml1body1nobr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr0.NodeType);

        var dochtml1body1nobr1 = dochtml1body1.ChildNodes[1];
        Assert.Empty(dochtml1body1nobr1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1nobr1).Attributes);
        Assert.Equal("nobr", dochtml1body1nobr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr1.NodeType);

        var dochtml1body1nobr2 = dochtml1body1.ChildNodes[2];
        Assert.Empty(dochtml1body1nobr2.ChildNodes);
        Assert.Empty(((Element)dochtml1body1nobr2).Attributes);
        Assert.Equal("nobr", dochtml1body1nobr2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1nobr2.NodeType);
    }

    [Fact]
    public void GenerateImpliedEndTagForParagraphElementWithTableNoQuirksmode()
    {
        var doc = (@"<!doctype html><html><body><p><table></table></body></html>").ToHtmlDocument();

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
        Assert.Empty(dochtml1body1p0.ChildNodes);
        Assert.Empty(((Element)dochtml1body1p0).Attributes);
        Assert.Equal("p", dochtml1body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1p0.NodeType);

        var dochtml1body1table1 = dochtml1body1.ChildNodes[1];
        Assert.Empty(dochtml1body1table1.ChildNodes);
        Assert.Empty(((Element)dochtml1body1table1).Attributes);
        Assert.Equal("table", dochtml1body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml1body1table1.NodeType);
    }

    [Fact]
    public void DoNotGenerateImpliedEndTagForParagraphElementWithTableLimitedQuirksmode()
    {
        var doc = (@"<p><table></table>").ToHtmlDocument();

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

        var dochtml0body1p0 = dochtml0body1.ChildNodes[0];
        Assert.Single(dochtml0body1p0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1p0).Attributes);
        Assert.Equal("p", dochtml0body1p0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0.NodeType);

        var dochtml0body1p0table0 = dochtml0body1p0.ChildNodes[0];
        Assert.Empty(dochtml0body1p0table0.ChildNodes);
        Assert.Empty(((Element)dochtml0body1p0table0).Attributes);
        Assert.Equal("table", dochtml0body1p0table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p0table0.NodeType);
    }
}
