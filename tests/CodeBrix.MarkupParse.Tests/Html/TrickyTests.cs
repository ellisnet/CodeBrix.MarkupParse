using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Parser;
using Xunit;
using System;
using System.IO;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tricky01.dat
/// </summary>

public class TrickyTests
{
    [Fact]
    public void BoldAndNotBold()
    {
        var doc = (@"<b><p>Bold </b> Not bold</p>
Also not bold.").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(3, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodyb = dochtmlbody.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodyb.ChildNodes);
        Assert.Empty(dochtmlbodyb.Attributes);
        Assert.Equal("b", dochtmlbodyb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyb.NodeType);

        var dochtmlbodyp = dochtmlbody.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbodyp.ChildNodes.Length);
        Assert.Empty(dochtmlbodyp.Attributes);
        Assert.Equal("p", dochtmlbodyp.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyp.NodeType);

        var dochtmlbodypb = dochtmlbodyp.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodypb.ChildNodes);
        Assert.Empty(dochtmlbodypb.Attributes);
        Assert.Equal("b", dochtmlbodypb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypb.NodeType);

        var text1 = dochtmlbodypb.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("Bold ", text1.TextContent);

        var text2 = dochtmlbodyp.ChildNodes[1];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal(" Not bold", text2.TextContent);

