using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests from https://github.com/html5lib/html5lib-tests:
/// tree-construction/tables01.dat
/// </summary>

public class HtmlTableTests
{
    [Fact]
    public void TableWithSingleTh()
    {
        var doc = (@"<table><th>").ToHtmlDocument();

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

        var dochtml0body1table0tbody0tr0th0 = dochtml0body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0th0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0th0.Attributes);
        Assert.Equal("th", dochtml0body1table0tbody0tr0th0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0th0.NodeType);
    }

    [Fact]
    public void TableWithSingleTd()
    {
        var doc = (@"<table><td>").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);
    }

    [Fact]
    public void TableWithSingleCol()
    {
        var doc = (@"<table><col foo='bar'>").ToHtmlDocument();

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

        var dochtml0body1table0colgroup0col0 = dochtml0body1table0colgroup0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0colgroup0col0.ChildNodes);
        Assert.Single(dochtml0body1table0colgroup0col0.Attributes);
        Assert.Equal("col", dochtml0body1table0colgroup0col0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0colgroup0col0.NodeType);
        Assert.Equal("bar", dochtml0body1table0colgroup0col0.Attributes.GetNamedItem("foo").Value);
    }

    [Fact]
    public void TableWithSingleColgroupClosingHtml()
    {
        var doc = (@"<table><colgroup></html>foo").ToHtmlDocument();

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
        Assert.Equal("foo", dochtml0body1Text0.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table1colgroup0 = dochtml0body1table1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table1colgroup0.ChildNodes);
        Assert.Empty(dochtml0body1table1colgroup0.Attributes);
        Assert.Equal("colgroup", dochtml0body1table1colgroup0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1colgroup0.NodeType);
    }

    [Fact]
    public void TableClosedFollowedByParagraph()
    {
        var doc = (@"<table></table><p>foo").ToHtmlDocument();

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

        var dochtml0body1table0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0.ChildNodes);
        Assert.Empty(dochtml0body1table0.Attributes);
        Assert.Equal("table", dochtml0body1table0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0.NodeType);

        var dochtml0body1p1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Single(dochtml0body1p1.ChildNodes);
        Assert.Empty(dochtml0body1p1.Attributes);
        Assert.Equal("p", dochtml0body1p1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1p1.NodeType);

        var dochtml0body1p1Text0 = dochtml0body1p1.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1p1Text0.NodeType);
        Assert.Equal("foo", dochtml0body1p1Text0.TextContent);
    }

    [Fact]
    public void TableClosingEveryhingUnorderedOpenedTd()
    {
        var doc = (@"<table></body></caption></col></colgroup></html></tbody></td></tfoot></th></thead></tr><td>").ToHtmlDocument();

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
        Assert.Empty(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);
    }

    [Fact]
    public void TableWithSelectOption()
    {
        var doc = (@"<table><select><option>3</select></table>").ToHtmlDocument();

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
        Assert.Equal("3", dochtml0body1select0option0Text0.TextContent);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);
    }

    [Fact]
    public void TableWithSelectAndTable()
    {
        var doc = (@"<table><select><table></table></select></table>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0.ChildNodes);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);

        var dochtml0body1table2 = dochtml0body1.ChildNodes[2] as Element;
        Assert.Empty(dochtml0body1table2.ChildNodes);
        Assert.Empty(dochtml0body1table2.Attributes);
        Assert.Equal("table", dochtml0body1table2.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table2.NodeType);
    }

    [Fact]
    public void TableWithSelectClosed()
    {
        var doc = (@"<table><select></table>").ToHtmlDocument();

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

        var dochtml0body1select0 = dochtml0body1.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1select0.ChildNodes);
        Assert.Empty(dochtml0body1select0.Attributes);
        Assert.Equal("select", dochtml0body1select0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1select0.NodeType);

        var dochtml0body1table1 = dochtml0body1.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table1.ChildNodes);
        Assert.Empty(dochtml0body1table1.Attributes);
        Assert.Equal("table", dochtml0body1table1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1.NodeType);
    }

    [Fact]
    public void TableWithSelectOptionAndContent()
    {
        var doc = (@"<table><select><option>A<tr><td>B</td></tr></table>").ToHtmlDocument();

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
        Assert.Single(dochtml0body1table1tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table1tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table1tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table1tbody0tr0td0.NodeType);

        var dochtml0body1table1tbody0tr0td0Text0 = dochtml0body1table1tbody0tr0td0.ChildNodes[0];
        Assert.Equal(NodeType.Text, dochtml0body1table1tbody0tr0td0Text0.NodeType);
        Assert.Equal("B", dochtml0body1table1tbody0tr0td0Text0.TextContent);
    }

    [Fact]
    public void TableWithTdClosedEverything()
    {
        var doc = (@"<table><td></body></caption></col></colgroup></html>foo").ToHtmlDocument();

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
        Assert.Equal("foo", dochtml0body1table0tbody0tr0td0Text0.TextContent);
    }

    [Fact]
    public void TableWithCellContent()
    {
        var doc = (@"<table><td>A</table>B").ToHtmlDocument();

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

        var dochtml0body1Text1 = dochtml0body1.ChildNodes[1];
        Assert.Equal(NodeType.Text, dochtml0body1Text1.NodeType);
        Assert.Equal("B", dochtml0body1Text1.TextContent);
    }

    [Fact]
    public void TableWithRowAndCaption()
    {
        var doc = (@"<table><tr><caption>").ToHtmlDocument();

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

        var dochtml0body1table0tbody0 = dochtml0body1table0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0.Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0.NodeType);

        var dochtml0body1table0tbody0tr0 = dochtml0body1table0tbody0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0.NodeType);

        var dochtml0body1table0caption1 = dochtml0body1table0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table0caption1.ChildNodes);
        Assert.Empty(dochtml0body1table0caption1.Attributes);
        Assert.Equal("caption", dochtml0body1table0caption1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0caption1.NodeType);
    }

    [Fact]
    public void TableWithRowClosedEverythingOpenedTd()
    {
        var doc = (@"<table><tr></body></caption></col></colgroup></html></td></th><td>foo").ToHtmlDocument();

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
        Assert.Equal("foo", dochtml0body1table0tbody0tr0td0Text0.TextContent);
    }

    [Fact]
    public void TableWithTdAndTr()
    {
        var doc = (@"<table><td><tr>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1table0tbody0.ChildNodes.Length);
        Assert.Empty(dochtml0body1table0tbody0.Attributes);
        Assert.Equal("tbody", dochtml0body1table0tbody0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0.NodeType);

        var dochtml0body1table0tbody0tr0 = dochtml0body1table0tbody0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0tr0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0.NodeType);

        var dochtml0body1table0tbody0tr0td0 = dochtml0body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);

        var dochtml0body1table0tbody0tr1 = dochtml0body1table0tbody0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr1.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr1.Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody0tr1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr1.NodeType);
    }

    [Fact]
    public void TableWithTdButtonAndTd()
    {
        var doc = (@"<table><td><button><td>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1table0tbody0tr0.ChildNodes.Length);
        Assert.Empty(dochtml0body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0.NodeType);

        var dochtml0body1table0tbody0tr0td0 = dochtml0body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);

        var dochtml0body1table0tbody0tr0td0button0 = dochtml0body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0td0button0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0button0.Attributes);
        Assert.Equal("button", dochtml0body1table0tbody0tr0td0button0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0button0.NodeType);

        var dochtml0body1table0tbody0tr0td1 = dochtml0body1table0tbody0tr0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0td1.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td1.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td1.NodeType);
    }

    [Fact]
    public void TableWithRowCellAndSvgDescTd()
    {
        var doc = (@"<table><tr><td><svg><desc><td>").ToHtmlDocument();

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
        Assert.Equal(2, dochtml0body1table0tbody0tr0.ChildNodes.Length);
        Assert.Empty(dochtml0body1table0tbody0tr0.Attributes);
        Assert.Equal("tr", dochtml0body1table0tbody0tr0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0.NodeType);

        var dochtml0body1table0tbody0tr0td0 = dochtml0body1table0tbody0tr0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0tr0td0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0.NodeType);

        var dochtml0body1table0tbody0tr0td0svg0 = dochtml0body1table0tbody0tr0td0.ChildNodes[0] as Element;
        Assert.Single(dochtml0body1table0tbody0tr0td0svg0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0svg0.Attributes);
        Assert.Equal("svg", dochtml0body1table0tbody0tr0td0svg0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0svg0.NodeType);

        var dochtml0body1table0tbody0tr0td0svg0desc0 = dochtml0body1table0tbody0tr0td0svg0.ChildNodes[0] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0td0svg0desc0.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td0svg0desc0.Attributes);
        Assert.Equal("desc", dochtml0body1table0tbody0tr0td0svg0desc0.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td0svg0desc0.NodeType);

        var dochtml0body1table0tbody0tr0td1 = dochtml0body1table0tbody0tr0.ChildNodes[1] as Element;
        Assert.Empty(dochtml0body1table0tbody0tr0td1.ChildNodes);
        Assert.Empty(dochtml0body1table0tbody0tr0td1.Attributes);
        Assert.Equal("td", dochtml0body1table0tbody0tr0td1.GetTagName());
        Assert.Equal(NodeType.Element, dochtml0body1table0tbody0tr0td1.NodeType);
    }

    [Fact]
    public void TableInParagraphElementInQuirksMode()
    {
        var doc = ("<p><table>").ToHtmlDocument();
        Assert.Equal(1, doc.Body.ChildElementCount);
        Assert.IsAssignableFrom<HtmlParagraphElement>(doc.Body.Children[0]);
        Assert.Equal(1, doc.Body.Children[0].ChildElementCount);
        Assert.IsAssignableFrom<HtmlTableElement>(doc.Body.Children[0].Children[0]);
    }

    [Fact]
    public void TableInParagraphElementInStandardMode()
    {
        var doc = (@"<!doctype html><p><table>").ToHtmlDocument();
        Assert.Equal(2, doc.Body.ChildElementCount);
        Assert.IsAssignableFrom<HtmlParagraphElement>(doc.Body.Children[0]);
        Assert.IsAssignableFrom<HtmlTableElement>(doc.Body.Children[1]);
    }
}
