using CodeBrix.MarkupParse.Dom;
using CodeBrix.MarkupParse.Html.Dom;
using Xunit;
using System;
using System.Linq;

namespace CodeBrix.MarkupParse.Tests.Html; //Was previously: namespace AngleSharp.Core.Tests.Html

/// <summary>
/// Tests taken (and ported) from
/// https://github.com/google/gumbo-parser/blob/master/tests/parser.cc
/// </summary>

public class GumboParserTests
{
    [Fact]
    public void GumboDoubleBody()
    {
        var document = ("<body class=first><body class=second id=merged>Text</body></body>").ToHtmlDocument();
        var root = document.Body;
        Assert.Single(root.ChildNodes);
        Assert.Equal(2, root.Attributes.Count());

        var cls = root.ClassName;
        Assert.Equal("first", cls);

        var id = root.Id;
        Assert.Equal("merged", id);

        var txt = root.ChildNodes[0];
        Assert.Equal(NodeType.Text, txt.NodeType);
        Assert.Equal("Text", txt.TextContent);
    }

    [Fact]
    public void GumboMisnestedHeading()
    {
        var document = (@"<h1>  <section>    <h2>      <dl><dt>List    </h1>  </section>  Heading1<h3>Heading3</h4>After</h3> text").ToHtmlDocument();

        var root = document.Body;
        Assert.Equal(3, root.ChildNodes.Length);

        var h1 = root.ChildNodes[0];
        Assert.Equal(NodeType.Element, h1.NodeType);
        Assert.Equal("h1", h1.GetTagName());
        Assert.Equal(3, h1.ChildNodes.Length);

        var section = h1.ChildNodes[1];
        Assert.Equal(NodeType.Element, section.NodeType);
        Assert.Equal("section", section.GetTagName());
        Assert.Equal(3, section.ChildNodes.Length);

        var h2 = section.ChildNodes[1];
        Assert.Equal(NodeType.Element, h2.NodeType);
        Assert.Equal("h2", h2.GetTagName());
        Assert.Equal(2, h2.ChildNodes.Length);

        var dl = h2.ChildNodes[1];
        Assert.Equal(NodeType.Element, dl.NodeType);
        Assert.Equal("dl", dl.GetTagName());
        Assert.Single(dl.ChildNodes);

        var dt = dl.ChildNodes[0];
        Assert.Equal(NodeType.Element, dt.NodeType);
        Assert.Equal("dt", dt.GetTagName());
        Assert.Single(dt.ChildNodes);

        var text1 = dt.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("List    ", text1.TextContent);

        var text2 = h1.ChildNodes[2];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal("  Heading1", text2.TextContent);

        var h3 = root.ChildNodes[1];
        Assert.Equal(NodeType.Element, h3.NodeType);
        Assert.Equal("h3", h3.GetTagName());
        Assert.Single(h3.ChildNodes);

        var text3 = h3.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("Heading3", text3.TextContent);

        var text4 = root.ChildNodes[2];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal("After text", text4.TextContent);
    }

    [Fact]
    public void GumboLinkifiedHeading()
    {
        var document = (@"<li><h3><a href=#foo>Text</a></h3><div>Summary</div>").ToHtmlDocument();

        var root = document.Body;
        Assert.Single(root.ChildNodes);

        var li = root.ChildNodes[0];
        Assert.Equal(NodeType.Element, li.NodeType);
        Assert.Equal("li", li.GetTagName());
        Assert.Equal(2, li.ChildNodes.Length);

        var h3 = li.ChildNodes[0];
        Assert.Equal(NodeType.Element, h3.NodeType);
        Assert.Equal("h3", h3.GetTagName());
        Assert.Single(h3.ChildNodes);

        var anchor = h3.ChildNodes[0];
        Assert.Equal(NodeType.Element, anchor.NodeType);
        Assert.Equal("a", anchor.GetTagName());
        Assert.Single(anchor.ChildNodes);

        var div = li.ChildNodes[1];
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Equal("div", div.GetTagName());
        Assert.Single(div.ChildNodes);
    }

    [Fact]
    public void GumboFormattingTagsInHeading()
    {
        var document = (@"<h2>This is <b>old</h2>text").ToHtmlDocument();

        var root = document.Body;
        Assert.Equal(2, root.ChildNodes.Length);

        var h2 = root.ChildNodes[0];
        Assert.Equal(NodeType.Element, h2.NodeType);
        Assert.Equal("h2", h2.GetTagName());
        Assert.Equal(2, h2.ChildNodes.Length);

        var text1 = h2.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("This is ", text1.TextContent);

        var b = h2.ChildNodes[1];
        Assert.Equal(NodeType.Element, b.NodeType);
        Assert.Equal("b", b.GetTagName());
        Assert.Single(b.ChildNodes);

        var text2 = b.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal("old", text2.TextContent);

        var bimpl = root.ChildNodes[1];
        Assert.Equal(NodeType.Element, bimpl.NodeType);
        Assert.Equal("b", bimpl.GetTagName());
        Assert.Single(bimpl.ChildNodes);

        var text3 = bimpl.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("text", text3.TextContent);
    }