        var text3 = dochtmlbody.ChildNodes[2];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("\nAlso not bold.", text3.TextContent);
    }

    [Fact]
    public void ItalicAndOrRed()
    {
        var doc = (@"<html>
<font color=red><i>Italic and Red<p>Italic and Red </font> Just italic.</p> Italic only.</i> Plain
<p>I should not be red. <font color=red>Red. <i>Italic and red.</p>
<p>Italic and red. </i> Red.</font> I should not be red.</p>
<b>Bold <i>Bold and italic</b> Only Italic </i> Plain").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(10, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodyfont1 = dochtmlbody.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodyfont1.ChildNodes);
        Assert.Single(dochtmlbodyfont1.Attributes);
        Assert.Equal("font", dochtmlbodyfont1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfont1.NodeType);
        Assert.Equal("red", dochtmlbodyfont1.Attributes.GetNamedItem("color").Value);

        var dochtmlbodyfonti1 = dochtmlbodyfont1.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodyfonti1.ChildNodes);
        Assert.Empty(dochtmlbodyfonti1.Attributes);
        Assert.Equal("i", dochtmlbodyfonti1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfonti1.NodeType);

        var text1 = dochtmlbodyfonti1.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal(@"Italic and Red", text1.TextContent);

        var dochtmlbodyi1 = dochtmlbody.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbodyi1.ChildNodes.Length);
        Assert.Empty(dochtmlbodyi1.Attributes);
        Assert.Equal("i", dochtmlbodyi1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyi1.NodeType);

        var dochtmlbodyip = dochtmlbodyi1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtmlbodyip.ChildNodes.Length);
        Assert.Empty(dochtmlbodyip.Attributes);
        Assert.Equal("p", dochtmlbodyip.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyip.NodeType);

        var dochtmlbodyipfont = dochtmlbodyip.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodyipfont.ChildNodes);
        Assert.Single(dochtmlbodyipfont.Attributes);
        Assert.Equal("font", dochtmlbodyipfont.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyipfont.NodeType);
        Assert.Equal("red", dochtmlbodyipfont.Attributes.GetNamedItem("color").Value);

        var text2 = dochtmlbodyipfont.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal(@"Italic and Red ", text2.TextContent);

        var dochtmlbodyfont2 = dochtmlbody.ChildNodes[4] as Element;
        Assert.Single(dochtmlbodyfont2.ChildNodes);
        Assert.Single(dochtmlbodyfont2.Attributes);
        Assert.Equal("font", dochtmlbodyfont2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfont2.NodeType);
        Assert.Equal("red", dochtmlbodyfont2.Attributes.GetNamedItem("color").Value);

        var dochtmlbodyfonti2 = dochtmlbodyfont2.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodyfonti2.ChildNodes);
        Assert.Empty(dochtmlbodyfonti2.Attributes);
        Assert.Equal("i", dochtmlbodyfonti2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfonti2.NodeType);

        var text3 = dochtmlbodyfonti2.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("\n", text3.TextContent);

        var dochtmlbodyp = dochtmlbody.ChildNodes[5] as Element;
        Assert.Equal(2, dochtmlbodyp.ChildNodes.Length);
        Assert.Empty(dochtmlbodyp.Attributes);
        Assert.Equal("p", dochtmlbodyp.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyp.NodeType);

        var dochtmlbodypfont = dochtmlbodyp.ChildNodes[0] as Element;
        Assert.Equal(2, dochtmlbodypfont.ChildNodes.Length);
        Assert.Single(dochtmlbodypfont.Attributes);
        Assert.Equal("font", dochtmlbodypfont.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypfont.NodeType);
        Assert.Equal("red", dochtmlbodypfont.Attributes.GetNamedItem("color").Value);

        var dochtmlbodypfonti = dochtmlbodypfont.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodypfonti.ChildNodes);
        Assert.Empty(dochtmlbodypfonti.Attributes);
        Assert.Equal("i", dochtmlbodypfonti.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypfonti.NodeType);

        var text4 = dochtmlbodypfonti.ChildNodes[0];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal(@"Italic and red. ", text4.TextContent);

        var text5 = dochtmlbodypfont.ChildNodes[1];
        Assert.Equal(NodeType.Text, text5.NodeType);
        Assert.Equal(@" Red.", text5.TextContent);

        var text6 = dochtmlbodyp.ChildNodes[1];
        Assert.Equal(NodeType.Text, text6.NodeType);
        Assert.Equal(@" I should not be red.", text6.TextContent);

        var text7 = dochtmlbody.ChildNodes[6];
        Assert.Equal(NodeType.Text, text7.NodeType);
        Assert.Equal("\n", text7.TextContent);

        var dochtmlbodyb = dochtmlbody.ChildNodes[7] as Element;
        Assert.Equal(2, dochtmlbodyb.ChildNodes.Length);
        Assert.Empty(dochtmlbodyb.Attributes);
        Assert.Equal("b", dochtmlbodyb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyb.NodeType);

        var text8 = dochtmlbodyb.ChildNodes[0];
        Assert.Equal(NodeType.Text, text8.NodeType);
        Assert.Equal(@"Bold ", text8.TextContent);

        var dochtmlbodybi = dochtmlbodyb.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodybi.ChildNodes);
        Assert.Empty(dochtmlbodybi.Attributes);
        Assert.Equal("i", dochtmlbodybi.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodybi.NodeType);

        var text9 = dochtmlbodybi.ChildNodes[0];
        Assert.Equal(NodeType.Text, text9.NodeType);
        Assert.Equal(@"Bold and italic", text9.TextContent);

        var dochtmlbodyi3 = dochtmlbody.ChildNodes[8] as Element;
        Assert.Single(dochtmlbodyi3.ChildNodes);
        Assert.Empty(dochtmlbodyi3.Attributes);
        Assert.Equal("i", dochtmlbodyi3.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyi3.NodeType);

        var text10 = dochtmlbodyi3.ChildNodes[0];
        Assert.Equal(NodeType.Text, text10.NodeType);
        Assert.Equal(@" Only Italic ", text10.TextContent);

        var text11 = dochtmlbody.ChildNodes[9];
        Assert.Equal(NodeType.Text, text11.NodeType);
        Assert.Equal(@" Plain", text11.TextContent);
    }

    [Fact]
    public void FormattingParagraphs()
    {
        var doc = (@"<html><body>
<p><font size=""7"">First paragraph.</p>
<p>Second paragraph.</p></font>
<b><p><i>Bold and Italic</b> Italic</p>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(6, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var text1 = dochtmlbody.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("\n", text1.TextContent);

        var dochtmlbodyp1 = dochtmlbody.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodyp1.ChildNodes);
        Assert.Empty(dochtmlbodyp1.Attributes);
        Assert.Equal("p", dochtmlbodyp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyp1.NodeType);

        var dochtmlbodypfont = dochtmlbodyp1.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodypfont.ChildNodes);
        Assert.Single(dochtmlbodypfont.Attributes);
        Assert.Equal("font", dochtmlbodypfont.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypfont.NodeType);
        Assert.Equal("7", dochtmlbodypfont.Attributes.GetNamedItem("size").Value);

        var text2 = dochtmlbodypfont.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal(@"First paragraph.", text2.TextContent);

        var dochtmlbodyfont = dochtmlbody.ChildNodes[2] as Element;
        Assert.Equal(2, dochtmlbodyfont.ChildNodes.Length);
        Assert.Single(dochtmlbodyfont.Attributes);
        Assert.Equal("font", dochtmlbodyfont.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfont.NodeType);
        Assert.Equal("7", dochtmlbodyfont.Attributes.GetNamedItem("size").Value);

        var text3 = dochtmlbodyfont.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("\n", text3.TextContent);

        var dochtmlbodyfontp = dochtmlbodyfont.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodyfontp.ChildNodes);
        Assert.Empty(dochtmlbodyfontp.Attributes);
        Assert.Equal("p", dochtmlbodyfontp.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfontp.NodeType);

        var text4 = dochtmlbodyfontp.ChildNodes[0];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal(@"Second paragraph.", text4.TextContent);

        var text5 = dochtmlbody.ChildNodes[3];
        Assert.Equal(NodeType.Text, text5.NodeType);
        Assert.Equal("\n", text5.TextContent);

        var dochtmlbodyb = dochtmlbody.ChildNodes[4] as Element;
        Assert.Empty(dochtmlbodyb.ChildNodes);
        Assert.Empty(dochtmlbodyb.Attributes);
        Assert.Equal("b", dochtmlbodyb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyb.NodeType);

        var dochtmlbodyp2 = dochtmlbody.ChildNodes[5] as Element;
        Assert.Equal(2, dochtmlbodyp2.ChildNodes.Length);
        Assert.Empty(dochtmlbodyp2.Attributes);
        Assert.Equal("p", dochtmlbodyp2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyp2.NodeType);

        var dochtmlbodypb = dochtmlbodyp2.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodypb.ChildNodes);
        Assert.Empty(dochtmlbodypb.Attributes);
        Assert.Equal("b", dochtmlbodypb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypb.NodeType);

        var dochtmlbodypbi = dochtmlbodypb.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodypbi.ChildNodes);
        Assert.Empty(dochtmlbodypbi.Attributes);
        Assert.Equal("i", dochtmlbodypbi.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypbi.NodeType);

        var text6 = dochtmlbodypbi.ChildNodes[0];
        Assert.Equal(NodeType.Text, text6.NodeType);
        Assert.Equal(@"Bold and Italic", text6.TextContent);

        var dochtmlbodypi = dochtmlbodyp2.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodypi.ChildNodes);
        Assert.Empty(dochtmlbodypi.Attributes);
        Assert.Equal("i", dochtmlbodypi.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypi.NodeType);

        var text7 = dochtmlbodypi.ChildNodes[0];
        Assert.Equal(NodeType.Text, text7.NodeType);
        Assert.Equal(@" Italic", text7.TextContent);
    }

    [Fact]
    public void DefinitionListWithFormatting()
    {
        var doc = (@"<html>
<dl>
<dt><b>Boo
<dd>Goo?
</dl>
</html>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodydl = dochtmlbody.ChildNodes[0] as Element;
        Assert.Equal(3, dochtmlbodydl.ChildNodes.Length);
        Assert.Empty(dochtmlbodydl.Attributes);
        Assert.Equal("dl", dochtmlbodydl.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydl.NodeType);

        var text1 = dochtmlbodydl.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("\n", text1.TextContent);

        var dochtmlbodydldt = dochtmlbodydl.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodydldt.ChildNodes);
        Assert.Empty(dochtmlbodydldt.Attributes);
        Assert.Equal("dt", dochtmlbodydldt.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydldt.NodeType);

        var dochtmlbodydldtb = dochtmlbodydldt.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodydldtb.ChildNodes);
        Assert.Empty(dochtmlbodydldtb.Attributes);
        Assert.Equal("b", dochtmlbodydldtb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydldtb.NodeType);

        var text2 = dochtmlbodydldtb.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal("Boo\n", text2.TextContent);

        var dochtmlbodydldd = dochtmlbodydl.ChildNodes[2] as Element;
        Assert.Single(dochtmlbodydldd.ChildNodes);
        Assert.Empty(dochtmlbodydldd.Attributes);
        Assert.Equal("dd", dochtmlbodydldd.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydldd.NodeType);

        var dochtmlbodydlddb = dochtmlbodydldd.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodydlddb.ChildNodes);
        Assert.Empty(dochtmlbodydlddb.Attributes);
        Assert.Equal("b", dochtmlbodydlddb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydlddb.NodeType);

        var text3 = dochtmlbodydlddb.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("Goo?\n", text3.TextContent);

        var dochtmlbodyb = dochtmlbody.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodyb.ChildNodes);
        Assert.Empty(dochtmlbodyb.Attributes);
        Assert.Equal("b", dochtmlbodyb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyb.NodeType);

        var text4 = dochtmlbodyb.ChildNodes[0];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal("\n", text4.TextContent);
    }

    [Fact]
    public void HelloWorldWithSomeDivs()
    {
        var doc = ("<html><body>\n<label><a><div>Hello<div>World</div></a></label>  \n</body></html>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var text1 = dochtmlbody.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("\n", text1.TextContent);

        var dochtmlbodylabel = dochtmlbody.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbodylabel.ChildNodes.Length);
        Assert.Empty(dochtmlbodylabel.Attributes);
        Assert.Equal("label", dochtmlbodylabel.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodylabel.NodeType);

        var dochtmlbodylabela = dochtmlbodylabel.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodylabela.ChildNodes);
        Assert.Empty(dochtmlbodylabela.Attributes);
        Assert.Equal("a", dochtmlbodylabela.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodylabela.NodeType);

        var dochtmlbodylabeldiv = dochtmlbodylabel.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbodylabeldiv.ChildNodes.Length);
        Assert.Empty(dochtmlbodylabeldiv.Attributes);
        Assert.Equal("div", dochtmlbodylabeldiv.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodylabeldiv.NodeType);

        var dochtmlbodylabeldiva = dochtmlbodylabeldiv.ChildNodes[0] as Element;
        Assert.Equal(2, dochtmlbodylabeldiva.ChildNodes.Length);
        Assert.Empty(dochtmlbodylabeldiva.Attributes);
        Assert.Equal("a", dochtmlbodylabeldiva.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodylabeldiva.NodeType);

        var text2 = dochtmlbodylabeldiva.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal(@"Hello", text2.TextContent);

        var dochtmlbodylabeldivadiv = dochtmlbodylabeldiva.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodylabeldivadiv.ChildNodes);
        Assert.Empty(dochtmlbodylabeldivadiv.Attributes);
        Assert.Equal("div", dochtmlbodylabeldivadiv.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodylabeldivadiv.NodeType);

        var text3 = dochtmlbodylabeldivadiv.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal(@"World", text3.TextContent);

        var text4 = dochtmlbodylabeldiv.ChildNodes[1];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal("  \n", text4.TextContent);
    }

    [Fact]
    public void TableFormattingGoneWild()
    {
        var doc = (@"<table><center> <font>a</center> <img> <tr><td> </td> </tr> </table>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(3, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodycenter = dochtmlbody.ChildNodes[0] as Element;
        Assert.Equal(2, dochtmlbodycenter.ChildNodes.Length);
        Assert.Empty(dochtmlbodycenter.Attributes);
        Assert.Equal("center", dochtmlbodycenter.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodycenter.NodeType);

        var text1 = dochtmlbodycenter.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal(@" ", text1.TextContent);

        var dochtmlbodycenterfont = dochtmlbodycenter.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodycenterfont.ChildNodes);
        Assert.Empty(dochtmlbodycenterfont.Attributes);
        Assert.Equal("font", dochtmlbodycenterfont.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodycenterfont.NodeType);

        var text2 = dochtmlbodycenterfont.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal(@"a", text2.TextContent);

        var dochtmlbodyfont = dochtmlbody.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbodyfont.ChildNodes.Length);
        Assert.Empty(dochtmlbodyfont.Attributes);
        Assert.Equal("font", dochtmlbodyfont.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfont.NodeType);

        var dochtmlbodyfontimg = dochtmlbodyfont.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodyfontimg.ChildNodes);
        Assert.Empty(dochtmlbodyfontimg.Attributes);
        Assert.Equal("img", dochtmlbodyfontimg.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfontimg.NodeType);

        var text3 = dochtmlbodyfont.ChildNodes[1];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal(@" ", text3.TextContent);

        var dochtmlbodytable = dochtmlbody.ChildNodes[2] as Element;
        Assert.Equal(2, dochtmlbodytable.ChildNodes.Length);
        Assert.Empty(dochtmlbodytable.Attributes);
        Assert.Equal("table", dochtmlbodytable.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytable.NodeType);

        var text4 = dochtmlbodytable.ChildNodes[0];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal(@" ", text4.TextContent);

        var dochtmlbodytabletbody = dochtmlbodytable.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbodytabletbody.ChildNodes.Length);
        Assert.Empty(dochtmlbodytabletbody.Attributes);
        Assert.Equal("tbody", dochtmlbodytabletbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbody.NodeType);

        var dochtmlbodytabletbodytr = dochtmlbodytabletbody.ChildNodes[0] as Element;
        Assert.Equal(2, dochtmlbodytabletbodytr.ChildNodes.Length);
        Assert.Empty(dochtmlbodytabletbodytr.Attributes);
        Assert.Equal("tr", dochtmlbodytabletbodytr.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbodytr.NodeType);

        var dochtmlbodytabletbodytrtd = dochtmlbodytabletbodytr.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodytabletbodytrtd.ChildNodes);
        Assert.Empty(dochtmlbodytabletbodytrtd.Attributes);
        Assert.Equal("td", dochtmlbodytabletbodytrtd.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbodytrtd.NodeType);

        var text5 = dochtmlbodytabletbodytrtd.ChildNodes[0];
        Assert.Equal(NodeType.Text, text5.NodeType);
        Assert.Equal(@" ", text5.TextContent);

        var text6 = dochtmlbodytabletbodytr.ChildNodes[1];
        Assert.Equal(NodeType.Text, text6.NodeType);
        Assert.Equal(@" ", text6.TextContent);

        var text7 = dochtmlbodytabletbody.ChildNodes[1];
        Assert.Equal(NodeType.Text, text7.NodeType);
        Assert.Equal(@" ", text7.TextContent);
    }

    [Fact]
    public void YouShouldSeeThisText()
    {
        var doc = (@"<table><tr><p><a><p>You should see this text.").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(3, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodyp1 = dochtmlbody.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodyp1.ChildNodes);
        Assert.Empty(dochtmlbodyp1.Attributes);
        Assert.Equal("p", dochtmlbodyp1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyp1.NodeType);

        var dochtmlbodypa1 = dochtmlbodyp1.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodypa1.ChildNodes);
        Assert.Empty(dochtmlbodypa1.Attributes);
        Assert.Equal("a", dochtmlbodypa1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypa1.NodeType);

        var dochtmlbodyp2 = dochtmlbody.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodyp2.ChildNodes);
        Assert.Empty(dochtmlbodyp2.Attributes);
        Assert.Equal("p", dochtmlbodyp2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyp2.NodeType);

        var dochtmlbodypa2 = dochtmlbodyp2.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodypa2.ChildNodes);
        Assert.Empty(dochtmlbodypa2.Attributes);
        Assert.Equal("a", dochtmlbodypa2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodypa2.NodeType);

        var text1 = dochtmlbodypa2.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal(@"You should see this text.", text1.TextContent);

        var dochtmlbodytable = dochtmlbody.ChildNodes[2] as Element;
        Assert.Single(dochtmlbodytable.ChildNodes);
        Assert.Empty(dochtmlbodytable.Attributes);
        Assert.Equal("table", dochtmlbodytable.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytable.NodeType);

        var dochtmlbodytabletbody = dochtmlbodytable.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodytabletbody.ChildNodes);
        Assert.Empty(dochtmlbodytabletbody.Attributes);
        Assert.Equal("tbody", dochtmlbodytabletbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbody.NodeType);

        var dochtmlbodytabletbodytr = dochtmlbodytabletbody.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodytabletbodytr.ChildNodes);
        Assert.Empty(dochtmlbodytabletbodytr.Attributes);
        Assert.Equal("tr", dochtmlbodytabletbodytr.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbodytr.NodeType);

    }

    [Fact]
    public void InsanelyBadlyNestedTagSequence()
    {
        var doc = (@"<TABLE>
<TR>
<CENTER><CENTER><TD></TD></TR><TR>
<FONT>
<TABLE><tr></tr></TABLE>
</P>
<a></font><font></a>
This page contains an insanely badly-nested tag sequence.").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(7, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var dochtmlbodycenter = dochtmlbody.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodycenter.ChildNodes);
        Assert.Empty(dochtmlbodycenter.Attributes);
        Assert.Equal("center", dochtmlbodycenter.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodycenter.NodeType);

        var dochtmlbodycentercenter = dochtmlbodycenter.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodycentercenter.ChildNodes);
        Assert.Empty(dochtmlbodycentercenter.Attributes);
        Assert.Equal("center", dochtmlbodycentercenter.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodycentercenter.NodeType);

        var dochtmlbodyfont = dochtmlbody.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodyfont.ChildNodes);
        Assert.Empty(dochtmlbodyfont.Attributes);
        Assert.Equal("font", dochtmlbodyfont.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfont.NodeType);

        var text1 = dochtmlbodyfont.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("\n", text1.TextContent);

        var dochtmlbodytable = dochtmlbody.ChildNodes[2] as Element;
        Assert.Equal(2, dochtmlbodytable.ChildNodes.Length);
        Assert.Empty(dochtmlbodytable.Attributes);
        Assert.Equal("table", dochtmlbodytable.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytable.NodeType);

        var text2 = dochtmlbodytable.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal("\n", text2.TextContent);

        var dochtmlbodytabletbody1 = dochtmlbodytable.ChildNodes[1] as Element;
        Assert.Equal(2, dochtmlbodytabletbody1.ChildNodes.Length);
        Assert.Empty(dochtmlbodytabletbody1.Attributes);
        Assert.Equal("tbody", dochtmlbodytabletbody1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbody1.NodeType);

        var dochtmlbodytabletbodytr1 = dochtmlbodytabletbody1.ChildNodes[0] as Element;
        Assert.Equal(2, dochtmlbodytabletbodytr1.ChildNodes.Length);
        Assert.Empty(dochtmlbodytabletbodytr1.Attributes);
        Assert.Equal("tr", dochtmlbodytabletbodytr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbodytr1.NodeType);

        var text3 = dochtmlbodytabletbodytr1.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("\n", text3.TextContent);

        var dochtmlbodytabletbodytrtd = dochtmlbodytabletbodytr1.ChildNodes[1] as Element;
        Assert.Empty(dochtmlbodytabletbodytrtd.ChildNodes);
        Assert.Empty(dochtmlbodytabletbodytrtd.Attributes);
        Assert.Equal("td", dochtmlbodytabletbodytrtd.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbodytrtd.NodeType);

        var dochtmlbodytabletbodytr2 = dochtmlbodytabletbody1.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodytabletbodytr2.ChildNodes);
        Assert.Empty(dochtmlbodytabletbodytr2.Attributes);
        Assert.Equal("tr", dochtmlbodytabletbodytr2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbodytr2.NodeType);

        var text4 = dochtmlbodytabletbodytr2.ChildNodes[0];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal("\n", text4.TextContent);

        var dochtmlbodytable2 = dochtmlbody.ChildNodes[3] as Element;
        Assert.Single(dochtmlbodytable2.ChildNodes);
        Assert.Empty(dochtmlbodytable2.Attributes);
        Assert.Equal("table", dochtmlbodytable2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytable2.NodeType);

        var dochtmlbodytabletbody = dochtmlbodytable2.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodytabletbody.ChildNodes);
        Assert.Empty(dochtmlbodytabletbody.Attributes);
        Assert.Equal("tbody", dochtmlbodytabletbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbody.NodeType);

        var dochtmlbodytabletbodytr = dochtmlbodytabletbody.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodytabletbodytr.ChildNodes);
        Assert.Empty(dochtmlbodytabletbodytr.Attributes);
        Assert.Equal("tr", dochtmlbodytabletbodytr.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodytabletbodytr.NodeType);

        var dochtmlbodyfont1 = dochtmlbody.ChildNodes[4] as Element;
        Assert.Equal(4, dochtmlbodyfont1.ChildNodes.Length);
        Assert.Empty(dochtmlbodyfont1.Attributes);
        Assert.Equal("font", dochtmlbodyfont1.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfont1.NodeType);

        var text5 = dochtmlbodyfont1.ChildNodes[0];
        Assert.Equal(NodeType.Text, text5.NodeType);
        Assert.Equal("\n", text5.TextContent);

        var dochtmlbodyfontp = dochtmlbodyfont1.ChildNodes[1] as Element;
        Assert.Empty(dochtmlbodyfontp.ChildNodes);
        Assert.Empty(dochtmlbodyfontp.Attributes);
        Assert.Equal("p", dochtmlbodyfontp.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfontp.NodeType);

        var text6 = dochtmlbodyfont1.ChildNodes[2];
        Assert.Equal(NodeType.Text, text6.NodeType);
        Assert.Equal("\n", text6.TextContent);

        var dochtmlbodyfonta = dochtmlbodyfont1.ChildNodes[3] as Element;
        Assert.Empty(dochtmlbodyfonta.ChildNodes);
        Assert.Empty(dochtmlbodyfonta.Attributes);
        Assert.Equal("a", dochtmlbodyfonta.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfonta.NodeType);

        var dochtmlbodya = dochtmlbody.ChildNodes[5] as Element;
        Assert.Single(dochtmlbodya.ChildNodes);
        Assert.Empty(dochtmlbodya.Attributes);
        Assert.Equal("a", dochtmlbodya.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodya.NodeType);

        var dochtmlbodyafont = dochtmlbodya.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodyafont.ChildNodes);
        Assert.Empty(dochtmlbodyafont.Attributes);
        Assert.Equal("font", dochtmlbodyafont.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyafont.NodeType);

        var dochtmlbodyfont2 = dochtmlbody.ChildNodes[6] as Element;
        Assert.Single(dochtmlbodyfont2.ChildNodes);
        Assert.Empty(dochtmlbodyfont2.Attributes);
        Assert.Equal("font", dochtmlbodyfont2.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyfont2.NodeType);

        var text7 = dochtmlbodyfont2.ChildNodes[0];
        Assert.Equal(NodeType.Text, text7.NodeType);
        Assert.Equal("\nThis page contains an insanely badly-nested tag sequence.", text7.TextContent);
    }

    [Fact]
    public void ImplicitlyClosingDivs()
    {
        var doc = (@"<html>
<body>
<b><nobr><div>This text is in a div inside a nobr</nobr>More text that should not be in the nobr, i.e., the
nobr should have closed the div inside it implicitly. </b><pre>A pre tag outside everything else.</pre>
</body>
</html>").ToHtmlDocument();

        var dochtml = doc.ChildNodes[0] as Element;
        Assert.Equal(2, dochtml.ChildNodes.Length);
        Assert.Empty(dochtml.Attributes);
        Assert.Equal("html", dochtml.GetTagName());
        Assert.Equal(NodeType.Element, dochtml.NodeType);

        var dochtmlhead = dochtml.ChildNodes[0] as Element;
        Assert.Empty(dochtmlhead.ChildNodes);
        Assert.Empty(dochtmlhead.Attributes);
        Assert.Equal("head", dochtmlhead.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlhead.NodeType);

        var dochtmlbody = dochtml.ChildNodes[1] as Element;
        Assert.Equal(3, dochtmlbody.ChildNodes.Length);
        Assert.Empty(dochtmlbody.Attributes);
        Assert.Equal("body", dochtmlbody.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbody.NodeType);

        var text1 = dochtmlbody.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("\n", text1.TextContent);

        var dochtmlbodyb = dochtmlbody.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodyb.ChildNodes);
        Assert.Empty(dochtmlbodyb.Attributes);
        Assert.Equal("b", dochtmlbodyb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodyb.NodeType);

        var dochtmlbodybnobr = dochtmlbodyb.ChildNodes[0] as Element;
        Assert.Empty(dochtmlbodybnobr.ChildNodes);
        Assert.Empty(dochtmlbodybnobr.Attributes);
        Assert.Equal("nobr", dochtmlbodybnobr.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodybnobr.NodeType);

        var dochtmlbodydiv = dochtmlbody.ChildNodes[2] as Element;
        Assert.Equal(3, dochtmlbodydiv.ChildNodes.Length);
        Assert.Empty(dochtmlbodydiv.Attributes);
        Assert.Equal("div", dochtmlbodydiv.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydiv.NodeType);

        var dochtmlbodydivb = dochtmlbodydiv.ChildNodes[0] as Element;
        Assert.Equal(2, dochtmlbodydivb.ChildNodes.Length);
        Assert.Empty(dochtmlbodydivb.Attributes);
        Assert.Equal("b", dochtmlbodydivb.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydivb.NodeType);

        var dochtmlbodydivbnobr = dochtmlbodydivb.ChildNodes[0] as Element;
        Assert.Single(dochtmlbodydivbnobr.ChildNodes);
        Assert.Empty(dochtmlbodydivbnobr.Attributes);
        Assert.Equal("nobr", dochtmlbodydivbnobr.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydivbnobr.NodeType);

        var text2 = dochtmlbodydivbnobr.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal(@"This text is in a div inside a nobr", text2.TextContent);

        var text3 = dochtmlbodydivb.ChildNodes[1];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("More text that should not be in the nobr, i.e., the\nnobr should have closed the div inside it implicitly. ", text3.TextContent);

        var dochtmlbodydivpre = dochtmlbodydiv.ChildNodes[1] as Element;
        Assert.Single(dochtmlbodydivpre.ChildNodes);
        Assert.Empty(dochtmlbodydivpre.Attributes);
        Assert.Equal("pre", dochtmlbodydivpre.GetTagName());
        Assert.Equal(NodeType.Element, dochtmlbodydivpre.NodeType);

        var text4 = dochtmlbodydivpre.ChildNodes[0];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal(@"A pre tag outside everything else.", text4.TextContent);

        var text5 = dochtmlbodydiv.ChildNodes[2];
        Assert.Equal(NodeType.Text, text5.NodeType);
        Assert.Equal("\n\n", text5.TextContent);
    }

    [Fact]
    public void HtmlDomConsturctionFromBytesOnlyZerosLeadsToInfiniteLoop()
    {
        var bs = new byte[5509];

        using var memoryStream = new MemoryStream(bs, false);
        var document = memoryStream.ToHtmlDocument();
        Assert.NotNull(document);
    }

    [Fact]
    public void SvgDoctypeWithIncompleteTemplateTagShouldNotPopEmptyStack_Issue735()
    {
        var source = @"<svg><!DOCTYPE html><<template>html><desc><template>><p>p</p></body></html>";
        var document = source.ToHtmlDocument();
        Assert.NotNull(document);
        Assert.Equal("<html><head></head><body><svg>&lt;<template>html&gt;<desc><template>&gt;<p>p</p></template></desc></template></svg></body></html>", document.ToHtml());
    }

    [Fact]
    public void SvgDoctypeWithDoubleTemplateTagShouldNotPopEmptyStack_Issue735()
    {
        var source = @"<svg><!DOCTYPE html><html><template><desc><template>><p>p</p></body></html>";
        var document = source.ToHtmlDocument();
        Assert.NotNull(document);
        Assert.Equal("<html><head></head><body><svg><html><template><desc><template>&gt;<p>p</p></template></desc></template></html></svg></body></html>", document.ToHtml());
    }

    [Fact]
    public void SvgDoctypeWithMultiOpenTemplateTagShouldNotPopEmptyStack_Issue735()
    {
        var source = @"<svg><!DOCTYPE html><<<template>tml><desc><template>><p>p</p></body></html>";
        var document = source.ToHtmlDocument();
        Assert.NotNull(document);
        Assert.Equal("<html><head></head><body><svg>&lt;&lt;<template>tml&gt;<desc><template>&gt;<p>p</p></template></desc></template></svg></body></html>", document.ToHtml());
    }

    [Fact]
    public void SvgDoctypeWithFramesetAndDoubleTemplateShouldNotPopEmptyStack_Issue735()
    {
        var source = @"<svg><!DOCTYPE html><<frameset>h<template>tml><desc><template>><p>p</p></body></html>";
        var document = source.ToHtmlDocument();
        Assert.NotNull(document);
        Assert.Equal("<html><head></head><body><svg>&lt;<frameset>h<template>tml&gt;<desc><template>&gt;<p>p</p></template></desc></template></frameset></svg></body></html>", document.ToHtml());
    }

    [Fact]
    public void SvgDoctypeWithDoubleTemplateAndPreShouldNotPopEmptyStack_Issue735()
    {
        var source = @"<svg><!DOCTYPE html><template>>html><desc><template>><p>p</p></body></html><pre>";
        var document = source.ToHtmlDocument();
        Assert.NotNull(document);
        Assert.Equal("<html><head></head><body><svg><template>&gt;html&gt;<desc><template>&gt;<p>p</p><pre></pre></template></desc></template></svg></body></html>", document.ToHtml());
    }

    // [Fact]
    // public void HeisenbergAlgorithmShouldNotBeOutOfBounds_Issue893()
    // {
    //     var content = Assets.GetManifestResourceString("Html.Heisenberg.Bug.txt");
    //     var document = content.ToHtmlDocument();
    //     Assert.NotNull(document);
    // }

    [Fact]
    public void AttributeValuesWithAmpersandAndUnderscoreAreOkay_Issue902()
    {
        var document = new HtmlParser(new HtmlParserOptions
        {
            IsScripting = false,
            IsStrictMode = true,
            IsEmbedded = false
        }).ParseDocument("<!DOCTYPE html><a href=\"https://test.de/?foo&_\"></a>");
        Assert.NotNull(document);
    }

    [Fact]
    public void StackEmptyShouldNotAppearWithTemplate_Issue1176()
    {
        var html = "<svg><template><title><v></temPlate>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<svg><template><title><v></v></title></template></svg>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableMenuShouldApplyHeisenbergCorrectly_Issue1179()
    {
        var html = "<table><a><menu>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><menu></menu></a><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableMenuClosedAnchorShouldApplyHeisenbergCorrectly_Issue1179()
    {
        var html = "<table><a><menu></a><nobr>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a></a><menu><a></a><nobr></nobr></menu><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableMenuTemplateShouldApplyHeisenbergCorrectly_Issue1179()
    {
        var html = "<table><a><menu><svg><template></a><nobr>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a></a><menu><a><svg><template></template></svg></a><nobr></nobr></menu><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableMenuTemplateShouldNotHang_Issue1179()
    {
        var html = "<table><a><menu><svg><template></a><nobr><p><nobr>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a></a><menu><a><svg><template></template></svg></a><nobr></nobr><p><nobr></nobr><nobr></nobr></p></menu><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableMainTemplateShouldNotHang_Issue1179()
    {
        var html = "<table><a><main><svg><template></a><a><main><a>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a></a><main><a><svg><template></template></svg></a><a></a><main><a></a><a></a></main></main><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableAnchorDivShouldNotHang_Issue1180()
    {
        var html = "<table><A><div><tr><A><s><object><svg><div></object></object><A>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><div></div></a><a><s><object><svg></svg><div></div></object></s></a><s><a></a></s><table><tbody><tr></tr></tbody></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableAnchorTemplateUntilAnchorShouldNotHang_Issue1180()
    {
        var html = "<table><A><template><tr><A>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><template><tr></tr><a></a></template></a><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableAnchorTemplateUntilStrikeShouldNotHang_Issue1180()
    {
        var html = "<table><A><template><tr><A><s>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><template><tr></tr><a><s></s></a></template></a><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableAnchorTemplateUntilObjectShouldNotHang_Issue1180()
    {
        var html = "<table><A><template><tr><A><s><object>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><template><tr></tr><a><s><object></object></s></a></template></a><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableAnchorTemplateUntilSvgShouldNotHang_Issue1180()
    {
        var html = "<table><A><template><tr><A><s><object><svg>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><template><tr></tr><a><s><object><svg></svg></object></s></a></template></a><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableAnchorTemplateUntilSecondTemplateShouldNotHang_Issue1180()
    {
        var html = "<table><A><template><tr><A><s><object><svg><template>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><template><tr></tr><a><s><object><svg><template></template></svg></object></s></a></template></a><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableAnchorTemplateUntilClosingObjectShouldNotHang_Issue1180()
    {
        var html = "<table><A><template><tr><A><s><object><svg><template></object><A>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><template><tr></tr><a><s><object><svg><template></template></svg></object></s></a><s><a></a></s></template></a><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableAnchorTemplateShouldNotHang_Issue1180()
    {
        var html = "<table><A><template><tr><A><s><object><svg><template></object></object><A>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        Assert.Equal("<a><template><tr></tr><a><s><object><svg><template></template></svg></object></s></a><s><a></a></s></template></a><table></table>", document.Body.InnerHtml);
    }

    [Fact]
    public void TemplateTableRowTemplateShouldNotHang_Issue1180()
    {
        var html = "<template><tr><A><template><tr><A><object><svg><template></object></object><e><A>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        // Note: Mozilla Firefox has this one wrong ("<br>"); a bug should be filed
        Assert.Equal("", document.Body.InnerHtml);
    }

    [Fact]
    public void TableCaptionSvgShouldNotHang_Issue1180()
    {
        var html = "<nobr><table><caption><table><caption><svg><html><html></table><nobr><g><svg><html><html></table><nobr>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        // Note: Seems to deviate also in Mozilla Firefox - maybe investigate for potential bug report
        Assert.Equal("<nobr><table><caption><table><caption><svg><html><html></html></html></svg></caption></table><nobr><g><svg><html><html></html></html></svg></g></nobr></caption></table></nobr><nobr></nobr>", document.Body.InnerHtml);
    }

    [Fact]
    public void TableCaptionMathShouldNotHang_Issue1180()
    {
        var html = "<nobr><table><caption><table><caption><svg><html><html></table><nobr><F><math><html><html></table><nobr>";
        var parser = new CodeBrix.MarkupParse.Html.Parser.HtmlParser();
        var document = parser.ParseDocument(html.ToCharArray(), 0);
        // Note: Seems to deviate also in Mozilla Firefox - maybe investigate for potential bug report
        Assert.Equal("<nobr><table><caption><table><caption><svg><html><html></html></html></svg></caption></table><nobr><f><math><html><html></html></html></math></f></nobr></caption></table></nobr><nobr></nobr>", document.Body.InnerHtml);
    }
}