    [Fact]
    public void GumboImplicitlyCloseLists()
    {
        var document = (@"<ul>
  <li>First
  <li>Second
</ul>").ToHtmlDocument();

        var root = document.Body;
        Assert.Single(root.ChildNodes);

        var ul = root.ChildNodes[0];
        Assert.Equal(NodeType.Element, ul.NodeType);
        Assert.Equal("ul", ul.GetTagName());
        Assert.Equal(3, ul.ChildNodes.Length);

        var text = ul.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("\n  ", text.TextContent);

        var li1 = ul.ChildNodes[1];
        Assert.Equal(NodeType.Element, li1.NodeType);
        Assert.Equal("li", li1.GetTagName());
        Assert.Single(li1.ChildNodes);

        var li2 = ul.ChildNodes[2];
        Assert.Equal(NodeType.Element, li2.NodeType);
        Assert.Equal("li", li2.GetTagName());
        Assert.Single(li2.ChildNodes);
    }

    /// <summary>
    /// See http://www.whatwg.org/specs/web-apps/current-work/multipage/the-end.html#misnested-tags:-b-i-/b-/i
    /// </summary>
    [Fact]
    public void GumboAdoptionAgency1()
    {
        var document = (@"<p>1<b>2<i>3</b>4</i>5</p>").ToHtmlDocument();

        var root = document.Body;
        Assert.Single(root.ChildNodes);

        var p = root.ChildNodes[0];
        Assert.Equal(NodeType.Element, p.NodeType);
        Assert.Equal("p", p.GetTagName());
        Assert.Equal(4, p.ChildNodes.Length);

        var text1 = p.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("1", text1.TextContent);

        var b = p.ChildNodes[1];
        Assert.Equal(NodeType.Element, b.NodeType);
        Assert.Equal("b", b.GetTagName());
        Assert.Equal(2, b.ChildNodes.Length);

        var text2 = b.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal("2", text2.TextContent);

        var i = b.ChildNodes[1];
        Assert.Equal(NodeType.Element, i.NodeType);
        Assert.Equal("i", i.GetTagName());
        Assert.Single(i.ChildNodes);

        var text3 = i.ChildNodes[0];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("3", text3.TextContent);

        var iadopt = p.ChildNodes[2];
        Assert.Equal(NodeType.Element, i.NodeType);
        Assert.Equal("i", iadopt.GetTagName());
        Assert.Single(iadopt.ChildNodes);

        var text4 = iadopt.ChildNodes[0];
        Assert.Equal(NodeType.Text, text4.NodeType);
        Assert.Equal("4", text4.TextContent);

        var text5 = p.ChildNodes[3];
        Assert.Equal(NodeType.Text, text5.NodeType);
        Assert.Equal("5", text5.TextContent);
    }

    /// <summary>
    /// See http://www.whatwg.org/specs/web-apps/current-work/multipage/the-end.html#misnested-tags:-b-p-/b-/p
    /// </summary>
    [Fact]
    public void GumboAdoptionAgency2()
    {
        var document = (@"<b>1<p>2</b>3</p>").ToHtmlDocument();

        var root = document.Body;
        Assert.Equal(2, root.ChildNodes.Length);

        var b = root.ChildNodes[0];
        Assert.Equal(NodeType.Element, b.NodeType);
        Assert.Equal("b", b.GetTagName());
        Assert.Single(b.ChildNodes);

        var text1 = b.ChildNodes[0];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("1", text1.TextContent);

        var p = root.ChildNodes[1];
        Assert.Equal(NodeType.Element, p.NodeType);
        Assert.Equal("p", p.GetTagName());
        Assert.Equal(2, p.ChildNodes.Length);

        var badopt = p.ChildNodes[0];
        Assert.Equal(NodeType.Element, badopt.NodeType);
        Assert.Equal("b", badopt.GetTagName());
        Assert.Single(badopt.ChildNodes);

        var text2 = badopt.ChildNodes[0];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal("2", text2.TextContent);

        var text3 = p.ChildNodes[1];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("3", text3.TextContent);
    }

    [Fact]
    public void GumboMetaBeforeHead()
    {
        var document = (@"<html><meta http-equiv='content-type' content='text/html; charset=UTF-8' /><head></head>").ToHtmlDocument();

        var root = document.Body;
        Assert.NotNull(root);
    }

    [Fact]
    public void GumboNoahsArkClause()
    {
        var document = (@"<p><font size=4><font color=red><font size=4><font size=4><font size=4><font size=4><font size=4><font color=red><p>X").ToHtmlDocument();

        var root = document.Body;
        Assert.Equal(2, root.ChildNodes.Length);

        var p1 = root.ChildNodes[0];
        Assert.Equal(NodeType.Element, p1.NodeType);
        Assert.Equal("p", p1.GetTagName());
        Assert.Single(p1.ChildNodes);

        var size1 = p1.ChildNodes[0];
        var red1 = size1.ChildNodes[0] as Element;
        Assert.Equal(NodeType.Element, red1.NodeType);
        Assert.Equal("font", red1.GetTagName());
        Assert.Single(red1.Attributes);
        Assert.NotNull(red1.GetAttribute("color"));
        Assert.Equal("red", red1.GetAttribute("color"));
        Assert.Single(red1.ChildNodes);

        var p2 = root.ChildNodes[1];
        Assert.Equal(NodeType.Element, p2.NodeType);
        Assert.Equal("p", p2.GetTagName());
        Assert.Single(p2.ChildNodes);

        var red2 = p2.ChildNodes[0] as Element;
        Assert.Equal(NodeType.Element, red2.NodeType);
        Assert.Equal("font", red2.GetTagName());
        Assert.Single(red2.Attributes);
        Assert.NotNull(red2.GetAttribute("color"));
        Assert.Equal("red", red2.GetAttribute("color"));
        Assert.Single(red2.ChildNodes);
    }

    [Fact]
    public void GumboRawtextInBody()
    {
        var document = (@"<body><noembed jsif=false></noembed>").ToHtmlDocument();

        var root = document.Body;
        Assert.Single(root.ChildNodes);

        var noembed = root.ChildNodes[0] as Element;
        Assert.Equal(NodeType.Element, noembed.NodeType);
        Assert.Equal("noembed", noembed.GetTagName());
        Assert.Single(noembed.Attributes);
    }

    [Fact]
    public void GumboNestedRawtextTags()
    {
        var document = (@"<noscript><noscript jstag=false><style>div{text-align:center}</style></noscript>").ToHtmlDocument();

        Assert.Equal(2, document.DocumentElement.ChildNodes.Length);

        var head = document.Head;
        Assert.Single(head.ChildNodes);

        var noscript = head.ChildNodes[0];
        Assert.Equal(NodeType.Element, noscript.NodeType);
        Assert.Equal("noscript", noscript.GetTagName());
        Assert.Single(noscript.ChildNodes);

        var style = noscript.ChildNodes[0];
        Assert.Equal(NodeType.Element, style.NodeType);
        Assert.Equal("style", style.GetTagName());
        Assert.Single(style.ChildNodes);

        var text = style.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("div{text-align:center}", text.TextContent);
    }

    [Fact]
    public void GumboIsIndex()
    {
        var document = (@"<isindex id=form1 action='/action' prompt='Secret Message'>").ToHtmlDocument();

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var form = body.ChildNodes[0] as Element;
        Assert.Equal(NodeType.Element, form.NodeType);
        Assert.Equal("form", form.GetTagName());
        Assert.Equal(3, form.ChildNodes.Length);

        var action = form.GetAttribute("action");
        Assert.NotNull(action);
        Assert.Equal("/action", action);

        var hr1 = form.ChildNodes[0];
        Assert.Equal(NodeType.Element, hr1.NodeType);
        Assert.Equal("hr", hr1.GetTagName());
        Assert.Empty(hr1.ChildNodes);

        var label = form.ChildNodes[1];
        Assert.Equal(NodeType.Element, label.NodeType);
        Assert.Equal("label", label.GetTagName());
        Assert.Equal(2, label.ChildNodes.Length);

        var text = label.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("Secret Message", text.TextContent);

        var input = label.ChildNodes[1] as Element;
        Assert.Equal(NodeType.Element, input.NodeType);
        Assert.Equal("input", input.GetTagName());
        Assert.Empty(input.ChildNodes);
        Assert.Equal(2, input.Attributes.Count());

        var id = input.GetAttribute("id");
        Assert.NotNull(id);
        Assert.Equal("form1", id);

        var name = input.GetAttribute("name");
        Assert.NotNull(name);
        Assert.Equal("isindex", name);

        var hr2 = form.ChildNodes[2];
        Assert.Equal(NodeType.Element, hr2.NodeType);
        Assert.Equal("hr", hr2.GetTagName());
        Assert.Empty(hr2.ChildNodes);
    }

    [Fact]
    public void GumboForm()
    {
        var document = (@"<form><input type=hidden /><isindex /></form>After form").ToHtmlDocument();

        var body = document.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var form = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, form.NodeType);
        Assert.Equal("form", form.GetTagName());
        Assert.Single(form.ChildNodes);

        var input = form.ChildNodes[0];
        Assert.Equal(NodeType.Element, input.NodeType);
        Assert.Equal("input", input.GetTagName());
        Assert.Empty(input.ChildNodes);

        var text = body.ChildNodes[1];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("After form", text.TextContent);
    }

    [Fact]
    public void GumboNestedForm()
    {
        var document = (@"<form><label>Label</label><form><input id=input2></form>After form").ToHtmlDocument();

        var body = document.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var form = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, form.NodeType);
        Assert.Equal("form", form.GetTagName());
        Assert.Equal(2, form.ChildNodes.Length);

        var label = form.ChildNodes[0];
        Assert.Equal(NodeType.Element, label.NodeType);
        Assert.Equal("label", label.GetTagName());
        Assert.Single(label.ChildNodes);

        var input = form.ChildNodes[1];
        Assert.Equal(NodeType.Element, input.NodeType);
        Assert.Equal("input", input.GetTagName());
        Assert.Empty(input.ChildNodes);

        var text = body.ChildNodes[1];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("After form", text.TextContent);
    }

    [Fact]
    public void GumboMisnestedFormInTable()
    {
        var document = (@"<table><tr><td><form><table><tr><td></td></tr></form><form></tr></table></form></td></tr></table>").ToHtmlDocument();

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var table1 = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, table1.NodeType);
        Assert.Equal("table", table1.GetTagName());
        Assert.Single(table1.ChildNodes);

        var tbody1 = table1.ChildNodes[0];
        Assert.Equal(NodeType.Element, tbody1.NodeType);
        Assert.Equal("tbody", tbody1.GetTagName());
        Assert.Single(tbody1.ChildNodes);

        var tr1 = tbody1.ChildNodes[0];
        Assert.Equal(NodeType.Element, tr1.NodeType);
        Assert.Equal("tr", tr1.GetTagName());
        Assert.Single(tr1.ChildNodes);

        var td1 = tr1.ChildNodes[0];
        Assert.Equal(NodeType.Element, td1.NodeType);
        Assert.Equal("td", td1.GetTagName());
        Assert.Single(td1.ChildNodes);

        var form1 = td1.ChildNodes[0];
        Assert.Equal(NodeType.Element, form1.NodeType);
        Assert.Equal("form", form1.GetTagName());
        Assert.Single(form1.ChildNodes);

        var table2 = form1.ChildNodes[0];
        Assert.Equal(NodeType.Element, table2.NodeType);
        Assert.Equal("table", table2.GetTagName());
        Assert.Single(table2.ChildNodes);

        var tbody2 = table2.ChildNodes[0];
        Assert.Equal(NodeType.Element, tbody2.NodeType);
        Assert.Equal("tbody", tbody2.GetTagName());
        Assert.Equal(2, tbody2.ChildNodes.Length);

        var tr2 = tbody2.ChildNodes[0];
        Assert.Equal(NodeType.Element, tr2.NodeType);
        Assert.Equal("tr", tr2.GetTagName());
        Assert.Single(tr2.ChildNodes);

        var form2 = tbody2.ChildNodes[1];
        Assert.Equal(NodeType.Element, form2.NodeType);
        Assert.Equal("form", form2.GetTagName());
        Assert.Empty(form2.ChildNodes);
    }

    [Fact]
    public void GumboImplicitColgroup()
    {
        var document = (@"<table><col /><col /></table>").ToHtmlDocument();

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var table = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, table.NodeType);
        Assert.Equal("table", table.GetTagName());
        Assert.Single(table.ChildNodes);

        var colgroup = table.ChildNodes[0];
        Assert.Equal(NodeType.Element, colgroup.NodeType);
        Assert.Equal("colgroup", colgroup.GetTagName());
        Assert.Equal(2, colgroup.ChildNodes.Length);

        var col1 = colgroup.ChildNodes[0];
        Assert.Equal(NodeType.Element, col1.NodeType);
        Assert.Equal("col", col1.GetTagName());
        Assert.Empty(col1.ChildNodes);

        var col2 = colgroup.ChildNodes[1];
        Assert.Equal(NodeType.Element, col2.NodeType);
        Assert.Equal("col", col2.GetTagName());
        Assert.Empty(col2.ChildNodes);
    }

    [Fact]
    public void GumboSelectInTable()
    {
        var document = (@"<table><td><select><option value=1></table>").ToHtmlDocument();

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var table = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, table.NodeType);
        Assert.Equal("table", table.GetTagName());
        Assert.Single(table.ChildNodes);

        var tbody = table.ChildNodes[0];
        Assert.Equal(NodeType.Element, tbody.NodeType);
        Assert.Equal("tbody", tbody.GetTagName());
        Assert.Single(tbody.ChildNodes);

        var tr = tbody.ChildNodes[0];
        Assert.Equal(NodeType.Element, tr.NodeType);
        Assert.Equal("tr", tr.GetTagName());
        Assert.Single(tr.ChildNodes);

        var td = tr.ChildNodes[0];
        Assert.Equal(NodeType.Element, td.NodeType);
        Assert.Equal("td", td.GetTagName());
        Assert.Single(td.ChildNodes);

        var select = td.ChildNodes[0];
        Assert.Equal(NodeType.Element, select.NodeType);
        Assert.Equal("select", select.GetTagName());
        Assert.Single(select.ChildNodes);

        var option = select.ChildNodes[0];
        Assert.Equal(NodeType.Element, option.NodeType);
        Assert.Equal("option", option.GetTagName());
        Assert.Empty(option.ChildNodes);
    }

    [Fact]
    public void GumboComplicatedSelect()
    {
        var document = (@"<select><div class=foo></div><optgroup><option>Option</option><input></optgroup></select>").ToHtmlDocument();

        var body = document.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var select = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, select.NodeType);
        Assert.Equal("select", select.GetTagName());
        Assert.Single(select.ChildNodes);

        var optgroup = select.ChildNodes[0];
        Assert.Equal(NodeType.Element, optgroup.NodeType);
        Assert.Equal("optgroup", optgroup.GetTagName());
        Assert.Single(optgroup.ChildNodes);

        var option = optgroup.ChildNodes[0];
        Assert.Equal(NodeType.Element, option.NodeType);
        Assert.Equal("option", option.GetTagName());
        Assert.Single(option.ChildNodes);

        var text = option.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("Option", text.TextContent);

        var input = body.ChildNodes[1];
        Assert.Equal(NodeType.Element, input.NodeType);
        Assert.Equal("input", input.GetTagName());
        Assert.Empty(input.ChildNodes);
    }

    [Fact]
    public void GumboDoubleSelect()
    {
        var document = (@"<select><select><div></div>").ToHtmlDocument();

        var body = document.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var select = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, select.NodeType);
        Assert.Equal("select", select.GetTagName());
        Assert.Empty(select.ChildNodes);

        var div = body.ChildNodes[1];
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Equal("div", div.GetTagName());
        Assert.Empty(div.ChildNodes);
    }

    [Fact]
    public void GumboInputInSelect()
    {
        var document = (@"<select><input /><div></div>").ToHtmlDocument();

        var body = document.Body;
        Assert.Equal(3, body.ChildNodes.Length);

        var select = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, select.NodeType);
        Assert.Equal("select", select.GetTagName());
        Assert.Empty(select.ChildNodes);

        var input = body.ChildNodes[1];
        Assert.Equal(NodeType.Element, input.NodeType);
        Assert.Equal("input", input.GetTagName());
        Assert.Empty(input.ChildNodes);

        var div = body.ChildNodes[2];
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Equal("div", div.GetTagName());
        Assert.Empty(div.ChildNodes);
    }

    [Fact]
    public void GumboNullDocument()
    {
        var document = (@"").ToHtmlDocument();
        Assert.NotNull(document);
        var body = document.Body;
        Assert.NotNull(body);
    }

    [Fact]
    public void GumboOneChar()
    {
        var document = (@"T").ToHtmlDocument();
        Assert.Single(document.ChildNodes);

        var root = document.DocumentElement;
        Assert.Equal("html", root.GetTagName());
        Assert.Equal(NodeType.Element, root.NodeType);
        Assert.Equal(2, root.ChildNodes.Length);

        var head = root.ChildNodes[0];
        Assert.Equal("head", head.GetTagName());
        Assert.Equal(NodeType.Element, head.NodeType);
        Assert.Empty(head.ChildNodes);

        var body = root.ChildNodes[1];
        Assert.Equal("body", body.GetTagName());
        Assert.Equal(NodeType.Element, body.NodeType);
        Assert.Single(body.ChildNodes);

        var text = body.ChildNodes[0];
        Assert.Equal("T", text.TextContent);
        Assert.Equal(NodeType.Text, text.NodeType);
    }

    [Fact]
    public void GumboTextOnly()
    {
        var document = (@"Test").ToHtmlDocument();
        Assert.Single(document.ChildNodes);

        var root = document.DocumentElement;
        Assert.Equal("html", root.GetTagName());
        Assert.Equal(NodeType.Element, root.NodeType);
        Assert.Equal(2, root.ChildNodes.Length);

        var head = root.ChildNodes[0];
        Assert.Equal("head", head.GetTagName());
        Assert.Equal(NodeType.Element, head.NodeType);
        Assert.Empty(head.ChildNodes);

        var body = root.ChildNodes[1];
        Assert.Equal("body", body.GetTagName());
        Assert.Equal(NodeType.Element, body.NodeType);
        Assert.Single(body.ChildNodes);

        var text = body.ChildNodes[0];
        Assert.Equal("Test", text.TextContent);
        Assert.Equal(NodeType.Text, text.NodeType);
    }

    [Fact]
    public void GumboUnexpectedEndBreak()
    {
        var document = (@"</br><div></div>").ToHtmlDocument();

        var body = document.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var br = body.ChildNodes[0];
        Assert.Equal("br", br.GetTagName());
        Assert.Equal(NodeType.Element, br.NodeType);
        Assert.Empty(br.ChildNodes);

        var div = body.ChildNodes[1];
        Assert.Equal("div", div.GetTagName());
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Empty(div.ChildNodes);
    }

    [Fact]
    public void GumboCaseSensitiveAttributesCamelCase()
    {
        var document = (@"<div class=camelCase>").ToHtmlDocument();

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var div = body.ChildNodes[0] as Element;
        Assert.Equal("div", div.GetTagName());
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Empty(div.ChildNodes);
        Assert.Single(div.Attributes);
        Assert.Equal("camelCase", div.GetAttribute("class"));
    }

    [Fact]
    public void GumboCaseSensitiveAttributesPascalCase()
    {
        var document = (@"<div class=PascalCase>").ToHtmlDocument();

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var div = body.ChildNodes[0] as Element;
        Assert.Equal("div", div.GetTagName());
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Empty(div.ChildNodes);
        Assert.Single(div.Attributes);
        Assert.Equal("PascalCase", div.GetAttribute("class"));
    }

    [Fact]
    public void GumboExplicitHtmlStructure()
    {
        var document = (@"<!doctype html>
<html><head><title>Foo</title></head>
<body><div class=bar>Test</div></body></html>").ToHtmlDocument();

        Assert.Equal(2, document.ChildNodes.Length);

        var root = document.ChildNodes[1];
        Assert.Equal(NodeType.Element, root.NodeType);
        Assert.Equal("html", root.GetTagName());
        Assert.Equal(3, root.ChildNodes.Length);

        var head = root.ChildNodes[0];
        Assert.Equal(NodeType.Element, head.NodeType);
        Assert.Equal("head", head.GetTagName());
        Assert.Equal(root, head.ParentElement);
        Assert.Single(head.ChildNodes);

        var body = root.ChildNodes[2];
        Assert.Equal(NodeType.Element, body.NodeType);
        Assert.Equal("body", body.GetTagName());
        Assert.Equal(root, body.ParentElement);
        Assert.Single(body.ChildNodes);

        var div = body.ChildNodes[0] as Element;
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Equal("div", div.GetTagName());
        Assert.Equal(body, div.ParentElement);
        Assert.Single(div.ChildNodes);
        Assert.Single(div.Attributes);

        var clas = div.Attributes.First();
        Assert.Equal("class", clas.Name);
        Assert.Equal("bar", clas.Value);

        var text = div.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("Test", text.TextContent);
    }

    [Fact]
    public void GumboDuplicateAttributes()
    {
        var document = (@"<input checked=""false"" checked id=foo id='bar'>").ToHtmlDocument();

        var body = document.Body;
        Assert.Equal(NodeType.Element, body.NodeType);
        Assert.Equal("body", body.GetTagName());
        Assert.Single(body.ChildNodes);

        var input = body.ChildNodes[0] as Element;
        Assert.Equal(NodeType.Element, input.NodeType);
        Assert.Equal("input", input.GetTagName());
        Assert.Empty(input.ChildNodes);
        Assert.Equal(2, input.Attributes.Count());

        var chked = input.GetAttribute("checked");
        Assert.Equal("false", chked);

        var id = input.GetAttribute("id");
        Assert.Equal("foo", id);
    }

    [Fact]
    public void GumboLinkTagsInHead()
    {
        var document = (@"<html>
  <head>
    <title>Sample title></title>

    <link rel=stylesheet>
    <link rel=author>
  </head>
  <body>Foo</body>").ToHtmlDocument();

        var root = document.DocumentElement;
        Assert.Equal(3, root.ChildNodes.Length);

        var head = document.Head;
        Assert.Equal(NodeType.Element, head.NodeType);
        Assert.Equal("head", head.GetTagName());
        Assert.Equal(7, head.ChildNodes.Length);

        var text1 = head.ChildNodes[2];
        Assert.Equal(NodeType.Text, text1.NodeType);
        Assert.Equal("\n\n    ", text1.TextContent);

        var link1 = head.ChildNodes[3];
        Assert.Equal(NodeType.Element, link1.NodeType);
        Assert.Equal("link", link1.GetTagName());
        Assert.Empty(link1.ChildNodes);

        var text2 = head.ChildNodes[4];
        Assert.Equal(NodeType.Text, text2.NodeType);
        Assert.Equal("\n    ", text2.TextContent);

        var link2 = head.ChildNodes[5];
        Assert.Equal(NodeType.Element, link2.NodeType);
        Assert.Equal("link", link2.GetTagName());
        Assert.Empty(link2.ChildNodes);

        var text3 = head.ChildNodes[6];
        Assert.Equal(NodeType.Text, text3.NodeType);
        Assert.Equal("\n  ", text3.TextContent);

        var body = document.Body;
        Assert.Equal(NodeType.Element, body.NodeType);
        Assert.Equal("body", body.GetTagName());
        Assert.Single(body.ChildNodes);
    }

    [Fact]
    public void GumboTextAfterHtml()
    {
        var document = (@"<html>Test</html> after doc").ToHtmlDocument();

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var text = body.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("Test after doc", text.TextContent);
    }

    [Fact]
    public void GumboWhitespaceInHead()
    {
        var document = (@"<html>  Test</html>").ToHtmlDocument();

        var root = document.DocumentElement;
        Assert.Equal(2, root.ChildNodes.Length);

        var head = document.Head;
        Assert.Empty(head.ChildNodes);

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var text = body.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("Test", text.TextContent);
    }

    [Fact]
    public void GumboDoctype()
    {
        var document = (@"<!doctype html>Test").ToHtmlDocument() as Document;
        Assert.Equal(QuirksMode.Off, document.QuirksMode);
        Assert.Equal(2, document.ChildNodes.Length);

        var doctype = document.Doctype;
        Assert.Equal("html", doctype.Name);
        Assert.Equal(string.Empty, doctype.PublicIdentifier);
        Assert.Equal(string.Empty, doctype.SystemIdentifier);
    }

    [Fact]
    public void GumboInvalidDoctype()
    {
        var document = (@"Test<!doctype root_element SYSTEM ""DTD_location"">").ToHtmlDocument() as Document;
        Assert.Equal(QuirksMode.On, document.QuirksMode);
        Assert.Single(document.ChildNodes);

        Assert.Null(document.Doctype);

        var body = document.Body;
        Assert.Single(body.ChildNodes);

        var text = body.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("Test", text.TextContent);
    }

    [Fact]
    public void GumboCommentInVerbatimMode()
    {
        var doc = (@"<body> <div id='onegoogle'>Text</div>  </body><!-- comment 

-->").ToHtmlDocument();
        var document = doc.DocumentElement;
        Assert.Equal(NodeType.Element, document.NodeType);
        Assert.Equal("html", document.GetTagName());
        Assert.Equal(3, document.ChildNodes.Length);

        var body = document.ChildNodes[1];
        Assert.Equal(NodeType.Element, body.NodeType);
        Assert.Equal("body", body.GetTagName());
        Assert.Equal(3, body.ChildNodes.Length);

        var comment = document.ChildNodes[2];
        Assert.Equal(NodeType.Comment, comment.NodeType);
        Assert.Equal(" comment \n\n", comment.TextContent);
    }

    [Fact]
    public void GumboCommentInText()
    {
        var doc = (@"Start <!-- comment --> end").ToHtmlDocument();
        var body = doc.Body;
        Assert.Equal(3, body.ChildNodes.Length);

        var start = body.ChildNodes[0];
        Assert.Equal(NodeType.Text, start.NodeType);
        Assert.Equal("Start ", start.TextContent);

        var comment = body.ChildNodes[1];
        Assert.Equal(NodeType.Comment, comment.NodeType);
        Assert.Equal(body, comment.ParentElement);
        Assert.Equal(" comment ", comment.TextContent);

        var end = body.ChildNodes[2];
        Assert.Equal(NodeType.Text, end.NodeType);
        Assert.Equal(" end", end.TextContent);
    }

    [Fact]
    public void GumboUnknownTag1()
    {
        var doc = (@"<foo>1<p>2</FOO>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Single(body.ChildNodes);

        var foo = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, foo.NodeType);
        Assert.Equal("foo", foo.GetTagName());
        Assert.Equal(typeof(HtmlUnknownElement), foo.GetType());
    }

    [Fact]
    public void GumboUnknownTag2()
    {
        var doc = (@"<div><sarcasm><div></div></sarcasm></div>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Single(body.ChildNodes); 
        
        var div = body.ChildNodes[0];
        Assert.Single(div.ChildNodes);

        var sarcasm = div.ChildNodes[0];
        Assert.Equal(NodeType.Element, sarcasm.NodeType);
        Assert.Equal("sarcasm", sarcasm.GetTagName());
        Assert.Equal(typeof(HtmlUnknownElement), sarcasm.GetType());
    }

    [Fact]
    public void GumboInvalidEndTag()
    {
        var doc = (@"<a><img src=foo.jpg></img></a>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Single(body.ChildNodes);

        var a = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, a.NodeType);
        Assert.Equal("a", a.GetTagName());
        Assert.Single(a.ChildNodes);

        var img = a.ChildNodes[0];
        Assert.Equal(NodeType.Element, img.NodeType);
        Assert.Equal("img", img.GetTagName());
        Assert.Empty(img.ChildNodes);
    }

    [Fact]
    public void GumboTables()
    {
        var doc = (@"<html><table>
  <tr><br /></invalid-tag>
    <th>One</th>
    <td>Two</td>
  </tr>
  <iframe></iframe>
</table><tr></tr><div></div></html>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Equal(4, body.ChildNodes.Length);

        var br = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, br.NodeType);
        Assert.Equal("br", br.GetTagName());
        Assert.Equal(body, br.ParentElement);
        Assert.Empty(br.ChildNodes);

        var iframe = body.ChildNodes[1];
        Assert.Equal(NodeType.Element, iframe.NodeType);
        Assert.Equal("iframe", iframe.GetTagName());
        Assert.Empty(iframe.ChildNodes);

        var table = body.ChildNodes[2];
        Assert.Equal(NodeType.Element, table.NodeType);
        Assert.Equal("table", table.GetTagName());
        Assert.Equal(body, table.ParentElement);
        Assert.Equal(2, table.ChildNodes.Length);

        var table_text = table.ChildNodes[0];
        Assert.Equal(NodeType.Text, table_text.NodeType);
        Assert.Equal("\n  ", table_text.TextContent);

        var tbody = table.ChildNodes[1];
        Assert.Equal(NodeType.Element, tbody.NodeType);
        Assert.Equal("tbody", tbody.GetTagName());
        Assert.Equal(2, tbody.ChildNodes.Length);

        var tr = tbody.ChildNodes[0];
        Assert.Equal(NodeType.Element, tr.NodeType);
        Assert.Equal("tr", tr.GetTagName());
        Assert.Equal(5, tr.ChildNodes.Length);

        var tr_text = tr.ChildNodes[0];
        Assert.Equal(NodeType.Text, tr_text.NodeType);
        Assert.Equal(tr, tr_text.ParentElement);
        Assert.Equal("\n    ", tr_text.TextContent);

        var th = tr.ChildNodes[1];
        Assert.Equal(NodeType.Element, th.NodeType);
        Assert.Equal("th", th.GetTagName());
        Assert.Equal(tr, th.ParentElement);
        Assert.Single(th.ChildNodes);

        var th_text = th.ChildNodes[0];
        Assert.Equal(NodeType.Text, th_text.NodeType);
        Assert.Equal("One", th_text.TextContent);

        var td = tr.ChildNodes[3];
        Assert.Equal(NodeType.Element, td.NodeType);
        Assert.Equal("td", td.GetTagName());
        Assert.Single(td.ChildNodes);

        var td_text = td.ChildNodes[0];
        Assert.Equal(NodeType.Text, td_text.NodeType);
        Assert.Equal("Two", td_text.TextContent);

        var div = body.ChildNodes[3];
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Equal("div", div.GetTagName());
        Assert.Empty(div.ChildNodes);
    }

    [Fact]
    public void GumboStartParagraphInTable()
    {
        var doc = (@"<table><P></tr></td>foo</table>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var paragraph = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, paragraph.NodeType);
        Assert.Equal("p", paragraph.GetTagName());
        Assert.Equal(body, paragraph.ParentElement);
        Assert.Single(paragraph.ChildNodes);

        var text = paragraph.ChildNodes[0];
        Assert.Equal(NodeType.Text, text.NodeType);
        Assert.Equal("foo", text.TextContent);

        var table = body.ChildNodes[1];
        Assert.Equal(NodeType.Element, table.NodeType);
        Assert.Equal("table", table.GetTagName());
        Assert.Equal(body, table.ParentElement);
        Assert.Empty(table.ChildNodes);
    }

    [Fact]
    public void GumboEndParagraphInTable()
    {
        var doc = (@"<table></p></table>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var paragraph = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, paragraph.NodeType);
        Assert.Equal("p", paragraph.GetTagName());
        Assert.Equal(body, paragraph.ParentElement);
        Assert.Empty(paragraph.ChildNodes);

        var table = body.ChildNodes[1];
        Assert.Equal(NodeType.Element, table.NodeType);
        Assert.Equal("table", table.GetTagName());
        Assert.Equal(body, table.ParentElement);
        Assert.Empty(table.ChildNodes);
    }

    [Fact]
    public void GumboUnclosedTableTags()
    {
        var doc = (@"<html><table>
  <tr>
    <td>One
    <td>Two
  <tr><td>Row2
  <tr><td>Row3
</table>
</html>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var table = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, table.NodeType);
        Assert.Equal("table", table.GetTagName());
        Assert.Equal(body, table.ParentElement);
        Assert.Equal(2, table.ChildNodes.Length);

        var table_text = table.ChildNodes[0];
        Assert.Equal(NodeType.Text, table_text.NodeType);
        Assert.Equal("\n  ", table_text.TextContent);

        var tbody = table.ChildNodes[1];
        Assert.Equal(NodeType.Element, tbody.NodeType);
        Assert.Equal("tbody", tbody.GetTagName());
        Assert.Equal(3, tbody.ChildNodes.Length);

        var tr = tbody.ChildNodes[0];
        Assert.Equal(NodeType.Element, tr.NodeType);
        Assert.Equal("tr", tr.GetTagName());
        Assert.Equal(3, tr.ChildNodes.Length);

        var tr_text = tr.ChildNodes[0];
        Assert.Equal(NodeType.Text, tr_text.NodeType);
        Assert.Equal("\n    ", tr_text.TextContent);

        var td1 = tr.ChildNodes[1];
        Assert.Equal(NodeType.Element, td1.NodeType);
        Assert.Equal("td", td1.GetTagName());
        Assert.Single(td1.ChildNodes);

        var td2 = tr.ChildNodes[2];
        Assert.Equal(NodeType.Element, td1.NodeType);
        Assert.Equal("td", td1.GetTagName());
        Assert.Single(td1.ChildNodes);

        var td1_text = td1.ChildNodes[0];
        Assert.Equal(NodeType.Text, td1_text.NodeType);
        Assert.Equal("One\n    ", td1_text.TextContent);

        var td2_text = td2.ChildNodes[0];
        Assert.Equal(NodeType.Text, td2_text.NodeType);
        Assert.Equal("Two\n  ", td2_text.TextContent);

        var tr3 = tbody.ChildNodes[2];
        Assert.Equal(NodeType.Element, tr3.NodeType);
        Assert.Equal("tr", tr3.GetTagName());
        Assert.Single(tr3.ChildNodes);

        var body_text = body.ChildNodes[1];
        Assert.Equal(NodeType.Text, body_text.NodeType);
        Assert.Equal("\n", body_text.TextContent);
    }

    [Fact]
    public void GumboMisnestedTable1()
    {
        var doc = (@"<table><tr><div><td></div></table>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Equal(2, body.ChildNodes.Length);

        var div = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, div.NodeType);
        Assert.Equal("div", div.GetTagName());
        Assert.Empty(div.ChildNodes);

        var table = body.ChildNodes[1];
        Assert.Equal(NodeType.Element, table.NodeType);
        Assert.Equal("table", table.GetTagName());
        Assert.Equal(body, table.ParentElement);
        Assert.Single(table.ChildNodes);

        var tbody = table.ChildNodes[0];
        Assert.Equal(NodeType.Element, tbody.NodeType);
        Assert.Equal("tbody", tbody.GetTagName());
        Assert.Single(tbody.ChildNodes);

        var tr = tbody.ChildNodes[0];
        Assert.Equal(NodeType.Element, tr.NodeType);
        Assert.Equal("tr", tr.GetTagName());
        Assert.Single(tr.ChildNodes);

        var td = tr.ChildNodes[0];
        Assert.Equal(NodeType.Element, td.NodeType);
        Assert.Equal("td", td.GetTagName());
        Assert.Empty(td.ChildNodes);
    }

    [Fact]
    public void GumboMisnestedTable2()
    {
        var doc = (@"<table><td>Cell1<table><th>Cell2<tr>Cell3</table>").ToHtmlDocument();
        var body = doc.Body;
        Assert.Single(body.ChildNodes);

        var table1 = body.ChildNodes[0];
        Assert.Equal(NodeType.Element, table1.NodeType);
        Assert.Equal("table", table1.GetTagName());
        Assert.Equal(body, table1.ParentElement);
        Assert.Single(table1.ChildNodes);

        var tbody1 = table1.ChildNodes[0];
        Assert.Equal(NodeType.Element, tbody1.NodeType);
        Assert.Equal("tbody", tbody1.GetTagName());
        Assert.Single(tbody1.ChildNodes);

        var tr1 = tbody1.ChildNodes[0];
        Assert.Equal(NodeType.Element, tr1.NodeType);
        Assert.Equal("tr", tr1.GetTagName());
        Assert.Single(tr1.ChildNodes);

        var td1 = tr1.ChildNodes[0];
        Assert.Equal(NodeType.Element, td1.NodeType);
        Assert.Equal("td", td1.GetTagName());
        Assert.Equal(2, td1.ChildNodes.Length);

        var cell1 = td1.ChildNodes[0];
        Assert.Equal(NodeType.Text, cell1.NodeType);
        Assert.Equal("Cell1Cell3", cell1.TextContent);

        var table2 = td1.ChildNodes[1];
        Assert.Equal(NodeType.Element, table2.NodeType);
        Assert.Equal("table", table2.GetTagName());
        Assert.Single(table2.ChildNodes);

        var tbody2 = table2.ChildNodes[0];
        Assert.Equal(NodeType.Element, tbody2.NodeType);
        Assert.Equal("tbody", tbody2.GetTagName());
        Assert.Equal(2, tbody2.ChildNodes.Length);

        var tr2 = tbody2.ChildNodes[0];
        Assert.Equal(NodeType.Element, tr2.NodeType);
        Assert.Equal("tr", tr2.GetTagName());
        Assert.Single(tr2.ChildNodes);

        var th1 = tr2.ChildNodes[0];
        Assert.Equal(NodeType.Element, th1.NodeType);
        Assert.Equal("th", th1.GetTagName());
        Assert.Single(th1.ChildNodes);

        var cell2 = th1.ChildNodes[0];
        Assert.Equal(NodeType.Text, cell2.NodeType);
        Assert.Equal("Cell2", cell2.TextContent);

        var tr3 = tbody2.ChildNodes[1];
        Assert.Equal(NodeType.Element, tr3.NodeType);
        Assert.Equal("tr", tr3.GetTagName());
        Assert.Empty(tr3.ChildNodes);
    }
}
